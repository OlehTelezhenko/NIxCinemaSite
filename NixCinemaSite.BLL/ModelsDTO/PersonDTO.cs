using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }
        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [DisplayName("Біографія")]
        public string Bio { get; set; }
        [DisplayName("Дата народження")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Адресса фотографії")]
        public string Photo { get; set; }
        public ICollection<FilmToPersonDTO>FilmsToPersons { get; set; }
    }
}
