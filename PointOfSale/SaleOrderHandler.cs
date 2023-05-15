using PointOfSale.Domain;

namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Catalog catalog;
    private readonly Scanner scanner;
    private readonly Display display;
    private readonly List<Price> _prices;

    public SaleOrderHandler(Scanner scanner, Display display, Catalog catalog) {
        this.scanner = scanner;
        this.display = display;
        this.catalog = catalog;
        _prices = new();
    }

    public void SubmitItem() {
        string productCode = scanner.Input;

        if (string.IsNullOrEmpty(productCode))
            display.DisplayEmptyCode();
        else if (!Product.IsCodeValid(productCode))
            display.DisplayInvalidCode();
        else if (!catalog.HasProduct(productCode))
            display.DisplayProductNotFound();
        else {
            Price price = catalog.GetPriceByProductCode(productCode);
            _prices.Add(price);
            display.DisplayPrice(price);
        }

    }

    public void SubmitTotal() {
        if (_prices.Count == 0)
            display.DisplayNoItemsToSale();
        else {
            display.DisplayTotal(CalculateTotal(_prices));
        }
    }

    private Price CalculateTotal(List<Price> prices) {
        decimal total = 0;

        foreach (Price price in prices)
            total += price.Value;

        return new Price(total, prices[0].Currency);
    }
}
