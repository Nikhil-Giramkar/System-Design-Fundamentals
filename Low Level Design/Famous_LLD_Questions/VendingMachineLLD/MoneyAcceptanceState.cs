namespace VendingMachineLLD;

public class MoneyAcceptanceState : IState
{
    public MoneyAcceptanceState()
    {
        Console.WriteLine("Machine Is In Money Acceptance State");
    }
    
    public void InsertMoneyButton(VendingMachine vm)
    {
        throw new Exception("Machine has already started accepting money");
    }

    public void InsertMoney(VendingMachine vm, Money money)
    {
        Console.WriteLine($"Accepted Rs. {(int)money}");
        vm.AddMoney(money);
    }

    public void SelectProductButton(VendingMachine vm)
    {
        vm.SetCurrentState(new ProductSelectionState());
    }

    public void SelectProduct(VendingMachine vm, int codeNumber)
    {
        throw new Exception("Cannot select product unless you click Select Product Button");
    }

    public void DispneProduct(VendingMachine vm)
    {
        throw new Exception("Cannot dispense product unless product is selected");
    }

    public void RefundFullMoney(VendingMachine vm, int totalMoney)
    {
        Console.WriteLine("Collect your money from Tray, going back to Idle State");
        vm.SetTotalMoney(0);
        vm.SetCurrentState(new IdleState());
    }

    public void UpdateInventory(VendingMachine vm, Item item, int codeNumber)
    {
        throw new Exception("Cannot update inventory, if machine is accepting money");
    }
}