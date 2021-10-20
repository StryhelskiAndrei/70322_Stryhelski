using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70322_Stryhelski.DAL
{
    public class FakeRepository:IRepository<Film>
    {
        public void Create(Film t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> Find(Func<Film, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Film Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> GetAll()
        {
            return new List<Film>
            {
                new Film{Category="Комедия",Name="Приключения шурика",Description="Советская комедия",Price=7},
                new Film{Category="Триллер",Name="Пила",Description="Ужастик, чувак всех шинкует",Price=9},
                new Film{Category="Сериал",Name="Теория большого взрыва",Description="Комедия про ученых",Price=9},
                new Film{Category="Фантастика",Name="Человек-Паук",Description="Обкуренный парень думает что он может лазить по стенам",Price=23},
                new Film{Category="Приключения",Name="Индиано Джонс",Description="Хрустальный череп",Price=19}
            };
        }

        public Task<Film> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Film t)
        {
            throw new NotImplementedException();
        }
    }
}
