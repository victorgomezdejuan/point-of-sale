namespace PointOfSale;
public class SaleOrder {
    private Scanner scanner;
    private Display display;
    private string itemId;

    public SaleOrder(Display display) {
        this.display = display;
    }

    internal void AddItem(string input) {
        if (string.IsNullOrEmpty(input)) {
            display.SetText("Error: Empty code");
        }
    }
}
