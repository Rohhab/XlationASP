﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XlationASP.Data;

#nullable disable

namespace XlationASP.Migrations
{
    [DbContext(typeof(DomainDbContext))]
    [Migration("20250125140328_AddEmailToXlator")]
    partial class AddEmailToXlator
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XlationASP.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint");

                    b.Property<int>("NoOfPages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("XlationAgreementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("XlationAgreementId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("XlationASP.Models.Genre", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("XlationASP.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<short>("DiscountRate")
                        .HasColumnType("smallint");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SignUpFee")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("MembershipType");
                });

            modelBuilder.Entity("XlationASP.Models.XlationAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("AgreementDuration")
                        .HasColumnType("time");

                    b.Property<DateTime>("DateOfAgreement")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("XlationAgreement");
                });

            modelBuilder.Entity("XlationASP.Models.Xlator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSubscribedToNewsLetter")
                        .HasColumnType("bit");

                    b.Property<byte>("MembershipTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("XlationAgreementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.HasIndex("XlationAgreementId");

                    b.ToTable("Xlators");
                });

            modelBuilder.Entity("XlationASP.Models.Book", b =>
                {
                    b.HasOne("XlationASP.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XlationASP.Models.XlationAgreement", null)
                        .WithMany("Books")
                        .HasForeignKey("XlationAgreementId");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("XlationASP.Models.Xlator", b =>
                {
                    b.HasOne("XlationASP.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XlationASP.Models.XlationAgreement", null)
                        .WithMany("Xlators")
                        .HasForeignKey("XlationAgreementId");

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("XlationASP.Models.XlationAgreement", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Xlators");
                });
#pragma warning restore 612, 618
        }
    }
}
