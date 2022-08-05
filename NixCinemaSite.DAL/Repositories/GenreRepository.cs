using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class GenreRepository : GenericRepository<GenreEntity>, IGenreRepository
    {
        private readonly CinemaDbContext _context;
        public GenreRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public GenreEntity GetObjectWithIncludes(Guid Id)
        {
            GenreEntity? genre = _context.Genres
                .Where(c => c.Id == Id)
                .Include(c => c.Films)
                .FirstOrDefault();
            return genre!;
        }

        public List<GenreEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {
            IQueryable<GenreEntity> genreIQuery = _context.Genres;

            if (!String.IsNullOrEmpty(searchString))
            {
                genreIQuery = genreIQuery.Where(c => c.Name.Contains(searchString));
            }

            switch (sortProperties)
            {
                case "SortByName":
                    genreIQuery = genreIQuery.OrderByDescending(s => s.Name);
                    break;
                default:
                    genreIQuery = genreIQuery.OrderBy(s => s.Name);
                    break;
            }

            if (currectPage > 1)
            {
                genreIQuery = genreIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                genreIQuery = genreIQuery.Take(pageSize);
            }

            var a = genreIQuery.AsNoTracking().ToList();
            return a;
        }
    }
}