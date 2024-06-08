int turn = 1;
bool isEmpireTurn = true;

Team empire = FactoryTeam.Create<EmpireSoldier>(int.Parse(args[0]), "Empire");
Team rebels = FactoryTeam.Create<RebelsSoldier>(int.Parse(args[1]), "Rebels");

List<ISoldier> aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Console.WriteLine($"Round {turn}");

Random random = new();

Console.WriteLine(empire.Score);
while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    Console.WriteLine($"Round {turn}");
    if (isEmpireTurn)
    {
        ISoldier soldierEmpire = aliveSoldiersEmpire[random.Next(aliveSoldiersEmpire.Count)];
        ISoldier soldierRebels = aliveSoldiersRebels[random.Next(aliveSoldiersRebels.Count)];
        soldierEmpire.Attack(soldierRebels);
    }
    else
    {
        ISoldier soldierEmpire = aliveSoldiersEmpire[random.Next(aliveSoldiersEmpire.Count)];
        ISoldier soldierRebels = aliveSoldiersRebels[random.Next(aliveSoldiersRebels.Count)];
        soldierRebels.Attack(soldierEmpire);
    }

    aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    isEmpireTurn = !isEmpireTurn;
}

if (aliveSoldiersEmpire.Count > 0)
{
    Console.WriteLine("Empire won!");
}
else
{
    Console.WriteLine("Rebels won!");
}