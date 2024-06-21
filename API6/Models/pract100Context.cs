using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API6.Models
{
    public partial class pract100Context : DbContext
    {
        public pract100Context()
        {
        }

        public pract100Context(DbContextOptions<pract100Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AnalysDocument> AnalysDocuments { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; } = null!;
        public virtual DbSet<Direction> Directions { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Admin___4C3F97F4A8C067BF");

                entity.ToTable("Admin_");

                entity.Property(e => e.EnterPassword).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name_");

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<AnalysDocument>(entity =>
            {
                entity.HasKey(e => e.Analysid)
                    .HasName("PK__AnalysDo__D4B74D035A291890");

                entity.ToTable("AnalysDocument");

                entity.Property(e => e.Analysid).HasColumnName("analysid");

                
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__ECE24AAB443B3E55");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.Oms).HasColumnName("OMS");

                
            });

            modelBuilder.Entity<AppointmentDocument>(entity =>
            {
                entity.HasKey(e => e.Appid)
                    .HasName("PK__Appointm__C00F024DC61ABCA0");

                entity.ToTable("AppointmentDocument");

                entity.Property(e => e.Appid).HasColumnName("appid");

               
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.IdDirection)
                    .HasName("PK__Directio__7780E2B27A29CAE3");

                entity.Property(e => e.Oms).HasColumnName("OMS");

                

               
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__F838DB3EEFDD5599");

                entity.ToTable("Doctor");

                entity.Property(e => e.EnterPassword).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name_");

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.WorkAdderss).HasMaxLength(50);

                
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Oms)
                    .HasName("PK__Patient__CB396B8B33C31E25");

                entity.ToTable("Patient");

                entity.Property(e => e.Oms)
                    .ValueGeneratedNever()
                    .HasColumnName("OMS");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("Address_");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LivingAddress).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name_");

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(18);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<ResearchDocument>(entity =>
            {
                entity.HasKey(e => e.Reserchdocid)
                    .HasName("PK__Research__D4C56C9255B5CBF1");

                entity.ToTable("ResearchDocument");

                entity.Property(e => e.Reserchdocid).HasColumnName("reserchdocid");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(1)
                    .IsFixedLength();

                
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.IdSpeciality)
                    .HasName("PK__Speciali__5C8D4E68768ED727");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name_");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Status___B450643A0132B36B");

                entity.ToTable("Status_");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name_");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
