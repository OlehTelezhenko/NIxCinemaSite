using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface ICountryRepository : IGenericRepository<CountryEntity>
    {
        public CountryEntity GetObjectWithIncludes(Guid Id);
        public List<CountryEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize);
    }
}
