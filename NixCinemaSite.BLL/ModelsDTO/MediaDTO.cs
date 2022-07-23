using NixCinemaSite.DAL.Entities;
using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class MediaDTO
    {
        public Guid Id { get; set; }

        [DisplayName("Назва медіафайлу")]
        public string MediaTitle { get; set; }

        [DisplayName("Посилання на медіфайл")]
        public string Link { get; set; }

        [DisplayName("Тип медіа файлу")]
        public string Type { get; set; }

        [DisplayName("Номер при сортуванні")]
        public int SortOrder { get; set; }

        [DisplayName("Назва фільму")]
        public string FilmTitle { get; set; }

        public Guid FilmId { get; set; }
        public FilmDTO Film { get; set; }
    }
}
