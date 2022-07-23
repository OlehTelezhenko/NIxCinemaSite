using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class PersonPageWithPaginationDTO
    {
        public string SearchString { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }

        [DisplayName("Медійні")]
        public IEnumerable<PersonDTO> Persons { get; set; }

    }
}
