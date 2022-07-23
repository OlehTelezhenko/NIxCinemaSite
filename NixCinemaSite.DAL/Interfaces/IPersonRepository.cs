using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        public PersonEntity GetObjectWithIncludes(Guid Id);
        public List<PersonEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize);
    }
}