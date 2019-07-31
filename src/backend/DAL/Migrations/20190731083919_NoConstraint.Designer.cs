﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AHPContext))]
    [Migration("20190731083919_NoConstraint")]
    partial class NoConstraint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.AlternativeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlternativeName")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<float>("GlobalPriority");

                    b.Property<Guid?>("GoalEntityId");

                    b.Property<Guid>("GoalId");

                    b.HasKey("Id");

                    b.HasIndex("GoalEntityId");

                    b.ToTable("Alternatives");
                });

            modelBuilder.Entity("DAL.CriteriumAlternativeEntity", b =>
                {
                    b.Property<Guid>("CriteriumId");

                    b.Property<Guid>("AlternativeId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<Guid>("Id");

                    b.Property<float>("LocalPriority");

                    b.HasKey("CriteriumId", "AlternativeId");

                    b.HasAlternateKey("AlternativeId", "CriteriumId");

                    b.ToTable("CriteriumAlternatives");
                });

            modelBuilder.Entity("DAL.CriteriumEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CriteriumName")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<float>("GlobalCriteriumPriority");

                    b.Property<Guid?>("GoalEntityId");

                    b.Property<Guid>("GoalId");

                    b.HasKey("Id");

                    b.HasIndex("GoalEntityId");

                    b.ToTable("Criteriums");
                });

            modelBuilder.Entity("DAL.GoalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("GoalName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("DAL.AlternativeEntity", b =>
                {
                    b.HasOne("DAL.GoalEntity", "GoalEntity")
                        .WithMany("Alternatives")
                        .HasForeignKey("GoalEntityId");
                });

            modelBuilder.Entity("DAL.CriteriumAlternativeEntity", b =>
                {
                    b.HasOne("DAL.AlternativeEntity", "AlternativeEntity")
                        .WithMany("CriteriumAlternatives")
                        .HasForeignKey("AlternativeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.CriteriumEntity", "CriteriumEntity")
                        .WithMany("CriteriumAlternatives")
                        .HasForeignKey("CriteriumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.CriteriumEntity", b =>
                {
                    b.HasOne("DAL.GoalEntity", "GoalEntity")
                        .WithMany("Criteriums")
                        .HasForeignKey("GoalEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
