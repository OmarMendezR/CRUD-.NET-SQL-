namespace PruebaTecnica.Models
{
    public class Product // Entity Base Class
    {
        // colums of Data Base
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricce { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; } 

    }
}
