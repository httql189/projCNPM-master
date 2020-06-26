namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineSMSystemDB : DbContext
    {
        public OnlineSMSystemDB()
            : base("name=OnlineSMSystemDB")
        {
        }

        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RatingProduct> RatingProducts { get; set; }
        public virtual DbSet<RatingSupplier> RatingSuppliers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierStatistic> SupplierStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.VerifyCode)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.RatingProducts)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.RatingSuppliers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Discounts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.RatingProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RatingProduct>()
                .Property(e => e.Score)
                .IsFixedLength();

            modelBuilder.Entity<RatingProduct>()
                .Property(e => e.DateRating)
                .IsFixedLength();

            modelBuilder.Entity<RatingSupplier>()
                .Property(e => e.Score)
                .IsFixedLength();

            modelBuilder.Entity<RatingSupplier>()
                .Property(e => e.DateRating)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SupplierStatistic>()
                .Property(e => e.TotalIncome)
                .HasPrecision(19, 4);
        }
    }
}
