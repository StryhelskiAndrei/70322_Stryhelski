using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _70322_Stryhelski.DAL
{
   public class EFFilmRepository: IRepository<Film>
    {
        private ApplicationDbContext context;
        private DbSet<Film> table;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public EFFilmRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Films;
        }
        public void Create(Film t)
        {
            table.Add(t);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context
            .Entry(new Film { FilmId = id })
            .State = EntityState.Deleted;
            context.SaveChanges();
        }
        public IEnumerable<Film> Find(Func<Film, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }
        public Film Get(int id)
        {
            return table.Find(id);
        }
        public IEnumerable<Film> GetAll()
        {
            return table;
        }
        public Task<Film> GetAsync(int id)
        {
            return table.FindAsync(id);
        }
        public void Update(Film t)
        {
            if (t.Image == null)
            {
                var film = context.Films
                .AsNoTracking()
                .Where(d => d.FilmId == t.FilmId)
                .FirstOrDefault();
                t.Image = film.Image;
                t.MimeType = film.MimeType;
            }
            context.Entry<Film>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
