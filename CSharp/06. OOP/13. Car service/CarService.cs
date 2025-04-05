namespace Practice_49;

using Factories;

public class CarService
{
    private Dictionary<string, PartStorage> _storages;
    private Queue<Car> _cars;
    private int _money;
    private int _repairPrice;
    private int _penaltyPerPart;
    
    public CarService(PartStorageFactory partFactory, CarFactory carFactory, int repairPrice, int penaltyPerPart, int balance)
    {
        _storages = partFactory.Create();
        _cars = carFactory.Create();
        _repairPrice = repairPrice;
        _penaltyPerPart = penaltyPerPart;
        _money = balance;
    }
    
    public int Money => _money;
    public int QueueSize => _cars.Count;
    public bool IsOpen => QueueSize > 0 && Money >= 0;
    
    public void ServeNext()
    {
        const string CommandAbortRepair = "abort";
        
        Car car = _cars.Dequeue();
        var invoice = new Invoice(car.Parts);
        
        if (invoice.PartsCount == 0)
        {
            Utils.PrintWaitMessage("Стекло протерли, колесо попинали. Готово");
            return;
        }
        
        bool isServe = true;
        
        while (isServe)
        {
            Console.Clear();
            
            DisplayRepairInfo(invoice);
            DisplayPartsToRepair(invoice);
            
            string userInput = Utils.ReadUserInput($"Выберите деталь для замены или введите \"{CommandAbortRepair}\" для отказа от ремонта");
            
            if (userInput == CommandAbortRepair)
            {
                _money -= CalculateAbortPenalty(invoice);
                isServe = false;
                continue;
            }
            
            if (TryConvertInputToIndex(userInput, invoice.PartsCount, out int index) == false)
                continue;
            
            if (TryRepairPart(invoice, index) == false)
                continue;

            if (invoice.PartsCount == invoice.RepairedCount)
            {
                int repairPrice = invoice.RepairFee + _repairPrice;
                
                _money += repairPrice;
                isServe = false;
                
                Utils.PrintWaitMessage($"Машина полностью обслужена! Вы заработали: {repairPrice}");
            }
        }
    }
    
    private int CalculateAbortPenalty(Invoice invoice)
    {
        int damagedPartsCount = invoice.PartsCount - invoice.RepairedCount;
        return damagedPartsCount == invoice.PartsCount ? _repairPrice : damagedPartsCount * _penaltyPerPart;
    }
    
    private void DisplayRepairInfo(Invoice invoice)
    {
        Console.WriteLine($"Заменено деталей: {invoice.RepairedCount}. Заработок: {invoice.RepairFee + _repairPrice}");
        Console.WriteLine($"Штраф за отказ от ремонта: {CalculateAbortPenalty(invoice)}");
        Console.WriteLine();
    }
    
    private void DisplayPartsToRepair(Invoice invoice)
    {
        Console.WriteLine("Заказ-наряд:");
        
        for (int i = 0; i < invoice.PartsCount; i++)
        {
            InvoiceCarPart details = invoice.GetPartDetails(i);
            PartStorage storage = _storages[details.Type];
            string partRepairStatus =
                details.IsDamaged ?
                    $"Стоимость ремонта: {details.Price}. Количество на складе: {storage.Amount}" :
                    "Исправно";
            
            Console.WriteLine($"{i + 1}. {details.Type}. {partRepairStatus}");
        }
        
        Console.WriteLine();
    }
    
    private bool TryConvertInputToIndex(string userInput, int maxValue, out int index)
    {
        index = 0;
        
        if (int.TryParse(userInput, out int number) == false)
        {
            Utils.PrintWaitMessage($"Значение \"{userInput}\" не является числом");
            return false;
        }
        
        index = number - 1;
        
        if (index < 0 || index >= maxValue)
        {
            Utils.PrintWaitMessage($"Некорректный номер: {number}");
            return false;
        }
        
        return true;
    }

    private bool TryRepairPart(Invoice invoice, int partIndex)
    {
        InvoiceCarPart details = invoice.GetPartDetails(partIndex);
        PartStorage storage = _storages[details.Type];

        if (details.IsDamaged == false)
        {
            Utils.PrintWaitMessage("Замена детали не требуется. Еще походит");
            return false;
        }
        
        if (storage.TryTake() == false)
        {
            Utils.PrintWaitMessage("На складе закончилась эта деталь");
            return false;
        }
        
        invoice.Repair(partIndex);
        return true;
    }
}
