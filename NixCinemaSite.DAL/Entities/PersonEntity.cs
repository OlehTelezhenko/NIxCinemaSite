namespace NixCinemaSite.DAL.Entities
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public ICollection<FilmToPersonEntity> FilmsToPersons { get; set; }
    }
}
