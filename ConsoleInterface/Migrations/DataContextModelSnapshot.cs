﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleInterface.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Goal", b =>
                {
                    b.Property<Guid>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsEven")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPowerPlay")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsShorthanded")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MatchStatisticId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlayerId1")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("GoalId");

                    b.HasIndex("MatchId");

                    b.HasIndex("MatchStatisticId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PlayerId1");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("DAL.Entities.Infraction", b =>
                {
                    b.Property<Guid>("InfractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("InfractionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InfractionId");

                    b.ToTable("Infractions");
                });

            modelBuilder.Entity("DAL.Entities.Match", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FirstTeamTeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SecondTeamTeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatOfFirstTeamMatchStatisticId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatOfSecondTeamMatchStatisticId")
                        .HasColumnType("uuid");

                    b.HasKey("MatchId");

                    b.HasIndex("FirstTeamTeamId");

                    b.HasIndex("SecondTeamTeamId");

                    b.HasIndex("StatOfFirstTeamMatchStatisticId");

                    b.HasIndex("StatOfSecondTeamMatchStatisticId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DAL.Entities.MatchStatistic", b =>
                {
                    b.Property<Guid>("MatchStatisticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BlockedShots")
                        .HasColumnType("integer");

                    b.Property<int>("Shots")
                        .HasColumnType("integer");

                    b.Property<string>("WinType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MatchStatisticId");

                    b.ToTable("MatchStatistics");
                });

            modelBuilder.Entity("DAL.Entities.Penalty", b =>
                {
                    b.Property<Guid>("PenaltyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("InfractionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MatchStatisticId")
                        .HasColumnType("uuid");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("PenaltyId");

                    b.HasIndex("InfractionId");

                    b.HasIndex("MatchStatisticId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Penalties");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DAL.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TeamStatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeamStatisticId")
                        .HasColumnType("uuid");

                    b.HasKey("TeamId");

                    b.HasIndex("TeamStatisticId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DAL.Entities.TeamStatistic", b =>
                {
                    b.Property<Guid>("TeamStatisticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Scores")
                        .HasColumnType("integer");

                    b.Property<int>("WinsAtOT")
                        .HasColumnType("integer");

                    b.Property<int>("WinsAtRegularTime")
                        .HasColumnType("integer");

                    b.Property<int>("WinsAtShootOut")
                        .HasColumnType("integer");

                    b.HasKey("TeamStatisticId");

                    b.ToTable("TeamStatistics");
                });

            modelBuilder.Entity("DAL.Entities.Goal", b =>
                {
                    b.HasOne("DAL.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.MatchStatistic", null)
                        .WithMany("Goals")
                        .HasForeignKey("MatchStatisticId");

                    b.HasOne("DAL.Entities.Player", null)
                        .WithMany("Assists")
                        .HasForeignKey("PlayerId");

                    b.HasOne("DAL.Entities.Player", null)
                        .WithMany("Goals")
                        .HasForeignKey("PlayerId1");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("DAL.Entities.Match", b =>
                {
                    b.HasOne("DAL.Entities.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.MatchStatistic", "StatOfFirstTeam")
                        .WithMany()
                        .HasForeignKey("StatOfFirstTeamMatchStatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.MatchStatistic", "StatOfSecondTeam")
                        .WithMany()
                        .HasForeignKey("StatOfSecondTeamMatchStatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");

                    b.Navigation("StatOfFirstTeam");

                    b.Navigation("StatOfSecondTeam");
                });

            modelBuilder.Entity("DAL.Entities.Penalty", b =>
                {
                    b.HasOne("DAL.Entities.Infraction", "Infraction")
                        .WithMany()
                        .HasForeignKey("InfractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.MatchStatistic", null)
                        .WithMany("Penalties")
                        .HasForeignKey("MatchStatisticId");

                    b.HasOne("DAL.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infraction");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.HasOne("DAL.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DAL.Entities.Team", b =>
                {
                    b.HasOne("DAL.Entities.TeamStatistic", "TeamStatistic")
                        .WithMany()
                        .HasForeignKey("TeamStatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamStatistic");
                });

            modelBuilder.Entity("DAL.Entities.MatchStatistic", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("Penalties");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Navigation("Assists");

                    b.Navigation("Goals");
                });

            modelBuilder.Entity("DAL.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
