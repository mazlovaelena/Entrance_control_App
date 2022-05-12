using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Entrance_Control_App.Models
{
    public partial class Entrance_ControlContext : DbContext
    {
        public Entrance_ControlContext()
        {
        }

        public Entrance_ControlContext(DbContextOptions<Entrance_ControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Entrance> Entrances { get; set; }
        public virtual DbSet<MonitorDatabase> MonitorDatabases { get; set; }
        public virtual DbSet<PersDapart> PersDaparts { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Turnstile> Turnstiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-G6IA9JI;initial catalog=Entrance_Control; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IdОтдела)
                    .HasName("PK__Отделы__853D46DEE3374A19");

                entity.Property(e => e.IdОтдела).HasColumnName("ID_Отдела");

                entity.Property(e => e.НаименованиеОтдела)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrance>(entity =>
            {
                entity.HasKey(e => e.IdЗапись)
                    .HasName("PK_Доступ");

                entity.ToTable("Entrance");

                entity.Property(e => e.IdЗапись)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Запись");

                entity.Property(e => e.IdПомещения).HasColumnName("ID_Помещения");

                entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");

                entity.Property(e => e.IdСтатус).HasColumnName("ID_Статус");

                entity.Property(e => e.IdТипТурникета).HasColumnName("ID_ТипТурникета");

                entity.Property(e => e.ДатаВхода).HasColumnType("date");

                entity.Property(e => e.ДатаВыхода).HasColumnType("date");

                entity.HasOne(d => d.IdRoom)
                    .WithMany(p => p.Entrances)
                    .HasForeignKey(d => d.IdПомещения)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Доступ__ID_Помещ__20C1E124");

                entity.HasOne(d => d.IdPers)
                    .WithMany(p => p.Entrances)
                    .HasForeignKey(d => d.IdСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Доступ__ID_Сотру__21B6055D");

                entity.HasOne(d => d.IdStat)
                    .WithMany(p => p.Entrances)
                    .HasForeignKey(d => d.IdСтатус)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Доступ__ID_Стату__239E4DCF");

                entity.HasOne(d => d.IdType)
                    .WithMany(p => p.Entrances)
                    .HasForeignKey(d => d.IdТипТурникета)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Доступ__ID_ТипТу__22AA2996");
            });

            modelBuilder.Entity<MonitorDatabase>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.ToTable("Monitor_Database");

                entity.Property(e => e.IdItem).HasColumnName("Id_item");

                entity.Property(e => e.DataModificationRecord).HasColumnType("datetime");

                entity.Property(e => e.Hostname).HasMaxLength(50);

                entity.Property(e => e.IdRecord).HasMaxLength(100);

                entity.Property(e => e.NameColumns).HasMaxLength(50);

                entity.Property(e => e.NameOperation).HasMaxLength(100);

                entity.Property(e => e.NameTable).HasMaxLength(50);

                entity.Property(e => e.NewRecord).HasMaxLength(100);

                entity.Property(e => e.NtUsername)
                    .HasMaxLength(100)
                    .HasColumnName("Nt_username");

                entity.Property(e => e.OldRecord).HasMaxLength(100);
            });

            modelBuilder.Entity<PersDapart>(entity =>
            {
                entity.HasKey(e => new { e.IdСотрудника, e.IdОтдела, e.IdДолжности })
                    .HasName("PK_СотрудникиОтделы");

                entity.ToTable("PersDapart");

                entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");

                entity.Property(e => e.IdОтдела).HasColumnName("ID_Отдела");

                entity.Property(e => e.IdДолжности).HasColumnName("ID_Должности");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PersDaparts)
                    .HasForeignKey(d => d.IdДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_СотрудникиОтделы_Должности");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.PersDaparts)
                    .HasForeignKey(d => d.IdОтдела)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_СотрудникиОтделы_Отделы");

                entity.HasOne(d => d.IPers)
                    .WithMany(p => p.PersDaparts)
                    .HasForeignKey(d => d.IdСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_СотрудникиОтделы_Сотрудники");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdСотрудника)
                    .HasName("PK__Сотрудни__F4052FE30925D646");

                entity.ToTable("Personal");

                entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");

                entity.Property(e => e.ДатаРождения).HasColumnType("date");

                entity.Property(e => e.ИмяСотрудника)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.КорпоративнаяПочта)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ОтчествоСотрудника)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ТелефонМобильный)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ФамилияСотрудника)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.IdДолжности)
                    .HasName("PK__Должност__9A158B47B71F37ED");

                entity.Property(e => e.IdДолжности).HasColumnName("ID_Должности");

                entity.Property(e => e.НаименованиеДолжности)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdПомещения)
                    .HasName("PK__Помещени__DF905A4F6F6216AF");

                entity.Property(e => e.IdПомещения).HasColumnName("ID_Помещения");

                entity.Property(e => e.НаименованиеПомещения)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdСтатус)
                    .HasName("PK__СтатусДо__6460985EFE64F2CE");

                entity.Property(e => e.IdСтатус).HasColumnName("ID_Статус");

                entity.Property(e => e.НаименованиеСтатус)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turnstile>(entity =>
            {
                entity.HasKey(e => e.IdТипТурникета)
                    .HasName("PK__ТипыТурн__1C7B151B04A3DFDB");

                entity.Property(e => e.IdТипТурникета).HasColumnName("ID_ТипТурникета");

                entity.Property(e => e.НаименованиеТипаТурникета)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
