public class Soldier : ISoldier
{
    private readonly Guid guid;
    public string Id { get; }
    public int Hp { get; set; }
    public bool IsSoldierAlive { get; set; }
    public int AttackPower { get; set; }

    Messages messages = new Messages();
    Random random = new();
    public Soldier(int attackPower, int hp)
    {
        guid = Guid.NewGuid();
        Id = guid.ToString();
        AttackPower = attackPower;
        Hp = hp;
        IsSoldierAlive = true;
    }

    public virtual void Attack(ISoldier soldier, string battleCry)
    {
        messages.PrintBattleCry(battleCry);
        messages.PrintWhoAttacksWho(Id, soldier.Id);

        int calculatedDamages = (int)(AttackPower * random.NextDouble());

        int newHp = soldier.Hp - calculatedDamages;
        soldier.Hp = newHp > 0 ? newHp : 0;

        messages.PrintInflictedDammages(calculatedDamages);

        if (soldier.Hp > 0)
        {
            soldier.Hp = soldier.Hp;
            Console.WriteLine($"Remaining HP of {soldier.Id}: {soldier.Hp}");
        }
        else
        {
            soldier.Hp = 0;
            soldier.IsSoldierAlive = false;
            messages.PrintSoldierDefeated(soldier.Id);
        }
    }

    public virtual int CalculatedSoldierScore()
    {
        int rate = 10;
        return Hp + (AttackPower * rate);
    }
}
