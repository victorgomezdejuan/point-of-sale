namespace PointOfSale;
public class SaleOrderHandler {
    private Scanner scanner;
    private Display display;

    public SaleOrderHandler(Scanner scanner, Display display) {
        this.scanner = scanner;
        this.display = display;
    }

    public void Submit() {
        string input = scanner.Input;

        if (string.IsNullOrEmpty(input)) {
            display.DisplayContent("Error: Empty code");
        }
    }
}
