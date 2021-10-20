using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _70322_Stryhelski.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Film> Films { get; set; }

        public void Populate()
        {
            if (!Films.Any())
            {
                List<Film> films = new List<Film>
                {


                new Film{Category="Комедия",Name="Приключения шурика",Description="Советская комедия",Price=7},
                new Film{Category="Триллер",Name="Пила",Description="Ужастик, чувак всех шинкует",Price=9},
                new Film{Category="Сериал",Name="Теория большого взрыва",Description="Комедия про ученых",Price=9},
                new Film{Category="Фантастика",Name="Человек-Паук",Description="Обкуренный парень думает что он может лазить по стенам",Price=23},
                new Film{Category="Приключения",Name="Индиано Джонс",Description="Хрустальный череп",Price=19}
                };
                Films.AddRange(films);
                SaveChanges();
            }
            if (!Roles.Any())
            {
                // Создаём менеджеры ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

                // Создаём роли "admin" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));

                // Создаём пользователя
                var userAdmin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    NickName = "SuperHero"
                };

                userManager.CreateAsync(userAdmin, "qwerty").Wait();

                // Добавляем созданного пользователя в администраторы
                userManager.AddToRole(userAdmin.Id, "admin");
            }
        }

    }
}
