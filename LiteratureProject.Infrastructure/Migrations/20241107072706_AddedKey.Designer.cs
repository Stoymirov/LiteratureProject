﻿// <auto-generated />
using System;
using LiteratureProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107072706_AddedKey")]
    partial class AddedKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiteratureProject.Data.Models.LiteratureWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("LiteratureWorks");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            IsDeleted = false,
                            Name = "Балкански синдром"
                        },
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            IsDeleted = false,
                            Name = "Железният Светилник"
                        });
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.AnalysisPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("LiteratureWorkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasComment("This is to show what kind of analysis part we are looking at. If it shows the topics, themes, etc.");

                    b.HasKey("Id");

                    b.HasIndex("LiteratureWorkId");

                    b.ToTable("AnalysisParts");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Content = "За една пиеса",
                            LiteratureWorkId = 3,
                            Name = "Име на творбата",
                            Type = 0
                        },
                        new
                        {
                            Id = 1,
                            Content = "Написана вчера",
                            LiteratureWorkId = 3,
                            Name = "История на Творбата",
                            Type = 3
                        });
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "587a3d44-9d0a-402c-a49d-8f8d198a7818",
                            Email = "teacher@mail.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "teacher@mail.com",
                            NormalizedUserName = "teacher@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEBSo2VUsve1MNZDZtHQw/d10htALzWew+8JKaMueKMZihqJolKs2TTJxQ+IL7EhI2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6a7fd7ed-e25e-40dc-8d6e-e4cb8b502411",
                            TwoFactorEnabled = false,
                            UserName = "teacher@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f03d79b6-29ca-4267-bdb3-42da461898f3",
                            Email = "student@mail.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "student@mail.com",
                            NormalizedUserName = "student@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEBQ/RJ+wOruwnyF0m79ECFLyTRRBwkHXmCvmSo6mDP0UsD9g2PtwPAeNOJM7jhBWCA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ec37c78c-6ef4-4e7b-96e4-fff210b15570",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Иван Вазов"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Алеко Константинов"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Станислав Стратиев"
                        });
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.BulgarianModels.BulgarianProblem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeckOfProblemsId")
                        .HasColumnType("int");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnswer1Correct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnswer2Correct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnswer3Correct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnswer4Correct")
                        .HasColumnType("bit");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeckOfProblemsId");

                    b.ToTable("BulgarianProblems");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.BulgarianModels.DeckOfBulgarianProblems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Topic")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DecksOfBulgarianProblems");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.StudentAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnalysisType")
                        .HasColumnType("int")
                        .HasComment("tells if an essay or an textanalysis");

                    b.Property<bool>("IsGraded")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("TotalGrade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAnalyses");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.StudentWorkComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComponentType")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentAnalysisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentAnalysisId");

                    b.ToTable("StudentWorkComponents");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.TeacherLiteratureWork", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LiteratureWorkId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "LiteratureWorkId");

                    b.HasIndex("LiteratureWorkId");

                    b.ToTable("UserLiteratureWorks");

                    b.HasData(
                        new
                        {
                            ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082",
                            LiteratureWorkId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LiteratureProject.Data.Models.LiteratureWork", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.AnalysisPart", b =>
                {
                    b.HasOne("LiteratureProject.Data.Models.LiteratureWork", "LiteratureWork")
                        .WithMany("AnalysisParts")
                        .HasForeignKey("LiteratureWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteratureWork");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.BulgarianModels.BulgarianProblem", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.BulgarianModels.DeckOfBulgarianProblems", "Deck")
                        .WithMany("BulgarianProblems")
                        .HasForeignKey("DeckOfProblemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.StudentAnalysis", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.StudentWorkComponent", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.StudentAnalysis", "StudentAnalysis")
                        .WithMany("StudentWorkComponents")
                        .HasForeignKey("StudentAnalysisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentAnalysis");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.TeacherLiteratureWork", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", "Teacher")
                        .WithMany("TeacherLiteratureWorks")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteratureProject.Data.Models.LiteratureWork", "LiteratureWork")
                        .WithMany("TeacherLiteratureWorks")
                        .HasForeignKey("LiteratureWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteratureWork");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LiteratureProject.Data.Models.LiteratureWork", b =>
                {
                    b.Navigation("AnalysisParts");

                    b.Navigation("TeacherLiteratureWorks");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("TeacherLiteratureWorks");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.BulgarianModels.DeckOfBulgarianProblems", b =>
                {
                    b.Navigation("BulgarianProblems");
                });

            modelBuilder.Entity("LiteratureProject.Infrastructure.Data.Models.StudentAnalysis", b =>
                {
                    b.Navigation("StudentWorkComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
