using Data;
using Microsoft.AspNet.SignalR;

namespace BabyRegisterWeb.SignalRHub
{
    public class BabyRegisterHub : Hub
    {
        public void Buy(int productId)
        {
            var registerItemDataSource = new RegisterItemDataSource();
            registerItemDataSource.SellItem(productId);
            Clients.All.setSold(productId);
        }

        public void AddBarCode(string barCode)
        {
            var registerItemDataSource = new RegisterItemDataSource();
            var item = registerItemDataSource.AddToRegister(barCode);
            if (item == null)
                return;

            Clients.Others.addToRegister(item);
        }
    }
}