namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RatingProduct")]
    public partial class RatingProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rp_id { get; set; }

        public int ProductID { get; set; }

        public int MemberID { get; set; }

        [StringLength(10)]
        public string Score { get; set; }

        [StringLength(10)]
        public string DateRating { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
