using BookSeller.Entity.DTO.Product;

namespace BookSeller.WebUI.Models.Product
{
    public class ProductViewModel
    {
        public List<ProductDTO> Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
