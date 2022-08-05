using NixCinemaSite.DAL.Entities;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IFilmToPersonRepository : IGenericRepository<FilmToPersonEntity>
    {
        public FilmToPersonEntity GetObjectWithIncludes(Guid Id);
    }
}