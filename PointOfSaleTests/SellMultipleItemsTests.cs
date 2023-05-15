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
            { "1234567890123", new Product("1234567890123", new Price(5.43M, '€')) }
        };
        SaleOrderHandler handler = new(scanner, display, new Catalog(pricesByProductCode));

        scanner.Scan("1234567890123");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 5,43 €", display.Text);
    }

    [Fact]
    public void MultipleScans_AllProductsNotFound() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, new Catalog(new Dictionary<string, Product>()));

        scanner.Scan("Product not found");
        handler.SubmitItem();
        scanner.Scan("Another product not found");
        handler.SubmitItem();
        scanner.Scan("And another product not found");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", display.Text);
    }

    [Fact]
    public void MultipleScans_AllProductsFound() {
        Display display = new();
        Scanner scanner = new();
        var pricesByProductCode = new Dictionary<string, Product> {
            { "1234567890123", new Product("1234567890123", new Price(5.43M, '€')) },
            { "1234567890124", new Product("1234567890124", new Price(15.01M, '€')) },
            { "1234567890125", new Product("1234567890125", new Price(3.29M, '€')) }
        };
        SaleOrderHandler handler = new(scanner, display, new Catalog(pricesByProductCode));

        scanner.Scan("1234567890123");
        handler.SubmitItem();
        scanner.Scan("1234567890124");
        handler.SubmitItem();
        scanner.Scan("1234567890125");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 23,73 €", display.Text);
    }
}
