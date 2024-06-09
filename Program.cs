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

// Retourne une erreur si l'utilisateur ne fournit qu'un seul argument lors de l'appel de la fonction dans la console
if (args.Length < 2)
{
    throw new ArgumentException("You need to provide two arguments");
}
// Retourne une erreur si l'utilisateur fournit des valeurs égales ou inférieures à 0 comme arguments
if (quantityBlueSoldiers <= 0 || quantityRedSoldiers <= 0)
{
    throw new ArgumentException("You need to choose two numbers that are at least above 0 for both arguments.");
}

// Initialisation de l'équipe bleue et de l'équipe rouge.
Team blueTeam = FactoryTeam.Create<EmpireSoldier>(quantityBlueSoldiers, blueTeamName, minAttackPower, maxAttackPower, minHp, maxHp, blueBattleCry);
Team redTeam = FactoryTeam.Create<RebelsSoldier>(quantityRedSoldiers, redTeamName, minAttackPower, maxAttackPower, minHp, maxHp, redBattleCry);

// Définition d'une liste de soldats encore en vie dans chaque équipe.
List<ISoldier> aliveSoldiersEmpire = blueTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
List<ISoldier> aliveSoldiersRebels = redTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();

// Instanciation de la classe Random pour générer une valeur aléatoire
Random random = new Random();
// Instanciation de la classe Messages pour pouvoir utiliser ses méthodes
Messages messages = new Messages();

// Fonction simulant une attaque entre les attaquants et les défenseurs, mettant à jour le tour d'équipe après chaque attaque.
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

// Les règles de la bataille ne définissant pas quelle équipe attaque en premier
// L'équipe attaquant en premier sera celle ayant le score le plus bas. 
isBlueTeamTurn = blueTeam.Score < redTeam.Score;

// Boucle simulant un combat jusqu'à ce qu'une des équipes n'ait plus de soldats.
while (aliveSoldiersEmpire.Count > 0 && aliveSoldiersRebels.Count > 0)
{
    messages.PrintTurn(turn);

    // Définition de l'équipe attaquante et de l'équipe défendante
    List<ISoldier> attacker = isBlueTeamTurn ? aliveSoldiersEmpire : aliveSoldiersRebels;
    List<ISoldier> defender = isBlueTeamTurn ? aliveSoldiersEmpire : aliveSoldiersEmpire;

    isBlueTeamTurn = PerformAttack(
        attacker,
        defender,
        isBlueTeamTurn,
        isBlueTeamTurn ? blueBattleCry : redBattleCry
    );

    // Mise à jour de la liste des soldats encore en vie dans chaque équipe.
    aliveSoldiersEmpire = blueTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    aliveSoldiersRebels = redTeam.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
    turn++;
    // Actualisation de l'équipe attaquante pour le prochain tour.
    isBlueTeamWonBattle = !isBlueTeamWonBattle;
}

// Fonction logique définissant l'équipe vainqueur.
if (aliveSoldiersEmpire.Count > 0)
{
    string wonAsSupposed = isBlueTeamWonBattle ? "as planned" : "";
    messages.PrintBattleWinner(blueTeamName, wonAsSupposed);
}
else
{
    string wonAsSupposed = isBlueTeamWonBattle ? "" : "as planned";
    messages.PrintBattleWinner(redTeamName, wonAsSupposed);
}
