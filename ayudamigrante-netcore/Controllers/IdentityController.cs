using ayudamigrante_netcore.Models;
using ayudamigrante_netcore.ApplicationServices;
using Codebehind;
using Models.Endpoint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Repositories;

namespace ayudamigrante_netcore.Controllers
{
    public class IdentityController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static bool SessionOnCookies(HttpRequest req) => req.Cookies.Keys.Contains("idAccount") && req.Cookies.Keys.Contains("sessionToken");

        public IdentityController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return Redirect(Url.Action("Login", "Identity"));
        }

        public IActionResult Login()
        {
            if (CookiesHandler.CookieExist(Request, "idAccount") && CookiesHandler.CookieExist(Request, "sessionToken"))
            {
                string session_idAccount = CookiesHandler.GetValue(Request, "idAccount");
                string session_sessionToken = CookiesHandler.GetValue(Request, "sessionToken");

                if (RepositorySession.OnSession(session_sessionToken, session_idAccount))
                {
                    ViewData["session"] = RepositorySession.Get(x => x.IDAccount == session_idAccount && x.SessionToken == session_sessionToken);
                    Account account = RepositoryAccount.Get(x => x.IDAccount == session_idAccount);
                    account.PasswordHash = null;
                    ViewData["account"] = account;

                    return Redirect(Url.Action("Index", "Feed"));
                }
            }
            return View();
        }

        public IActionResult Logout(string sessionToken)
        {
            Session session = RepositorySession.Get(x => x.SessionToken == sessionToken);
            session.SessionToken = null;
            RepositorySession.AddOrUpdate(session);

            CookiesHandler.ClearCookie(HttpContext, "sessionToken");
            CookiesHandler.ClearCookie(HttpContext, "idAccount");

            return Redirect(Url.Action("Index", "Home"));
        }

        [HttpPost]
        public IActionResult SubmitLogin(string email, string password)
        {
            if (RepositoryAccount.IsPasswordCorrect(email, password))
            {
                Account account = RepositoryAccount.Get(x => x.Email == email);

                if (account.RequirePasswordReset)
                    return Redirect(Url.Action("ChangePassword", "Identity", new { idAccount = account.IDAccount }));

                if (RepositorySession.Exist(x => x.IDAccount == account.IDAccount))
                {
                    Session session = RepositorySession.Get(x => x.IDAccount == account.IDAccount);
                    session.LastLogin = DateTime.UtcNow;
                    session.SessionToken = Security.SHA256Hash(Guid.NewGuid().ToString());
                    RepositorySession.AddOrUpdate(session);

                    CookiesHandler.AddCookie(HttpContext, "sessionToken", session.SessionToken);
                    CookiesHandler.AddCookie(HttpContext, "idAccount", account.IDAccount);

                    Console.WriteLine($"Sesion renovada: {account.IDAccount}, Token de sesion creado: {session.IDSession} ({session.SessionToken}) @ {session.LastLogin.ToLocalTime().ToLongTimeString()}");
                }
                else
                {
                    Session session = new Session()
                    {
                        IDSession = Guid.NewGuid().ToString(),
                        IDAccount = account.IDAccount,
                        SessionToken = Security.SHA256Hash(Guid.NewGuid().ToString()),
                        LastLogin = DateTime.UtcNow
                    };

                    RepositorySession.AddOrUpdate(session);

                    CookiesHandler.AddCookie(HttpContext, "sessionToken", session.SessionToken);
                    CookiesHandler.AddCookie(HttpContext, "idAccount", account.IDAccount);
                    // HttpContext.Response.Cookies.Append("sessionToken", session.SessionToken);
                    // HttpContext.Response.Cookies.Append("idAccount", account.IDAccount);

                    Console.WriteLine($"Sesion iniciada: {account.IDAccount}, Token de sesion creado: {session.IDSession} ({session.SessionToken}) @ {session.LastLogin.ToLocalTime().ToLongTimeString()}");
                }
                return Redirect(Url.Action("Index", "Feed"));
            }
            return Redirect(Url.Action("Login", "Identity"));
        }
    }
}
