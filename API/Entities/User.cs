using System.Collections.Generic;
using API.Enums;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public int PenaltyPoints {get; set;}
        public EUserRole UserRole {get; set;}

        [JsonIgnore]
        public ICollection<Recipe> Recipes {get; set;}

        public ICollection<Recipe> Favorites {get; set;}
    }
}