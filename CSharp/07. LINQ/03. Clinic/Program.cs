namespace Practice_52;

class Program
{
    static void Main(string[] args)
    {
        const string CommandSortByName = "1";
        const string CommandSortByAge = "2";
        const string CommandFindByDesease = "3";
        const string CommandExit = "4";
        
        var clinic = new Clinic(new PatientsFactory());
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            Console.WriteLine($"{CommandSortByName}. Вывести список пациентов с сортировкой по имени");
            Console.WriteLine($"{CommandSortByAge}. Вывести список пациентов с сортировкой по возрасту");
            Console.WriteLine($"{CommandFindByDesease}. Найти пациентов по болезни");
            Console.WriteLine($"{CommandExit}. Выход");
            Console.WriteLine();
            
            string userInput = Utils.ReadUserInput("Введите команду");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandSortByName:
                    clinic.ShowSortedByName();
                    break;
                
                case CommandSortByAge:
                    clinic.ShowSortedByAge();
                    break;
                
                case CommandFindByDesease:
                    clinic.ShowWithDesease();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage($"Неизвестная команда: \"{userInput}\"");
                    break;
            }
        }
    }
}
