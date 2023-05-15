using PointOfSale.Domain;

namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Catalog _catalog;
    private readonly Scanner _scanner;
    private readonly Display _display;
    private readonly List<Price> _prices;

    public SaleOrderHandler(Scanner scanner, Display display, Catalog catalog) {
        _scanner = scanner;
        _display = display;
        _catalog = catalog;
        _prices = new();
    }

    public void SubmitItem() {
        string productCode = _scanner.Input;

        if (string.IsNullOrEmpty(productCode))
            _display.DisplayEmptyCode();
        else if (!Product.IsCodeValid(productCode))
            _display.DisplayInvalidCode();
        else if (!_catalog.HasProduct(productCode))
            _display.DisplayProductNotFound();
        else {
            Price price = _catalog.GetPriceByProductCode(productCode);
            _prices.Add(price);
            _display.DisplayPrice(price);
        }
    }

    public void SubmitTotal() {
        if (_prices.Count == 0)
            _display.DisplayNoItemsToSale();
        else {
            _display.DisplayTotal(CalculateTotal(_prices));
        }
    }

    private Price CalculateTotal(List<Price> prices) {
        decimal total = 0;

        foreach (Price price in prices)
            total += price.Value;

        return new Price(total, prices[0].Currency);
    }
}
