using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class CountryPageWithPaginationDTO : BasePaginationDTO
    {
        public string NameSort { get; set; }
        [DisplayName("Країна")]
        public IEnumerable<CountryDTO> Countries { get; set; }
    }
}
