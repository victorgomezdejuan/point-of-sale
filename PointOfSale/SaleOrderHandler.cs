﻿namespace PointOfSale;
public class SaleOrderHandler {
    private readonly Catalog catalog;
    private readonly Scanner scanner;
    private readonly Display display;

    public SaleOrderHandler(Scanner scanner, Display display, Catalog catalog) {
        this.scanner = scanner;
        this.display = display;
        this.catalog = catalog;
    }

    public void Submit() {
        string productCode = scanner.Input;

        if (string.IsNullOrEmpty(productCode))
            display.DisplayEmptyCode();
        else if (productCode.Length != 13 || !long.TryParse(productCode, out _))
            display.DisplayInvalidCode();
        else if (!catalog.HasProduct(productCode))
            display.DisplayProductNotFound();
        else
            display.DisplayPrice(catalog.GetPriceByProductCode(productCode));
    }
}
