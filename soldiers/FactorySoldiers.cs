public static class FactorySoldiers
{
    public static List<ISoldier> Create<T>(int numberOfSoldiers, int minAttackPower, int maxAttackPower, int minHp, int maxHp) where T : ISoldier
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
                soldiers.Add(new EmpireSoldier(id, attackPower, hp));
            }
            else if (typeof(T) == typeof(RebelsSoldier))
            {
                soldiers.Add(new RebelsSoldier(id, attackPower, hp));
            }
        }

        return soldiers;
    }
}





// public static class FactorySoldiers
// {
//     public static List<ISoldier> CreateRebelsSoldiers<T>(int numberOfSoldiers) where T : ISoldier, new()
//     {
//         var soldiers = new List<ISoldier>();
//         var random = new Random();

//         for (int i = 0; i < numberOfSoldiers; i++)
//         {
//             string id = Guid.NewGuid().ToString();
//             int attackPower = random.Next(100, 500);
//             int hp = random.Next(1000, 2000);
//             soldiers.Add(new RebelsSoldiers(id, attackPower, hp));
//         }

//         return soldiers;
//     }

//     public static List<ISoldier> CreateEmpireSoldiers<T>(int numberOfSoldiers) where T : ISoldier
//     {
//         var soldiers = new List<ISoldier>();
//         var random = new Random();

//         for (int i = 0; i < numberOfSoldiers; i++)
//         {
//             string id = Guid.NewGuid().ToString();
//             int attackPower = random.Next(100, 500);
//             int hp = random.Next(1000, 2000);
//             soldiers.Add(new EmpireSoldiers(id, attackPower, hp));
//         }

//         return soldiers;
//     }

//     internal static List<ISoldier> Create<T>(int numberOfSoldiers) where T : ISoldier, new()
//     {
//         throw new NotImplementedException();
//     }
// }
