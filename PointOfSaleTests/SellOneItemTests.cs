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
}