using System.Web.Mvc;
using Data;

namespace BabyRegisterWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var registerItemDataSource = new RegisterItemDataSource();
            var items = registerItemDataSource.GetItemsInRegister();

            return View(items);
        }
    }
}