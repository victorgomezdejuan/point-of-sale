namespace PointOfSale.Domain;
public class Price {
    public decimal Value { get; private set; }

    public char Currency { get; private set; }

    public Price(decimal value, char currency) {
        Value = value;
        Currency = currency;
    }
}
