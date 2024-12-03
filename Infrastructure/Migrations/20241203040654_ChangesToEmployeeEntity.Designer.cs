﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTT.CafeManagement.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NTT.CafeManagement.Infrastructure.Migrations
{
    [DbContext(typeof(CafeManagementDbContext))]
    [Migration("20241203040654_ChangesToEmployeeEntity")]
    partial class ChangesToEmployeeEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.Cafe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text")
                        .HasColumnName("logo_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_cafes");

                    b.ToTable("cafes", "public");
                });

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("code");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees", "public");
                });

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.EmployeeCafeAssignment", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_id");

                    b.Property<Guid>("CafeId")
                        .HasColumnType("uuid")
                        .HasColumnName("cafe_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("EmployeeId", "CafeId")
                        .HasName("pk_employee_cafe_assignments");

                    b.HasIndex("CafeId")
                        .HasDatabaseName("ix_employee_cafe_assignments_cafe_id");

                    b.ToTable("employee_cafe_assignments", "public");
                });

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.EmployeeCafeAssignment", b =>
                {
                    b.HasOne("NTT.CafeManagement.Domain.Models.Cafe", "Cafe")
                        .WithMany("EmployeeCafeAssignments")
                        .HasForeignKey("CafeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_employee_cafe_assignments_cafes_cafe_id");

                    b.HasOne("NTT.CafeManagement.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeCafeAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_employee_cafe_assignments_employees_employee_id");

                    b.Navigation("Cafe");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.Cafe", b =>
                {
                    b.Navigation("EmployeeCafeAssignments");
                });

            modelBuilder.Entity("NTT.CafeManagement.Domain.Models.Employee", b =>
                {
                    b.Navigation("EmployeeCafeAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
