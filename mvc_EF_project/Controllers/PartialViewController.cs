using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_EF_project.Controllers
{
    public class PartialViewController : Controller
    {
        //
        // GET: /PartialView/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly] //[ChildActionOnly]表示这个Action只能作为ChildAction使用
        public PartialViewResult ChildAction(DateTime time)
        {
            string greetings = string.Empty;
            if (time.Hour > 18)
            {
                greetings = "Good evening now is " + time.ToString("HH:mm:ss");
            }
            else if (time.Hour > 12)
            {
                greetings = "Good afternoon now is " + time.ToString("HH:mm:ss");
            }
            else
            {
                greetings = "Good morning now is " + time.ToString("HH:mm:ss");
            }
            return PartialView("ChildAction", greetings);
        }

        public PartialViewResult ChildAction2(DateTime time)
        {
            string greetings = string.Empty;
            if (time.Hour > 18)
            {
                greetings = "Good evening now is " + time.ToString("HH:mm:ss");
            }
            else if (time.Hour > 12)
            {
                greetings = "Good afternoon now is " + time.ToString("HH:mm:ss");
            }
            else
            {
                greetings = "Good morning now is " + time.ToString("HH:mm:ss");
            }
            return PartialView("ChildAction", greetings);
        }
	}
}