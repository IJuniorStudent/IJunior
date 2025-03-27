namespace Practice_46.Battle;

using Units;

public class SquadFactory
{
    public SquadFactory() { }

    public Squad CreateTeam(string name)
    {
        return new Squad(name, [
            new Trooper(),
            new Sniper(),
            new Bomber(),
            new MachineGunner()
        ]);
    }
}
