using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Endpoint;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ayudamigrante_netcore.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController/p/5
        [HttpGet]
        public ActionResult P(string id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        public ActionResult Submit(Post form, string redirect)
        {
            try
            {
                Post p = new Post()
                {
                    IDPost = Guid.NewGuid().ToString(),
                    Body = form.Body,
                    IDAccount = form.IDAccount,
                    DateTimeUTC = DateTime.UtcNow,
                };

                // Console.WriteLine(p);
                RepositoryPost.Add(p);
                return Redirect(redirect);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Redirect(redirect);
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
