﻿namespace OnlineShop.Db.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}