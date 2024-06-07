
int turn = 1;
bool isEmpireTurn = true;

Team empire = FactoryTeam.Create(int.Parse(args[0]), "Empire");
Team rebels = FactoryTeam.Create(int.Parse(args[1]), "Rebels");

empire.UpdateScore();
rebels.UpdateScore();

List<ISoldier> aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Console.WriteLine($"Round {turn}");

Random random = new();

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

Console.WriteLine("finish");
