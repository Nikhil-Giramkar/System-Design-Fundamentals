namespace Src;

public interface IStock
{
    event EventHandler<StockPriceChangedEventArgs> StockPriceChanged;
    decimal Price { get; set; }
    string Name { get; set; }
}