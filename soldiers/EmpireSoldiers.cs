public class EmpireSoldier : Soldier
{
    public EmpireSoldier(int attackPower, int hp) : base(attackPower, hp)
    {
    }

    public override void Attack(ISoldier soldier, string battleCry)
    {
        Console.WriteLine(battleCry);
        base.Attack(soldier, battleCry);
    }
}
