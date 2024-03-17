﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240112224013_Creatiodestables")]
    partial class Creatiodestables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entity.Categorie", b =>
                {
                    b.Property<int>("Idcategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcategorie"));

                    b.Property<string>("Titrecategorie")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Idcategorie");

                    b.ToTable("Categorie", "db");
                });

            modelBuilder.Entity("DAL.Entity.Commentaire", b =>
                {
                    b.Property<int>("Idcommentaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcommentaire"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(3);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnOrder(1);

                    b.Property<int>("Idcours")
                        .HasColumnType("int");

                    b.Property<string>("Nomuser")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnOrder(2);

                    b.HasKey("Idcommentaire");

                    b.HasIndex("Idcours");

                    b.ToTable("Commentaire", "db");
                });

            modelBuilder.Entity("DAL.Entity.Cours", b =>
                {
                    b.Property<int>("Idcours")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcours"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(3);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etapes")
                        .HasColumnType("varchar(250)")
                        .HasColumnOrder(2);

                    b.Property<int>("Idcategorie")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnOrder(1);

                    b.HasKey("Idcours");

                    b.HasIndex("Idcategorie");

                    b.ToTable("Cours", "db");
                });

            modelBuilder.Entity("DAL.Entity.Commentaire", b =>
                {
                    b.HasOne("DAL.Entity.Cours", "Cours")
                        .WithMany()
                        .HasForeignKey("Idcours")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cours");
                });

            modelBuilder.Entity("DAL.Entity.Cours", b =>
                {
                    b.HasOne("DAL.Entity.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("Idcategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });
#pragma warning restore 612, 618
        }
    }
}
