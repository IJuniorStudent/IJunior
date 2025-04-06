namespace Practice_49;

using Factories;

public class CarService
{
    private Dictionary<string, Shelf> _storages;
    private Queue<Car> _cars;
    private int _repairPrice;
    private int _penaltyPerPart;
    
    public CarService(PartStorageFactory partFactory, CarFactory carFactory, int repairPrice, int penaltyPerPart, int balance)
    {
        _storages = partFactory.Create();
        _cars = carFactory.Create();
        _repairPrice = repairPrice;
        _penaltyPerPart = penaltyPerPart;
        Money = balance;
    }
    
    public int Money { get; private set; }
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
            
            var damagedParts = invoice.GetPartTypes();
            
            DisplayRepairInfo(invoice);
            DisplayPartsToRepair(damagedParts, invoice);
            
            string userInput = Utils.ReadUserInput($"Выберите деталь для замены или введите \"{CommandAbortRepair}\" для отказа от ремонта");
            
            if (userInput == CommandAbortRepair)
            {
                Money -= CalculateAbortPenalty(invoice);
                isServe = false;
                continue;
            }
            
            if (TrySelectRepairPartType(damagedParts, userInput, out string partType) == false)
                continue;
            
            if (TryRepairPart(car, partType) == false)
                continue;
            
            invoice.RegisterRepairedPart(partType);
            
            if (car.IsDamaged == false)
            {
                int repairPrice = invoice.RepairFee + _repairPrice;
                
                Money += repairPrice;
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
    
    private void DisplayPartsToRepair(List<string> damagedParts, Invoice invoice)
    {
        Console.WriteLine("Заказ-наряд:");
        
        for (int i = 0; i < damagedParts.Count; i++)
        {
            string partType = damagedParts[i];
            Shelf storage = _storages[partType];
            
            string partRepairStatus =
                invoice.IsPartRepaired(partType) == false ?
                    $"Стоимость ремонта: {invoice.GetPartRepairPrice(partType)}. Количество на складе: {storage.Count}" :
                    "Исправно";
            
            Console.WriteLine($"{i + 1}. {partType}. {partRepairStatus}");
        }
        
        Console.WriteLine();
    }
    
    private bool TrySelectRepairPartType(List<string> damagedParts, string userInput, out string partType)
    {
        partType = "";
        
        if (int.TryParse(userInput, out int number) == false)
        {
            Utils.PrintWaitMessage($"Значение \"{userInput}\" не является числом");
            return false;
        }
        
        int index = number - 1;
        
        if (index < 0 || index >= damagedParts.Count)
        {
            Utils.PrintWaitMessage($"Некорректный номер: {number}");
            return false;
        }
        
        partType = damagedParts[index];
        return true;
    }
    
    private bool TryRepairPart(Car car, string partType)
    {
        if (car.HasPart(partType) == false)
        {
            Utils.PrintWaitMessage($"В машине отсутствует деталь \"{partType}\"");
            return false;
        }
        
        if (_storages.TryGetValue(partType, out Shelf storage) == false)
        {
            Utils.PrintWaitMessage($"Деталь \"{partType}\" отсутствует на складе");
            return false;
        }
        
        if (storage.TryTake(out CarPart part) == false)
        {
            Utils.PrintWaitMessage($"Деталь \"{partType}\" закончилась");
            return false;
        }
        
        car.ReplacePart(part);
        return true;
    }
}
