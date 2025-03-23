namespace Src;

public class Stock : IStock
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    private  decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                StockPriceChanged?.Invoke(this, new StockPriceChangedEventArgs(_price));
            }
        }
        
    }
    
    public event EventHandler<StockPriceChangedEventArgs>? StockPriceChanged;
    
    public Stock(string name, decimal price)
    {
        _price = price;
        _name = name;
    }
}