namespace VendingMachineLLD;

public class VendingMachine
{
    private IState _currentState;
    private int  _currentTotalMoney;
    private Dictionary<int, Item>  _items;
    private int _totalMoneyTillNow;
    private int _currentSelectedProduct;

    public VendingMachine()
    {
        _currentState = new IdleState();
        _currentTotalMoney = 0;
        _currentSelectedProduct = 0;
        _items = new Dictionary<int, Item>();
    }
    public void SetCurrentState(IState state)
    {
        _currentState = state;
    }

    public void UpdateInventory(Item item, int codeNumber)
    {
        _currentState.UpdateInventory(this, item, codeNumber);
    }
    
    public void ClickInsertMoneyButton()
    {
        _currentState.InsertMoneyButton(this);
    }
    
    public void InsertMoney(Money money)
    {
        _currentState.InsertMoney(this, money);
    }

    public void SelectProductButton()
    {
        _currentState.SelectProductButton(this);
    }

    public void SelectProduct(int codeNumber)
    {
        _currentState.SelectProduct(this,codeNumber);
    }
    
    public void RefundMoney()
    {
        _currentState.RefundFullMoney(this,  _currentTotalMoney);
    }
    
    public void DispenseProduct()
    {
        _currentState.DispneProduct(this);
    }
    
    internal Item GetItem(int codeNumber)
    {
        return _items[codeNumber];
    }

    internal int GetCurrentTotalMoney()
    {
        return _currentTotalMoney;
    }
   

    public int GetTotalMoneyCollected()
    {
        return _totalMoneyTillNow;
    }
    
    internal void SetTotalMoney(int totalMoney)
    {
        _currentTotalMoney = totalMoney;
    }

    internal void AddProducts(int codeNumber, Item item)
    {
        _items.Add(codeNumber, item);
        Console.WriteLine($"Added {item.Name} to {codeNumber} in Inventory");
    }

    internal void AddMoney(Money money)
    {
        _currentTotalMoney +=(int)money;
    }

    internal void SelectProductToDispense(int codeNumber)
    {
        _currentSelectedProduct = codeNumber;
    }

    internal int GetProductNumberToBeDispensed()
    {
        return _currentSelectedProduct;
    }
    internal Item GetProduct(int codeNumber)
    {
        return _items[codeNumber];
    }

    internal void RemoveProduct(int codeNumber)
    {
        _items.Remove(codeNumber);
    }

    internal void AddTotalMoneyTillNow()
    {
        _totalMoneyTillNow += _currentTotalMoney;
    }
}