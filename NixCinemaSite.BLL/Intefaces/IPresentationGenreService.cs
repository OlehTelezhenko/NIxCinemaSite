using NixCinemaSite.BLL.ModelsDTO;
namespace NixCinemaSite.BLL.Intefaces
{
    public interface IPresentationGenreService : IPresentationService<GenreDTO>
    {
        public GenreDTO Find(string input);
        public GenrePageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString);
    }
}
