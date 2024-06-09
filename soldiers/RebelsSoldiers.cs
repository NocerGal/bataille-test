public class RebelsSoldier : Soldier
{
    public RebelsSoldier(string id, int attackPower, int hp) : base(id, attackPower, hp)
    {
    }

    public override void Attack(ISoldier soldier)
    {
        Console.WriteLine("Traitor !");
        base.Attack(soldier);
    }
}
