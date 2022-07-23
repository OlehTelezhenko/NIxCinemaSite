namespace NixCinemaSite.DAL.Entities
{
    public class CountryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<FilmEntity> Films { get; set; }
    }
}
