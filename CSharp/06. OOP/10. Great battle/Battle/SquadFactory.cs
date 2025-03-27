namespace Practice_46.Battle;

public abstract class SquadFactory
{
    protected SquadFactory() { }

    public abstract Squad CreateRedTeam();
    public abstract Squad CreateBlueTeam();
}
