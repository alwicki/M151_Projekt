﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210615132915_updateStepOrder")]
    partial class updateStepOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("API.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("API.Entities.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LikeId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("API.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Persons")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("API.Entities.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("StepId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("API.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("API.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeTag", b =>
                {
                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("integer");

                    b.HasKey("RecipesRecipeId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("RecipeTags");
                });

            modelBuilder.Entity("RecipeUser", b =>
                {
                    b.Property<int>("FavoritesRecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("FavoritesRecipeId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("API.Entities.Ingredient", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");

                    b.HasOne("API.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Entities.Like", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany("Likes")
                        .HasForeignKey("RecipeId");

                    b.HasOne("API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Recipe", b =>
                {
                    b.HasOne("API.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Step", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipeTag", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeUser", b =>
                {
                    b.HasOne("API.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("FavoritesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ingredients");

                    b.Navigation("Likes");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
