namespace VendingMachineLLD;

public class DispenseState : IState
{
    public DispenseState()
    {
        Console.WriteLine("Machine Is In Dispense State");
    }
    public void InsertMoneyButton(VendingMachine vm)
    {
        throw new Exception("Cannot click insert money button in Dispense state");
    }

    public void InsertMoney(VendingMachine vm, Money money)
    {
        throw new Exception("Cannot insert money in Dispense state");
    }

    public void SelectProductButton(VendingMachine vm)
    {
        throw new Exception("Cannot select product in Dispense state");
    }

    public void SelectProduct(VendingMachine vm, int codeNumber)
    {
        throw new Exception("Cannot select another product in Dispense state");
    }

    public void DispneProduct(VendingMachine vm)
    {
        var item = vm.GetProduct(vm.GetProductNumberToBeDispensed());
        Console.WriteLine($"Dispensing product {item.Name}");
        Console.WriteLine("Collect it from tray");
        
        vm.RemoveProduct(vm.GetProductNumberToBeDispensed());
        Console.WriteLine($"Removed {item.Name} from Inventory");
        
        vm.AddTotalMoneyTillNow();
        vm.SelectProductToDispense(0);
        vm.SetTotalMoney(0);
        vm.SetCurrentState(new IdleState());
    }

    public void RefundFullMoney(VendingMachine vm, int totalMoney)
    {
        throw new Exception("Cannot return  refund in Dispense state");
    }

    public void UpdateInventory(VendingMachine vm, Item item, int codeNumber)
    {
        throw new Exception("Cannot update inventory in Dispense state");
    }
}