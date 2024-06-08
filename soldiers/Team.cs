public class Team
{
    public string Name { get; }
    public List<ISoldier> Soldiers { get; }
    public int Score { get; private set; }

    public Team(string name, List<ISoldier> soldiers)
    {
        Name = name;
        Soldiers = soldiers ?? new List<ISoldier>();
        Score = Soldiers.Sum(s => s.Hp);
    }

    public void UpdateScore()
    {
        Score = Soldiers.Sum(s => s.Hp);
    }
}
