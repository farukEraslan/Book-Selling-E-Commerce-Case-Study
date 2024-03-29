﻿namespace BookSeller.Entity.DTO.Product
{
    public class ProductCreateDTO
    {
        public Guid CategoryId { get; set; }
        public string BookName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string ISBN { get; set; }
    }
}
