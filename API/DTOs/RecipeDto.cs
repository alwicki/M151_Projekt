using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Step> Steps {get; set;}
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; } 
        public ICollection<Like> Likes { get; set; } 
        public UserDto User {get; set;}
    }
}