using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface IAccountService
    {
        public Task Register(UserDTO userDTO);
        public Task Login(LoginDTO userDTO);
        public Task LogOut();
    }
}
