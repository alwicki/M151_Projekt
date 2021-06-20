using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public class Seed
    {
     public  static async Task SeedUsers(DataContext context){
         if(await context.Users.AnyAsync()) return;

         var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
         var users = JsonSerializer.Deserialize<List<User>>(userData);
         foreach(var user in users)
         {
             using var hmac = new HMACSHA512();
             user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("12345"));
             user.PasswordSalt = hmac.Key;
             context.Users.Add(user);
         }

         await context.SaveChangesAsync();
     }
public static async Task SeedRecipes(DataContext context){
    if(await context.Recipes.AnyAsync()) return;
    var recipeData = await System.IO.File.ReadAllTextAsync("Data/RecipeSeedData.json");
    var recipes = JsonSerializer.Deserialize<List<Recipe>>(recipeData);
    foreach(var recipe in recipes){
        context.Recipes.Add(recipe);
    }

    await context.SaveChangesAsync();
}

    }
    }