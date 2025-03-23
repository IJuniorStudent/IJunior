namespace Practice_12;

class Program
{
    static void Main(string[] args)
    {
        const float UsdToRubExchangeRate = 90.0f;
        const float EurToRubExchangeRate = 100.0f;
        const float EurToUsdExchangeRate = EurToRubExchangeRate / UsdToRubExchangeRate;
        const float RubToUsdExchangeRate = 1.0f / UsdToRubExchangeRate;
        const float RubToEurExchangeRate = 1.0f / EurToRubExchangeRate;
        const float UsdToEurExchangeRate = 1.0f / EurToUsdExchangeRate;
 
        const string CurrencyRubName = "RUB";
        const string CurrencyUsdName = "USD";
        const string CurrencyEurName = "EUR";
 
        const string ExchangePromptFormatMessage = "Введите количество {0}, которое хотите зачислить на счет {1}";
        
        const string CommandRubToUsdExchange = "1";
        const string CommandUsdToRubExchange = "2";
        const string CommandRubToEurExchange = "3";
        const string CommandEurToRubExchange = "4";
        const string CommandUsdToEurExchange = "5";
        const string CommandEurToUsdExchange = "6";
        const string CommandExit = "7";
        
        float userRubWalletBalance = 1000.0f;
        float userEurWalletBalance = 1000.0f;
        float userUsdWalletBalance = 1000.0f;
        
        bool isAppRunning = true;
 
        while (isAppRunning)
        {
            Console.WriteLine($"Средства на счету {CurrencyRubName}: {userRubWalletBalance}");
            Console.WriteLine($"Средства на счету {CurrencyUsdName}: {userUsdWalletBalance}");
            Console.WriteLine($"Средства на счету {CurrencyEurName}: {userEurWalletBalance}");
            Console.WriteLine();
            Console.WriteLine("Введите номер операции:");
            Console.WriteLine($"{CommandRubToUsdExchange}. Перевести средства со счета {CurrencyRubName} на счет {CurrencyUsdName}");
            Console.WriteLine($"{CommandUsdToRubExchange}. Перевести средства со счета {CurrencyUsdName} на счет {CurrencyRubName}");
            Console.WriteLine($"{CommandRubToEurExchange}. Перевести средства со счета {CurrencyRubName} на счет {CurrencyEurName}");
            Console.WriteLine($"{CommandEurToRubExchange}. Перевести средства со счета {CurrencyEurName} на счет {CurrencyRubName}");
            Console.WriteLine($"{CommandUsdToEurExchange}. Перевести средства со счета {CurrencyUsdName} на счет {CurrencyEurName}");
            Console.WriteLine($"{CommandEurToUsdExchange}. Перевести средства со счета {CurrencyEurName} на счет {CurrencyUsdName}");
            Console.WriteLine($"{CommandExit}. Выйти из приложения");
            Console.Write("> ");
            
            string userCommand = Console.ReadLine();
 
            float moneyAmountToExchange = 0.0f;
            
            switch (userCommand)
            {
                case CommandRubToUsdExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyRubName, CurrencyUsdName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userRubWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyRubName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userRubWalletBalance -= moneyAmountToExchange;
                    userUsdWalletBalance += moneyAmountToExchange * RubToUsdExchangeRate;
                    break;
                
                case CommandUsdToRubExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyUsdName, CurrencyRubName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userUsdWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyUsdName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userUsdWalletBalance -= moneyAmountToExchange;
                    userRubWalletBalance += moneyAmountToExchange * UsdToRubExchangeRate;
                    break;
                
                case CommandRubToEurExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyRubName, CurrencyEurName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userRubWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyRubName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userRubWalletBalance -= moneyAmountToExchange;
                    userEurWalletBalance += moneyAmountToExchange * RubToEurExchangeRate;
                    break;
                
                case CommandEurToRubExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyEurName, CurrencyRubName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userEurWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyEurName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userEurWalletBalance -= moneyAmountToExchange;
                    userRubWalletBalance += moneyAmountToExchange * EurToRubExchangeRate;
                    break;
                
                case CommandUsdToEurExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyUsdName, CurrencyEurName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userUsdWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyUsdName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userUsdWalletBalance -= moneyAmountToExchange;
                    userEurWalletBalance += moneyAmountToExchange * UsdToEurExchangeRate;
                    break;
                
                case CommandEurToUsdExchange:
                    Console.WriteLine(ExchangePromptFormatMessage, CurrencyEurName, CurrencyUsdName);
                    Console.Write("> ");
                    moneyAmountToExchange = Convert.ToSingle(Console.ReadLine());
                    if (userEurWalletBalance < moneyAmountToExchange)
                    {
                        Console.Clear();
                        Console.WriteLine($"На счету {CurrencyEurName} недостаточно средств для списания {moneyAmountToExchange}");
                        Console.WriteLine();
                        continue;
                    }
                    userEurWalletBalance -= moneyAmountToExchange;
                    userUsdWalletBalance += moneyAmountToExchange * EurToUsdExchangeRate;
                    break;
                
                case CommandExit:
                    isAppRunning = false;
                    Console.WriteLine("До свидания!");
                    continue;
                
                default:
                    Console.Clear();
                    Console.WriteLine($"Недопустимый номер операции \"{userCommand}\"");
                    Console.WriteLine();
                    continue;
            }
            
            Console.Clear();
        }
    }
}
 