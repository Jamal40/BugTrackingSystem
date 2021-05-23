﻿// <auto-generated />
using System;
using BugTrackingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugTrackingSystem.Migrations
{
    [DbContext(typeof(BugTrackerDbContext))]
    [Migration("20210427014746_AddingConstraint")]
    partial class AddingConstraint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugTrackingSystem.Models.BugTrackerUser", b =>
                {
                    b.Property<string>("BugTrackerUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("BugTrackerUserID");

                    b.HasIndex("ProjectID");

                    b.ToTable("BugTrackerUsers");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManagerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("TicketID");

                    b.HasIndex("DeveloperID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.BugTrackerUser", b =>
                {
                    b.HasOne("BugTrackingSystem.Models.Project", null)
                        .WithMany("Developers")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.Project", b =>
                {
                    b.HasOne("BugTrackingSystem.Models.BugTrackerUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.Ticket", b =>
                {
                    b.HasOne("BugTrackingSystem.Models.BugTrackerUser", "Developer")
                        .WithMany("Tickets")
                        .HasForeignKey("DeveloperID");

                    b.HasOne("BugTrackingSystem.Models.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.BugTrackerUser", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BugTrackingSystem.Models.Project", b =>
                {
                    b.Navigation("Developers");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}