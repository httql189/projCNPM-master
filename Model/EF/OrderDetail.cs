namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? ProductID { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        public double? Discount { get; set; }

        public virtual Order Order { get; set; }
    }
}
