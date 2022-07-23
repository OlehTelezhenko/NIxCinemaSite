namespace NixCinemaSite.DAL.Entities
{
    public class FilmEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public DateTime DatePremier { get; set; }

        public Guid CountryId { get; set; }
        public CountryEntity Country { get; set; } //страна одна
        public Guid CertificateId { get; set; }
        public CertificateEntity Certificate { get; set; } //один сертификат
        public ICollection<MediaEntity> Media { get; set; } //одна медиа
        public ICollection<GenreEntity> Genres { get; set; } //много жанров
        public ICollection<FilmToPersonEntity> FilmsToPersons { get; set; } //много актеров/режисеров
        

    }
}
