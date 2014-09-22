using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BabyGiftRegisterLibrary.Managers;
using BabyGiftRegisterLibrary.Model;
using Java.Lang;
using WebLogic;
using ZXing.Mobile;
using Result = ZXing.Result;

namespace BabyGiftRegisterAndroid
{
    [Activity(Label = "Baby Gift Register", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light")]
    public class RegisterItemActivity : ActionBarActivity
    {
        private SignalRClient _client;
        private RegisterItemManager _registerItemManager;
        private RegisterItemPagerAdapter _registerItemPagerAdapter;
        private ViewPager _viewPager;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.RegisterItemActivity);
            var registerItems = await RestClient.GetRegisterItems();
            _registerItemManager = new RegisterItemManager(registerItems);
            _registerItemManager.MoveFirst();


           SetupSignalR();

            _registerItemPagerAdapter = new RegisterItemPagerAdapter(SupportFragmentManager, _registerItemManager);
            _viewPager = FindViewById<ViewPager>(Resource.Id.registerItemPager);
            _viewPager.Adapter = _registerItemPagerAdapter;
        }

        private async void SetupSignalR()
        {
            _client = new SignalRClient();
            await _client.Connect();
            _client.OnSetSold += SetSold;
            _client.OnAddToRegister += AddToRegister;
        }

    
        public async void Buy(int productId)
        {
            await _client.Buy(productId);
        }

        private void AddToRegister(RegisterItem obj)
        {
            RunOnUiThread(() => Toast.MakeText(this,
                "Add To Register",
                ToastLength.Short).Show());
        }

        public void SetSold(int productId)
        {
            RunOnUiThread(() =>
            {
                var registerItem = _registerItemManager.GetItemById(productId);
                registerItem.Sold = true;
                var fragment = GetFragment(productId);
                if (fragment == null)
                    return;

                fragment.SetSold();
            });
        }

        private async void HandleScanResult(Result result)
        {
            if (result != null && !string.IsNullOrEmpty(result.Text))
            {
                await _client.AddBarCode(result.Text);
                return;
            }
            Toast.MakeText(this,
                "Scanning Canceled!",
                ToastLength.Short).Show();
        }

        #region Other Code

        private RegisterItemFragment GetFragment(int productId)
        {
            return SupportFragmentManager.Fragments.Cast<RegisterItemFragment>()
                .FirstOrDefault(g => g != null && g.RegisterItem != null && g.RegisterItem.Id == productId);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var actionItem = menu.Add(new String("Action Button"));
            MenuItemCompat.SetShowAsAction(actionItem, MenuItemCompat.ShowAsActionIfRoom);
            actionItem.SetIcon(Android.Resource.Drawable.IcMenuCamera);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            LoadScanner();

            return true;
        }

        private async void LoadScanner()
        {
            var scanner = new MobileBarcodeScanner(this)
            {
                UseCustomOverlay = false,
                TopText = "Hold the camera up to the barcode\nAbout 6 inches away",
                BottomText = "Wait for the barcode to automatically scan!",
            };

            var result = await scanner.Scan();

            HandleScanResult(result);
        }
        #endregion
    }
}