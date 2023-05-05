namespace PointOfSale;
public class Display {
    public string Text { get; private set; }

    internal void DisplayContent(string text) {
        Text = text;
    }
}
