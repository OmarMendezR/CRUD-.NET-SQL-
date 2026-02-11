namespace PruebaTecnica.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Default value to avoid null reference
        public string Description { get; set; } = string.Empty; // Default value to avoid null reference
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true; // Default value to true

        public DateTime DateTime { get; set; } = DateTime.Now; // Default value to current date and time
    }
}
