using Microsoft.AspNetCore.Identity;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities.Identity;

namespace NixCinemaSite.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(UserDTO userDTO)
        {
            User user = new User
            {
                DateOfBirth = userDTO.DateOfBirth,
                Email = userDTO.Email,
                EmailConfirmed = true,
                UserName = userDTO.UserName,
                PhoneNumber = userDTO.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);
            }
        }

        public async Task Login(LoginDTO loginDTO)
        {
            await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, loginDTO.RememberMe, false);
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
