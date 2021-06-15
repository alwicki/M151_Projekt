using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class updateEntitiesIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Recipes_FavoritesId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesId",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Tags_TagsId",
                table: "RecipeTags");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Units",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Step",
                newName: "StepId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "RecipeTags",
                newName: "TagsTagId");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "RecipeTags",
                newName: "RecipesRecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTags_TagsId",
                table: "RecipeTags",
                newName: "IX_RecipeTags_TagsTagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Likes",
                newName: "LikeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "FavoritesId",
                table: "Favorites",
                newName: "FavoritesRecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Recipes_FavoritesRecipeId",
                table: "Favorites",
                column: "FavoritesRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesRecipeId",
                table: "RecipeTags",
                column: "RecipesRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Tags_TagsTagId",
                table: "RecipeTags",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Recipes_FavoritesRecipeId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesRecipeId",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Tags_TagsTagId",
                table: "RecipeTags");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Units",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StepId",
                table: "Step",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "RecipeTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "RecipesRecipeId",
                table: "RecipeTags",
                newName: "RecipesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTags_TagsTagId",
                table: "RecipeTags",
                newName: "IX_RecipeTags_TagsId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LikeId",
                table: "Likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FavoritesRecipeId",
                table: "Favorites",
                newName: "FavoritesId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Recipes_FavoritesId",
                table: "Favorites",
                column: "FavoritesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesId",
                table: "RecipeTags",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Tags_TagsId",
                table: "RecipeTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
