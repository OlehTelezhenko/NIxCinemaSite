using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface IPresentationMediaService : IPresentationService<MediaDTO>
    {
        public MediaPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchMedias);
    }
}
