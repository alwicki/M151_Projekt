using System.Collections.Generic;

namespace API.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }

        public byte[] Image {get; set;}

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Step> Steps {get; set;}
        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments {get; set;}

        public ICollection<Tag> Tags {get; set;}
        public ICollection<User> Users {get; set;}

        public User User {get; set;}
        public int UserId {get; set;}
    }
}