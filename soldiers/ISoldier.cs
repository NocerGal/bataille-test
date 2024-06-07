public interface ISoldier
{
    string Id { get; }
    int Hp { get; set; }
    bool IsSoldierAlive { get; set; }
    int AttackPower { get; set; }

    void Attack(ISoldier soldier);
}
