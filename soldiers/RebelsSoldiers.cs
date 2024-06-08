public class RebelsSoldier : Soldier
{
    public RebelsSoldier() : base("Rebel", 20, 100) // Valeurs par défaut
    {
    }

    public RebelsSoldier(string id, int attackPower, int hp) : base(id, attackPower, hp)
    {
    }

    public override void Attack(ISoldier soldier)
    {
        Console.WriteLine($"{Id} (Rebel) attacks {soldier.Id}");
        base.Attack(soldier);
    }
}