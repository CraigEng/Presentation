using System.Linq;
using System.Windows;
using BabyGiftRegisterLibrary.Model;
using BabyGiftRegisterWindows.ViewModel;
using Microsoft.Phone.Controls;
using WebLogic;

namespace BabyGiftRegisterWindows
{
    public partial class MainPage
    {
        private SignalRClient _client;
        public ItemsChangeObservableCollection<RegisterItemViewModel> RegisterItemViewModels { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            GetItems();
            SetupSignalR();
        }

        private async void SetupSignalR()
        {
            _client = new SignalRClient();
            await _client.Connect();
            _client.OnSetSold += SetSold;
            _client.OnAddToRegister += AddToRegister;
        }

        private void SetSold(int productId)
        {
            Dispatcher.BeginInvoke(() =>
            {
                SetCurrentToDefault();
                var item = GetItem(productId);
                item.ItemSold = true;
            });
        }

        private void AddToRegister(RegisterItem registerItem)
        {
            Dispatcher.BeginInvoke(() =>
            {
                SetCurrentToDefault();
                RegisterItemViewModels.Add(new RegisterItemViewModel(registerItem));
            });
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if (selectedItem.Sold)
                return;

            await _client.Buy(selectedItem.Id);
        }
        
        #region Other Code
        private async void GetItems()
        {
            var registerItems = await RestClient.GetRegisterItems();
            RegisterItemViewModels = new ItemsChangeObservableCollection<RegisterItemViewModel>();

            foreach (var registerItem in registerItems)
            {
                RegisterItemViewModels.Add(new RegisterItemViewModel(registerItem));
            }

            ItemPanorama.DataContext = RegisterItemViewModels;
        }

        private RegisterItemViewModel GetItem(int productId)
        {
            return RegisterItemViewModels.First(x => x.Id == productId);
        }

        private void SetCurrentToDefault()
        {
            var selectedItem = GetSelectedItem();
            ItemPanorama.DefaultItem = selectedItem;
        }

        private RegisterItemViewModel GetSelectedItem()
        {
            RegisterItemViewModel selectedItem = null;
            if (ItemPanorama.SelectedItem is RegisterItemViewModel)
            {
                selectedItem = ItemPanorama.SelectedItem as RegisterItemViewModel;
            }
            else if (ItemPanorama.SelectedItem is PanoramaItem &&
                     (ItemPanorama.SelectedItem as PanoramaItem).Header is RegisterItemViewModel)
            {
                selectedItem = (ItemPanorama.SelectedItem as PanoramaItem).Header as RegisterItemViewModel;
            }
            return selectedItem;
        }
        #endregion
    }
}