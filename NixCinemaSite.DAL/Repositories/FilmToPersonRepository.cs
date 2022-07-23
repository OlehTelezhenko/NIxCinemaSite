using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class FilmToPersonRepository : GenericRepository<FilmToPersonEntity>, IFilmToPersonRepository
    {
        private readonly CinemaDbContext _context;
        public FilmToPersonRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }
        public FilmToPersonEntity GetObjectWithIncludes(Guid Id)
        {
            FilmToPersonEntity? filmToPersonEntity = _context.FilmToPeople
                .Where(c => c.Id == Id)
                .Include(f => f.Film)
                .Include(p => p.Person)
                .FirstOrDefault();
            return filmToPersonEntity!;
        }
    }
}
