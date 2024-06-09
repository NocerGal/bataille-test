public class EmpireSoldier : Soldier
{
    public string BattleCry { get; }

    public EmpireSoldier(string id, int attackPower, int hp, string battleCry) : base(id, attackPower, hp)
    {
        BattleCry = battleCry;
    }

    public override void Attack(ISoldier soldier, string battleCry)
    {
        Console.WriteLine(battleCry);
        base.Attack(soldier, battleCry);
    }
}