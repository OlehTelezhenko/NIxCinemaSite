using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class FilmPageWithPaginationDTO
    {
        public string SearchString { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public string FilmTitleSort { get; set; }

        [DisplayName("Фільм")]
        public IEnumerable<FilmDTO> Films { get; set; }
    }
}
