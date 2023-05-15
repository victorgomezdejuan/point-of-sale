using PointOfSale;
using PointOfSale.Domain;

namespace PointOfSaleTests;
public class SellMultipleItemsTests {
    [Fact]
    public void NoScans() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, new Catalog(new Dictionary<string, Product>()));

        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", display.Text);
    }

    [Fact]
    public void OneScan_ProductNotFound() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, new Catalog(new Dictionary<string, Product>()));

        scanner.Scan("Not found product");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", display.Text);
    }

    [Fact]
    public void OneScan_ProductFound() {
        Display display = new();
        Scanner scanner = new();
        var pricesByProductCode = new Dictionary<string, Product> {
            { "11111", new Product("11111", new Price(5.43M, '€')) }
        };
        SaleOrderHandler handler = new(scanner, display, new Catalog(pricesByProductCode));

        scanner.Scan("11111");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 5,43 €", display.Text);
    }
}
