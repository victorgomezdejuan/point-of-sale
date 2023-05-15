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
}
