namespace Practice_6;

class Program
{
    static void Main(string[] args)
    {
        int minutesPerHour = 60;
        int patientWaitTimeMinutes = 10;
        
        Console.Write("Введите количество пациентов: ");
        int patientsCount = Convert.ToInt32(Console.ReadLine());
        
        int totalWaitTime = patientsCount * patientWaitTimeMinutes;
        int waitTimeHours = totalWaitTime / minutesPerHour;
        int waitTimeMinutes = totalWaitTime % minutesPerHour;
        
        Console.WriteLine($"Вы должны отстоять в очереди {waitTimeHours} часа и {waitTimeMinutes} минут.");
        Console.ReadLine();
    }
}
