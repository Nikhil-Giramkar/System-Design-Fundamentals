namespace VendingMachineLLD;

public class Item
{
    public int Price{get;set;}
    public string Name {get;set;}

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }
}