namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplierStatistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SStatisticID { get; set; }

        public int OrderID { get; set; }

        public int? OrderAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalIncome { get; set; }

        public double? avgCount { get; set; }

        public int? RateCount { get; set; }

        public double? CanceledRatio { get; set; }

        public double? ShippedRatio { get; set; }
    }
}
