public static class FactorySoldiers
{
    public static List<ISoldier> Create<T>(int numberOfSoldiers, int minAttackPower, int maxAttackPower, int minHp, int maxHp, string battleCry) where T : ISoldier
    {
        var soldiers = new List<ISoldier>();
        var random = new Random();

        for (int i = 0; i < numberOfSoldiers; i++)
        {
            string id = Guid.NewGuid().ToString();
            int attackPower = random.Next(minAttackPower, maxAttackPower);
            int hp = random.Next(minHp, maxHp);

            if (typeof(T) == typeof(EmpireSoldier))
            {
                soldiers.Add(new EmpireSoldier(id, attackPower, hp, battleCry));
            }
            else if (typeof(T) == typeof(RebelsSoldier))
            {
                soldiers.Add(new RebelsSoldier(id, attackPower, hp, battleCry));
            }
        }

        return soldiers;
    }
}