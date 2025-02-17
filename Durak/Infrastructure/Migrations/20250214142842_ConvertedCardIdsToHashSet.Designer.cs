﻿// <auto-generated />
using System.Collections.Generic;
using Durak.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Durak.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250214142842_ConvertedCardIdsToHashSet")]
    partial class ConvertedCardIdsToHashSet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Durak.Domain.Entities.CardEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("Suit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Durak.Domain.Entities.DeskEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("Desks");
                });

            modelBuilder.Entity("Durak.Domain.Entities.HandEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.PrimitiveCollection<HashSet<long>>("CardIds")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<long?>("DeskEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("DeskId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeskEntityId");

                    b.HasIndex("DeskId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("Durak.Domain.Entities.MovesHistoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ActionType")
                        .HasColumnType("integer");

                    b.PrimitiveCollection<List<long>>("BeatenCardIds")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<bool>("IsBeaten")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("boolean");

                    b.Property<int>("MoveId")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.PrimitiveCollection<HashSet<long>>("MovedCardIds")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("MoveHistories");
                });

            modelBuilder.Entity("Durak.Domain.Entities.PlayerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Durak.Domain.Entities.HandEntity", b =>
                {
                    b.HasOne("Durak.Domain.Entities.DeskEntity", null)
                        .WithMany("Hands")
                        .HasForeignKey("DeskEntityId");

                    b.HasOne("Durak.Domain.Entities.DeskEntity", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Durak.Domain.Entities.PlayerEntity", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desk");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Durak.Domain.Entities.MovesHistoryEntity", b =>
                {
                    b.HasOne("Durak.Domain.Entities.PlayerEntity", "Player")
                        .WithMany("MovesHistories")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Durak.Domain.Entities.DeskEntity", b =>
                {
                    b.Navigation("Hands");
                });

            modelBuilder.Entity("Durak.Domain.Entities.PlayerEntity", b =>
                {
                    b.Navigation("MovesHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
