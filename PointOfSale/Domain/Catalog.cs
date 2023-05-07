namespace PointOfSale.Domain;
public class Catalog {
    private readonly Dictionary<string, Product> pricesByProductCode;

    public Catalog(Dictionary<string, Product> pricesByProductCode) => this.pricesByProductCode = pricesByProductCode;

    public bool HasProduct(string input) => pricesByProductCode.ContainsKey(input);

    public string GetPriceByProductCode(string input) => pricesByProductCode[input].Price;
}
