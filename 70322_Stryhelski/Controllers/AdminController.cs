using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70322_Stryhelski.DAL;

namespace _70322_Stryhelski.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository<Film> repository;
        public AdminController(IRepository<Film> repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Film film, HttpPostedFileBase imageUpload = null)
        {
            if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                film.Image = new byte[count];
                imageUpload.InputStream.Read(film.Image, 0, (int)count);
                film.MimeType = imageUpload.ContentType;
            }
            try
            {
                repository.Create(film);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(film);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Film film, HttpPostedFileBase imageUpload = null)
        {
            if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                film.Image = new byte[count];
                imageUpload.InputStream.Read(film.Image, 0, (int)count);
                film.MimeType = imageUpload.ContentType;
            }
            try
            {
                repository.Update(film);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(film);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
