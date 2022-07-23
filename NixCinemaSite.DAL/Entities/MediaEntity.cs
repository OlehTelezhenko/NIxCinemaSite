namespace NixCinemaSite.DAL.Entities
{
    public class MediaEntity
    {
        public Guid Id { get; set; }
        public string MediaTitle { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }
        public Guid FilmId { get; set; }
        public string FilmTitle { get; set; }
        public FilmEntity Film { get; set; }
    }
}
