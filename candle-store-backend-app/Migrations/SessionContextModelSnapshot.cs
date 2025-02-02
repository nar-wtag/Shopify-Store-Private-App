﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using candle_store_backend_app.Contexts;

#nullable disable

namespace candle_store_backend_app.Migrations
{
    [DbContext(typeof(SessionContext))]
    partial class SessionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("candle_store_backend_app.Models.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Scope")
                        .HasColumnType("TEXT");

                    b.Property<string>("Shop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
