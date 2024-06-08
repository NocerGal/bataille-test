public class Soldier : ISoldier
{
    private readonly Guid guid;

    public Soldier(string id, int attackPower, int hp)
    {
        guid = Guid.NewGuid();
        Id = guid.ToString();
        AttackPower = attackPower;
        Hp = hp;
        IsSoldierAlive = true;
    }

    public string Id { get; }
    public int Hp { get; set; }
    public bool IsSoldierAlive { get; set; }
    public int AttackPower { get; set; }

    public virtual void Attack(ISoldier soldier)
    {
        Console.WriteLine($"{Id} attacks {soldier.Id}");

        Random random = new();
        int calculatedDamages = (int)(AttackPower * random.NextDouble());

        int newHp = soldier.Hp - calculatedDamages;
        soldier.Hp = newHp > 0 ? newHp : 0;

        Console.WriteLine($"Damage inflicted: {calculatedDamages}");

        if (soldier.Hp > 0)
        {
            soldier.Hp = soldier.Hp;
            Console.WriteLine($"Remaining HP of {soldier.Id}: {soldier.Hp}");
        }
        else
        {
            soldier.Hp = 0;
            soldier.IsSoldierAlive = false;
            Console.WriteLine($"{soldier.Id} has been slain!");
        }
    }
}
