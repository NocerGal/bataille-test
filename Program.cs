int turn = 1;
bool isBlueTeamTurn;
bool isBlueTeamWonBattle = true;
string blueTeamName = "Empire";
string redTeamName = "Rebels";
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

if (quantityBlueSoldiers == 0 || quantityRedSoldiers == 0)
{
    throw new ArgumentException("You need to choose two numbers that are at least above 0 for both arguments.");
}

Team blueTeam = FactoryTeam.Create<EmpireSoldier>(quantityBlueSoldiers, blueTeamName, minAttackPower, maxAttackPower, minHp, maxHp, blueBattleCry);
Team redTeam = FactoryTeam.Create<RebelsSoldier>(quantityRedSoldiers, redTeamName, minAttackPower, maxAttackPower, minHp, maxHp, redBattleCry);

List<ISoldier> aliveSoldiersEmpire = blueTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = redTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

Random random = new();
Messages messages = new();

bool PerformAttack(List<ISoldier> attackers, List<ISoldier> defenders, bool isBlueTeamTurn, string battleCry)
{
    string attackerTeam = isBlueTeamTurn ? blueTeamName : redTeamName;
    string defenderTeam = isBlueTeamTurn ? redTeamName : blueTeamName;
    Console.WriteLine("Luc", attackerTeam, defenderTeam);
    ISoldier attacker = attackers[random.Next(attackers.Count)];
    ISoldier defender = defenders[random.Next(defenders.Count)];
    messages.PrintHeroScore(attackerTeam, attacker);
    messages.PrintHeroScore(defenderTeam, defender);
    attacker.Attack(defender, battleCry);
    isBlueTeamTurn = !isBlueTeamTurn;
    return isBlueTeamTurn;
}


isBlueTeamTurn = blueTeam.Score < redTeam.Score;


// L'équipe ayant un score initial le moins élevé attaque en première.
if (isBlueTeamTurn)
{
    messages.PrintLikelyWinner(redTeamName);
    messages.PrintTurn(turn);
    isBlueTeamTurn = PerformAttack(aliveSoldiersEmpire, aliveSoldiersRebels, isBlueTeamTurn, blueBattleCry);
    turn++;
}
else
{
    messages.PrintLikelyWinner(blueTeamName);
    messages.PrintTurn(turn);
    isBlueTeamTurn = PerformAttack(aliveSoldiersRebels, aliveSoldiersEmpire, isBlueTeamTurn, redBattleCry);
    turn++;
}

while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    messages.PrintTurn(turn);

    List<ISoldier> attacker = isBlueTeamTurn ? aliveSoldiersEmpire : aliveSoldiersRebels;
    List<ISoldier> defender = isBlueTeamTurn ? aliveSoldiersEmpire : aliveSoldiersEmpire;

    isBlueTeamTurn = PerformAttack(
        attacker,
        defender,
        isBlueTeamTurn,
        isBlueTeamTurn ? blueBattleCry : redBattleCry
    ); // Mettre à jour la valeur de isBlueTeamTurn

    aliveSoldiersEmpire = blueTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = redTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
}


if (aliveSoldiersEmpire.Count > 0)
{
    string wonAsSuposed = isBlueTeamWonBattle ? "as planned" : "";
    messages.PrintBattleWinner(blueTeamName, wonAsSuposed);
}
else
{
    string wonAsSuposed = isBlueTeamWonBattle ? "" : "as planned";
    messages.PrintBattleWinner(redTeamName, wonAsSuposed);
}
