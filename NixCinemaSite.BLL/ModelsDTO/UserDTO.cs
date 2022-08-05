using System.ComponentModel.DataAnnotations;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Логін не може бути пустим")]
        [Display(Name = "Логин")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Введіть номер телефону")]
        [Display(Name = "Номер мобільного телефону")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string? PasswordConfirmed { get; set; }

        [Required(ErrorMessage = "Введіть електронну адресу")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Дата народження не введена")]
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }
    }
}
