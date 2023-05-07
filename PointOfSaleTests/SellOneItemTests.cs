using PointOfSale;
using PointOfSale.Domain;

namespace PointOfSaleTests;

public class SellOneItemTests {
    private readonly Dictionary<string, Product> pricesByProductCode;
    private readonly Display display;
    private readonly Scanner scanner;
    private readonly SaleOrderHandler handler;

    public SellOneItemTests() {
        pricesByProductCode = new() {
            { "1234567890123", new Product("1234567890123", new Price(5.25M, '€')) }
        };
        display = new();
        scanner = new();
        handler = new(scanner, display, new Catalog(pricesByProductCode));
    }

    [Fact]
    public void EmptyCode() {
        scanner.Scan("");
        handler.Submit();

        Assert.Equal("Error: Empty code", display.Text);
    }

    [Fact]
    public void InvalidCode_Length() {
        scanner.Scan(new string('1', 12));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void InvalidCode_NoInteger() {
        scanner.Scan(new string('a', 13));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void ProductFound() {
        scanner.Scan("1234567890123");
        handler.Submit();

        Assert.Equal("5,25 €", display.Text);
    }

    [Fact]
    public void ProductNotFound() {
        scanner.Scan("1234567890124");
        handler.Submit();

        Assert.Equal("Error: Product not found", display.Text);
    }
}