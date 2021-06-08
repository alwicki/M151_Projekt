using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps {get; set;}
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; } 
        public UserDto User {get; set;}
    }
}