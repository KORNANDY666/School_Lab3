using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using School_Lab3.Models;

namespace School_Lab3.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<SchoolInfo> SchoolInfos { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<SubjectSchool> SubjectSchools { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ANDREAS; Initial Catalog=MySchool;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Class");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FkSchoolSubjectId).HasColumnName("FK_SchoolSubjectId");

                entity.Property(e => e.FkTitleId).HasColumnName("FK_TitleId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.HiredDate).HasColumnType("date");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.PhoneNr).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.FkSchoolSubject)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FkSchoolSubjectId)
                    .HasConstraintName("FK_Employee_SubjectSchool");

                entity.HasOne(d => d.FkTitle)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FkTitleId)
                    .HasConstraintName("FK_Employee_Title");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.DateOfGrade).HasColumnType("date");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.GivenGrade)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_Grade_Employee");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_Grade_Student");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("School");

                entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeId");

                entity.Property(e => e.FkSinfoId).HasColumnName("FK_SInfoId");

                entity.HasOne(d => d.FkGrade)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.FkGradeId)
                    .HasConstraintName("FK_School_Grade");

                entity.HasOne(d => d.FkSinfo)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.FkSinfoId)
                    .HasConstraintName("FK_School_School_Info1");
            });

            modelBuilder.Entity<SchoolInfo>(entity =>
            {
                entity.HasKey(e => e.SchoolInfo1);

                entity.ToTable("School_Info");

                entity.Property(e => e.SchoolInfo1).HasColumnName("SchoolInfo");

                entity.Property(e => e.KindOfSchool)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.PhoneNr).HasMaxLength(15);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<SubjectSchool>(entity =>
            {
                entity.ToTable("SubjectSchool");

                entity.Property(e => e.Lesson)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");

                entity.Property(e => e.WorkTitle).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
