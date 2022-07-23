using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class FilmDTO
    {
        [DisplayName("Id фільму")]
        public Guid Id { get; set; }
        [DisplayName("Назва фільму")]
        public string Title { get; set; }

        [DisplayName("Триваліть у хвилинах")]
        public int Duration { get; set; }

        [DisplayName("Опис фільму")]
        public string Description { get; set; }

        [DisplayName("Рейтінг")]
        public float Rating { get; set; }

        [DisplayName("Дата прим'єрі")]
        public DateTime DatePremier { get; set; }
        [DisplayName("Країна")]
        public CountryDTO Country { get; set; }

        [DisplayName("Медійна інформація")]
        public ICollection<MediaDTO> Media { get; set; }
        [DisplayName("Жанр")]
        public ICollection<GenreDTO> Genres { get; set; }
        [DisplayName("Знімальна группа")]
        public ICollection<FilmToPersonDTO> FilmsToPersons { get; set; }
        [DisplayName("Сертіфікат")]
        public CertificateDTO Certificate { get; set; }


        [DisplayName("Сертіфікат")]
        public Guid CertificateId { get; set; }

        [DisplayName("Країна")]
        public Guid CountryId { get; set; }

        [DisplayName("Знімальна група")]
        public string[] PersonsIds { get; set; }

        [DisplayName("Роль")]
        public string[] RolePersons { get; set; }

        [DisplayName("Жанр(и)")]
        public string[] GenresIds { get; set; }
        public string MediaId { get; set; }
        public IFormFile UploadFiles {get;set;}

    }
}
