namespace Practice_46.Battle;

public class Arena
{
    private Squad _redSquad;
    private Squad _blueSquad;
    
    public Arena(SquadFactory factory)
    {
        _redSquad = factory.CreateTeam("Красный взвод");
        _blueSquad = factory.CreateTeam("Синий взвод");
    }
    
    public void Fight()
    {
        while (_redSquad.IsAlive && _blueSquad.IsAlive)
        {
            Attack(_redSquad, _blueSquad);
            Attack(_blueSquad, _redSquad);
        }
    }
    
    public void ShowWinner()
    {
        Squad winner = GetWinner();
        
        Console.WriteLine($"Победитель - {winner.Name}");
    }
    
    private Squad GetWinner()
    {
        return _redSquad.IsAlive ? _redSquad : _blueSquad;
    }
    
    private void Attack(Squad attacker, Squad defender)
    {
        if (defender.IsAlive == false)
            return;
        
        attacker.Attack(defender.Units);
        defender.RemoveDead();
    }
}
