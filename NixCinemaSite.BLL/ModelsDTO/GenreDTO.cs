using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class GenreDTO 
    {
        public Guid Id { get; set; }
        [DisplayName("Жанр")]
        public string Name { get; set; }
        public ICollection<FilmDTO> Films { get; set; }
    }
}
