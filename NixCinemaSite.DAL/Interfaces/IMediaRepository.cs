using NixCinemaSite.DAL.Entities;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IMediaRepository : IGenericRepository<MediaEntity>
    {
        public MediaEntity GetObjectWithIncludes(Guid Id);
        public List<MediaEntity> GetListAfterPagination(string searchMedias, string sortProperties, int currectPage, int pageSize);
    }
}