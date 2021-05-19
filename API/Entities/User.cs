using System.Collections.Generic;
using API.Enums;

namespace API.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public UserRole UserRole {get; set;}

        public List<Recipe> Recipes {get; set;}

        public ICollection<Recipe> Favorites {get; set;}
    }
}