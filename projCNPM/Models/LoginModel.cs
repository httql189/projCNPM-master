using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projCNPM.Models
{
    public class LoginModel
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Password { get; set; }
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string District { get; set; }

        [StringLength(20)]
        public string Province { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(10)]
        public string CMND { get; set; }

        [StringLength(10)]
        public string Image { get; set; }

        public bool? IsSupplier { get; set; }

        [StringLength(10)]
        public string GroupID { get; set; }

        public bool? Status { get; set; }
        [StringLength(100)]
        public string VerifyCode { get; set; }
    }
}