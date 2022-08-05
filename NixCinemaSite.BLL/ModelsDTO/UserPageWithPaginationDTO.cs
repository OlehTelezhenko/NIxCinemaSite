using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class UserPageWithPaginationDTO : BasePaginationDTO
    {
        [DisplayName("Користувачі")]
        public List<UserWithRolesDTO> Users { get; set; }
    }
}
