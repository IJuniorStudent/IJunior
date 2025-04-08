namespace Practice_52;

public class Clinic
{
    private List<Patient> _patients;
    
    public Clinic(PatientsFactory factory)
    {
        _patients = factory.Create();
    }
    
    public void ShowSortedByName()
    {
        DisplayPatients(
            "Список пациентов с сортировкой по имени",
            _patients
                .OrderBy(entry => entry.FullName)
                .ToList()
        );
    }
    
    public void ShowSortedByAge()
    {
        DisplayPatients(
            "Список пациентов с сортировкой по возрасту",
            _patients
                .OrderBy(entry => entry.Age)
                .ThenBy(entry => entry.FullName)
                .ToList()
        );
    }
    
    public void ShowWithDesease()
    {
        string desease = Utils.ReadUserInput("Введите название болезни");
        string deseaseLower = desease.ToLower();
        
        Console.Clear();
        
        DisplayPatients(
            $"Список пациентов с болезнью: \"{desease}\"",
            _patients
                .Where(entry => entry.Desease.ToLower() == deseaseLower)
                .ToList()
        );
    }

    private void DisplayPatients(string headMessage, List<Patient> patients)
    {
        Console.WriteLine(headMessage);
        Console.WriteLine();
        
        if (patients.Count == 0)
        {
            Utils.PrintWaitMessage("Пациенты не найдены");
            return;
        }
        
        for (int i = 0; i < patients.Count; i++)
            Console.WriteLine($"{i + 1}. {patients[i].Summary}");
        
        Console.WriteLine();
        Utils.WaitAnyKeyPress();
    }
}