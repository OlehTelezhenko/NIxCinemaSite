using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class CertificateDTO
    {
        public Guid Id { get; set; }

        [DisplayName("Сертіфікат")]
        public string Name { get; set; }

        [DisplayName("Опис")]
        public string Description { get; set; }

        [DisplayName("Адреса зображення сертіфікату")]
        public string Image { get; set; }

        public ICollection<FilmDTO> Films { get; set; }
    }
}
