public interface ISoldier : IAttack
{
    string Id { get; }
    int Hp { get; set; }
    bool IsSoldierAlive { get; set; }
    int AttackPower { get; set; }
}
