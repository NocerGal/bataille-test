public static class FactoryTeam
{
    public static Team Create<T>(int numberOfSoldiers, string teamName) where T : ISoldier, new()
    {
        List<ISoldier> soldiers = FactorySoldiers.Create<T>(numberOfSoldiers);
        return new Team(teamName, soldiers);
    }
}

