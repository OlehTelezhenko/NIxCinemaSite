namespace NixCinemaSite.DAL.Entities
{
    public class FilmToPersonEntity
    {
        public Guid Id { get; set; }
        public string Role { get; set; }

        public Guid FilmId { get; set; }
        public FilmEntity Film { get; set; }

        public Guid PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
