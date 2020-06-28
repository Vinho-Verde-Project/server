﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    [DbContext(typeof(AdmContext))]
    [Migration("20200628155939_CorrectStepProduct")]
    partial class CorrectStepProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Characteristics")
                        .IsRequired()
                        .HasColumnName("characteristics")
                        .HasColumnType("text");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnName("desc")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnName("adress")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnName("birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnName("hashed_password")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnName("nif")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_employee");

                    b.HasIndex("RoleId")
                        .HasName("ix_employee_role_id");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("Api.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnName("desc")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_permission");

                    b.ToTable("permission");
                });

            modelBuilder.Entity("Api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("integer");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnName("desc")
                        .HasColumnType("text");

                    b.Property<int?>("StepId")
                        .HasColumnName("step_id")
                        .HasColumnType("integer");

                    b.Property<int>("StockId")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("CategoryId")
                        .HasName("ix_product_category_id");

                    b.HasIndex("StepId")
                        .HasName("ix_product_step_id");

                    b.HasIndex("StockId")
                        .HasName("ix_product_stock_id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnName("desc")
                        .HasColumnType("text");

                    b.Property<int>("PermissionId")
                        .HasColumnName("permission_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_role");

                    b.HasIndex("PermissionId")
                        .HasName("ix_role_permission_id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Api.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnName("desc")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnName("ended_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnName("started_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("text");

                    b.Property<int>("TaskId")
                        .HasColumnName("task_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_step");

                    b.HasIndex("EmployeeId")
                        .HasName("ix_step_employee_id");

                    b.HasIndex("TaskId")
                        .HasName("ix_step_task_id");

                    b.ToTable("step");
                });

            modelBuilder.Entity("Api.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnName("entry_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("double precision");

                    b.Property<string>("Warehouse")
                        .IsRequired()
                        .HasColumnName("warehouse")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_stock");

                    b.HasIndex("EmployeeId")
                        .HasName("ix_stock_employee_id");

                    b.ToTable("stock");
                });

            modelBuilder.Entity("Api.Models.StockProduct", b =>
                {
                    b.Property<int>("StockId")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("integer");

                    b.Property<double>("MinQantity")
                        .HasColumnName("min_qantity")
                        .HasColumnType("double precision");

                    b.HasKey("StockId", "ProductId")
                        .HasName("pk_stock_product");

                    b.HasIndex("ProductId")
                        .HasName("ix_stock_product_product_id");

                    b.ToTable("stock_product");
                });

            modelBuilder.Entity("Api.Models.StockWine", b =>
                {
                    b.Property<int>("StockId")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.Property<int>("WineId")
                        .HasColumnName("wine_id")
                        .HasColumnType("integer");

                    b.HasKey("StockId", "WineId")
                        .HasName("pk_stock_wine");

                    b.HasIndex("WineId")
                        .HasName("ix_stock_wine_wine_id");

                    b.ToTable("stock_wine");
                });

            modelBuilder.Entity("Api.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndedAt")
                        .HasColumnName("ended_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnName("started_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_task");

                    b.ToTable("task");
                });

            modelBuilder.Entity("Api.Models.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnName("batch")
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("integer");

                    b.Property<string>("ProductionDate")
                        .IsRequired()
                        .HasColumnName("production_date")
                        .HasColumnType("text");

                    b.Property<string>("ShelfLife")
                        .IsRequired()
                        .HasColumnName("shelf_life")
                        .HasColumnType("text");

                    b.Property<int>("TaskId")
                        .HasColumnName("task_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_wine");

                    b.HasIndex("CategoryId")
                        .HasName("ix_wine_category_id");

                    b.HasIndex("TaskId")
                        .HasName("ix_wine_task_id");

                    b.ToTable("wine");
                });

            modelBuilder.Entity("Api.Models.Employee", b =>
                {
                    b.HasOne("Api.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_employee_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Product", b =>
                {
                    b.HasOne("Api.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Step", null)
                        .WithMany("Products")
                        .HasForeignKey("StepId")
                        .HasConstraintName("fk_product_step_step_id");

                    b.HasOne("Api.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .HasConstraintName("fk_product_stock_stock_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.HasOne("Api.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("fk_role_permission_permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Step", b =>
                {
                    b.HasOne("Api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("fk_step_employee_employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .HasConstraintName("fk_step_task_task_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Stock", b =>
                {
                    b.HasOne("Api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("fk_stock_employee_employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.StockProduct", b =>
                {
                    b.HasOne("Api.Models.Product", "Product")
                        .WithMany("StockProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_stock_product_product_product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Stock", "Stock")
                        .WithMany("StockProducts")
                        .HasForeignKey("StockId")
                        .HasConstraintName("fk_stock_product_stock_stock_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.StockWine", b =>
                {
                    b.HasOne("Api.Models.Stock", "Stock")
                        .WithMany("StockWines")
                        .HasForeignKey("StockId")
                        .HasConstraintName("fk_stock_wine_stock_stock_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Wine", "Wine")
                        .WithMany("StockWines")
                        .HasForeignKey("WineId")
                        .HasConstraintName("fk_stock_wine_wine_wine_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Wine", b =>
                {
                    b.HasOne("Api.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_wine_category_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .HasConstraintName("fk_wine_task_task_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
