namespace PointOfSale;
public class Scanner {
    private readonly SaleOrder order;

    public Scanner(SaleOrder order) {
        this.order = order;
    }

    public void Scan(string input) {
        order.AddItem(input);
    }
}
