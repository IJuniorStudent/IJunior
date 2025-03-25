namespace Practice_46.Battle;

using Units;

public class Arena
{
    private Squad _redSquad;
    private Squad _blueSquad;
    
    public Arena()
    {
        InitSquads();
    }
    
    public void Fight()
    {
        while (_redSquad.IsAlive && _blueSquad.IsAlive)
        {
            _redSquad.Attack(_blueSquad);
            
            if (_blueSquad.IsAlive)
                _blueSquad.Attack(_redSquad);
        }
    }
    
    public Squad GetWinner()
    {
        return _redSquad.IsAlive ? _redSquad : _blueSquad;
    }
    
    private void InitSquads()
    {
        _redSquad = InitSquad("Красный взвод", [
            new Trooper(),
            new Sniper(),
            new Bomber(),
            new MachineGunner()
        ]);
        
        _blueSquad = InitSquad("Синий взвод", [
            new MachineGunner(),
            new Bomber(),
            new Trooper(),
            new Sniper()
        ]);
    }
    
    private Squad InitSquad(string name, IEnumerable<Soldier> soldiers)
    {
        var squad = new Squad(name);
        squad.AddSoldiers(soldiers);
        
        return squad;
    }
}
