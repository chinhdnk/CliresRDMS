using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Entities.ProjectsDB
{
    public partial class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {
        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCrf> TblCrfs { get; set; }
        public virtual DbSet<TblField> TblFields { get; set; }
        public virtual DbSet<TblSite> TblSites { get; set; }
        public virtual DbSet<TblStudyCode> TblStudyCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCrf>(entity =>
            {
                entity.HasKey(e => e.Crfid)
                    .HasName("PK_tblCRFs_1");

                entity.ToTable("tblCRFs");

                entity.Property(e => e.Crfid)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("crfid");

                entity.Property(e => e.Crfformat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("crfformat");

                entity.Property(e => e.Crforder).HasColumnName("crforder");

                entity.Property(e => e.Entrymode).HasColumnName("entrymode");

                entity.Property(e => e.Isrepeat).HasColumnName("isrepeat");

                entity.Property(e => e.Keyfields)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("keyfields");

                entity.Property(e => e.Needcustom)
                    .HasColumnName("needcustom")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Relativecrf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("relativecrf");
            });

            modelBuilder.Entity<TblField>(entity =>
            {
                entity.HasKey(e => new { e.Crfid, e.Questionid });

                entity.ToTable("tblFields");

                entity.Property(e => e.Crfid)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("crfid");

                entity.Property(e => e.Questionid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("questionid");

                entity.Property(e => e.Blind).HasColumnName("blind");

                entity.Property(e => e.Category)
                    .HasMaxLength(25)
                    .HasColumnName("category");

                entity.Property(e => e.Controltype)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("controltype");

                entity.Property(e => e.Defaultvalue)
                    .HasMaxLength(250)
                    .HasColumnName("defaultvalue");

                entity.Property(e => e.Defunit)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("defunit");

                entity.Property(e => e.Ectrlwidth).HasColumnName("ectrlwidth");

                entity.Property(e => e.Elabelwidth).HasColumnName("elabelwidth");

                entity.Property(e => e.Esection)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("esection");

                entity.Property(e => e.Estyle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("estyle");

                entity.Property(e => e.Gridname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gridname");

                entity.Property(e => e.Gridorder).HasColumnName("gridorder");

                entity.Property(e => e.Height)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("height");

                entity.Property(e => e.Ispk).HasColumnName("ispk");

                entity.Property(e => e.Isrequired)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("isrequired");

                entity.Property(e => e.Lines)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lines");

                entity.Property(e => e.Maxvalue)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("maxvalue");

                entity.Property(e => e.Minvalue)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("minvalue");

                entity.Property(e => e.Page)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("page");

                entity.Property(e => e.Pctrlwidth).HasColumnName("pctrlwidth");

                entity.Property(e => e.Pformat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pformat");

                entity.Property(e => e.Plabelwidth).HasColumnName("plabelwidth");

                entity.Property(e => e.Pstyle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("pstyle");

                entity.Property(e => e.Qn0)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("qn0");

                entity.Property(e => e.Qorder).HasColumnName("qorder");

                entity.Property(e => e.Splitrow).HasColumnName("splitrow");

                entity.Property(e => e.Submissionvalue)
                    .HasMaxLength(250)
                    .HasColumnName("submissionvalue");

                entity.Property(e => e.Tags)
                    .HasMaxLength(2500)
                    .HasColumnName("tags");

                entity.Property(e => e.VariableName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("variableName");
            });

            modelBuilder.Entity<TblSite>(entity =>
            {
                entity.HasKey(e => e.SiteCode);

                entity.ToTable("tblSites");

                entity.Property(e => e.SiteCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(2500);
            });

            modelBuilder.Entity<TblStudyCode>(entity =>
            {
                entity.HasKey(e => e.Studycode);

                entity.ToTable("tblStudyCodes");

                entity.Property(e => e.Studycode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("studycode");

                entity.Property(e => e.Addedby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("addedby");

                entity.Property(e => e.Batchid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("batchid");

                entity.Property(e => e.Enrolldate)
                    .HasColumnType("datetime")
                    .HasColumnName("enrolldate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Freezed).HasColumnName("freezed");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
