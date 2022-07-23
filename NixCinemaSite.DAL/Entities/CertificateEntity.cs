namespace NixCinemaSite.DAL.Entities
{
    public class CertificateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<FilmEntity> Films { get; set; }
    }
}
