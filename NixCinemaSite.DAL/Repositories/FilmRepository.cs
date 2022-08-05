using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class FilmRepository : GenericRepository<FilmEntity>, IFilmRepository
    {
        private readonly CinemaDbContext _context;
        public FilmRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public FilmEntity GetObjectWithIncludes(Guid Id)
        {
            FilmEntity? film = _context.Films
                .Where(c => c.Id == Id)
                .Include(c => c.Country)
                .Include(c => c.Certificate)
                .Include(c => c.Media)
                .Include(c => c.Genres)
                .Include(c => c.FilmsToPersons)
                .ThenInclude(c => c.Person)
                .FirstOrDefault();
            return film!;
        }

        public List<FilmEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {

            IQueryable<FilmEntity> filmIQuery = _context.Films;

            if (!String.IsNullOrEmpty(searchString))
            {
                var splitSearchString = searchString.Split(' ', '	');
                foreach (var item in splitSearchString)
                {
                    filmIQuery = filmIQuery.Where(
                    l => l.Title.Contains(item));
                }
            }

            switch (sortProperties)
            {
                case "SortByTitle":
                    filmIQuery = filmIQuery.OrderByDescending(s => s.Title);
                    break;
                default:
                    filmIQuery = filmIQuery.OrderBy(s => s.Title);
                    break;
            }

            if (currectPage > 1)
            {
                filmIQuery = filmIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                filmIQuery = filmIQuery.Take(pageSize);
            }

            return filmIQuery.AsNoTracking().ToList();
        }

    }
}