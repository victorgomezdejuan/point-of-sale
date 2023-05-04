using PointOfSale;

namespace PointOfSaleTests;

public class SellOneItemTests {
    [Fact]
    public void EmptyCode() {
        Scanner scanner = new();
        Display display = new();
        SaleOrder order = new(scanner, display);

        scanner.Scan("");

        Assert.Equal("Error: Empty code", display.GetText());
    }
}