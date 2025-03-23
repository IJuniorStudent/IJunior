namespace Practice_35;

class Program
{
    static void Main(string[] args)
    {
        const string CommandAddEmployee = "1";
        const string CommandRemoveEmployee = "2";
        const string CommandDisplayEmploeeList = "3";
        const string CommandExit = "4";
        
        List<string> employeeNames = new List<string>();
        List<string> jobNames = new List<string>();
        Dictionary<string, int> jobStats = new Dictionary<string, int>();
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
                    AddEmployee(employeeNames, jobNames, jobStats);
                    break;
                
                case CommandRemoveEmployee:
                    RemoveEmployee(employeeNames, jobNames, jobStats);
                    break;
                
                case CommandDisplayEmploeeList:
                    DisplayEmployeeList(employeeNames, jobNames, jobStats);
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Console.WriteLine($"Неизвестный номер операции: \"{userInput}\"");
                    WaitAnyKeyPress();
                    break;
            }
        }
    }
    
    static void AddEmployee(List<string> names, List<string> jobs, Dictionary<string, int> stats)
    {
        Console.Clear();
        
        string firstName = ReadUserInput("Введите имя");
        string lastName = ReadUserInput("Введите фамилию");
        string jobName = ReadUserInput("Введите должность");
        
        names.Add($"{lastName} {firstName}");
        jobs.Add(jobName);
        
        if (stats.ContainsKey(jobName) == false)
            stats.Add(jobName, 0);
        
        stats[jobName]++;
    }
    
    static void RemoveEmployee(List<string> names, List<string> jobs, Dictionary<string, int> stats)
    {
        int employeeNumber = ReadNumberInput("Введите номер сотрудника для удаления");
        int employeeIndex = employeeNumber - 1;
        
        if (employeeIndex < 0 || employeeIndex >= names.Count)
        {
            Console.WriteLine($"Сотрудник с номером {employeeNumber} отсутствует в списке");
            WaitAnyKeyPress();
            return;
        }
        
        string jobName = jobs[employeeIndex];
        
        names.RemoveAt(employeeIndex);
        jobs.RemoveAt(employeeIndex);
        
        stats[jobName]--;
        
        if (stats[jobName] == 0)
            stats.Remove(jobName);
    }
    
    static void DisplayEmployeeList(List<string> names, List<string> jobs, Dictionary<string, int> stats)
    {
        Console.Clear();
        
        Console.WriteLine("Список сотрудников:");
        
        for (int i = 0; i < names.Count; i++)
            Console.WriteLine($"{i + 1}. {names[i]} - {jobs[i]}");
        
        Console.WriteLine();
        Console.WriteLine("Текущие должности:");
        
        foreach (var jobStat in stats)
            Console.WriteLine($"{jobStat.Key} - {jobStat.Value}");
        
        WaitAnyKeyPress();
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
        {
            Console.WriteLine("Число введено некорректно");
            WaitAnyKeyPress();
        }
        
        return number;
    }
    
    static void WaitAnyKeyPress()
    {
        Console.WriteLine();
        Console.WriteLine("Для продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}
