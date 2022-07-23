
namespace NixCinemaSite.BLL.ModelsDTO
{
    public class FilmToPersonDTO
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public Guid FilmId { get; set; }
        public FilmDTO Film { get; set; }
        public Guid PersonId { get; set; }
        public PersonDTO Person { get; set; }
    }
}
