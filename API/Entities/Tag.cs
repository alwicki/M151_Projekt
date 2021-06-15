using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; }
    }
}