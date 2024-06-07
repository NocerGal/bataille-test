public class Team
{
    public string Name { get; }
    public List<ISoldier> Soldiers { get; }
    public int Score { get; private set; }

    public Team(string name, List<ISoldier> soldiers)
    {
        Name = name;
        Soldiers = soldiers;
        Score = 0;
    }

    public void UpdateScore()
    {
        Score = Soldiers.Sum(s => s.Hp);
    }
}
