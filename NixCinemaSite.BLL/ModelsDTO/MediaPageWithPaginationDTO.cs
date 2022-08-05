using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class MediaPageWithPaginationDTO : BasePaginationDTO
    {
        public string NameSort { get; set; }
        [DisplayName("Медіа")]
        public IEnumerable<MediaDTO> Medias { get; set; }
    }
}
