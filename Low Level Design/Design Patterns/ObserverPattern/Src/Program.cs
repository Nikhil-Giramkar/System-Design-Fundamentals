namespace Src;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");
        var adani = new Stock("Adani", 100);
        var tata = new Stock("Tata", 150); 
        var reliance = new Stock("Reliance", 50);

        var nikhil = new Watcher("Nikhil");
        var ansh = new Watcher("Ansh");
        var suraj = new Watcher("Suraj");
        
        
        //Subscribe
        //Nikhil is interested in Adani and Reliance
        adani.StockPriceChanged += nikhil.HandleStockPriceChange;
        reliance.StockPriceChanged += nikhil.HandleStockPriceChange;
        
        //Ansh is interested in all
        adani.StockPriceChanged += ansh.HandleStockPriceChange;
        reliance.StockPriceChanged += ansh.HandleStockPriceChange;
        tata.StockPriceChanged += ansh.HandleStockPriceChange;
        
        //Suraj interested in tata only
        tata.StockPriceChanged += suraj.HandleStockPriceChange;
    
        
        //....
        //Adani price changed
        adani.Price = 200;
        
        //Tata price changed
        tata.Price = 40;
        
        //Unsubscribe
        //Nikhil not interested in Adani
        adani.StockPriceChanged -= nikhil.HandleStockPriceChange;
        
        //Adani changes 
        adani.Price = 90;



    }
}