
public class EmpireSoldier : Soldier
{
    public EmpireSoldier() : base("Empire", 20, 100) // Valeurs par défaut
    {
    }

    public EmpireSoldier(string id, int attackPower, int hp) : base(id, attackPower, hp)
    {
    }

    public override void Attack(ISoldier soldier)
    {
        Console.WriteLine($"{Id} (Empire) attacks {soldier.Id}");
        base.Attack(soldier);
    }
}