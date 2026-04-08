namespace API_Ecommerce.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string Type { get; set; }
    }
}
