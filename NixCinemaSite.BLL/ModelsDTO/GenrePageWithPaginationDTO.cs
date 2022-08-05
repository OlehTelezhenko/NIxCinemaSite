using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class GenrePageWithPaginationDTO : BasePaginationDTO
    {
        public string NameSort { get; set; }
        [DisplayName("Жанр")]
        public IEnumerable<GenreDTO> Genres { get; set; }
    }
}
