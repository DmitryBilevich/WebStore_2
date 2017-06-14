namespace WebStore.Model
{
    public class ProductDescription
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsShort { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
}