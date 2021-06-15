using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace API.Entities
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Title { get; set; }
                
        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}