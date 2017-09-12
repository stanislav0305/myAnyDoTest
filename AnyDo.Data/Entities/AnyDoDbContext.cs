using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnyDo.Data.Entities
{
    public partial class AnyDoDbContext : DbContext
    {
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Preferences> Preferences { get; set; }
        public virtual DbSet<SubTask> SubTask { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskCategory> TaskCategory { get; set; }

        public AnyDoDbContext(DbContextOptions<AnyDoDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer(@"Data Source=STAS-PC\SQLEXPRESS;Initial Catalog=AnyDoDb;Integrated Security=False;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.FileNameFull)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attachments_Tasks");
            });

            modelBuilder.Entity<Preferences>(entity =>
            {
                entity.Property(e => e.DateFormat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeFormat)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SubTask>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modefied).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.SubTask)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubTasks_Tasks");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.AttachmentCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.MakeUpTo).HasColumnType("datetime");

                entity.Property(e => e.Modefied).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SubTaskCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.TaskCategory)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TaskCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_TaskCategories");
            });

            modelBuilder.Entity<TaskCategory>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modefied).HasColumnType("datetime");

                entity.Property(e => e.TaskCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
