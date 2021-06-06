using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class CliresSystemDBContext : DbContext
    {
        public CliresSystemDBContext()
        {
        }

        public CliresSystemDBContext(DbContextOptions<CliresSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccessLog> TblAccessLogs { get; set; }
        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblGroup> TblGroups { get; set; }
        public virtual DbSet<TblGroupPermission> TblGroupPermissions { get; set; }
        public virtual DbSet<TblMenu> TblMenus { get; set; }
        public virtual DbSet<TblPasswordHistory> TblPasswordHistories { get; set; }
        public virtual DbSet<TblPermission> TblPermissions { get; set; }
        public virtual DbSet<TblSignUp> TblSignUps { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserGroup> TblUserGroups { get; set; }
        public virtual DbSet<TblUserPermission> TblUserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAccessLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("tblAccessLog");

                entity.Property(e => e.LogId)
                    .ValueGeneratedNever()
                    .HasColumnName("log_id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ip");

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasColumnName("log_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("tblAccount");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expired_date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("full_name");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.OnLogin).HasColumnName("on_login");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("password_date");

                entity.Property(e => e.ResetPwDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_pw_date");

                entity.Property(e => e.ResetPwKey)
                    .HasMaxLength(99)
                    .HasColumnName("reset_pw_key");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("salt");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.WrongTime).HasColumnName("wrong_time");
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("tblGroup");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<TblGroupPermission>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PermId });

                entity.ToTable("tblGroup_Permission");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("perm_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_Permission_tblGroup");

                entity.HasOne(d => d.Perm)
                    .WithMany(p => p.TblGroupPermissions)
                    .HasForeignKey(d => d.PermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGroup_Permission_tblPermission");
            });

            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("tblMenu");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(N'chinhdnk')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(((5)-(31))-(2021))");

                entity.Property(e => e.Icon)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("icon");

                entity.Property(e => e.Link)
                    .HasMaxLength(500)
                    .HasColumnName("link");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(250)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<TblPasswordHistory>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.CreatedDate });

                entity.ToTable("tblPasswordHistory");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.TblPasswordHistories)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPasswordHistory_tblUser");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => e.PermId);

                entity.ToTable("tblPermission");

                entity.Property(e => e.PermId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("perm_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("('chinhdnk')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(((5)-(31))-(2021))");

                entity.Property(e => e.Menu).HasColumnName("menu");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.MenuNavigation)
                    .WithMany(p => p.TblPermissions)
                    .HasForeignKey(d => d.Menu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPermission_tblMenu");
            });

            modelBuilder.Entity<TblSignUp>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("tblSignUp");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.City)
                    .HasMaxLength(250)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("full_name");

                entity.Property(e => e.Institution)
                    .HasMaxLength(500)
                    .HasColumnName("institution");

                entity.Property(e => e.MPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("m_phone");

                entity.Property(e => e.OPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("o_phone");

                entity.Property(e => e.RegDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reg_date");

                entity.Property(e => e.RegProject)
                    .HasMaxLength(500)
                    .HasColumnName("reg_project");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("tblUser");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.City)
                    .HasMaxLength(250)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.ESignature)
                    .IsUnicode(false)
                    .HasColumnName("e_signature");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("full_name");

                entity.Property(e => e.Institution)
                    .HasMaxLength(500)
                    .HasColumnName("institution");

                entity.Property(e => e.MPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("m_phone");

                entity.Property(e => e.OPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("o_phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblUserGroup>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.GroupId });

                entity.ToTable("tblUser_Group");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Group_tblGroup");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.TblUserGroups)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Group_tblUser");
            });

            modelBuilder.Entity<TblUserPermission>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.PermId });

                entity.ToTable("tblUser_Permission");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.PermId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("perm_id");

                entity.HasOne(d => d.Perm)
                    .WithMany(p => p.TblUserPermissions)
                    .HasForeignKey(d => d.PermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Permission_tblPermission");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.TblUserPermissions)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Permission_tblUser_Permission");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
