int turn = 1;
bool isBlueTeamTurn = true;
bool isBlueTeamWonBattle = true;
string blueTeam = "Empire";
string redTeam = "Rebels";
string blueBattleCry = "Pour la princesse Organa !";
string redBattleCry = "Traitor !";
int quantityBlueSoldiers = int.Parse(args[0]);
int quantityRedSoldiers = int.Parse(args[1]);

int minAttackPower = 100;
int maxAttackPower = 500;
int minHp = 1000;
int maxHp = 2000;

if (args.Length < 2)
{
    throw new ArgumentException("You need to provide two arguments");
}

if (int.Parse(args[0]) == 0 || int.Parse(args[1]) == 0)
{
    throw new ArgumentException("You need to choose two numbers that are at least above 0 for both arguments.");
}

Team empire = FactoryTeam.Create<EmpireSoldier>(quantityBlueSoldiers, blueTeam, minAttackPower, maxAttackPower, minHp, maxHp, redBattleCry);
Team rebels = FactoryTeam.Create<RebelsSoldier>(quantityRedSoldiers, redTeam, minAttackPower, maxAttackPower, minHp, maxHp, blueBattleCry);

List<ISoldier> aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Random random = new();

void PerformAttack(List<ISoldier> attackers, List<ISoldier> defenders, bool isBlueTeamTurn, string battleCry)
{
    string attackerTeam = isBlueTeamTurn ? blueTeam : redTeam;
    string defenderTeam = isBlueTeamTurn ? redTeam : blueTeam;
    ISoldier attacker = attackers[random.Next(attackers.Count)];
    ISoldier defender = defenders[random.Next(defenders.Count)];
    Console.WriteLine($"Hero of {attackerTeam}: {attacker.Id} with score {attacker.CalculatedSoldierScore()}");
    Console.WriteLine($"Hero of {defenderTeam}: {defender.Id} with score {defender.CalculatedSoldierScore()}");
    attacker.Attack(defender, battleCry);
    isBlueTeamTurn = !isBlueTeamTurn;
}

// L'équipe ayant un score initiale le moins élevé attaque en première.
if (empire.Score < rebels.Score)
{
    Console.WriteLine($"{redTeam} is more likely to win the battle!");
    Console.WriteLine($"Round {turn}");
    PerformAttack(aliveSoldiersEmpire, aliveSoldiersRebels, isBlueTeamTurn, blueBattleCry);
    turn++;
}
else
{
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
    Console.WriteLine($"{blueTeam} is more likely to win the battle!");
    Console.WriteLine($"Round {turn}");
    PerformAttack(aliveSoldiersRebels, aliveSoldiersEmpire, isBlueTeamTurn, redBattleCry);
    turn++;
}

while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    Console.WriteLine($"Round {turn}");
    if (isBlueTeamTurn)
    {
        PerformAttack(aliveSoldiersEmpire, aliveSoldiersRebels, isBlueTeamTurn, blueBattleCry);
    }
    else
    {
        PerformAttack(aliveSoldiersRebels, aliveSoldiersEmpire, isBlueTeamTurn, redBattleCry);
    }
    aliveSoldiersEmpire = empire.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = rebels.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
}

if (aliveSoldiersEmpire.Count > 0)
{
    string wonAsSuposed = isBlueTeamWonBattle ? "as planned" : "";
    Console.WriteLine($"{blueTeam} won {wonAsSuposed}!");
}
else
{
    string wonAsSuposed = isBlueTeamWonBattle ? "" : "as planned";
    Console.WriteLine($"{redTeam} won!");
}
