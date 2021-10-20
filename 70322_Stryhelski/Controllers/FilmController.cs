using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70322_Stryhelski.DAL;
using _70322_Stryhelski.Models;
using System.Threading.Tasks;

namespace _70322_Stryhelski.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film

        //List<Film> films = new List<Film>
        //{
        //    new Film{Category="Комедия",Name="Приключения шурика",Description="Советская комедия",Price=7},
        //    new Film{Category="Триллер",Name="Пила",Description="Ужастик, чувак всех шинкует",Price=9},
        //    new Film{Category="Сериал",Name="Теория большого взрыва",Description="Комедия про ученых",Price=9}
        //};

        //public ActionResult List()
        //{
        //    return View(films);
        //}
        int pageSize = 3;
        IRepository<Film> repository;
        public FilmController(IRepository<Film> repo)
        {
            repository = repo;
        }

        public PartialViewResult Side()
        {
            var groups = repository
                 .GetAll()
                 .Select(d => d.Category)
                 .Distinct();
            return PartialView(groups);

        }
        //public FileContentResult GetImage(int id)
        //{
        //    var film = repository.Get(id);
        //    if (film != null)
        //    {
        //        return new FileContentResult(film.Image, film.MimeType);
        //    }
        //    else return null;
        //}
        public async Task<FileResult> GetImage(int id)
        {
            var film = await repository.GetAsync(id);
            if (film != null)
            {
                return new FileContentResult(film.Image, film.MimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult List(string group, int page=1)
        {
            var lst = repository.GetAll()
                .Where(d=> group==null || d.Category.Equals(group))
                .OrderBy(d => d.Price);
            var model = PageListViewModel<Film>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
            //return View(PageListViewModel<Film>.CreatePage(lst,page,pageSize));
        }
    }
}