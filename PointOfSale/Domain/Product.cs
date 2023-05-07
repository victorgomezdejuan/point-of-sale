﻿namespace PointOfSale.Domain;
public class Product {
    public string Code { get; private set; }
    public string Price { get; private set; }
    public Product(string code, string price) {
        Code = code;
        Price = price;
    }
}
