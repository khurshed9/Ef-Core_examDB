﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using examdb.DataContext;

#nullable disable

namespace examdb.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241006071334_finish")]
    partial class finish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("examdb.Infrastucture.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("departmentName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("firstName");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("hireDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("lastName");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid")
                        .HasColumnName("managerId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("phone");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("position");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal")
                        .HasColumnName("salary");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("employees", t =>
                        {
                            t.HasCheckConstraint("ValidPhone", "length(phone) >= 10");

                            t.HasCheckConstraint("ValidSalary", "salary > 0");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
