namespace Src;

public class Watcher
{
    private string _name;

    public Watcher(string name)
    {
        _name = name;
    }

    public void HandleStockPriceChange(object? sender, StockPriceChangedEventArgs e)
    {
        var stock = sender as IStock;
        Console.WriteLine($"{_name} Notified: {stock?.Name} changed to {e.Price}");
    }
}