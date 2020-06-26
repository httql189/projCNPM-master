namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [Key]
        [Column(Order = 0)]
        public int SupplierID { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string District { get; set; }

        [StringLength(20)]
        public string Province { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        public TimeSpan TimeStart { get; set; }

        public TimeSpan TimeEnd { get; set; }

        public bool? Status { get; set; }

        public virtual Member Member { get; set; }
    }
}
