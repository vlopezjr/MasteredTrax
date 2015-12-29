using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MasteredTrax.Models;

namespace MasteredTrax.Migrations
{
    [DbContext(typeof(MastedTraxContext))]
    [Migration("20151228231824_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MasteredTrax.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Facebook");

                    b.Property<string>("Instagram");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Snapchat");

                    b.Property<string>("Twitter");

                    b.Property<string>("Vevo");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("ArtistId");

                    b.Property<string>("City");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("State");

                    b.Property<string>("TicketLink");

                    b.Property<string>("Title");

                    b.Property<string>("Venue");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<string>("Caption");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Mp3");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("ExternalLink");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Mp4");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MasteredTrax.Models.Album", b =>
                {
                    b.HasOne("MasteredTrax.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("MasteredTrax.Models.Event", b =>
                {
                    b.HasOne("MasteredTrax.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("MasteredTrax.Models.Photo", b =>
                {
                    b.HasOne("MasteredTrax.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("MasteredTrax.Models.Song", b =>
                {
                    b.HasOne("MasteredTrax.Models.Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("MasteredTrax.Models.Video", b =>
                {
                    b.HasOne("MasteredTrax.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });
        }
    }
}
