namespace Practice_30;

class Program
{
    const string CommandAddEmployee = "1";
    const string CommandPrintAllEmployees = "2";
    const string CommandRemoveEmployee = "3";
    const string CommandFindEmployee = "4";
    const string CommandExit = "5";
    
    static void Main(string[] args)
    {
        string[] employeeNames = [];
        string[] employeeJobs = [];
        
        bool isAppRunning = true;
        
        while (isAppRunning)
        {
            PrintMenu();
            
            Console.WriteLine();
            
            switch (ReadUserInput("Укажите номер действия"))
            {
                case CommandAddEmployee:
                    Console.Clear();
                    
                    string firstName = ReadUserInput("Введите имя");
                    string lastName = ReadUserInput("Введите фамилию");
                    string parentName = ReadUserInput("Введите отчество");
                    string job = ReadUserInput("Укажите должность");
                    
                    AddEmployee(ref employeeNames, ref employeeJobs, $"{lastName} {firstName} {parentName}", job);
                    
                    Console.Clear();
                    break;
                
                case CommandPrintAllEmployees:
                    Console.Clear();
                    PrintEmployeesList(employeeNames, employeeJobs);
                    Console.WriteLine();
                    break;
                
                case CommandRemoveEmployee:
                    Console.Clear();
                    
                    if (employeeNames.Length == 0)
                    {
                        Console.WriteLine("Список сотрудников пуст\n");
                        continue;
                    }
                    
                    if (ReadNumberInput("Укажите номер сотрудника", out int employeeNumber) == false)
                    {
                        Console.WriteLine("Число введено некорректно\n");
                        continue;
                    }
                    
                    employeeNumber--;
                    
                    if (employeeNumber < 0 || employeeNumber >= employeeNames.Length)
                    {
                        Console.WriteLine($"Сотрудник с номером {employeeNumber + 1} отсутствует\n");
                        continue;
                    }
                    
                    RemoveEmployee(ref employeeNames, ref employeeJobs, employeeNumber - 1);
                    
                    Console.WriteLine("Данные сотрудника успешно удалены");
                    Console.WriteLine();
                    break;
                
                case CommandFindEmployee:
                    Console.Clear();
                    
                    string userInput = ReadUserInput("Введите фамилию сотрудника");
                    
                    SearchEmployeeByName(employeeNames, employeeJobs, userInput);
                    
                    Console.WriteLine();
                    break;
                
                case CommandExit:
                    isAppRunning = false;
                    Console.WriteLine("До свидания!");
                    break;
            }
        }
    }
    
    static void PrintMenu()
    {
        Console.WriteLine($"{CommandAddEmployee} - Добавить досье");
        Console.WriteLine($"{CommandPrintAllEmployees} - Показать полный список досье");
        Console.WriteLine($"{CommandRemoveEmployee} - Удалить досье");
        Console.WriteLine($"{CommandFindEmployee} - Найти досье по фамилии");
        Console.WriteLine($"{CommandExit} - Выход");
    }
    
    static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    static bool ReadNumberInput(string promptMessage, out int number)
    {
        return int.TryParse(ReadUserInput(promptMessage), out number);
    }
    
    static void AddEmployee(ref string[] names, ref string[] jobs, string employeeName, string jobName)
    {
        AddElement(ref names, employeeName);
        AddElement(ref jobs, jobName);
    }
    
    static void RemoveEmployee(ref string[] names, ref string[] jobs, int employeeIndex)
    {
        RemoveElement(ref names, employeeIndex);
        RemoveElement(ref jobs, employeeIndex);
    }
    
    static void PrintEmployee(int employeeIndex, string name, string job)
    {
        Console.WriteLine($"{employeeIndex}. {name} - {job}");
    }
    
    static void PrintEmployeesList(string[] names, string[] jobs)
    {
        for (int i = 0; i < names.Length; i++)
            PrintEmployee(i + 1, names[i], jobs[i]);
    }
    
    static void SearchEmployeeByName(string[] names, string[] jobs, string employeeName)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].ToLower().Contains(employeeName.ToLower()))
                PrintEmployee(i + 1, names[i], jobs[i]);
        }
    }
    
    static void AddElement(ref string[] list, string element)
    {
        int listLength = list.Length;
        string[] newList = new string[listLength + 1];
        
        for (int i = 0; i < listLength; i++)
            newList[i] = list[i];
        
        newList[listLength] = element;
        list = newList;
    }
    
    static void RemoveElement(ref string[] list, int index)
    {
        if (index < 0 || index >= list.Length)
            return;
        
        string[] newList = new string[list.Length - 1];
        int newListIndex = 0;
        
        for (int i = 0; i < list.Length; i++)
        {
            if (i == index)
                continue;
            
            newList[newListIndex++] = list[i];
        }
        
        list = newList;
    }
}