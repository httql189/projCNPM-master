namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderID { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DeliveriedDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }

        [StringLength(60)]
        public string ShipAddress { get; set; }

        [StringLength(60)]
        public string ShipDistrict { get; set; }

        [StringLength(60)]
        public string ShipProvince { get; set; }

        public int? Status { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
