using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class MediaPageWithPaginationDTO
    {
        public string SearchString { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public string NameSort { get; set; }
        [DisplayName("Медіа")]
        public IEnumerable<MediaDTO> Medias { get; set; }
    }
}
