namespace PointOfSale.Domain;
public class Product {
    public string Code { get; private set; }

    public Price Price { get; private set; }

    public Product(string code, Price price) {
        Code = code;
        Price = price;
    }

    public static bool IsCodeValid(string code) => code.Length == 13 && long.TryParse(code, out _);
}
