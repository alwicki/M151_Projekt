using System.Collections.Generic;

namespace API.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Step> Steps {get; set;}
        public List<Like> Likes { get; set; }

        public List<Comment> Comments {get; set;}

        public ICollection<Tag> Tags {get; set;}
        public ICollection<User> Users {get; set;}

        public User User {get; set;}
    }
}