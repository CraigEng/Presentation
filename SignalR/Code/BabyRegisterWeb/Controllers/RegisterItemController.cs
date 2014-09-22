using System.Collections.Generic;
using System.Web.Http;
using BabyGiftRegisterLibrary.Model;
using Data;

namespace BabyRegisterWeb.Controllers
{
    public class RegisterItemController : ApiController
    {
        public IEnumerable<RegisterItem> GetItemsInRegister()
        {
            var registerItemDataSource = new RegisterItemDataSource();
            return registerItemDataSource.GetItemsInRegister();
        }
    }
}