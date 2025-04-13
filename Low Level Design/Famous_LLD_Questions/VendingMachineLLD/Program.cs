
using VendingMachineLLD;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        /*
         * https://www.youtube.com/watch?v=wOXs5Z_z0Ew&list=PL6W8uoQQ2c61X_9e6Net0WdYZidm7zooW&index=19&t=55s
         *
         * Question:
         * https://github.com/ashishps1/awesome-low-level-design/blob/main/solutions/csharp/vendingmachine/README.md
         * 
         * This is a typical problem to test State Design Pattern and should be solved using that only
         * Similar questions can be LLD of TV, MediaPlayer
         * 
         * The Vending Machine can be in 4 states
         * Idle
         * MoneyAccept
         * ProductSelect
         * DispenseProduct
         */
        
        VendingMachine vm = new VendingMachine();
        var coke = new Item("Pepsi", 50);
        var chips = new Item("Cheetos", 20);
        var soda = new Item("Kinley", 50);
        var cake = new Item("Cake", 30);
        try
        {
            vm.UpdateInventory(coke, 101);
            vm.UpdateInventory(chips, 102);
            vm.UpdateInventory(soda, 201);
            vm.UpdateInventory(cake, 202);

            vm.ClickInsertMoneyButton();
            vm.InsertMoney(Money.Note20);
            vm.InsertMoney(Money.Note20);
            vm.InsertMoney(Money.Note20);

            vm.SelectProductButton();
            vm.SelectProduct(201);

            vm.DispenseProduct();

            Console.WriteLine($"Total Money in Machine -  {vm.GetTotalMoneyCollected()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            vm.SetCurrentState(new IdleState());
        }
        

    }
}