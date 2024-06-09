public class EmpireSoldier : Soldier
{

    public EmpireSoldier(string id, int attackPower, int hp) : base(id, attackPower, hp)
    {
    }

    public override void Attack(ISoldier soldier)
    {
        Console.WriteLine("Pour la princesse Organa !");
        base.Attack(soldier);
    }
}
