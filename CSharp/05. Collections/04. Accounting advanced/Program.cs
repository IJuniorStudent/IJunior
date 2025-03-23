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
                    RemoveEmployeeJob(employeeDatabase);
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
 
    static void RemoveEmployeeJob(Dictionary<string, List<string>> database)
    {
        Console.Clear();
        
        if (database.Count == 0)
        {
            DisplayWaitMessage("В базе данных нет ни одного сотрудника");
            return;
        }
        
        Console.WriteLine("Удаление сотрудника");
        Console.WriteLine();
        
        List<string> jobNames = database.Keys.ToList();
        
        if (AskSelectListIndex("Введите номер должности, для снятия сотрудника", jobNames, out int jobIndex) == false)
        {
            DisplayWaitMessage("Должность с таким номером отсутствует в базе данных");
            return;
        }
        
        Console.WriteLine();
        
        string jobName = jobNames[jobIndex];
        List<string> employeeList = database[jobName];
        
        if (AskSelectListIndex("Введите номер сотрудника для снятия с должности", employeeList, out int employeeIndex) == false)
        {
            DisplayWaitMessage("Сотрудник с таким номером не занимает выбранную должность");
            return;
        }
        
        string employeeName = employeeList[employeeIndex];
        employeeList.RemoveAt(employeeIndex);
        
        if (employeeList.Count == 0)
            database.Remove(jobName);
        
        DisplayWaitMessage($"Сотрудник \"{employeeName}\" снят с должности \"{jobName}\"");
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
 
    static bool AskSelectListIndex(string promptMessage, List<string> list, out int selectedIndex)
    {
        DisplayNumberedList(list);
 
        int userNumber = ReadNumberInput(promptMessage);
        selectedIndex = userNumber - 1;
        
        return selectedIndex >= 0 && selectedIndex < list.Count;
    }
    
    static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    static int ReadNumberInput(string promptMessage)
    {
        int number;
        
        while (int.TryParse(ReadUserInput(promptMessage), out number) == false)
            DisplayWaitMessage("Число введено некорректно");
        
        return number;
    }
 
    static void DisplayNumberedList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
            Console.WriteLine($"{i + 1}. {list[i]}");
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
