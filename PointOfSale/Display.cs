namespace PointOfSale;
public class Display {
    public string Text { get; private set; }

    public void DisplayContent(string text) {
        Text = text;
    }

    public void DisplayEmptyCode() => DisplayContent("Error: Empty code");

    public void DisplayPrice(string formattedPrice) => DisplayContent(formattedPrice);

    public void DisplayInvalidCode() => DisplayContent("Error: Invalid code");

    public void DisplayProductNotFound() => DisplayContent("Error: Product not found");
}
