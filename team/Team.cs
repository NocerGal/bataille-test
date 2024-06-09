public class Team
{
    // Name et Soldier, Soldiers et BattleCry en readonly pour éviter de modifier leurs valeurs. 
    public string Name { get; }
    public List<ISoldier> Soldiers { get; }
    public int Score { get; set; }
    public string BattleCry { get; }

    public Team(string name, List<ISoldier> soldiers, string battleCry)
    {
        Name = name;
        Soldiers = soldiers;
        BattleCry = battleCry;


        Score = Soldiers.Sum(soldier =>
        {
            int soldierHp = soldier.Hp;
            int soldierAttackPower = soldier.AttackPower;
            int rate = 10;
            int calculatedScore = (soldierHp + soldierAttackPower) * rate;

            return calculatedScore;
        });
    }
}
