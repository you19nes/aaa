using Microsoft.AspNetCore.Mvc;

namespace aaa.Controllers
{
    public class ItemInfoController : Controller
    {
        public IActionResult ItemInfo()
        {
            return View("../ItemInfo/ItemInfo");
        }
    }
}
