using PointOfSale.Domain;

namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Catalog catalog;
    private readonly Scanner scanner;
    private readonly Display display;
    private Price? _price;

    public SaleOrderHandler(Scanner scanner, Display display, Catalog catalog) {
        this.scanner = scanner;
        this.display = display;
        this.catalog = catalog;
        _price = null;
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
            _price = catalog.GetPriceByProductCode(productCode);
            display.DisplayPrice(_price);
        }

    }

    public void SubmitTotal() {
        if (_price is null)
            display.DisplayNoItemsToSale();
        else {
            display.DisplayTotal(_price);
        }
    }
}
