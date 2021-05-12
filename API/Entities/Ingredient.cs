namespace API.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int Amount {get; set;}

        public Unit Unit {get; set;}
    }
}