namespace VendingMachineLLD;

public interface IState
{
    void InsertMoneyButton(VendingMachine vm);
    void InsertMoney(VendingMachine vm, Money money);
    
    void SelectProductButton(VendingMachine vm);
    void SelectProduct(VendingMachine vm, int codeNumber);
    
    void DispneProduct(VendingMachine vm);
    void RefundFullMoney(VendingMachine vm, int totalMoney);
    
    void UpdateInventory(VendingMachine vm, Item item, int codeNumber);
}