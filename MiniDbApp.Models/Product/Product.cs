﻿namespace MiniDbApp.Models.Product;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Tax { get; set; }

}