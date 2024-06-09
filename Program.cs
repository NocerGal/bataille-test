int turn = 1;
bool isBlueTeamTurn = true;
bool isBlueTeamWonBattle = true;
string BlueTeam = "Empire";
string RedTeam = "Rebels";

int minAttackPower = 100;
int maxAttackPower = 500;
int minHp = 1000;
int maxHp = 2000;

if (int.Parse(args[0]) == 0 || int.Parse(args[1]) == 0)
{
    Console.WriteLine("You need to choose numbers that are at least above 0 for both arguments.");
    return;
}

Team empire = FactoryTeam.Create<EmpireSoldier>(int.Parse(args[0]), BlueTeam, minAttackPower, maxAttackPower, minHp, maxHp);
Team rebels = FactoryTeam.Create<RebelsSoldier>(int.Parse(args[1]), RedTeam, minAttackPower, maxAttackPower, minHp, maxHp);

List<ISoldier> aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Random random = new();

void PerformAttack(List<ISoldier> attackers, List<ISoldier> defenders, bool isBlueTeamTurn)
{
    ISoldier attacker = attackers[random.Next(attackers.Count)];
    ISoldier defender = defenders[random.Next(defenders.Count)];
    attacker.Attack(defender);
    isBlueTeamTurn = !isBlueTeamTurn;
}

if (isBlueTeamTurn)
{
    Console.WriteLine($"{BlueTeam} is more likely to win the battle!");
    Console.WriteLine($"Round {turn}");
    PerformAttack(aliveSoldiersEmpire, aliveSoldiersRebels, isBlueTeamTurn);
    turn++;
}
else
{
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
    Console.WriteLine($"{RedTeam} is more likely to win the battle!");
    Console.WriteLine($"Round {turn}");
    PerformAttack(aliveSoldiersRebels, aliveSoldiersEmpire, isBlueTeamTurn);
    turn++;
}

while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    Console.WriteLine($"Round {turn}");
    if (isBlueTeamTurn)
    {
        PerformAttack(aliveSoldiersEmpire, aliveSoldiersRebels, isBlueTeamTurn);
    }
    else
    {
        PerformAttack(aliveSoldiersRebels, aliveSoldiersEmpire, isBlueTeamTurn);
    }
    aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
}

if (aliveSoldiersEmpire.Count > 0)
{
    string wonAsSuposed = isBlueTeamWonBattle ? "as planned" : "";
    Console.WriteLine($"{BlueTeam} won {wonAsSuposed}!");
}
else
{
    string wonAsSuposed = isBlueTeamWonBattle ? "" : "as planned";
    Console.WriteLine($"{RedTeam} won!");
}
