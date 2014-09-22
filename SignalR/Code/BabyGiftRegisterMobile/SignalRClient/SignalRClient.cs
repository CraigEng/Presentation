using System;
using System.Threading.Tasks;
using BabyGiftRegisterLibrary.Model;
using Microsoft.AspNet.SignalR.Client;

namespace WebLogic
{
    public class SignalRClient
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public SignalRClient()
        {
            _connection = new HubConnection("http://192.168.0.6/BabyRegisterWeb");
            _proxy = _connection.CreateHubProxy("BabyRegisterHub");
        }

        public event Action<int> OnSetSold;
        public event Action<RegisterItem> OnAddToRegister;

        public async Task Connect()
        {
            await _connection.Start();
            _proxy.On("setSold", (int productId) =>
            {
                if (OnSetSold != null)
                {
                    OnSetSold(productId);
                }
            });

            _proxy.On("addToRegister", (RegisterItem registerItem) =>
            {
                if (OnAddToRegister != null)
                {
                    OnAddToRegister(registerItem);
                }
            });
        }

        public async Task Buy(int productId)
        {
            await _proxy.Invoke("Buy", productId);
        }

        public async Task AddBarCode(string barCode)
        {
            await _proxy.Invoke("AddBarCode", barCode);
        }
    }
}