﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Store;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(ResourcesContext))]
    [Migration("20240227155208_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Store.Entities.AnswerRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("QuestionRecordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionRecordId");

                    b.ToTable("Answers", (string)null);
                });

            modelBuilder.Entity("Store.Entities.InterviewRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("SurveyRecordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SurveyRecordId");

                    b.ToTable("Interviews", (string)null);
                });

            modelBuilder.Entity("Store.Entities.QuestionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SurveyRecordId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SurveyRecordId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("Store.Entities.ResultRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("InterviewRecordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("InterviewRecordId");

                    b.ToTable("Results", (string)null);
                });

            modelBuilder.Entity("Store.Entities.SurveyRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 15, 52, 8, 464, DateTimeKind.Utc).AddTicks(5938));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 15, 52, 8, 464, DateTimeKind.Utc).AddTicks(6247));

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 15, 52, 8, 464, DateTimeKind.Utc).AddTicks(6110));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Surveys", (string)null);
                });

            modelBuilder.Entity("Store.Entities.AnswerRecord", b =>
                {
                    b.HasOne("Store.Entities.QuestionRecord", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionRecordId");
                });

            modelBuilder.Entity("Store.Entities.InterviewRecord", b =>
                {
                    b.HasOne("Store.Entities.SurveyRecord", null)
                        .WithMany("Interviews")
                        .HasForeignKey("SurveyRecordId");
                });

            modelBuilder.Entity("Store.Entities.QuestionRecord", b =>
                {
                    b.HasOne("Store.Entities.SurveyRecord", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyRecordId");
                });

            modelBuilder.Entity("Store.Entities.ResultRecord", b =>
                {
                    b.HasOne("Store.Entities.InterviewRecord", null)
                        .WithMany("Results")
                        .HasForeignKey("InterviewRecordId");
                });

            modelBuilder.Entity("Store.Entities.InterviewRecord", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Store.Entities.QuestionRecord", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Store.Entities.SurveyRecord", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
