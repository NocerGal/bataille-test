public class RebelsSoldier : Soldier
{
    public string BattleCry { get; }

    public RebelsSoldier(string id, int attackPower, int hp, string battleCry) : base(id, attackPower, hp)
    {
        BattleCry = battleCry;
    }

    public override void Attack(ISoldier soldier, string battleCry)
    {
        Console.WriteLine(battleCry);
        base.Attack(soldier, battleCry);
    }
}