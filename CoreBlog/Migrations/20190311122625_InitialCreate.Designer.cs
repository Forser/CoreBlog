﻿// <auto-generated />
using System;
using CoreBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreBlog.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20190311122625_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreBlog.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("CoreBlog.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorForeignKey");

                    b.Property<int>("BlogForeignKey");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostCreatedAt");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("AuthorForeignKey");

                    b.HasIndex("BlogForeignKey");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CoreBlog.Models.PostTag", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PostId1");

                    b.Property<string>("TagForeignKey");

                    b.HasKey("PostId");

                    b.HasIndex("PostId1");

                    b.HasIndex("TagForeignKey");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("CoreBlog.Models.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CoreBlog.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoreBlog.Models.Post", b =>
                {
                    b.HasOne("CoreBlog.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreBlog.Models.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreBlog.Models.PostTag", b =>
                {
                    b.HasOne("CoreBlog.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId1");

                    b.HasOne("CoreBlog.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagForeignKey");
                });
#pragma warning restore 612, 618
        }
    }
}