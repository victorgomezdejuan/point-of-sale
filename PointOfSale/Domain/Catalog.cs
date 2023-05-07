namespace PointOfSale.Domain;
public class Catalog {
    private readonly Dictionary<string, Product> pricesByProductCode;

    public Catalog(Dictionary<string, Product> pricesByProductCode) => this.pricesByProductCode = pricesByProductCode;

    public bool HasProduct(string code) => pricesByProductCode.ContainsKey(code);

    public Price GetPriceByProductCode(string code) => pricesByProductCode[code].Price;
}
