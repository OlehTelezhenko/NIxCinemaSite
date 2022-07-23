using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        [DisplayName("Назва країни")]
        public string Name { get; set; }
        public ICollection<FilmDTO> Films { get; set; }
    }
}
