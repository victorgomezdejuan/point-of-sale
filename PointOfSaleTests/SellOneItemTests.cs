using PointOfSale;

namespace PointOfSaleTests;

public class SellOneItemTests {
    [Fact]
    public void EmptyCode() {
        Display display = new();
        SaleOrder order = new(display);
        Scanner scanner = new(order);

        scanner.Scan("");

        Assert.Equal("Error: Empty code", display.Text);
    }
}