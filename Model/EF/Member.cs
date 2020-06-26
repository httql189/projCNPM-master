namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Orders = new HashSet<Order>();
            RatingProducts = new HashSet<RatingProduct>();
            RatingSuppliers = new HashSet<RatingSupplier>();
            Suppliers = new HashSet<Supplier>();
        }

        public int MemberID { get; set; }
        //public string Gender { get; set; }


        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string PassWord { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
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
        public virtual GroupUser GroupUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingProduct> RatingProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingSupplier> RatingSuppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
