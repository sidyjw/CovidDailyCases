﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DailyCasesReportContext))]
    partial class DailyCasesReportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Domain.DailyCasesReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumSequences")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumSequencesTotal")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PercSequences")
                        .HasColumnType("REAL");

                    b.Property<string>("Variant")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DailyCasesReports");
                });
#pragma warning restore 612, 618
        }
    }
}
