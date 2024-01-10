namespace BookSeller.Entity.DTO.Category
{
    public class CategoryDTO : IDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
