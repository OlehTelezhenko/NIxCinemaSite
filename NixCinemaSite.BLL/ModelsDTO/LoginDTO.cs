using System.ComponentModel.DataAnnotations;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class LoginDTO
    {
        [Required]
        [Display(Name = "Логін")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
