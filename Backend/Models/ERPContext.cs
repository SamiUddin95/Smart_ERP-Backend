using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class ERPContext : DbContext
    {
        public virtual DbSet<AccCategory> AccCategory { get; set; }
        public virtual DbSet<AccGroup> AccGroup { get; set; }
        public virtual DbSet<AccGroupCategory> AccGroupCategory { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccType> AccType { get; set; }
        public virtual DbSet<Active> Active { get; set; }
        public virtual DbSet<AgreementType> AgreementType { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<CounterSale> CounterSale { get; set; }
        public virtual DbSet<CounterSaleDetail> CounterSaleDetail { get; set; }
        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ItemBrand> ItemBrand { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<ItemClass> ItemClass { get; set; }
        public virtual DbSet<ItemItems> ItemItems { get; set; }
        public virtual DbSet<ItemManufacturer> ItemManufacturer { get; set; }
        public virtual DbSet<Month> Month { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<PartyOtherContactDetail> PartyOtherContactDetail { get; set; }
        public virtual DbSet<PartyPriceDetail> PartyPriceDetail { get; set; }
        public virtual DbSet<PartyProductDetail> PartyProductDetail { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<PaymentTerms> PaymentTerms { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<PurchaseOpeningPurchase> PurchaseOpeningPurchase { get; set; }
        public virtual DbSet<PurchasePurchase> PurchasePurchase { get; set; }
        public virtual DbSet<ReceivedPayments> ReceivedPayments { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<SalesMan> SalesMan { get; set; }
        public virtual DbSet<SalesManType> SalesManType { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopType> ShopType { get; set; }
        public virtual DbSet<SubArea> SubArea { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<VendorDetails> VendorDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=TEK;Initial Catalog=ERP;user id=sa1;password=123qwe;integrated security=True;Trusted_Connection=True;Encrypt=Yes;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccCategory>(entity =>
            {
                entity.Property(e => e.ManualCode).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Priority).IsUnicode(false);
            });

            modelBuilder.Entity<AccGroup>(entity =>
            {
                entity.Property(e => e.ManualCode).IsUnicode(false);

                entity.Property(e => e.Priority).IsUnicode(false);
            });

            modelBuilder.Entity<AccGroupCategory>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DiscNo).IsUnicode(false);

                entity.Property(e => e.KindCode).IsUnicode(false);

                entity.Property(e => e.ManualCode).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Priority).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<AccType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Active>(entity =>
            {
                entity.Property(e => e.IsActive).IsUnicode(false);
            });

            modelBuilder.Entity<AgreementType>(entity =>
            {
                entity.Property(e => e.AgreementName).IsUnicode(false);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<CustomerDetails>(entity =>
            {
                entity.Property(e => e.BankDetails).IsUnicode(false);

                entity.Property(e => e.BillTo).IsUnicode(false);

                entity.Property(e => e.Business).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.ContactPerson).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Facebook).IsUnicode(false);

                entity.Property(e => e.Individual).IsUnicode(false);

                entity.Property(e => e.Instagram).IsUnicode(false);

                entity.Property(e => e.Linkedin).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.ShipTo).IsUnicode(false);

                entity.Property(e => e.ShopName).IsUnicode(false);

                entity.Property(e => e.TikTok).IsUnicode(false);

                entity.Property(e => e.Twitter).IsUnicode(false);

                entity.Property(e => e.Website).IsUnicode(false);

                entity.HasOne(d => d.PaymentTermsNavigation)
                    .WithMany(p => p.CustomerDetails)
                    .HasForeignKey(d => d.PaymentTerms)
                    .HasConstraintName("FK_Customer_Details_Payment_terms");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName).IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.DueDate).IsUnicode(false);

                entity.Property(e => e.Invoice1).IsUnicode(false);

                entity.Property(e => e.Particulars).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerName)
                    .HasConstraintName("FK_Invoice_Customer");
            });

            modelBuilder.Entity<ItemBrand>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ItemCategory)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_CATEGORY_DEPARTMENT");

                entity.HasOne(d => d.IsActiveNavigation)
                    .WithMany(p => p.ItemCategory)
                    .HasForeignKey(d => d.IsActive)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_CATEGORY_ACTIVE");
            });

            modelBuilder.Entity<ItemClass>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItemClass)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ITEM_CLASS_ITEM_CATEGORY");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ItemClass)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ITEM_CLASS_DEPARTMENT");
            });

            modelBuilder.Entity<ItemItems>(entity =>
            {
                entity.Property(e => e.AliasName).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_BRAND");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_CATEGORY");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_CLASS");

                entity.HasOne(d => d.LockdiscNavigation)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.Lockdisc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_ACTIVE");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_MANUFACTURER");
            });

            modelBuilder.Entity<ItemManufacturer>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Telephoneno).IsUnicode(false);

                entity.Property(e => e.Telephoneno2).IsUnicode(false);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.Property(e => e.MonthName).IsUnicode(false);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.ContactPerson).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FaxNo).IsUnicode(false);

                entity.Property(e => e.MobileNo).IsUnicode(false);

                entity.Property(e => e.Nic).IsUnicode(false);

                entity.Property(e => e.Ntn).IsUnicode(false);

                entity.Property(e => e.PartyName).IsUnicode(false);

                entity.Property(e => e.TaxRegNo).IsUnicode(false);

                entity.Property(e => e.TelPhoneNo).IsUnicode(false);
            });

            modelBuilder.Entity<PartyOtherContactDetail>(entity =>
            {
                entity.Property(e => e.CellNo).IsUnicode(false);

                entity.Property(e => e.ContactPerson).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.OfficeAddress).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.ResAddress).IsUnicode(false);
            });

            modelBuilder.Entity<PartyPriceDetail>(entity =>
            {
                entity.Property(e => e.BarCode).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<PartyProductDetail>(entity =>
            {
                entity.Property(e => e.BarCode).IsUnicode(false);

                entity.Property(e => e.Gst).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentMode1).IsUnicode(false);
            });

            modelBuilder.Entity<PaymentTerms>(entity =>
            {
                entity.Property(e => e.PaymentTerms1).IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentType1).IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOpeningPurchase>(entity =>
            {
                entity.Property(e => e.AccName).IsUnicode(false);

                entity.Property(e => e.Barcode).IsUnicode(false);

                entity.Property(e => e.Bonus).IsUnicode(false);

                entity.Property(e => e.BonusQty).IsUnicode(false);

                entity.Property(e => e.Disc).IsUnicode(false);

                entity.Property(e => e.DiscFlatEn).IsUnicode(false);

                entity.Property(e => e.DiscFlatValue).IsUnicode(false);

                entity.Property(e => e.DiscPerValue).IsUnicode(false);

                entity.Property(e => e.DiscValue2).IsUnicode(false);

                entity.Property(e => e.Flatdisc).IsUnicode(false);

                entity.Property(e => e.Gst).IsUnicode(false);

                entity.Property(e => e.GstValue2).IsUnicode(false);

                entity.Property(e => e.Gstmode).IsUnicode(false);

                entity.Property(e => e.Gstval).IsUnicode(false);

                entity.Property(e => e.Itemname).IsUnicode(false);

                entity.Property(e => e.LooseQty).IsUnicode(false);

                entity.Property(e => e.Margin).IsUnicode(false);

                entity.Property(e => e.Markup).IsUnicode(false);

                entity.Property(e => e.Misc).IsUnicode(false);

                entity.Property(e => e.Netrate).IsUnicode(false);

                entity.Property(e => e.QtyPack).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Stock).IsUnicode(false);

                entity.Property(e => e.TotalIncTax).IsUnicode(false);

                entity.Property(e => e.TotalQty).IsUnicode(false);

                entity.Property(e => e.TotalStock).IsUnicode(false);

                entity.Property(e => e.Totalexctax).IsUnicode(false);

                entity.Property(e => e.Vehicleno).IsUnicode(false);

                entity.Property(e => e.WithholdingTaxPerc).IsUnicode(false);
            });

            modelBuilder.Entity<PurchasePurchase>(entity =>
            {
                entity.Property(e => e.Barcode).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.PartyInv).IsUnicode(false);

                entity.Property(e => e.PartyName).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<ReceivedPayments>(entity =>
            {
                entity.Property(e => e.PaymentNo).IsUnicode(false);

                entity.Property(e => e.ReceiptNo).IsUnicode(false);

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.ReceivedPayments)
                    .HasForeignKey(d => d.CustomerName)
                    .HasConstraintName("FK_Received_Payments_CustomerName");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.ReceivedPayments)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("FK_Received_Payments_Invoice");

                entity.HasOne(d => d.ModeNavigation)
                    .WithMany(p => p.ReceivedPayments)
                    .HasForeignKey(d => d.Mode)
                    .HasConstraintName("FK_Received_Payments_Mode");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.ReceivedPayments)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Received_Payments_Payment_Type");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.Year).IsUnicode(false);
            });

            modelBuilder.Entity<SalesMan>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SalesManType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.AgreementStartDate).IsUnicode(false);

                entity.Property(e => e.ShopLocation).IsUnicode(false);

                entity.Property(e => e.ShopName).IsUnicode(false);

                entity.Property(e => e.ShopSize).IsUnicode(false);
            });

            modelBuilder.Entity<ShopType>(entity =>
            {
                entity.Property(e => e.ShopType1).IsUnicode(false);
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.JoiningDate).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserType1).IsUnicode(false);
            });

            modelBuilder.Entity<VendorDetails>(entity =>
            {
                entity.Property(e => e.BankDetails).IsUnicode(false);

                entity.Property(e => e.Business).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.ContactPerson).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Individual).IsUnicode(false);

                entity.Property(e => e.PaymentTerms).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Salutation).IsUnicode(false);

                entity.Property(e => e.VendorAddress).IsUnicode(false);

                entity.Property(e => e.VendorName).IsUnicode(false);

                entity.Property(e => e.Website).IsUnicode(false);
            });
        }
    }
}
