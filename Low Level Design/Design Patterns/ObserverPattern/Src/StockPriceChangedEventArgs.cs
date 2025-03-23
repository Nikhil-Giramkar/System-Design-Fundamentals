namespace Src;

public class StockPriceChangedEventArgs : EventArgs
{
    public decimal Price { get; set; }

    public StockPriceChangedEventArgs(decimal newPrice)
    {
        Price = newPrice;
    }
}