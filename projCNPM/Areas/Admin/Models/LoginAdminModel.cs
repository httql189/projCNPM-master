using System.ComponentModel.DataAnnotations;

namespace projCNPM.Areas.Admin.Models
{
    public class LoginAdminModel
    {

        [Required(ErrorMessage = "Mời nhập Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập Password")]
        public string PassWord { get; set; }

        public string ChangePassWord { get; set; }
        public bool Rememberme { get; set; }
    }
}