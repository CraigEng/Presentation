using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using BabyGiftRegisterLibrary.Model;

namespace BabyGiftRegisterAndroid
{
    public class RegisterItemFragment : Fragment
    {
        private Button _buttonBuy;
        private ImageView _imageView;
        private TextView _textName;
        private TextView _textPrice;

        public RegisterItem RegisterItem { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.RegisterItemFragment, container, false);
            _imageView = rootView.FindViewById<ImageView>(Resource.Id.imageProduct);
            _textName = rootView.FindViewById<TextView>(Resource.Id.textName);
            _textPrice = rootView.FindViewById<TextView>(Resource.Id.textPrice);
            _buttonBuy = rootView.FindViewById<Button>(Resource.Id.buttonBuy);

            _textName.Text = RegisterItem.Name;
            _textPrice.Text = RegisterItem.Price;
            _imageView.SetImageResource(ResourceHelper.TranslateDrawable(RegisterItem.ImageName));

            if (RegisterItem.Sold)
            {
                _buttonBuy.SetBackgroundResource(Resource.Drawable.buttonSold);
                _buttonBuy.Text = "SOLD!";
            }
            else
            {
                _buttonBuy.Click += ButtonBuy_Click;
            }

            return rootView;
        }

        public void SetSold()
        {
            _buttonBuy.Click -= ButtonBuy_Click;
            _buttonBuy.SetBackgroundResource(Resource.Drawable.buttonSold);
            _buttonBuy.Text = "SOLD!";
            RegisterItem.Sold = true;
        }

        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            var registerItemActivity = (RegisterItemActivity) Activity;
            registerItemActivity.Buy(RegisterItem.Id);
        }
    }
}