public static class FactorySoldiers
{
    public static List<ISoldier> Create<T>(int numberOfSoldiers, int minAttackPower, int maxAttackPower, int minHp, int maxHp) where T : ISoldier
    {
        var soldiers = new List<ISoldier>();
        var random = new Random();

        for (int i = 0; i < numberOfSoldiers; i++)
        {
            int attackPower = random.Next(minAttackPower, maxAttackPower);
            int hp = random.Next(minHp, maxHp);

            if (typeof(T) == typeof(EmpireSoldier))
            {
                soldiers.Add(new EmpireSoldier(attackPower, hp));
            }
            else if (typeof(T) == typeof(RebelsSoldier))
            {
                soldiers.Add(new RebelsSoldier(attackPower, hp));
            }
        }

        return soldiers;
    }
}
