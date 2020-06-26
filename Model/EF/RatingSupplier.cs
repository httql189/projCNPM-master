namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RatingSupplier")]
    public partial class RatingSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rs_id { get; set; }

        public int SupplierID { get; set; }

        public int MemberID { get; set; }

        [StringLength(10)]
        public string Score { get; set; }

        [StringLength(10)]
        public string DateRating { get; set; }

        public virtual Member Member { get; set; }
    }
}
