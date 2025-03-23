namespace Practice_40;

class Program
{
    static void Main(string[] args)
    {
        const string CommandExit = "exit";
        
        PlayTable table = new PlayTable();
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine($"Введите количество карт, которое хотите взять у крупье или команту {CommandExit} для выхода.");
            
            table.DisplayDealerDeckSize();
            table.DisplayPlayerDeck();
            
            Console.WriteLine();
            Console.Write("> ");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    table.TryMoveCardsFromDealerToPlayer(userInput);
                    break;
            }
        }
    }
}

class Card
{
    private string _rank;
    private string _suit;
    
    public Card(string rank, string suit)
    {
        _rank = rank;
        _suit = suit;
    }
    
    public string Type => $"{_rank} - {_suit}";
}

class CardsDeck
{
    protected List<Card> Cards;
    
    public CardsDeck()
    {
        Cards = new List<Card>();
    }
    
    public int Count => Cards.Count;
    
    public void Push(Card card)
    {
        Cards.Add(card);
    }
    
    public Card PopFrom(int index)
    {
        Card card = Cards[index];
        Cards.RemoveAt(index);
        
        return card;
    }
    
    public void Print()
    {
        if (Cards.Count == 0)
        {
            Console.WriteLine("Колода не содержит карт");
            return;
        }
        
        foreach (var card in Cards)
            Console.WriteLine(card.Type);
    }
}

class FullCardsDeck : CardsDeck
{
    public FullCardsDeck()
    {
        string[] suits = [ "Бубны", "Черви", "Пики", "Трефы" ];
        string[] ranks = [ "6", "7", "8", "9", "Валет", "Дама", "Король", "Туз" ];
        
        foreach (var suit in suits)
            foreach (var rank in ranks)
                Cards.Add(new Card(rank, suit));
    }
    
    public void Shuffle(Random random)
    {
        int cardsCount = Cards.Count;
        
        for (int i = 0; i < cardsCount; i++)
        {
            int nextIndex = random.Next(i, cardsCount);
            (Cards[nextIndex], Cards[i]) = (Cards[i], Cards[nextIndex]);
        }
    }
}

class Dealer
{
    private Random _random;
    private FullCardsDeck _deck;
    
    public Dealer()
    {
        _random = new Random();
        _deck = new FullCardsDeck();
        
        _deck.Shuffle(_random);
    }
    
    public int DeckSize => _deck.Count;
    
    public Card PopRandomCard()
    {
        return _deck.PopFrom(_random.Next(0, _deck.Count));
    }
}

class Player
{
    private CardsDeck _deck;
    
    public Player()
    {
        _deck = new CardsDeck();
    }
    
    public void Take(Card card)
    {
        _deck.Push(card);
    }
    
    public void DisplayDeck()
    {
        _deck.Print();
    }
}

class PlayTable
{
    private Dealer _dealer;
    private Player _player;
    
    public PlayTable()
    {
        _dealer = new Dealer();
        _player = new Player();
    }
    
    public void DisplayDealerDeckSize()
    {
        Console.WriteLine($"Количество карт в колоде у крупье: {_dealer.DeckSize}");
    }
    
    public void DisplayPlayerDeck()
    {
        Console.WriteLine("Колода игрока:");
        _player.DisplayDeck();
    }
    
    public void TryMoveCardsFromDealerToPlayer(string userInput)
    {
        if (int.TryParse(userInput, out int cardsCount) == false)
        {
            Utils.PrintWaitMessage("Введено некорректное число");
            return;
        }
        
        if (_dealer.DeckSize < cardsCount)
        {
            Utils.PrintWaitMessage("У крупье недостаточно карт");
            return;
        }
        
        for (int i = 0; i < cardsCount; i++)
            _player.Take(_dealer.PopRandomCard());
    }
}

class Utils
{
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
