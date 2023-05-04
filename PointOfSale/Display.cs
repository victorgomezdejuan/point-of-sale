namespace PointOfSale;
public class Display {
    public string Text { get; private set; }

    internal void SetText(string text) {
        Text = text;
    }
}
