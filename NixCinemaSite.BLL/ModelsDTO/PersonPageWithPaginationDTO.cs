using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class PersonPageWithPaginationDTO : BasePaginationDTO
    {
        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }

        [DisplayName("Медійні")]
        public IEnumerable<PersonDTO> Persons { get; set; }

    }
}
