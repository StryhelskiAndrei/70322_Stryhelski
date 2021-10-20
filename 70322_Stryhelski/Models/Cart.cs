using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _70322_Stryhelski.DAL;

namespace _70322_Stryhelski.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> cartItems;
        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="dish">объект для добавления</param>
        public void AddItem(Film film)
        {
            if (cartItems.ContainsKey(film.FilmId))
                cartItems[film.FilmId].Count += 1;
            else
                cartItems.Add(film.FilmId,
                new CartItem { Film = film, Count = 1 });
        }
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="dish">Объект для удаления</param>
        public void RemoveItem(Film film)
        {
            if (cartItems[film.FilmId].Count == 1)
                cartItems.Remove(film.FilmId);
            else
                cartItems[film.FilmId].Count -= 1;
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }
        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public double GetTotal()
        {
            return cartItems
            .Values
            .Sum(i => i.Film.Price * i.Count);
        }
        /// <summary>
        /// Получение содержимого корзины
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }
    }
}