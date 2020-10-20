using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InlTrmWeb.Models
{
    public partial class INLTRMContext : DbContext
    {
        public INLTRMContext()
        {
        }

        public INLTRMContext(DbContextOptions<INLTRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<CostTypes> CostTypes { get; set; }
        public virtual DbSet<Costs> Costs { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=INLTRM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => e.AttachId)
                    .HasName("PK__ATTACHME__9BF4538E56D90A81");

                entity.ToTable("ATTACHMENTS");

                entity.Property(e => e.AttachId).HasColumnName("ATTACH_ID");

                entity.Property(e => e.Created)
                    .HasColumnName("CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("FILE")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<CostTypes>(entity =>
            {
                entity.HasKey(e => e.CostTypeId)
                    .HasName("PK__COST_TYP__9884E23AFE16C417");

                entity.ToTable("COST_TYPES");

                entity.Property(e => e.CostTypeId).HasColumnName("COST_TYPE_ID");

                entity.Property(e => e.CostName)
                    .IsRequired()
                    .HasColumnName("COST_NAME")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Costs>(entity =>
            {
                entity.HasKey(e => e.CostId)
                    .HasName("PK__COSTS__D03B59DB34E3EA7F");

                entity.ToTable("COSTS");

                entity.Property(e => e.CostId).HasColumnName("COST_ID");

                entity.Property(e => e.AttachId).HasColumnName("ATTACH_ID");

                entity.Property(e => e.CostAmount)
                    .HasColumnName("COST_AMOUNT")
                    .HasColumnType("numeric(28, 6)");

                entity.Property(e => e.CostDate)
                    .HasColumnName("COST_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CostDescription)
                    .IsRequired()
                    .HasColumnName("COST_DESCRIPTION")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CostEmpId).HasColumnName("COST_EMP_ID");

                entity.Property(e => e.CostTypeId).HasColumnName("COST_TYPE_ID");

                entity.Property(e => e.Created)
                    .HasColumnName("CREATED")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Attach)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.AttachId)
                    .HasConstraintName("FK__COSTS__ATTACH_ID__693CA210");

                entity.HasOne(d => d.CostEmp)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CostEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COSTS__COST_EMP___6A30C649");

                entity.HasOne(d => d.CostType)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CostTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COSTS__COST_TYPE__6B24EA82");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__EMPLOYEE__16EBFA26BCB23243");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AuthLevel).HasColumnName("AUTH_LEVEL");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONE_NUMBER")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
