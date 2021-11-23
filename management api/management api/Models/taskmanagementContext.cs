using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace management_api.Models
{
    public partial class taskmanagementContext : DbContext
    {
        public taskmanagementContext()
        {
        }

        public taskmanagementContext(DbContextOptions<taskmanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projectdetail> Projectdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server = JBMAC056\\SQLEXPRESS; initial catalog = taskmanagement;integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Projectdetail>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__projectd__BC799E1FEAF577F6");

                entity.ToTable("projectdetail");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ApiEndDate)
                    .HasColumnType("date")
                    .HasColumnName("api_end_date");

                entity.Property(e => e.ApiStartDate)
                    .HasColumnType("date")
                    .HasColumnName("api_start_date");

                entity.Property(e => e.ApiTasksPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("api_tasks_percent");

                entity.Property(e => e.DbEndDate)
                    .HasColumnType("date")
                    .HasColumnName("db_end_date");

                entity.Property(e => e.DbStartDate)
                    .HasColumnType("date")
                    .HasColumnName("db_start_date");

                entity.Property(e => e.DbTasksPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("db_tasks_percent");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duration");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.ProjectName)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate");

                entity.Property(e => e.TestingEndDate)
                    .HasColumnType("date")
                    .HasColumnName("testing_end_date");

                entity.Property(e => e.TestingStartDate)
                    .HasColumnType("date")
                    .HasColumnName("testing_start_date");

                entity.Property(e => e.TestingTasksPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("testing_tasks_percent");

                entity.Property(e => e.UiEndDate)
                    .HasColumnType("date")
                    .HasColumnName("ui_end_date");

                entity.Property(e => e.UiStartDate)
                    .HasColumnType("date")
                    .HasColumnName("ui_start_date");

                entity.Property(e => e.UiTasksPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ui_tasks_percent");

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
