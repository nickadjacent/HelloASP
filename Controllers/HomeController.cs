using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloASP
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        // [Route("")]   <-- alternate to above without the route above
        public ViewResult Index()
        {
            // will look for HiThere file in --> Views/Home/index.cshtml
            return View();
        }

        // localhost:5000/hello
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            // locslhost:5000
            Console.WriteLine("Hello There, redirecting...");
            return RedirectToAction("HelloUser", new { username = "Nick", location = "Whittier" });
        }





        // localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        public IActionResult HelloUser(string username, string location)
        {
            var response = new { user = username, place = location };
            if (location == "Whittier")
                return Json(response);

            else if (location == "CostaMesa")
                return View("Index");

            return RedirectToAction("Index");
        }
    }
}