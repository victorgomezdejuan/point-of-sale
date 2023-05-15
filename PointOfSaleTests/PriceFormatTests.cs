using PointOfSale;
using PointOfSale.Domain;

namespace PointOfSaleTests;
public class PriceFormatTests {
    [Fact]
    public void FormatPrice() {
        AssertPriceFormat(0M, "0,00 €");
        AssertPriceFormat(0.1M, "0,10 €");
        AssertPriceFormat(0.01M, "0,01 €");
        AssertPriceFormat(1M, "1,00 €");
        AssertPriceFormat(5.43M, "5,43 €");
        AssertPriceFormat(1185.17M, "1.185,17 €");
        AssertPriceFormat(1185M, "1.185,00 €");
        AssertPriceFormat(8432172.11M, "8.432.172,11 €");
    }

    private static void AssertPriceFormat(decimal value, string format) {
        Price price = new(value, '€');
        string formattedPrice = Display.FormatPrice(price);
        Assert.Equal(format, formattedPrice);
    }
}
