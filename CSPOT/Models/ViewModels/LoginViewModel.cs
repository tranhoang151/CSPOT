using System.ComponentModel.DataAnnotations;

namespace CSPOT.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập?")]
        public bool RememberMe { get; set; }
    }
}
