using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database_API.Models
{
    public partial class _102119144Context : DbContext
    {
        public _102119144Context()
        {

        }
        public _102119144Context(DbContextOptions<_102119144Context> options)
            : base(options)
        {

        }
        public virtual DbSet<Payment9144> Payment9144 { get; set; }
        public virtual DbSet<AuthorisedPerson9144> AuthorisedPerson9144 { get; set; }
        public virtual DbSet<Account9144> Account9144 { get; set; }
        public virtual DbSet<AuthorisedAccounts9144> AuthorisedAccounts9144 { get; set; }
        public virtual DbSet<Ledger9144> Ledger9144 { get; set; }
        public virtual DbSet<Inventory9144> Inventory9144 { get; set; }
        public virtual DbSet<Location9144> Location9144 { get; set; }
        public virtual DbSet<Order9144> Order9144 { get; set; }
        public virtual DbSet<Orderline9144> Orderline9144 { get; set; }
        public virtual DbSet<Product9144> Product9144 { get; set; }
        public virtual DbSet<PurchaseOrder9144> PurchaseOrder9144 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=db.swinswd.com;Database=102119144;User ID=102199144;Password=password;Trusted_Connection=False;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "102119144");

            modelBuilder.Entity<Payment9144>(entity =>
            {
                entity.HasKey(e => new { e.ID, e.TimeRecieved })
                    .HasName("PK_ACCOUNTPAYMENT");

                entity.ToTable("ACCOUNTPAYMENT9144");

                entity.Property(e => e.ID).HasColumnName("ACCOUNTID");

                entity.Property(e => e.TimeRecieved)
                    .HasColumnName("DATETIMERECEIVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sum)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Payment9144)
                    .HasForeignKey(d => d.ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTPAYMENT_ACCOUNT");
            });

            modelBuilder.Entity<AuthorisedPerson9144>(entity =>
            {
                entity.HasKey(e => e.userID)
                    .HasName("PK_AUTHORISEDPERSON");

                entity.ToTable("AUTHORISEDPERSON9144");

                entity.Property(e => e.userID).HasColumnName("USERID");

                entity.Property(e => e.accountID).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AuthorisedPerson9144)
                    .HasForeignKey(d => d.accountID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORISEDPERSON_CLIENTACCOUNT");
            });

            modelBuilder.Entity<Account9144>(entity =>
            {
                entity.HasKey(e => e.acctId)
                    .HasName("PK_CLIENTACCOUNT");

                entity.ToTable("CLIENTACCOUNT9144");

                entity.HasIndex(e => e.acctName)
                    .HasName("UQ_CLENTACCOUNT_NAME")
                    .IsUnique();

                entity.Property(e => e.acctId).HasColumnName("ACCOUNTID");

                entity.Property(e => e.acctName)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.acctBalance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.credLimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<AuthorisedAccounts9144>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Accountid })
                    .HasName("PK__CLIENTAU__AA6830EAFE4ACF36");

                entity.ToTable("CLIENTAUTHORISEDACCOUNTS9144");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.acctName)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.acctBalance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.credLimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AuthorisedAccounts9144)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTAUT__ACCOU__65D7BC2E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthorisedAccounts9144)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTAUT__USERI__66CBE067");
            });

            modelBuilder.Entity<Ledger9144>(entity =>
            {
                entity.HasKey(e => e.ItemID)
                    .HasName("PK_GENERALLEDGER");

                entity.ToTable("GENERALLEDGER9144");

                entity.HasIndex(e => e.ItemDescription)
                    .HasName("UQ_GENERALEDGER_DESCRIPTION")
                    .IsUnique();

                entity.Property(e => e.ItemID)
                    .HasColumnName("ITEMID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemAmount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Inventory9144>(entity =>
            {
                entity.HasKey(e => new { e.ProductID, e.LocationID })
                    .HasName("PK_INVENTORY");

                entity.ToTable("INVENTORY9144");

                entity.Property(e => e.ProductID).HasColumnName("PRODUCTID");

                entity.Property(e => e.LocationID)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Stock).HasColumnName("NUMINSTOCK");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory9144)
                    .HasForeignKey(d => d.LocationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory9144)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_PRODUCT");
            });

            modelBuilder.Entity<Location9144>(entity =>
            {
                entity.HasKey(e => e.LocationID)
                    .HasName("PK_LOCATION");

                entity.ToTable("LOCATION9144");

                entity.Property(e => e.LocationID)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasColumnName("LOCNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("MANAGER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order9144>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDER9144");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.DateTimeCreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTimeDispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order9144)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_AUTHORISEDPERSON");
            });

            modelBuilder.Entity<Orderline9144>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("PK_ORDERLINE");

                entity.ToTable("ORDERLINE9144");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline9144)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline9144)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_PRODUCT");
            });

            modelBuilder.Entity<Product9144>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK_PRODUCT");

                entity.ToTable("PRODUCT9144");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("BUYPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Prodname)
                    .IsRequired()
                    .HasColumnName("PRODNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Sellprice)
                    .HasColumnName("SELLPRICE")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<PurchaseOrder9144>(entity =>
            {
                entity.HasKey(e => new { e.ProductID, e.LocationID, e.DateTimeCreated })
                    .HasName("PK_PURCHASEORDER");

                entity.ToTable("PURCHASEORDER9144");

                entity.Property(e => e.ProductID).HasColumnName("PRODUCTID");

                entity.Property(e => e.LocationID)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.DateTimeCreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnName("QUANTITY");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PurchaseOrder9144)
                    .HasForeignKey(d => d.LocationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrder9144)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_PRODUCT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
