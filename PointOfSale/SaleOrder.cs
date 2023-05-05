namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Dictionary<string, string> pricesByProductCode;
    private Scanner scanner;
    private Display display;

    public SaleOrderHandler(Scanner scanner, Display display, Dictionary<string, string> pricesByProductCode) {
        this.scanner = scanner;
        this.display = display;
        this.pricesByProductCode = pricesByProductCode;
    }

    public void Submit() {
        string input = scanner.Input;


        if (string.IsNullOrEmpty(input)) {
            display.DisplayContent("Error: Empty code");
        }
        else if (input.Length != 13 || !long.TryParse(input, out _)) {
            display.DisplayContent("Error: Invalid code");
        }
        else {
            if (!pricesByProductCode.ContainsKey(input))
                display.DisplayContent("Error: Product not found");
            else
                display.DisplayContent(pricesByProductCode[input]);
        }
    }
}
