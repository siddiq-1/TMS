using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TMS.Model;
using Task = TMS.Model.Task;

namespace TMS.Data.MODEL
{
    public partial class TaskManagementSystemContext : DbContext
    {
        public TaskManagementSystemContext()
        {
        }

        public TaskManagementSystemContext(DbContextOptions<TaskManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RecurringJob> RecurringJobs { get; set; } = null!;
        public virtual DbSet<ReportTypeMaster> ReportTypeMasters { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ScheduleReport> ScheduleReports { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAssignment> TaskAssignments { get; set; } = null!;
        public virtual DbSet<TaskCategory> TaskCategories { get; set; } = null!;
        public virtual DbSet<TaskStatusMaster> TaskStatusMasters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserManagerMapping> UserManagerMappings { get; set; } = null!;
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TFBH7SV;Initial Catalog=TaskManagementSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecurringJob>(entity =>
            {
                entity.ToTable("RecurringJob");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<ReportTypeMaster>(entity =>
            {
                entity.ToTable("ReportTypeMaster");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Standard')");
            });

            modelBuilder.Entity<ScheduleReport>(entity =>
            {
                entity.ToTable("ScheduleReport");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CronExpression).HasMaxLength(20);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ScheduleTime).HasMaxLength(100);

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ScheduleReports)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_ScheduleReport_ReportTypeMaster");

                entity.HasOne(d => d.RecurringJob)
                    .WithMany(p => p.ScheduleReports)
                    .HasForeignKey(d => d.RecurringJobId)
                    .HasConstraintName("FK_ScheduleReport_RecurringJob");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ScheduleReports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ScheduleReport_User");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.ToTable("TaskAssignment");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.TaskAssignmentAssignedByNavigations)
                    .HasForeignKey(d => d.AssignedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.TaskAssignmentAssignedToNavigations)
                    .HasForeignKey(d => d.AssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TaskAssignments)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_TaskAssignment_TaskCategory");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TaskAssignments)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_TaskAssignment_TaskStatusMaster");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAssignments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskAssignment_Task");
            });

            modelBuilder.Entity<TaskCategory>(entity =>
            {
                entity.ToTable("TaskCategory");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TaskStatusMaster>(entity =>
            {
                entity.ToTable("TaskStatusMaster");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Pending')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AlternateContactNo).HasMaxLength(15);

                entity.Property(e => e.ContactNo).HasMaxLength(15);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'NA')");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'NA')");

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<UserManagerMapping>(entity =>
            {
                entity.ToTable("UserManagerMapping");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ManagerId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserManagerMappings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRoleMapping>(entity =>
            {
                entity.ToTable("UserRoleMapping");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleMappings)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoleMapping_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleMappings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoleMapping_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
