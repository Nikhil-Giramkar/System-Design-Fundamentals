namespace VendingMachineLLD;

public class ProductSelectionState : IState
{
    public ProductSelectionState()
    {
        Console.WriteLine("Machine Is In ProductSelectionState State");
    }
    
    public void InsertMoneyButton(VendingMachine vm)
    {
        throw new Exception("Money is already inserted, now select a product");
    }

    public void InsertMoney(VendingMachine vm, Money money)
    {
        throw new Exception("Money is already inserted, now select a product");
    }

    public void SelectProductButton(VendingMachine vm)
    {
        throw new Exception("Button already clicked, enter code number");
    }

    public void SelectProduct(VendingMachine vm, int codeNumber)
    {
        
       var item = vm.GetItem(codeNumber);
       Console.WriteLine($"Selected Code number - {codeNumber}");
       if (item.Price > vm.GetCurrentTotalMoney())
       {
           throw new Exception("Insufficient funds money added");
       }
       int change = vm.GetCurrentTotalMoney() - item.Price;
       if (change > 0)
       {
           GetChange(vm, change);
       }
       vm.SelectProductToDispense(codeNumber);
       vm.SetCurrentState(new DispenseState());
        
    }

    public void DispneProduct(VendingMachine vm)
    {
        throw new Exception("Cannot Dispense product in selection state");
    }

    private void GetChange(VendingMachine vm,  int change)
    {
        Console.WriteLine($"Collect Rs.{change} change from tray");
        vm.SetTotalMoney(vm.GetCurrentTotalMoney() -  change);
    }

    public void RefundFullMoney(VendingMachine vm, int totalMoney)
    {
        Console.WriteLine("Collect your money from Tray, going back to Idle State");
        vm.SetTotalMoney(0);
        vm.SetCurrentState(new IdleState());
    }

    public void UpdateInventory(VendingMachine vm, Item item, int codeNumber)
    {
        throw new Exception("Cannot Update inventory in selection state");
    }
}