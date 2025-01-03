namespace RestoranMenüSiparisMVC.Data
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public double Price { get; set; }
        public int? Unit { get; set; }
        public string? MealPic { get; set; }
    }
}
 