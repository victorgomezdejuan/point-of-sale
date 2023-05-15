using PointOfSale;
using PointOfSale.Domain;

namespace PointOfSaleTests;

public class SellOneItemTests {
    private readonly Display display;
    private readonly Scanner scanner;
    private readonly SaleOrderHandler handler;

    public SellOneItemTests() {
        display = new();
        scanner = new();
        Dictionary<string, Product> pricesByProductCode = new() {
            { "1234567890123", new Product("1234567890123", new Price(5.25M, '€')) }
        };
        handler = new(scanner, display, new Catalog(pricesByProductCode));
    }

    [Fact]
    public void EmptyCode() {
        scanner.Scan("");
        handler.SubmitItem();

        Assert.Equal("Error: Empty code", display.Text);
    }

    [Fact]
    public void InvalidCode_Length() {
        scanner.Scan(new string('1', 12));
        handler.SubmitItem();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void InvalidCode_NoInteger() {
        scanner.Scan(new string('a', 13));
        handler.SubmitItem();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void ProductFound() {
        scanner.Scan("1234567890123");
        handler.SubmitItem();

        Assert.Equal("5,25 €", display.Text);
    }

    [Fact]
    public void ProductNotFound() {
        scanner.Scan("1234567890124");
        handler.SubmitItem();

        Assert.Equal("Error: Product not found", display.Text);
    }
}