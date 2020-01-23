﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCServ.Context;

namespace PCServ.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200123132420_ServReq")]
    partial class ServReq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("PCServ.Models.ServRequestRepo.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("PCServ.Models.ServRequestRepo.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StuffId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("StuffId");

                    b.ToTable("ServReqs");
                });

            modelBuilder.Entity("PCServ.Models.Ticket.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserTechnicianId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserClientId");

                    b.HasIndex("UserTechnicianId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("PCServ.Models.Ticket.TicketStatusChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserTechnicianId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserTechnicianId");

                    b.ToTable("TicketStatusChange");
                });

            modelBuilder.Entity("PCServ.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PCServ.Models.ServRequestRepo.ServiceRequest", b =>
                {
                    b.HasOne("PCServ.Models.User.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("PCServ.Models.ServRequestRepo.Product", "Stuff")
                        .WithMany()
                        .HasForeignKey("StuffId");
                });

            modelBuilder.Entity("PCServ.Models.Ticket.Ticket", b =>
                {
                    b.HasOne("PCServ.Models.User.User", "UserClient")
                        .WithMany()
                        .HasForeignKey("UserClientId");

                    b.HasOne("PCServ.Models.User.User", "UserTechnician")
                        .WithMany()
                        .HasForeignKey("UserTechnicianId");
                });

            modelBuilder.Entity("PCServ.Models.Ticket.TicketStatusChange", b =>
                {
                    b.HasOne("PCServ.Models.Ticket.Ticket", null)
                        .WithMany("Changes")
                        .HasForeignKey("TicketId");

                    b.HasOne("PCServ.Models.User.User", "UserTechnician")
                        .WithMany()
                        .HasForeignKey("UserTechnicianId");
                });
#pragma warning restore 612, 618
        }
    }
}
