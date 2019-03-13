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
    [Migration("20190313164338_InitialCreate")]
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

            modelBuilder.Entity("CoreBlog.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.Property<string>("UrlSlug");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoreBlog.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorForeignKey");

                    b.Property<int>("BlogForeignKey");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<string>("MetaDataDescription");

                    b.Property<DateTime?>("ModifiedLastAt");

                    b.Property<DateTime>("PostCreatedAt");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortContent");

                    b.Property<string>("Title");

                    b.Property<string>("UrlSlug");

                    b.HasKey("PostId");

                    b.HasIndex("AuthorForeignKey");

                    b.HasIndex("BlogForeignKey");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CoreBlog.Models.PostTag", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.Property<int>("id");

                    b.HasKey("PostId", "TagId");

                    b.HasAlternateKey("id");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("CoreBlog.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName");

                    b.Property<string>("UrlSlug");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CoreBlog.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName");

                    b.Property<int>("BlogForeignKey");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.HasIndex("BlogForeignKey");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoreBlog.Models.Post", b =>
                {
                    b.HasOne("CoreBlog.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreBlog.Models.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogForeignKey")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CoreBlog.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CoreBlog.Models.PostTag", b =>
                {
                    b.HasOne("CoreBlog.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreBlog.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreBlog.Models.User", b =>
                {
                    b.HasOne("CoreBlog.Models.Blog", "Blog")
                        .WithMany("Users")
                        .HasForeignKey("BlogForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}