namespace API.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Amount {get; set;}

        public Unit Unit {get; set;}
    }
}