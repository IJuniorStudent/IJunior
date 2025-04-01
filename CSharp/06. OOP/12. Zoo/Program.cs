namespace Practice_48;

using Factories;

class Program
{
    static void Main(string[] args)
    {
        const string CommandExit = "exit";
        
        var zoo = new Zoo(new AnimalAreaFactory(), 4);
        bool isAppRun = true;
        int minAreaNumber = 1;
        string promptMessage = $"Введите номер вольера от {minAreaNumber} до {zoo.AreaCount} для просмотра\nИли введите \"{CommandExit}\" для выхода";
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine($"В зоопарке расположено {zoo.AreaCount} вольеров");
            Console.WriteLine();
            
            string userInput = Utils.ReadUserInput(promptMessage);
            
            switch (userInput)
            {
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    zoo.DisplayArea(userInput);
                    break;
            }
        }
    }
}
