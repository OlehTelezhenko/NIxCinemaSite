using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IFilmToPersonRepository : IGenericRepository<FilmToPersonEntity>
    {
        public FilmToPersonEntity GetObjectWithIncludes(Guid Id);
    }
}