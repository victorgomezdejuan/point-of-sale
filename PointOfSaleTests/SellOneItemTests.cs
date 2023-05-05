using PointOfSale;

namespace PointOfSaleTests;

public class SellOneItemTests {
    [Fact]
    public void EmptyCode() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, null);

        scanner.Scan("");
        handler.Submit();

        Assert.Equal("Error: Empty code", display.Text);
    }

    [Fact]
    public void InvalidCode_Length() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, null);

        scanner.Scan(new string('1', 12));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void InvalidCode_NoInteger() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, null);

        scanner.Scan(new string('a', 13));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void ProductFound() {
        Dictionary<string, string> pricesByProductCode = new() {
            { "1234567890123", "5.25 €" }
        };
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, pricesByProductCode);

        scanner.Scan("1234567890123");
        handler.Submit();

        Assert.Equal("5.25 €", display.Text);
    }

    [Fact]
    public void ProductNotFound() {
        Dictionary<string, string> pricesByProductCode = new() {
            { "1234567890123", "5.25 €" }
        };
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display, pricesByProductCode);
        scanner.Scan("1234567890124");
        handler.Submit();
        Assert.Equal("Error: Product not found", display.Text);
    }
}