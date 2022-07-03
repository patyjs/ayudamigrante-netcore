using ayudamigrante_netcore.Models;
using ayudamigrante_netcore.ApplicationServices;
using Models.Endpoint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ayudamigrante_netcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (CookiesHandler.CookieExist(Request, "sessionToken") && CookiesHandler.CookieExist(Request, "idAccount"))
                if(RepositorySession.OnSession(CookiesHandler.GetValue(Request, "sessionToken"), CookiesHandler.GetValue(Request, "idAccount")))
                {
                    return Redirect(Url.Action("Index", "Feed"));
                }

            return View();
        }

        public IActionResult Privacy()
        {
            if (CookiesHandler.CookieExist(Request, "sessionToken") && CookiesHandler.CookieExist(Request, "idAccount"))
                if(RepositorySession.OnSession(CookiesHandler.GetValue(Request, "sessionToken"), CookiesHandler.GetValue(Request, "idAccount")))
                {
                    var sessionToken = CookiesHandler.GetValue(Request, "sessionToken");
                    var idAccount = CookiesHandler.GetValue(Request, "idAccount");

                    ViewData["session"] = RepositorySession.Get(x => x.IDAccount == idAccount && x.SessionToken == sessionToken);
                    Account account = RepositoryAccount.Get(x => x.IDAccount == idAccount);
                    account.PasswordHash = null;
                    ViewData["account"] = account;
                }
                
            return View();
        }

        public IActionResult Terms()
        {
            if (CookiesHandler.CookieExist(Request, "sessionToken") && CookiesHandler.CookieExist(Request, "idAccount"))
                if(RepositorySession.OnSession(CookiesHandler.GetValue(Request, "sessionToken"), CookiesHandler.GetValue(Request, "idAccount")))
                {
                    var sessionToken = CookiesHandler.GetValue(Request, "sessionToken");
                    var idAccount = CookiesHandler.GetValue(Request, "idAccount");

                    ViewData["session"] = RepositorySession.Get(x => x.IDAccount == idAccount && x.SessionToken == sessionToken);
                    Account account = RepositoryAccount.Get(x => x.IDAccount == idAccount);
                    account.PasswordHash = null;
                    ViewData["account"] = account;
                }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
