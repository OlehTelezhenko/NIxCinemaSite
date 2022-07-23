using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface ICertificateRepository : IGenericRepository<CertificateEntity>
    {
        public CertificateEntity GetObjectWithIncludes(Guid Id);
        public List<CertificateEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize);
    }
}
