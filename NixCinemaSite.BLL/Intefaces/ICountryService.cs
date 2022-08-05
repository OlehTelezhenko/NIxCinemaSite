using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface ICountryService : IPresentationService<CountryDTO>
    {
        public CountryDTO Find(string input);
        public CountryPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString);
    }
}
