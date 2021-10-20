using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70322_Stryhelski.DAL;
using _70322_Stryhelski.Models;


namespace _70322_Stryhelski.Controllers
{
    public class MenuController : Controller
    {
        //IRepository<Film> repository; ////new add
        //    public MenuController(IRepository<Film> repo)
        //{
        //    repository = repo;
        //}
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        //public PartialViewResult Main()
        //{
        //    return PartialView();
        //}


        public PartialViewResult Main(string a = "Index", string c = "Home")
        { /*items.First(m => m.Controller == c).Active = "active"; return PartialView(items);*/
            var menuItem = items.FirstOrDefault(m => m.Controller == c);

            if (menuItem != null)
            {
                menuItem.Active = "active";
            }

            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        //public PartialViewResult Side()
        //{
        //    var groups = repository
        //         .GetAll()
        //         .Select(d => d.Category)
        //         .Distinct();
        //    return PartialView(groups);
                
        //}

        public PartialViewResult Map()
        {
            return PartialView(items);
        }

        List<MenuItem> items;
        
        public MenuController()
        {
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог", Controller="Film",Action="List", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin",Action="Index", Active=string.Empty},
            };
        }
    }
}