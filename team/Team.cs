public class Team
{
    public string Name { get; }
    public List<ISoldier> Soldiers { get; }
    public int Score { get; set; }

    public Team(string name, List<ISoldier> soldiers)
    {
        Name = name;
        Soldiers = soldiers ?? new List<ISoldier>();
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
