using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities.Identity;

namespace NixCinemaSite.BLL.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper) 
        { 
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<UserPageWithPaginationDTO> GetPageAfterPaginationAsync(string? sortProperty, int? currectPage, string? searchString)
        {
            UserPageWithPaginationDTO pageUser = new UserPageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString))
            {
                pageUser.TotalPages = (int)Math.Ceiling(decimal.Divide(_userManager.Users.Count(), pageUser.PageSize));
            }

            if (currectPage != 0 && currectPage != null)
            {
                pageUser.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageUser.TotalPages)
            {
                pageUser.CurrentPage = pageUser.TotalPages;
            }

            // TODO сервис юзер сортировка
/*
            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pagePerson.FirstNameSort = "SortByNameDesc";
            }
            else
            {
                pagePerson.FirstNameSort = "SortByName";
            }
*/

            if (!String.IsNullOrEmpty(searchString))
            {
                pageUser.SearchString = searchString;
            }

            IQueryable<User> userIQuery = _userManager.Users.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
                userIQuery = userIQuery.Where(c => c.UserName.Contains(searchString));

            switch (sortProperty)
            {
                case "SortByName":
                    userIQuery = userIQuery.OrderByDescending(s => s.UserName);
                    break;
                default:
                    userIQuery = userIQuery.OrderBy(s => s.UserName);
                    break;
            }

            if (currectPage > 1)
            {
                userIQuery = userIQuery.Skip((pageUser.CurrentPage - 1) * pageUser.PageSize).Take(pageUser.PageSize);
            }
            else
            {
                userIQuery = userIQuery.Take(pageUser.PageSize);
            }

            var users = userIQuery.ToList();

            pageUser.Users = new List<UserWithRolesDTO>();

            foreach (var User in users)
            {
                // TODO сервис виводить главную роль из ролей 
                var userDTO = _mapper.Map<User, UserWithRolesDTO>(User);
                userDTO.Id = Guid.Parse(User.Id);
                pageUser.Users.Add(userDTO);
            }
            
            if (!String.IsNullOrEmpty(searchString))
            {
                pageUser.TotalPages = (int)Math.Ceiling(decimal.Divide(pageUser.Users.Count(), pageUser.PageSize));
            }

            return pageUser;
        }

        public async Task<UserWithRolesDTO> GetByIdAsync(Guid id)
        {
            var a = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<User, UserWithRolesDTO>(a);
        }

        public async Task CreateAsync(UserWithRolesDTO userDTO)
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
                await _userManager.AddToRolesAsync(user, userDTO.UserRoles);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var userToDelete = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(userToDelete);
        }

        public async Task<UserWithRolesDTO> DetailsAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userDTO = _mapper.Map<User, UserWithRolesDTO>(user);
            userDTO.AllRoles = _roleManager.Roles.ToList();
            userDTO.UserRoles = (List<string>)await _userManager.GetRolesAsync(user);
            return userDTO;
        }

        public async Task EditAsync(UserWithRolesDTO userToUpdate)
        {
            // TODO переделать 
            User user = await _userManager.FindByIdAsync(userToUpdate.Id.ToString());
            user.DateOfBirth = userToUpdate.DateOfBirth;
            user.Email = userToUpdate.Email;
            user.PhoneNumber = userToUpdate.PhoneNumber;
            user.UserName = userToUpdate.UserName;
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var addedRoles = userToUpdate.UserRoles.Except(userRoles);
                var removedRoles = userRoles.Except(userToUpdate.UserRoles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
            }
        }
    }
}
