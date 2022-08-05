using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface IPersonService : IPresentationService<PersonDTO>
    {
        public PersonDTO Find(string input);
        public PersonPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchMedias);
    }
}
