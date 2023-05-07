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

        if (string.IsNullOrEmpty(input))
            DisplayEmptyCode();
        else if (input.Length != 13 || !long.TryParse(input, out _))
            DisplayInvalidCode();
        else if (!pricesByProductCode.ContainsKey(input))
            DisplayProductNotFound();
        else {
            DisplayPrice(GetPriceByProductCode(input));
        }
    }

    private void DisplayPrice(string formattedPrice) => display.DisplayContent(formattedPrice);

    private void DisplayEmptyCode() => display.DisplayContent("Error: Empty code");

    private void DisplayInvalidCode() => display.DisplayContent("Error: Invalid code");

    private void DisplayProductNotFound() => display.DisplayContent("Error: Product not found");

    private string GetPriceByProductCode(string input) => pricesByProductCode[input];
}
