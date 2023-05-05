using PointOfSale;

namespace PointOfSaleTests;

public class SellOneItemTests {
    [Fact]
    public void EmptyCode() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display);

        scanner.Scan("");
        handler.Submit();

        Assert.Equal("Error: Empty code", display.Text);
    }

    [Fact]
    public void InvalidCode_Length() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display);

        scanner.Scan(new string('1', 12));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }

    [Fact]
    public void InvalidCode_NoInteger() {
        Display display = new();
        Scanner scanner = new();
        SaleOrderHandler handler = new(scanner, display);

        scanner.Scan(new string('a', 13));
        handler.Submit();

        Assert.Equal("Error: Invalid code", display.Text);
    }
}