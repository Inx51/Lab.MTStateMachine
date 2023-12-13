﻿// <auto-generated />
using System;
using Lab.MTStateMachine.Sagas.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab.MTStateMachine.Migrations
{
    [DbContext(typeof(MakeSaladStateContext))]
    [Migration("20231213114634_0002")]
    partial class _0002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Lab.MTStateMachine.Sagas.MakeSaladState", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentState")
                        .HasMaxLength(64)
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int?>("SaladId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VegId")
                        .HasColumnType("TEXT");

                    b.HasKey("CorrelationId");

                    b.ToTable("MakeSaladState");
                });
#pragma warning restore 612, 618
        }
    }
}