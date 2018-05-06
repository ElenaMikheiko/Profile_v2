﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Profile.DataAccess.Data;
using System;

namespace Profile.DataAccess.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    [Migration("20180214162356_AddGoggleApiKeyToUserInfo")]
    partial class AddGoggleApiKeyToUserInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Profile.Model.Models.AdditionalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("AdditionalInfo");
                });

            modelBuilder.Entity("Profile.Model.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int?>("UserInfoId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserInfoId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Profile.Model.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Link");

                    b.Property<string>("Organization");

                    b.Property<string>("Title");

                    b.Property<string>("YearOfAttestation");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Profile.Model.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Skype");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("Profile.Model.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Organization");

                    b.Property<string>("Specialization");

                    b.Property<string>("YearOfGraduation");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Profile.Model.Models.CV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("Profile.Model.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Department");

                    b.Property<string>("EducationalInstitution");

                    b.Property<string>("Level");

                    b.Property<string>("Specialization");

                    b.Property<string>("YearOfAdmission");

                    b.Property<string>("YearOfGraduation");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Profile.Model.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("ExamName");

                    b.Property<string>("Organization");

                    b.Property<string>("Specialization");

                    b.Property<string>("YearOfAttestation");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Profile.Model.Models.ForeignLanguage", b =>
                {
                    b.Property<int>("CVId");

                    b.Property<int>("LanguageId");

                    b.Property<int>("LanguageLevelId");

                    b.HasKey("CVId", "LanguageId", "LanguageLevelId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LanguageLevelId");

                    b.ToTable("ForeignLanguages");
                });

            modelBuilder.Entity("Profile.Model.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Profile.Model.Models.LanguageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LevelName");

                    b.HasKey("Id");

                    b.ToTable("LanguageLevels");
                });

            modelBuilder.Entity("Profile.Model.Models.MilitaryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("MilitaryStatus");
                });

            modelBuilder.Entity("Profile.Model.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Link");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("Profile.Model.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("LetterLink");

                    b.Property<string>("PersonContact");

                    b.Property<string>("PersonName");

                    b.Property<string>("PersonPosition");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("Profile.Model.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Profile.Model.Models.Stream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StreamName");

                    b.HasKey("Id");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("Profile.Model.Models.StreamSkill", b =>
                {
                    b.Property<int>("StreamId");

                    b.Property<int>("SkillId");

                    b.HasKey("StreamId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("StreamSkills");
                });

            modelBuilder.Entity("Profile.Model.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfGraduation");

                    b.Property<int>("UserInfoId");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Profile.Model.Models.StudentSkill", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("SkillId");

                    b.HasKey("StudentId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("StudentSkills");
                });

            modelBuilder.Entity("Profile.Model.Models.StudentStream", b =>
                {
                    b.Property<int>("StreamId");

                    b.Property<int>("StudentId");

                    b.HasKey("StreamId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentStreams");
                });

            modelBuilder.Entity("Profile.Model.Models.Summary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Summary");
                });

            modelBuilder.Entity("Profile.Model.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("EnName");

                    b.Property<string>("EnSurname");

                    b.Property<string>("GoogleApiKey");

                    b.Property<string>("Phone");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("RuName");

                    b.Property<string>("RuSurname");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Profile.Model.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVId");

                    b.Property<string>("EndMonth");

                    b.Property<string>("EndYear");

                    b.Property<string>("Organization");

                    b.Property<string>("Position");

                    b.Property<string>("Responsibilities");

                    b.Property<string>("StartMonth");

                    b.Property<string>("StartYear");

                    b.Property<bool>("ToPresent");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Profile.Model.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Profile.Model.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Profile.Model.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.ApplicationUser", b =>
                {
                    b.HasOne("Profile.Model.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("Profile.Model.Models.ContactInfo", b =>
                {
                    b.HasOne("Profile.Model.Models.CV", "Resume")
                        .WithMany()
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.Course", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Courses")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.CV", b =>
                {
                    b.HasOne("Profile.Model.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.Education", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Educations")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.Exam", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Test")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.ForeignLanguage", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Languages")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.LanguageLevel", "LanguageLevel")
                        .WithMany()
                        .HasForeignKey("LanguageLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.Portfolio", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Portfolio")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.Recommendation", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Recommendations")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.StreamSkill", b =>
                {
                    b.HasOne("Profile.Model.Models.Skill", "Skill")
                        .WithMany("StreamSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.Stream", "Stream")
                        .WithMany("StreamSkills")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.StudentSkill", b =>
                {
                    b.HasOne("Profile.Model.Models.Skill", "Skill")
                        .WithMany("StudentSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.Student", "Student")
                        .WithMany("StudentSkills")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.StudentStream", b =>
                {
                    b.HasOne("Profile.Model.Models.Stream", "Stream")
                        .WithMany()
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Profile.Model.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Profile.Model.Models.WorkExperience", b =>
                {
                    b.HasOne("Profile.Model.Models.CV")
                        .WithMany("Experience")
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}