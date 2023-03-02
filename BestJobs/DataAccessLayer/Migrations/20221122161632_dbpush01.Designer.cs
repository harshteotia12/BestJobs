﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20221122161632_dbpush01")]
    partial class dbpush01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.CandidateDetails", b =>
                {
                    b.Property<int>("CandidateDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddLine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CandidateDetailsId");

                    b.ToTable("CandidateDetails");
                });

            modelBuilder.Entity("DataAccessLayer.CandidateResume", b =>
                {
                    b.Property<int>("CandidateResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentCTC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CurrentOrganization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GraduationSchool")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GraduationSchoolPercentage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GraduationStream")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenthSchool")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenthSchoolPercentage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TwelfthSchool")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TwelfthSchoolPercentage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CandidateResumeId");

                    b.HasIndex("CandidateDetailsId");

                    b.ToTable("CandidateResume");
                });

            modelBuilder.Entity("DataAccessLayer.Files", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DataFiles")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentId");

                    b.HasIndex("CandidateDetailsId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DataAccessLayer.HR", b =>
                {
                    b.Property<int>("HRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HRName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HRYOE")
                        .HasColumnType("int");

                    b.Property<byte[]>("OrgPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Orgname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HRId");

                    b.ToTable("HR");
                });

            modelBuilder.Entity("DataAccessLayer.JobStatus", b =>
                {
                    b.Property<int>("JobStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CandidateUserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HRUserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsComleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<int>("JobsId")
                        .HasColumnType("int");

                    b.HasKey("JobStatusId");

                    b.HasIndex("JobsId");

                    b.ToTable("JobStatus");
                });

            modelBuilder.Entity("DataAccessLayer.Jobs", b =>
                {
                    b.Property<int>("JobsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HRId")
                        .HasColumnType("int");

                    b.Property<string>("JobsDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("JobsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("JobsPackage")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobsPostDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("JobsSkill")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("JobsId");

                    b.HasIndex("HRId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("DataAccessLayer.Skills", b =>
                {
                    b.Property<int>("SkillsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SkillProficiency")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SkillsId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DataAccessLayer.CandidateResume", b =>
                {
                    b.HasOne("DataAccessLayer.CandidateDetails", "CandidateDetails")
                        .WithMany("CandidateResume")
                        .HasForeignKey("CandidateDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CandidateDetails");
                });

            modelBuilder.Entity("DataAccessLayer.Files", b =>
                {
                    b.HasOne("DataAccessLayer.CandidateDetails", "CandidateDetails")
                        .WithMany("Files")
                        .HasForeignKey("CandidateDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CandidateDetails");
                });

            modelBuilder.Entity("DataAccessLayer.JobStatus", b =>
                {
                    b.HasOne("DataAccessLayer.Jobs", "Jobs")
                        .WithMany("JobStatus")
                        .HasForeignKey("JobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DataAccessLayer.Jobs", b =>
                {
                    b.HasOne("DataAccessLayer.HR", "HR")
                        .WithMany("Jobs")
                        .HasForeignKey("HRId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HR");
                });

            modelBuilder.Entity("DataAccessLayer.CandidateDetails", b =>
                {
                    b.Navigation("CandidateResume");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("DataAccessLayer.HR", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DataAccessLayer.Jobs", b =>
                {
                    b.Navigation("JobStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
