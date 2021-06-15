namespace API.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Description { get; set; }
        public int Amount {get; set;}

        //public int UnitId {get; set;}
        public Unit Unit {get; set;}
    }
}