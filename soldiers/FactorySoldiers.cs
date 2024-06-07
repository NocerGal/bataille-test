public static class FactorySoldiers
{
    public static List<ISoldier> CreateRebelsSoldiers(int numberOfSoldiers)
    {
        var soldiers = new List<ISoldier>();
        var random = new Random();

        for (int i = 0; i < numberOfSoldiers; i++)
        {
            string id = Guid.NewGuid().ToString();
            int attackPower = random.Next(100, 500);
            int hp = random.Next(1000, 2000);
            soldiers.Add(new RebelsSoldiers(id, attackPower, hp));
        }

        return soldiers;
    }

    public static List<ISoldier> CreateEmpireSoldiers(int numberOfSoldiers)
    {
        var soldiers = new List<ISoldier>();
        var random = new Random();

        for (int i = 0; i < numberOfSoldiers; i++)
        {
            string id = Guid.NewGuid().ToString();
            int attackPower = random.Next(100, 500);
            int hp = random.Next(1000, 2000);
            soldiers.Add(new EmpireSoldiers(id, attackPower, hp));
        }

        return soldiers;
    }
}
