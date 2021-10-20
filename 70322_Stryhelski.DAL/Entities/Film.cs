using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _70322_Stryhelski.DAL
{
    public class Film
    {
        [HiddenInput]
        public int FilmId { get; set; }  //id

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название блюда")]
        public string Name { get; set; }  //Название фильма

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 100)]
        public double Price { get; set; }  //цена фильма

        [Required]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }

        [ScaffoldColumn(false)]
        public string MimeType { get; set; }
    }
}
