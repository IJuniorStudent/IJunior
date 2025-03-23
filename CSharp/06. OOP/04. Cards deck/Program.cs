namespace Practice_40;

class Program
{
    static void Main(string[] args)
    {
        const string CommandExit = "exit";
        
        CardsDeck deck = new CardsDeck();
        Player player = new Player();
        Dealer dealer = new Dealer();
        
        bool isAppRun = true;
        
        while (isAppRun)
        {
            Console.Clear();
            
            Console.WriteLine($"Введите количество карт, которое хотите взять у крупье или команду {CommandExit} для выхода.");
            Console.WriteLine($"Количество карт в колоде: {deck.Count}");
            
            player.DisplayCards();
            
            Console.WriteLine();
            Console.Write("> ");
            
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case CommandExit:
                    isAppRun = false;
                    break;
                
                default:
                    dealer.TryGiveCardsToPlayer(player, deck, userInput);
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
    private List<Card> _cards;
    
    public CardsDeck()
    {
        _cards = GenerateCards();
    }
    
    public int Count => _cards.Count;
    
    public Card PopFrom(int index)
    {
        Card card = _cards[index];
        _cards.RemoveAt(index);
        
        return card;
    }
    
    private List<Card> GenerateCards()
    {
        var cards = new List<Card>();
        
        string[] suits = [ "Бубны", "Черви", "Пики", "Трефы" ];
        string[] ranks = [ "6", "7", "8", "9", "Валет", "Дама", "Король", "Туз" ];
        
        foreach (var suit in suits)
            foreach (var rank in ranks)
                cards.Add(new Card(rank, suit));
        
        return cards;
    }
}

class Dealer
{
    private Random _random;
    
    public Dealer()
    {
        _random = new Random();
    }
    
    public void TryGiveCardsToPlayer(Player player, CardsDeck deck, string userRequest)
    {
        if (int.TryParse(userRequest, out int cardsCount) == false)
        {
            Utils.PrintWaitMessage($"Нет такого числа: \"{userRequest}\"");
            return;
        }
        
        if (deck.Count < cardsCount)
        {
            Utils.PrintWaitMessage("В колоде недостаточно карт");
            return;
        }
        
        for (int i = 0; i < cardsCount; i++)
            player.TakeCard(deck.PopFrom(_random.Next(0, deck.Count)));
    }
}

class Player
{
    private List<Card> _cards;
    
    public Player()
    {
        _cards = new List<Card>();
    }
    
    public void TakeCard(Card card)
    {
        _cards.Add(card);
    }
    
    public void DisplayCards()
    {
        if (_cards.Count == 0)
        {
            Console.WriteLine("У игрока на руках нет карт");
            return;
        }
        
        Console.WriteLine("Карты игрока:");
        
        foreach (var card in _cards)
            Console.WriteLine(card.Type);
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
