public static class FactoryTeam
{
    public static Team Create(int numberOfSoldiers, string teamName)
    {
        List<ISoldier> soldiers = teamName switch
        {
            "Empire" => FactorySoldiers.CreateEmpireSoldiers(numberOfSoldiers),
            "Rebels" => FactorySoldiers.CreateRebelsSoldiers(numberOfSoldiers),
            _ => throw new ArgumentException("Invalid team name")
        };

        return new Team(teamName, soldiers);
    }
}
