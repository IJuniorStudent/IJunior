namespace Practice_46.Battle;

using Units;

public class SquadFactoryFixed : SquadFactory
{
    public SquadFactoryFixed() { }

    public override Squad CreateRedTeam()
    {
        return new Squad("Красный взвод", [
            new Trooper(),
            new Sniper(),
            new Bomber(),
            new MachineGunner()
        ]);
    }

    public override Squad CreateBlueTeam()
    {
        return new Squad("Синий взвод", [
            new Trooper(),
            new Sniper(),
            new Bomber(),
            new MachineGunner()
        ]);
    }
}
