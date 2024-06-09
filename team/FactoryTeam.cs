public static class FactoryTeam
{
    public static Team Create<T>(int numberOfSoldiers, string teamName, int minAttackPower, int maxAttackPower, int minHp, int maxHp, string battleCry) where T : ISoldier
    {
        List<ISoldier> soldiers = FactorySoldiers.Create<T>(numberOfSoldiers, minAttackPower, maxAttackPower, minHp, maxHp);
        return new Team(teamName, soldiers, battleCry);
    }
}
