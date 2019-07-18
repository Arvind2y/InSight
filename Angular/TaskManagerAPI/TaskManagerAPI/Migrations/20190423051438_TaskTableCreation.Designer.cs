﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Migrations
{
    [DbContext(typeof(TaskDetailsContext))]
    [Migration("20190423051438_TaskTableCreation")]
    partial class TaskTableCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagerAPI.Models.TaskDetail", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ParentTask");

                    b.Property<int>("Priority");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("TaskId");

                    b.ToTable("TaskDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
