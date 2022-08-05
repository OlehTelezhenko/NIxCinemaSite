using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class FilmPageWithPaginationDTO : BasePaginationDTO
    {
        public string FilmTitleSort { get; set; }

        [DisplayName("Фільм")]
        public IEnumerable<FilmDTO> Films { get; set; }
    }
}
