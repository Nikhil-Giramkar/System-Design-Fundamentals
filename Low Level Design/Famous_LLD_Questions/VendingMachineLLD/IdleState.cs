namespace VendingMachineLLD;

public class IdleState : IState
{
    public IdleState()
    {
        Console.WriteLine("Machine Is In Idle State");
    }
    public void InsertMoneyButton(VendingMachine vm)
    {
        vm.SetCurrentState(new MoneyAcceptanceState());
    }

    public void InsertMoney(VendingMachine vm, Money money)
    {
        RefundFullMoney(vm, (int)money);
        throw new Exception("Cannot insert money in Idle State, collect you money from Tray");
    }

    public void SelectProductButton(VendingMachine vm)
    {
        throw new Exception("Cannot click select product button in Idle State, first insert money");
    }

    public void SelectProduct(VendingMachine vm, int codeNumber)
    {
        throw new Exception("Cannot select product in Idle State, first insert money");
    }

    public void DispneProduct(VendingMachine vm)
    {
        throw new Exception("Cannot Dispense Product in Idle State, first insert money, select product");
    }

    public void RefundFullMoney(VendingMachine vm,  int totalMoney)
    {
        if (totalMoney == 0)
        {
            throw new Exception("No money inserted");
        }
        Console.WriteLine("Collect you money from Tray", totalMoney);
    }

    public void UpdateInventory(VendingMachine vm, Item item, int codeNumber)
    {
        vm.AddProducts(codeNumber, item);
    }
}