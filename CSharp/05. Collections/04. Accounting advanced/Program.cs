namespace Practice_35;

class Program
{
    static void Main(string[] args)
    {
        const string CommandAddEmployee = "1";
        const string CommandRemoveEmployee = "2";
        const string CommandDisplayEmploeeList = "3";
        const string CommandExit = "4";
        
        Dictionary<string, List<string>> employeeDatabase = new Dictionary<string, List<string>>();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine("Укажите номер операции:");
            Console.WriteLine($"{CommandAddEmployee}. Добавить сотрудника");
            Console.WriteLine($"{CommandRemoveEmployee}. Удалить сотрудника");
            Console.WriteLine($"{CommandDisplayEmploeeList}. Показать весь список сотрудников");
            Console.WriteLine($"{CommandExit}. Выход");
            
            string userInput = ReadUserInput("");
            
            switch (userInput)
            {
                case CommandAddEmployee:
                    AddEmployee(employeeDatabase);
                    break;
                
                case CommandRemoveEmployee:
                    RemoveEmployees(employeeDatabase);
                    break;
                
                case CommandDisplayEmploeeList:
                    DisplayEmployeeList(employeeDatabase);
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    DisplayWaitMessage($"Неизвестный номер операции: \"{userInput}\"");
                    break;
            }
        }
    }
    
    static string FormatEmployeeName(string fistName, string lastName)
    {
        return $"{lastName} {fistName}";
    }
    
    static void AddEmployee(Dictionary<string, List<string>> database)
    {
        Console.Clear();
        Console.WriteLine("Добавление сотрудника");
        Console.WriteLine();
        
        string firstName = ReadUserInput("Введите имя");
        string lastName = ReadUserInput("Введите фамилию");
        string jobName = ReadUserInput("Введите должность");
        
        if (database.ContainsKey(jobName) == false)
            database.Add(jobName, []);
        
        database[jobName].Add(FormatEmployeeName(firstName, lastName));
    }
    
    static void RemoveEmployees(Dictionary<string, List<string>> database)
    {
        Console.Clear();
        Console.WriteLine("Удаление сотрудника");
        Console.WriteLine();
        
        string firstName = ReadUserInput("Введите имя");
        string lastName = ReadUserInput("Введите фамилию");
        
        string fullName = FormatEmployeeName(firstName, lastName);
        List<string> jobNames = database.Keys.ToList();
        int removedCount = 0;
        
        foreach (var jobName in jobNames)
        {
            removedCount += database[jobName].RemoveAll(element => element == fullName);
            
            if (database[jobName].Count == 0)
                database.Remove(jobName);
        }
        
        if (removedCount > 0)
            DisplayWaitMessage($"Удалено {removedCount} сотрудников с именем \"{fullName}\"");
        else
            DisplayWaitMessage($"Сотрудники с именем \"{fullName}\" не найдены");
    }
    
    static void DisplayEmployeeList(Dictionary<string, List<string>> database)
    {
        Console.Clear();
        
        if (database.Count == 0)
        {
            DisplayWaitMessage("В базе данных нет ни одного сотрудника");
            return;
        }
        
        Console.WriteLine("Список должностей и сотрудников:");
        Console.WriteLine();
 
        foreach (var job in database)
        {
            Console.WriteLine(job.Key);
            
            foreach (string employeeName in job.Value)
                Console.WriteLine($"- {employeeName}");
            
            Console.WriteLine();
        }
        
        WaitAnyKeyPress();
    }
    
    static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    static void DisplayWaitMessage(string message)
    {
        Console.WriteLine(message);
        WaitAnyKeyPress();
    }
    
    static void WaitAnyKeyPress()
    {
        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}
