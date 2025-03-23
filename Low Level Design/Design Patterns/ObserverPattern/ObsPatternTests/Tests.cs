using Src;
using Xunit;

namespace ObsPatternTests;

public class ObserverPatternTests
{
    [Fact]
    public void Stock_PriceChange_Notified_To_Observers()
    {
        // Arrange
        var stock = new Stock("Infosys", 100);
        var user1Notifications = new List<string>();
        var user2Notifications = new List<string>();

        stock.StockPriceChanged+= (sender, e) => user1Notifications.Add($"Alice received stock update: New price is {e.Price}");
        stock.StockPriceChanged += (sender, e) => user2Notifications.Add($"Bob received stock update: New price is {e.Price}");
        
        // Act
        stock.Price = 110.50m;
        stock.Price = 120.00m;
        
        // Assert
        Assert.Equal(2, user1Notifications.Count);
        Assert.Equal(2, user2Notifications.Count);

        Assert.Equal("Alice received stock update: New price is 110.50", user1Notifications[0]);
        Assert.Equal("Bob received stock update: New price is 110.50", user2Notifications[0]);
        Assert.Equal("Alice received stock update: New price is 120.00", user1Notifications[1]);
        Assert.Equal("Bob received stock update: New price is 120.00", user2Notifications[1]);
    }
    
    [Fact]
    public void Stock_PriceChanged_Event_Only_Notifies_Subscribed_Observers()
    {
        // Arrange
        var stock = new Stock("Infosys", 100);
        var user1 = new Watcher("Nikhil");
        var user2 = new Watcher("Ansh");
        
        stock.StockPriceChanged+= user1.HandleStockPriceChange;
        stock.StockPriceChanged += user2.HandleStockPriceChange;

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter); // Redirect console output
        
        // Act
        stock.Price = 110.50m;
        stock.StockPriceChanged -= user1.HandleStockPriceChange;
        stock.Price = 120.00m;

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Nikhil Notified: Infosys changed to 110.5", output);
        Assert.Contains("Ansh Notified: Infosys changed to 110.5", output);
        Assert.DoesNotContain("Nikhil Notified: Infosys changed to 120", output);
        Assert.Contains("Ansh Notified: Infosys changed to 120", output);
        
        // Restore the original console output
        Console.SetOut(Console.Out);
    }
}