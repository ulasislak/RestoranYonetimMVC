namespace RestoranMenüSiparisMVC.Models
{
    public class OrdersDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ingredient { get; set; }        
        public double? Price { get; set; }
        public int? Unit { get; set; }
        public string? MealPic { get; set; }
        public int? ProductId { get; set; } 
        public string? CustomerId { get; set; } 
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }=DateTime.Now;
        public decimal? TotalPrice { get; set; }
    }
}
