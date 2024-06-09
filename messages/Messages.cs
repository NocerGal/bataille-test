public class Messages
{
    public virtual void PrintHeroScore(string team, ISoldier soldier)
    {
        Console.WriteLine($"Hero of {team}: {soldier.Id} with score {soldier.CalculatedSoldierScore()}");
    }

    public virtual void PrintLikelyWinner(string team)
    {
        Console.WriteLine($"{team} is more likely to win the battle!");
    }
    public virtual void PrintTurn(int turn)
    {
        Console.WriteLine($"Turn {turn}");
    }

    public virtual void PrintBattleWinner(string team, string supposedWinner)
    {
        Console.WriteLine($"{team} won {supposedWinner}!");
    }

}