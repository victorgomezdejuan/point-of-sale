namespace PointOfSale;
public class Catalog {
    private readonly Dictionary<string, string> pricesByProductCode;

    public Catalog(Dictionary<string, string> pricesByProductCode) => this.pricesByProductCode = pricesByProductCode;

    public bool HasProduct(string input) => pricesByProductCode.ContainsKey(input);

    public string GetPriceByProductCode(string input) => pricesByProductCode[input];
}
