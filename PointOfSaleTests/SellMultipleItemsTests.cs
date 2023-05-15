using PointOfSale;
using PointOfSale.Domain;

namespace PointOfSaleTests;
public class SellMultipleItemsTests {
    private readonly Display _display;
    private readonly Scanner _scanner;

    public SellMultipleItemsTests() {
        _display = new();
        _scanner = new();
    }

    [Fact]
    public void NoScans() {
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(new Dictionary<string, Product>()));

        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", _display.Text);
    }

    [Fact]
    public void OneScan_ProductNotFound() {
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(new Dictionary<string, Product>()));

        _scanner.Scan("Not found product");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", _display.Text);
    }

    [Fact]
    public void OneScan_ProductFound() {
        var pricesByProductCode = new Dictionary<string, Product> {
            { "1234567890123", new Product("1234567890123", new Price(5.43M, '€')) }
        };
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(pricesByProductCode));

        _scanner.Scan("1234567890123");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 5,43 €", _display.Text);
    }

    [Fact]
    public void MultipleScans_AllProductsNotFound() {
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(new Dictionary<string, Product>()));

        _scanner.Scan("Product not found");
        handler.SubmitItem();
        _scanner.Scan("Another product not found");
        handler.SubmitItem();
        _scanner.Scan("And another product not found");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Error: No items to sale", _display.Text);
    }

    [Fact]
    public void MultipleScans_AllProductsFound() {
        var pricesByProductCode = new Dictionary<string, Product> {
            { "1234567890123", new Product("1234567890123", new Price(5.43M, '€')) },
            { "1234567890124", new Product("1234567890124", new Price(15.01M, '€')) },
            { "1234567890125", new Product("1234567890125", new Price(3.29M, '€')) }
        };
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(pricesByProductCode));

        _scanner.Scan("1234567890123");
        handler.SubmitItem();
        _scanner.Scan("1234567890124");
        handler.SubmitItem();
        _scanner.Scan("1234567890125");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 23,73 €", _display.Text);
    }

    [Fact]
    public void MultipleScans_OneProductNotFound() {
        var pricesByProductCode = new Dictionary<string, Product> {
            { "1234567890123", new Product("1234567890123", new Price(2.11M, '€')) },
            { "1234567890124", new Product("1234567890124", new Price(5M, '€')) },
            { "1234567890125", new Product("1234567890125", new Price(25.77M, '€')) }
        };
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(pricesByProductCode));

        _scanner.Scan("1234567890123");
        handler.SubmitItem();
        _scanner.Scan("Non existing product in catalog");
        handler.SubmitItem();
        _scanner.Scan("1234567890125");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 27,88 €", _display.Text);
    }

    [Fact]
    public void MultipleScans_OneEmpty() {
        var pricesByProductCode = new Dictionary<string, Product> {
            { "1234567890123", new Product("1234567890123", new Price(2.11M, '€')) },
            { "1234567890124", new Product("1234567890124", new Price(5M, '€')) },
            { "1234567890125", new Product("1234567890125", new Price(25.77M, '€')) }
        };
        SaleOrderHandler handler = new(_scanner, _display, new Catalog(pricesByProductCode));

        _scanner.Scan("1234567890123");
        handler.SubmitItem();
        _scanner.Scan("");
        handler.SubmitItem();
        _scanner.Scan("1234567890125");
        handler.SubmitItem();
        handler.SubmitTotal();

        Assert.Equal("Total: 27,88 €", _display.Text);
    }
}
