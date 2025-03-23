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
            
            string userCommand = ReadUserInput("Укажите номер действия");
            
            Console.Clear();
            
            switch (userCommand)
            {
                case CommandAddEmployee:
                    HandleCommandAdd(ref employeeNames, ref employeeJobs);
                    break;
                
                case CommandPrintAllEmployees:
                    HandleCommandPrintAll(employeeNames, employeeJobs);
                    break;
                
                case CommandRemoveEmployee:
                    HandleCommandRemove(ref employeeNames, ref employeeJobs);
                    break;
                
                case CommandFindEmployee:
                    HandleCommandFind(employeeNames, employeeJobs);
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
 
    static void HandleCommandAdd(ref string[] names, ref string[] jobs)
    {
        string firstName = ReadUserInput("Введите имя");
        string lastName = ReadUserInput("Введите фамилию");
        string parentName = ReadUserInput("Введите отчество");
        string job = ReadUserInput("Укажите должность");
                    
        AddEmployee(ref names, ref jobs, $"{lastName} {firstName} {parentName}", job);
                    
        Console.Clear();
    }
 
    static void HandleCommandPrintAll(string[] names, string[] jobs)
    {
        for (int i = 0; i < names.Length; i++)
            PrintEmployee(i + 1, names[i], jobs[i]);
        
        Console.WriteLine();
    }
 
    static void HandleCommandRemove(ref string[] names, ref string[] jobs)
    {
        if (names.Length == 0)
        {
            Console.WriteLine("Список сотрудников пуст\n");
            return;
        }
 
        int employeeNumber = GetNumberFromInput("Укажите номер сотрудника");
        int employeeIndex = employeeNumber - 1;
 
        if (employeeIndex < 0 || employeeIndex >= names.Length)
        {
            Console.WriteLine($"Сотрудник с номером {employeeNumber} отсутствует\n");
            return;
        }
 
        RemoveEmployee(ref names, ref jobs, employeeIndex);
                    
        Console.WriteLine("Данные сотрудника успешно удалены");
        Console.WriteLine();
    }
 
    static void HandleCommandFind(string[] names, string[] jobs)
    {
        string userInput = ReadUserInput("Введите фамилию сотрудника");
        bool isAnyFound = false;
        
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].ToLower().StartsWith(userInput.ToLower()))
            {
                PrintEmployee(i + 1, names[i], jobs[i]);
                isAnyFound = true;
            }
        }
        
        if (isAnyFound == false)
            Console.WriteLine("Сотрудник с такой фамилией не найден");
        
        Console.WriteLine();
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
 
    static int GetNumberFromInput(string promptMessage)
    {
        int number;
        
        while (ReadNumberInput(promptMessage, out number) == false)
        {
            Console.Clear();
            Console.WriteLine("Число введено некорректно, попробуйте снова\n");
        }
 
        return number;
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
        
        for (int i = 0; i < index; i++)
            newList[i] = list[i];
        
        for (int i = index + 1; i < list.Length; i++)
            newList[i - 1] = list[i];
        
        list = newList;
    }
}
