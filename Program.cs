int turn = 1;
bool isTeamBlueTurn = true;
bool isTeamBlueWonBattle = true;
string TeamBlue = "Empire";
string TeamRed = "Rebels";

int minAttackPower = 100;
int maxAttackPower = 500;
int minHp = 1000;
int maxHp = 2000;

if (int.Parse(args[0]) == 0 || int.Parse(args[1]) == 0)
{
    Console.WriteLine("You need to choose numbers that are at least above 0 for both arguments.");
    return;
}

Team empire = FactoryTeam.Create<EmpireSoldier>(int.Parse(args[0]), TeamBlue, minAttackPower, maxAttackPower, minHp, maxHp);
Team rebels = FactoryTeam.Create<RebelsSoldier>(int.Parse(args[1]), TeamRed, minAttackPower, maxAttackPower, minHp, maxHp);

List<ISoldier> aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Random random = new();

while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    Console.WriteLine($"Round {turn}");
    if (isTeamBlueTurn)
    {

        Console.WriteLine($"{TeamBlue} is more likely to win the battle!");
        ISoldier soldierEmpire = aliveSoldiersEmpire[random.Next(aliveSoldiersEmpire.Count)];
        ISoldier soldierRebels = aliveSoldiersRebels[random.Next(aliveSoldiersRebels.Count)];
        soldierEmpire.Attack(soldierRebels);
    }
    else
    {
        isTeamBlueWonBattle = !isTeamBlueWonBattle;
        Console.WriteLine($"{TeamRed} is more likely to win the battle!");
        ISoldier soldierEmpire = aliveSoldiersEmpire[random.Next(aliveSoldiersEmpire.Count)];
        ISoldier soldierRebels = aliveSoldiersRebels[random.Next(aliveSoldiersRebels.Count)];
        soldierRebels.Attack(soldierEmpire);
    }
    aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    isTeamBlueTurn = !isTeamBlueTurn;
}

if (aliveSoldiersEmpire.Count > 0)
{
    string wonAsSuposed = isTeamBlueWonBattle ? "as planned" : "";
    Console.WriteLine($"{TeamBlue} won {wonAsSuposed}!");
}
else
{
    string wonAsSuposed = isTeamBlueWonBattle ? "" : "as planned";
    Console.WriteLine($"{TeamRed} won!");
}
