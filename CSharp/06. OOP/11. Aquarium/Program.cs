namespace Practice_47;

class Program
{
    static void Main(string[] args)
    {
        const string CommandAddFish = "1";
        const string CommandRemoveFish = "2";
        const string CommandSkipStep = "3";
        const string CommandExit = "4";
        
        var factory = new FishFactory();
        var aquarium = new Aquarium(5);
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            aquarium.DisplayPopulation();
            
            Console.WriteLine();
            Console.WriteLine("Доступные команды:");
            Console.WriteLine($"{CommandAddFish}. Добавить рыбу");
            Console.WriteLine($"{CommandRemoveFish}. Достать рыбу");
            Console.WriteLine($"{CommandSkipStep}. Ничего не делать");
            Console.WriteLine($"{CommandExit}. Выход");
            
            switch (Utils.ReadUserInput("Что делаем?"))
            {
                case CommandAddFish:
                    aquarium.AddFish(factory);
                    break;
                
                case CommandRemoveFish:
                    aquarium.RemoveFish();
                    break;
                
                case CommandSkipStep:
                    aquarium.Update();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage("Неизвестная команда");
                    break;
            }
        }
    }
}