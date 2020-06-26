namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int d_id { get; set; }

        public int product_id { get; set; }

        [Column("discount")]
        public double? discount1 { get; set; }

        public DateTime? date_discount { get; set; }

        public virtual Product Product { get; set; }
    }
}
