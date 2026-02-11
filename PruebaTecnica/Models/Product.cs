namespace PruebaTecnica.Models
{
    public class Product
    {
        
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; // Default value to avoid null reference
        public string Description { get; set; } = string.Empty; // Default value to avoid null reference
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true; // Default value to true

        public DateTime CreateAt { get; set; } = DateTime.Now; // Default value to current date and time
    }
}

// NOTE:
// This entity is currently used directly in API requests and responses.
// This may expose internal fields (Id, IsActive, CreatedAt) and could lead to over-posting vulnerabilities.
// In a production scenario, DTOs should be implemented to prevent unintended data binding.
