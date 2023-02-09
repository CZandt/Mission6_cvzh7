﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission6_cvzh7.Models;

namespace Mission6_cvzh7.Migrations
{
    [DbContext(typeof(MovieFormContext))]
    partial class MovieFormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission6_cvzh7.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            Category = "Action/Adventure",
                            Director = "Christopher Nolan",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Tenet",
                            Year = 2020
                        },
                        new
                        {
                            MovieID = 2,
                            Category = "Mystery/Thriller",
                            Director = "Rian Johnson",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Knives Out",
                            Year = 2019
                        },
                        new
                        {
                            MovieID = 3,
                            Category = "Comedy/Family",
                            Director = "John Lasseter",
                            Edited = false,
                            Rating = "G",
                            Title = "Cars",
                            Year = 2006
                        });
                });
#pragma warning restore 612, 618
        }
    }
}