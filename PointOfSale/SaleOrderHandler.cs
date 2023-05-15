using PointOfSale.Domain;

namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Catalog catalog;
    private readonly Scanner scanner;
    private readonly Display display;
    private string _productCode;

    public SaleOrderHandler(Scanner scanner, Display display, Catalog catalog) {
        this.scanner = scanner;
        this.display = display;
        this.catalog = catalog;
    }

    public void SubmitItem() {
        _productCode = scanner.Input;

        if (string.IsNullOrEmpty(_productCode))
            display.DisplayEmptyCode();
        else if (!Product.IsCodeValid(_productCode))
            display.DisplayInvalidCode();
        else if (!catalog.HasProduct(_productCode))
            display.DisplayProductNotFound();
        else
            display.DisplayPrice(catalog.GetPriceByProductCode(_productCode));
    }

    public void SubmitTotal() {
        if (string.IsNullOrEmpty(_productCode))
            display.DisplayNoItemsToSale();
        else {
            display.DisplayTotal(catalog.GetPriceByProductCode(_productCode));
        }
    }
}
