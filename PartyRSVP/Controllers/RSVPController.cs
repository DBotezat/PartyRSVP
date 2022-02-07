using Microsoft.AspNetCore.Mvc;
using PartyRSVP.Models;
using PartyRSVP.Models.PartyRSVP.Models;

namespace PartyRSVP.Controllers
{
    public class RSVPController : Controller
    {
        //private MyContext _context;
        public ViewResult Index()
        {
            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(CustomerRespond customerRespond)
        {
            if (ModelState.IsValid)
            {
                if (customerRespond.Attend.Value)
                    return RedirectToAction("Thanks");
                else
                    return RedirectToAction("Sorry");
            }
            return View(customerRespond);
        }
        public ActionResult Thanks()
        {
            return View();
        }
        public ActionResult Sorry()
        {
            return View();
        }

    }
}
