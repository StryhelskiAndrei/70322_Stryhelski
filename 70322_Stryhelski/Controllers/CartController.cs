using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70322_Stryhelski.DAL;
using _70322_Stryhelski.Models;

namespace _70322_Stryhelski.Controllers
{
    public class CartController : Controller
    {
        IRepository<Film> repository;
        public CartController(IRepository<Film> repo)
        {
            repository = repo;
        }
        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
                GetCart().AddItem(item);
            return Redirect(returnUrl);
        }
        public ActionResult DeleteFromCart(int id)
        {
            var item = repository.Get(id);

            if (item != null)
            {
                GetCart().RemoveItem(item);
                ViewBag.Message = "Товар был успешно убран из корзины";
                ViewBag.Total = GetCart().GetTotal();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("CartPartial", GetCart());
            }

            return RedirectToAction("Index");
           // return null;
        }
        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}