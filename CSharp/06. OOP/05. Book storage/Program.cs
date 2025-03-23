namespace Practice_41;

class Program
{
    static void Main(string[] args)
    {
        const string CommandAddBook = "1";
        const string CommandRemoveBook = "2";
        const string CommandPrintBooks = "3";
        const string CommandFindBook = "4";
        const string CommandExit = "5";
        
        BookStorage storage = new BookStorage();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            Console.WriteLine($"{CommandAddBook}. Добавить книгу");
            Console.WriteLine($"{CommandRemoveBook}. Удалить книгу");
            Console.WriteLine($"{CommandPrintBooks}. Показать весь список книг");
            Console.WriteLine($"{CommandFindBook}. Поиск книги по названию, автору или году");
            Console.WriteLine($"{CommandExit}. Выход");
            
            string userInput = Utils.ReadUserInput("Выберите опцию");
            
            Console.Clear();
            
            switch (userInput)
            {
                case CommandAddBook:
                    storage.AddBook();
                    break;
                
                case CommandRemoveBook:
                    storage.RemoveBook();
                    break;
                
                case CommandPrintBooks:
                    storage.PrintWaitBookList();
                    break;
                
                case CommandFindBook:
                    storage.SearchBooks();
                    break;
                
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    Utils.PrintWaitMessage($"Неизвестная опция \"{userInput}\"");
                    break;
            }
        }
    }
}

class Book
{
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }
    
    public string Summary => $"{Title} - {Author} - {Year}";
}

class BookStorage
{
    private List<Book> _books;
    
    public BookStorage()
    {
        _books = new List<Book>();
    }
    
    public void AddBook()
    {
        string title = Utils.ReadUserInput("Введите название книги");
        string author = Utils.ReadUserInput("Введите автора книги");
        
        if (Utils.TryReadNumberInput("Введите год выпуска книги", out int year) == false)
            return;
        
        _books.Add(new Book(title, author, year));
    }
    
    public void RemoveBook()
    {
        PrintBooks();
        
        if (_books.Count == 0)
            return;
        
        if (Utils.TryReadNumberInput("Введите номер книги, которую хотите удалить", out int bookNumber) == false)
            return;
        
        int bookIndex = bookNumber - 1;
        
        if (bookIndex < 0 || bookIndex >= _books.Count)
        {
            Utils.PrintWaitMessage($"Книги с номером {bookNumber} не существует");
            return;
        }
        
        _books.RemoveAt(bookIndex);
        
        Utils.PrintWaitMessage("Книга удалена из библиотеки");
    }
    
    public void PrintWaitBookList()
    {
        PrintBooks();
        
        Utils.WaitAnyKeyPress();
    }
    
    public void PrintBooks()
    {
        if (_books.Count == 0)
        {
            Utils.PrintWaitMessage("В библиотеке отсутствуют книги");
            return;
        }
        
        PrintBookList(_books);
    }
    
    public void SearchBooks()
    {
        const string CommandSearchByTitle = "1";
        const string CommandSearchByAuthor = "2";
        const string CommandSearchByYear = "3";
        const string CommandSearchCancel = "4";
        
        Console.WriteLine($"{CommandSearchByTitle}. Найти книги по названию");
        Console.WriteLine($"{CommandSearchByAuthor}. Найти книги по автору");
        Console.WriteLine($"{CommandSearchByYear}. Найти книги по году выпуска");
        Console.WriteLine($"{CommandSearchCancel}. Назад");
        
        List<Book>? foundBooks = null;
        string userInput = Utils.ReadUserInput("Выберите опцию");
        
        switch (userInput)
        {
            case CommandSearchByTitle:
                foundBooks = FindByTitle();
                break;
            
            case CommandSearchByAuthor:
                foundBooks = FindByAuthor();
                break;
            
            case CommandSearchByYear:
                foundBooks = FindByYear();
                break;
            
            case CommandSearchCancel:
                return;
            
            default:
                Utils.PrintWaitMessage($"Неизвестная опция: \"{userInput}\"");
                return;
        }
        
        if (foundBooks == null)
            return;
        
        if (foundBooks.Count == 0)
        {
            Utils.PrintWaitMessage("Книги с указанными параметрами не найдены");
            return;
        }
        
        Console.WriteLine("Найденные книги:");
        
        PrintBookList(foundBooks);
        
        Utils.WaitAnyKeyPress();
    }
    
    private void PrintBookList(List<Book> bookList)
    {
        for (int i = 0; i < bookList.Count; i++)
            Console.WriteLine($"{i + 1}. {bookList[i].Summary}");
    }
    
    private List<Book> FindByTitle()
    {
        string searchPattern = Utils.ReadUserInput("Введите полное название книги или его часть").ToLower();
        
        return _books.FindAll(book => book.Title.ToLower().Contains(searchPattern));
    }
    
    private List<Book> FindByAuthor()
    {
        string searchPattern = Utils.ReadUserInput("Введите полное имя автора или его часть").ToLower();
        
        return _books.FindAll(book => book.Author.ToLower().Contains(searchPattern));
    }
    
    private List<Book>? FindByYear()
    {
        if (Utils.TryReadNumberInput("Введите точный год выпуска книги", out int year) == false)
            return null;
        
        return _books.FindAll(book => book.Year == year);
    }
}

class Utils
{
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        Console.Write("> ");
        
        return Console.ReadLine();
    }
    
    public static bool TryReadNumberInput(string promptMessage, out int number)
    {
        if (int.TryParse(ReadUserInput(promptMessage), out number) == false)
        {
            PrintWaitMessage("Ввведено некорректное число");
            return false;
        }
        
        return true;
    }
    
    public static void PrintWaitMessage(string message)
    {
        Console.WriteLine(message);
        
        WaitAnyKeyPress();
    }
    
    public static void WaitAnyKeyPress()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }
}
