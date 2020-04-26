using System.Web.Mvc;
using WeatherA.Class;

namespace WeatherA.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMessages()
        {
            AlertsHelper _messageRepository = new AlertsHelper();
            return PartialView("_MessagesList", _messageRepository.GetAllMessages());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}