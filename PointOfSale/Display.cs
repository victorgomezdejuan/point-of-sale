using PointOfSale.Domain;
using System.Globalization;

namespace PointOfSale;
public class Display {
    public string Text { get; private set; }

    public void DisplayContent(string text) {
        Text = text;
    }

    public void DisplayEmptyCode() => DisplayContent("Error: Empty code");

    public void DisplayPrice(Price price) => DisplayContent(FormatPrice(price));

    public static string FormatPrice(Price price) => price.Value.ToString("N2", CultureInfo.GetCultureInfo("es-ES")) + " " + price.Currency;

    public void DisplayInvalidCode() => DisplayContent("Error: Invalid code");

    public void DisplayProductNotFound() => DisplayContent("Error: Product not found");

    public void DisplayNoItemsToSale() => DisplayContent("Error: No items to sale");

    public void DisplayTotal(Price total) => DisplayContent("Total: " + FormatPrice(total));
}
