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
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CounterSale> CounterSale { get; set; }
        public virtual DbSet<CounterSaleDetail> CounterSaleDetail { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<GoDown> GoDown { get; set; }
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
        public virtual DbSet<PurchaseOrderCateory> PurchaseOrderCateory { get; set; }
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

        // Unable to generate entity type for table 'dbo.Customer_Details'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=MOHSINNADEEM\SQL2K17DEV;Database=ERP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccCategory>(entity =>
            {
                entity.ToTable("ACC_CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountTypeId).HasColumnName("ACCOUNT_TYPE_ID");

                entity.Property(e => e.ManualCode)
                    .HasColumnName("MANUAL_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasColumnName("PRIORITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccGroup>(entity =>
            {
                entity.ToTable("ACC_GROUP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountTypeId).HasColumnName("ACCOUNT_TYPE_ID");

                entity.Property(e => e.GroupCategoryId).HasColumnName("GROUP_CATEGORY_ID");

                entity.Property(e => e.ManualCode)
                    .HasColumnName("MANUAL_CODE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasColumnName("PRIORITY")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccGroupCategory>(entity =>
            {
                entity.ToTable("ACC_GROUP_CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountCategoryId).HasColumnName("ACCOUNT_CATEGORY_ID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("ACCOUNT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeId).HasColumnName("ACCOUNT_TYPE_ID");

                entity.Property(e => e.BalanceLimit).HasColumnName("BALANCE_LIMIT");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DiscNo)
                    .HasColumnName("DISC_NO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.KindCode)
                    .HasColumnName("KIND_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManualCode)
                    .HasColumnName("MANUAL_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasColumnName("PRIORITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubCdTypeId).HasColumnName("SUB_CD_TYPE_ID");

                entity.Property(e => e.SubGroupId).HasColumnName("SUB_GROUP_ID");

                entity.Property(e => e.TaxAmount).HasColumnName("TAX_AMOUNT");

                entity.Property(e => e.TaxLimit).HasColumnName("TAX_LIMIT");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccType>(entity =>
            {
                entity.ToTable("ACC_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Active>(entity =>
            {
                entity.ToTable("ACTIVE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgreementType>(entity =>
            {
                entity.ToTable("agreement_type");

                entity.Property(e => e.AgreementTypeId).HasColumnName("agreement_type_id");

                entity.Property(e => e.AgreementName)
                    .IsRequired()
                    .HasColumnName("agreement_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("AREA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRAND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CounterSale>(entity =>
            {
                entity.ToTable("COUNTER_SALE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.EarnedPoints)
                    .HasColumnName("EARNED_POINTS")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.FlatDiscount)
                    .HasColumnName("FLAT_DISCOUNT")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("GRAND_TOTAL")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.GrossSale)
                    .HasColumnName("GROSS_SALE")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Misc)
                    .HasColumnName("MISC")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.NetAmount)
                    .HasColumnName("NET_AMOUNT")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Return)
                    .HasColumnName("RETURN")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.TotalDiscount)
                    .HasColumnName("TOTAL_DISCOUNT")
                    .HasColumnType("decimal(19, 2)");
            });

            modelBuilder.Entity<CounterSaleDetail>(entity =>
            {
                entity.ToTable("COUNTER_SALE_DETAIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarCode).HasColumnName("BAR_CODE");

                entity.Property(e => e.CounterSaleId).HasColumnName("COUNTER_SALE_ID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.NetTotal)
                    .HasColumnName("NET_TOTAL")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("SALE_PRICE")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("decimal(19, 2)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GoDown>(entity =>
            {
                entity.ToTable("GO_DOWN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.CustomerName).HasColumnName("Customer_Name");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Invoice1)
                    .HasColumnName("Invoice#")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Particulars)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");
            });

            modelBuilder.Entity<ItemBrand>(entity =>
            {
                entity.ToTable("ITEM_BRAND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ITEM_CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnName("HEIGHT");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.Width).HasColumnName("WIDTH");
            });

            modelBuilder.Entity<ItemClass>(entity =>
            {
                entity.ToTable("ITEM_CLASS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItemClass)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ITEM_CLASS_ITEM_CATEGORY");
            });

            modelBuilder.Entity<ItemItems>(entity =>
            {
                entity.ToTable("ITEM_ITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AliasName)
                    .HasColumnName("ALIAS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.ClassId).HasColumnName("CLASS_ID");

                entity.Property(e => e.Discflat).HasColumnName("DISCFLAT");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("ITEM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lockdisc).HasColumnName("LOCKDISC");

                entity.Property(e => e.ManufacturerId).HasColumnName("MANUFACTURER_ID");

                entity.Property(e => e.PurchasePrice).HasColumnName("PURCHASE_PRICE");

                entity.Property(e => e.RecentPurchase).HasColumnName("RECENT_PURCHASE");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnName("SALE_PRICE");

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

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ItemItems)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_ITEMS_MANUFACTURER");
            });

            modelBuilder.Entity<ItemManufacturer>(entity =>
            {
                entity.ToTable("ITEM_MANUFACTURER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telephoneno)
                    .HasColumnName("TELEPHONENO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telephoneno2)
                    .HasColumnName("TELEPHONENO2")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("month");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.MonthName)
                    .HasColumnName("month_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("PARTY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Address1)
                    .HasColumnName("ADDRESS_1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DueDays).HasColumnName("DUE_DAYS");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNo)
                    .HasColumnName("FAX_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("MOBILE_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nic)
                    .HasColumnName("NIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ntn)
                    .HasColumnName("NTN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartyName)
                    .HasColumnName("PARTY_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubAreaId).HasColumnName("SUB_AREA_ID");

                entity.Property(e => e.TaxRegNo)
                    .HasColumnName("TAX_REG_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelPhoneNo)
                    .HasColumnName("TEL_PHONE_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartyOtherContactDetail>(entity =>
            {
                entity.ToTable("PARTY_OTHER_CONTACT_DETAIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CellNo)
                    .HasColumnName("CELL_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeAddress)
                    .HasColumnName("OFFICE_ADDRESS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PARTY_ID");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ResAddress)
                    .HasColumnName("RES_ADDRESS")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartyPriceDetail>(entity =>
            {
                entity.ToTable("PARTY_PRICE_DETAIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("DISCOUNT");

                entity.Property(e => e.Discount2).HasColumnName("DISCOUNT2");

                entity.Property(e => e.Gst).HasColumnName("GST");

                entity.Property(e => e.Gstper2).HasColumnName("GSTPer2");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PARTY_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartyProductDetail>(entity =>
            {
                entity.ToTable("PARTY_PRODUCT_DETAIL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarCode)
                    .HasColumnName("BAR_CODE")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("DISCOUNT");

                entity.Property(e => e.Discper2).HasColumnName("DISCPER2");

                entity.Property(e => e.FlatDiscOnEachQty).HasColumnName("FLAT_DISC_ON_EACH_QTY");

                entity.Property(e => e.Gst)
                    .HasColumnName("GST")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gstper2).HasColumnName("GSTPER2");

                entity.Property(e => e.ItemName)
                    .HasColumnName("ITEM_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PARTY_ID");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnName("SALE_PRICE");
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.ToTable("Payment_Mode");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentMode1)
                    .HasColumnName("Payment_mode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentTerms>(entity =>
            {
                entity.ToTable("Payment_terms");

                entity.Property(e => e.PaymentTerms1)
                    .HasColumnName("Payment_Terms")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentType1)
                    .HasColumnName("PAYMENT_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOpeningPurchase>(entity =>
            {
                entity.ToTable("PURCHASE_OPENING_PURCHASE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccName)
                    .HasColumnName("ACC_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AvgPrice)
                    .HasColumnName("AVG_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Barcode)
                    .HasColumnName("BARCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bonus)
                    .HasColumnName("BONUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BonusQty)
                    .HasColumnName("BONUS_QTY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Disc)
                    .HasColumnName("DISC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscFlatEn)
                    .HasColumnName("DISC_FLAT_EN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscFlatValue)
                    .HasColumnName("DISC_FLAT_VALUE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscPerValue)
                    .HasColumnName("DISC_PER_VALUE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscValue2)
                    .HasColumnName("DISC_VALUE2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Flatdisc)
                    .HasColumnName("FLATDISC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Godown)
                    .HasColumnName("GODOWN")
                    .HasMaxLength(50);

                entity.Property(e => e.GrantTotal)
                    .HasColumnName("GRANT_TOTAL")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Gst)
                    .HasColumnName("GST")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GstValue2)
                    .HasColumnName("GST_VALUE2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gstmode)
                    .HasColumnName("GSTMODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gstval)
                    .HasColumnName("GSTVAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .HasColumnName("ITEMNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LooseQty)
                    .HasColumnName("LOOSE_QTY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Margin)
                    .HasColumnName("MARGIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Markup)
                    .HasColumnName("MARKUP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Misc)
                    .HasColumnName("MISC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Netrate)
                    .HasColumnName("NETRATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purprice)
                    .HasColumnName("PURPRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.QtyPack)
                    .HasColumnName("QTY_PACK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecentPurPrice)
                    .HasColumnName("RECENT_PUR_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saleprice)
                    .HasColumnName("SALEPRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Stock)
                    .HasColumnName("STOCK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("TOTAL_AMOUNT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalIncTax)
                    .HasColumnName("TOTAL_INC_TAX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalQty)
                    .HasColumnName("TOTAL_QTY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalStock)
                    .HasColumnName("TOTAL_STOCK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Totalexctax)
                    .HasColumnName("TOTALEXCTAX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vehicleno)
                    .HasColumnName("VEHICLENO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WithholdingTaxPerc)
                    .HasColumnName("WITHHOLDING_TAX_PERC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrderCateory>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER_CATEORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchasePurchase>(entity =>
            {
                entity.ToTable("PURCHASE_PURCHASE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Approved).HasColumnName("APPROVED");

                entity.Property(e => e.AvgPrice).HasColumnName("AVG_PRICE");

                entity.Property(e => e.Barcode)
                    .HasColumnName("BARCODE")
                    .IsUnicode(false);

                entity.Property(e => e.BonusQty).HasColumnName("BONUS_QTY");

                entity.Property(e => e.BonusQuantity).HasColumnName("BONUS_QUANTITY");

                entity.Property(e => e.BonusValue).HasColumnName("BONUS_VALUE");

                entity.Property(e => e.DescPercValue).HasColumnName("DESC_PERC_VALUE");

                entity.Property(e => e.DiscFlatEn).HasColumnName("DISC_FLAT_EN");

                entity.Property(e => e.DiscFlatValue).HasColumnName("DISC_FLAT_VALUE");

                entity.Property(e => e.DiscFlatValue2).HasColumnName("DISC_FLAT_VALUE2");

                entity.Property(e => e.Discbypercent)
                    .HasColumnName("DISCBYPERCENT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Discbyvalue)
                    .HasColumnName("DISCBYVALUE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Expiry)
                    .HasColumnName("EXPIRY")
                    .HasColumnType("date");

                entity.Property(e => e.GrandTotal).HasColumnName("GRAND_TOTAL");

                entity.Property(e => e.GstValue).HasColumnName("GST_VALUE");

                entity.Property(e => e.GstValue2).HasColumnName("GST_VALUE2");

                entity.Property(e => e.Gstbypercent).HasColumnName("GSTBYPERCENT");

                entity.Property(e => e.Gstbyvalue).HasColumnName("GSTBYVALUE");

                entity.Property(e => e.ItemName)
                    .HasColumnName("ITEM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LooseQty).HasColumnName("LOOSE_QTY");

                entity.Property(e => e.Marginbypercent).HasColumnName("MARGINBYPERCENT");

                entity.Property(e => e.MiscEn).HasColumnName("MISC_EN");

                entity.Property(e => e.NetRate)
                    .HasColumnName("NET_RATE")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.PartyInv)
                    .HasColumnName("PARTY_INV")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartyName)
                    .HasColumnName("PARTY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("PURCHASE_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.QtyPack).HasColumnName("QTY_PACK");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.RecentPurchasePrice).HasColumnName("RECENT_PURCHASE_PRICE");

                entity.Property(e => e.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RetailPrice).HasColumnName("RETAIL_PRICE");

                entity.Property(e => e.SaleDisc)
                    .HasColumnName("SALE_DISC")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("SALE_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalExcTax)
                    .HasColumnName("TOTAL_EXC_TAX")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalExecTax).HasColumnName("TOTAL_EXEC_TAX");

                entity.Property(e => e.TotalIncTax).HasColumnName("TOTAL_INC_TAX");

                entity.Property(e => e.TotalIncludeTax)
                    .HasColumnName("TOTAL_INCLUDE_TAX")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalQty).HasColumnName("TOTAL_QTY");

                entity.Property(e => e.TotalStock).HasColumnName("TOTAL_STOCK");
            });

            modelBuilder.Entity<ReceivedPayments>(entity =>
            {
                entity.ToTable("Received_Payments");

                entity.Property(e => e.CustomerName).HasColumnName("Customer_Name");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.PaymentNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNumber).HasColumnName("Reference_Number");

                entity.Property(e => e.UnusedAmount)
                    .HasColumnName("Unused_Amount")
                    .HasMaxLength(50);

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
                entity.ToTable("rent");

                entity.Property(e => e.RentId).HasColumnName("rent_id");

                entity.Property(e => e.AgreementTypeId).HasColumnName("agreement_type_id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ElectricityBill).HasColumnName("electricity_bill");

                entity.Property(e => e.Maintenance).HasColumnName("maintenance");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.Rent1).HasColumnName("rent");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesMan>(entity =>
            {
                entity.ToTable("SALES_MAN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalesManTypeId).HasColumnName("SALES_MAN_TYPE_ID");
            });

            modelBuilder.Entity<SalesManType>(entity =>
            {
                entity.ToTable("SALES_MAN_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shop");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.AgreementStartDate)
                    .HasColumnName("agreement_start_date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLocation)
                    .IsRequired()
                    .HasColumnName("shop_location")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasColumnName("shop_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShopSize)
                    .IsRequired()
                    .HasColumnName("shop_size")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShopTypeId).HasColumnName("shop_type_id");
            });

            modelBuilder.Entity<ShopType>(entity =>
            {
                entity.ToTable("shop_type");

                entity.Property(e => e.ShopTypeId).HasColumnName("shop_type_id");

                entity.Property(e => e.ShopType1)
                    .IsRequired()
                    .HasColumnName("shop_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.ToTable("SUB_AREA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joining_date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("user_type");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.Property(e => e.UserType1)
                    .HasColumnName("user_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VendorDetails>(entity =>
            {
                entity.ToTable("Vendor_Details");

                entity.Property(e => e.BankDetails)
                    .HasColumnName("Bank_Details")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Business)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Individual)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentTerms)
                    .HasColumnName("Payment_Terms")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salutation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddress)
                    .HasColumnName("Vendor_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorBalance).HasColumnName("Vendor_Balance");

                entity.Property(e => e.VendorName)
                    .HasColumnName("Vendor_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
