namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Discounts = new HashSet<Discount>();
            RatingProducts = new HashSet<RatingProduct>();
        }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }

        public double? avgScore { get; set; }

        public int? RateCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingProduct> RatingProducts { get; set; }
    }
}
