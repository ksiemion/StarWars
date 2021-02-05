﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Infrastructure.Data;

namespace StarWars.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210204143351_Planets")]
    partial class Planets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CharacterCharacter", b =>
                {
                    b.Property<int>("FriendOfID")
                        .HasColumnType("int");

                    b.Property<int>("FriendsID")
                        .HasColumnType("int");

                    b.HasKey("FriendOfID", "FriendsID");

                    b.HasIndex("FriendsID");

                    b.ToTable("CharacterCharacter");
                });

            modelBuilder.Entity("CharacterEpisode", b =>
                {
                    b.Property<int>("CharactersID")
                        .HasColumnType("int");

                    b.Property<int>("EpisodesID")
                        .HasColumnType("int");

                    b.HasKey("CharactersID", "EpisodesID");

                    b.HasIndex("EpisodesID");

                    b.ToTable("CharacterEpisode");
                });

            modelBuilder.Entity("StarWars.Core.Domain.Character", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlanetID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("StarWars.Core.Domain.Episode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("StarWars.Core.Domain.Planet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Planet");
                });

            modelBuilder.Entity("CharacterCharacter", b =>
                {
                    b.HasOne("StarWars.Core.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("FriendOfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("FriendsID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterEpisode", b =>
                {
                    b.HasOne("StarWars.Core.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Domain.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWars.Core.Domain.Character", b =>
                {
                    b.HasOne("StarWars.Core.Domain.Planet", "Planet")
                        .WithMany("Characters")
                        .HasForeignKey("PlanetID");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("StarWars.Core.Domain.Planet", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}