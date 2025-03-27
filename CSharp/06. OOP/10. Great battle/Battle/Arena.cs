namespace Practice_46.Battle;

using Units;

public class Arena
{
    private Squad _redSquad;
    private Squad _blueSquad;
    
    public Arena(SquadFactory factory)
    {
        _redSquad = factory.CreateRedTeam();
        _blueSquad = factory.CreateBlueTeam();
    }
    
    public void Fight()
    {
        while (_redSquad.IsAlive && _blueSquad.IsAlive)
        {
            _redSquad.Attack(_blueSquad.Units);
            _blueSquad.RemoveDead();
            
            if (_blueSquad.IsAlive)
            {
                _blueSquad.Attack(_redSquad.Units);
                _redSquad.RemoveDead();
            }
        }
    }
    
    public Squad GetWinner()
    {
        return _redSquad.IsAlive ? _redSquad : _blueSquad;
    }
}
