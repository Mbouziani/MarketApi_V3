using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketApi_V3.Models
{
    public partial class MarketManagementV2DBContext : DbContext
    {
        public MarketManagementV2DBContext()
        {
        }

        public MarketManagementV2DBContext(DbContextOptions<MarketManagementV2DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<Branche> Branches { get; set; } = null!;
       
        public virtual DbSet<Company> Companies { get; set; } = null!; 
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Reciep> Recieps { get; set; } = null!;
        public virtual DbSet<Returne> Returnes { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Salereturned> Salereturneds { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Zone> Zones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.AgentId).HasColumnName("agentId");

                entity.Property(e => e.AgentAccountNumber).HasColumnName("agentAccountNumber");

                entity.Property(e => e.AgentAddress)
                    .HasMaxLength(50)
                    .HasColumnName("agentAddress");

                entity.Property(e => e.AgentEmail)
                    .HasMaxLength(50)
                    .HasColumnName("agentEmail");

                entity.Property(e => e.AgentMobile)
                    .HasMaxLength(50)
                    .HasColumnName("agentMobile");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(50)
                    .HasColumnName("agentName");

                entity.Property(e => e.AgentPercentDiscount).HasColumnName("agentPercentDiscount");

                entity.Property(e => e.AgentTele)
                    .HasMaxLength(50)
                    .HasColumnName("agentTele");

                entity.Property(e => e.AgentVatNumber)
                    .HasMaxLength(50)
                    .HasColumnName("agentVatNumber");
            });

            modelBuilder.Entity<Branche>(entity =>
            {
                entity.ToTable("branche");

                entity.Property(e => e.BrancheId).HasColumnName("brancheID");

                entity.Property(e => e.BrancheAddress)
                    .HasMaxLength(500)
                    .HasColumnName("brancheAddress");

                entity.Property(e => e.BrancheDirector)
                    .HasMaxLength(250)
                    .HasColumnName("brancheDirector");

                entity.Property(e => e.BrancheName)
                    .HasMaxLength(250)
                    .HasColumnName("brancheName");

                entity.Property(e => e.BrancheNumber).HasColumnName("brancheNumber");

                entity.Property(e => e.BranchePhone)
                    .HasMaxLength(20)
                    .HasColumnName("branchePhone");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__branche__company__787EE5A0");
            });

      
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(500)
                    .HasColumnName("companyAddress");

                entity.Property(e => e.CompanyCommercial)
                    .HasMaxLength(100)
                    .HasColumnName("companyCommercial");

                entity.Property(e => e.CompanyFractionDigits).HasDefaultValueSql("((2))");

                entity.Property(e => e.CompanyLink)
                    .HasMaxLength(300)
                    .HasColumnName("companyLink");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(250)
                    .HasColumnName("companyName");

                entity.Property(e => e.CompanyNumber).HasColumnName("companyNumber");

                entity.Property(e => e.CompanyPhone)
                    .HasMaxLength(20)
                    .HasColumnName("companyPhone");

                entity.Property(e => e.CompanyTaxNumber)
                    .HasMaxLength(100)
                    .HasColumnName("companyTaxNumber");

                entity.Property(e => e.CompanyZoneCount).HasColumnName("companyZoneCount");
            });

       
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ProductActiveStatus).HasColumnName("productActiveStatus");

                entity.Property(e => e.ProductBarcode)
                    .HasMaxLength(50)
                    .HasColumnName("productBarcode");

                entity.Property(e => e.ProductImageLink)
                    .HasMaxLength(700)
                    .HasColumnName("productImageLink");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(200)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice).HasColumnName("productPrice");

                entity.Property(e => e.ProductTypeProduct)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("productTypeProduct");

                entity.Property(e => e.ProductTypeSize)
                    .HasMaxLength(50)
                    .HasColumnName("productTypeSize");

                entity.Property(e => e.ProductZone).HasColumnName("productZone");
            });

            modelBuilder.Entity<Reciep>(entity =>
            {
                entity.ToTable("reciep");

                entity.Property(e => e.ReciepId).HasColumnName("reciepID");

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.ReciepAgentName)
                    .HasMaxLength(200)
                    .HasColumnName("reciepAgentName");

                entity.Property(e => e.ReciepAgentNumber).HasColumnName("reciepAgentNumber");

                entity.Property(e => e.ReciepCloseCashier)
                    .HasColumnName("reciepCloseCashier")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciepDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reciepDate");

                entity.Property(e => e.ReciepNumber).HasColumnName("reciepNumber");

                entity.Property(e => e.ReciepPaymentMethode)
                    .HasMaxLength(50)
                    .HasColumnName("reciepPaymentMethode");

                entity.Property(e => e.ReciepPaymentPrice).HasColumnName("reciepPaymentPrice");

                entity.Property(e => e.ReciepPercDiscount).HasColumnName("reciepPercDiscount");

                entity.Property(e => e.ReciepPriceTax).HasColumnName("reciepPriceTax");

                entity.Property(e => e.ReciepPriceTotalWithTax).HasColumnName("reciepPriceTotalWithTax");

                entity.Property(e => e.ReciepProductCount).HasColumnName("reciepProductCount");

                entity.Property(e => e.ReciepTotalPrice).HasColumnName("reciepTotalPrice");

                entity.Property(e => e.ReciepTotalWithDiscount).HasColumnName("reciepTotalWithDiscount");

                entity.Property(e => e.ReciepVatNumber)
                    .HasMaxLength(50)
                    .HasColumnName("reciepVatNumber");

                entity.Property(e => e.ReciepZoneNumber).HasColumnName("reciepZoneNumber");

                entity.Property(e => e.ZoneId).HasColumnName("zoneID");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Recieps)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("fk_branchID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Recieps)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_companyID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Recieps)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("fk_zoneID");
            });

            modelBuilder.Entity<Returne>(entity =>
            {
                entity.HasKey(e => e.ReturnId)
                    .HasName("PK_reciepreturned");

                entity.ToTable("returne");

                entity.Property(e => e.ReturnId).HasColumnName("ReturnID");

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.ReturnAgentName).HasMaxLength(200);

                entity.Property(e => e.ReturnCloseCashier).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnPaymentMethode).HasMaxLength(50);

                entity.Property(e => e.ReturnReciepDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnVatNumber).HasMaxLength(50);

                entity.Property(e => e.ZoneId).HasColumnName("zoneID");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Returnes)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("fk_branchID_rt");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Returnes)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_companyID_rt");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Returnes)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("fk_zoneID_rt");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.Property(e => e.SaleId).HasColumnName("saleID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ReciepId).HasColumnName("reciepID");

                entity.Property(e => e.SaleProductName)
                    .HasMaxLength(150)
                    .HasColumnName("saleProductName");

                entity.Property(e => e.SaleProductTypeSize)
                    .HasMaxLength(50)
                    .HasColumnName("saleProductTypeSize");

                entity.Property(e => e.SaleQuntity).HasColumnName("saleQuntity");

                entity.Property(e => e.SaleReciepNumber).HasColumnName("saleReciepNumber");

                entity.Property(e => e.SaleTotalPrice).HasColumnName("saleTotalPrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__sale__productID__5165187F");

                entity.HasOne(d => d.Reciep)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ReciepId)
                    .HasConstraintName("FK__sale__reciepID__52593CB8");
            });

            modelBuilder.Entity<Salereturned>(entity =>
            {
                entity.HasKey(e => e.RsaleId)
                    .HasName("PK__saleretu__FAE8F5153DBC2610");

                entity.ToTable("salereturned");

                entity.Property(e => e.RsaleId).HasColumnName("rsaleID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ReturnId).HasColumnName("ReturnID");

                entity.Property(e => e.RsaleProductName)
                    .HasMaxLength(150)
                    .HasColumnName("rsaleProductName");

                entity.Property(e => e.RsaleProductTypeSize)
                    .HasMaxLength(50)
                    .HasColumnName("rsaleProductTypeSize");

                entity.Property(e => e.RsaleQuntity).HasColumnName("rsaleQuntity");

                entity.Property(e => e.RsaleReturnNumber).HasColumnName("rsaleReturnNumber");

                entity.Property(e => e.RsaleTotalPrice).HasColumnName("rsaleTotalPrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Salereturneds)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__saleretur__produ__571DF1D5");

                entity.HasOne(d => d.Return)
                    .WithMany(p => p.Salereturneds)
                    .HasForeignKey(d => d.ReturnId)
                    .HasConstraintName("FK__saleretur__retur__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserAge)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userAge");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserNumberLogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userNumberLogin");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userPhone");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("zone");

                entity.Property(e => e.ZoneId).HasColumnName("zoneID");

                entity.Property(e => e.BrancheId).HasColumnName("brancheID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.ZoneAddress)
                    .HasMaxLength(500)
                    .HasColumnName("zoneAddress");

                entity.Property(e => e.ZoneDirector)
                    .HasMaxLength(250)
                    .HasColumnName("zoneDirector");

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(250)
                    .HasColumnName("zoneName");

                entity.Property(e => e.ZoneNumber).HasColumnName("zoneNumber");

                entity.Property(e => e.ZonePhone)
                    .HasMaxLength(20)
                    .HasColumnName("zonePhone");

                entity.Property(e => e.ZoneTax).HasColumnName("zoneTax");

                entity.Property(e => e.ZoneType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("zoneType");

                entity.HasOne(d => d.Branche)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.BrancheId)
                    .HasConstraintName("FK__zone__brancheID__7E37BEF6");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__zone__companyID__7F2BE32F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
