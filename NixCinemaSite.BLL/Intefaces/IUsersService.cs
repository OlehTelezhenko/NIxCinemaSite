using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface IUsersService
    {
        public Task<UserPageWithPaginationDTO> GetPageAfterPaginationAsync(string? sortProperty, int? currectPage, string? searchString);
        public Task<UserWithRolesDTO> GetByIdAsync(Guid id);
        public Task CreateAsync(UserWithRolesDTO userDTO);
        public Task DeleteAsync(Guid id);
        public Task<UserWithRolesDTO> DetailsAsync(Guid id);
        public Task EditAsync(UserWithRolesDTO userToUpdate);
    }
}
