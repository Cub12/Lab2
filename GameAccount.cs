namespace Lab2;

public abstract class GameAccount
{
    private static int _totalGamesCount;
    public string UserName { get; }
    private decimal CurrentRating { get; set; }
    private readonly List<GameStatistics> _allGames = new();

    protected GameAccount(string name, decimal rating)
    {
        if (rating < 1)
        {
            rating = 1;
        }

        UserName = name;
        CurrentRating = rating;
    }

    public void WinGame(Game game)
    {
        decimal changeOfRating = game.CalculateRating();
        
        if (changeOfRating < 0)
        {
            changeOfRating = 0;
        }
        
        _allGames.Add(new GameStatistics(true, changeOfRating, ++_totalGamesCount));
        CurrentRating += CalculateWinPoints(changeOfRating);
    }

    public void LoseGame(Game game)
    {
        decimal changeOfRating = game.CalculateRating();
        if (changeOfRating < 0)
        {
            changeOfRating = 0;
        }
        
        CurrentRating -= CalculateLosePoints(changeOfRating);
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }

        _allGames.Add(new GameStatistics(false, changeOfRating, ++_totalGamesCount));
    }

    public string GetStats()
    {
        var report = "";
        foreach (var game in _allGames)
        {
            var result = game.Won ? "Win" : "Lose";
            report += $"Result: {result}, Change of Rating: " + $"{game.ChangeOfRating}, Game Index: {game.GameIndex}\n";
        }
        
        report += $"Final Rating: {CurrentRating}\n";
        return report;
    }

    protected virtual decimal CalculateWinPoints(decimal changeOfRating)
    {
        return changeOfRating;
    }

    protected virtual decimal CalculateLosePoints(decimal changeOfRating)
    {
        return changeOfRating;
    }
}
    
public class StandardGameAccount : GameAccount
{
    public StandardGameAccount(string name, decimal rating) : base(name, rating) { }
}

public class ReducedLossGameAccount : GameAccount
{
    public ReducedLossGameAccount(string name, decimal rating) : base(name, rating) { }

    protected override decimal CalculateLosePoints(decimal changeOfRating)
    {
        return changeOfRating / 2;
    }
}

public class WinningStreakGameAccount : GameAccount
{
    private int _consecutiveWins;
    public WinningStreakGameAccount(string name, decimal rating) : base(name, rating) { }

    protected override decimal CalculateWinPoints(decimal changeOfRating)
    {
        _consecutiveWins++;
        if (_consecutiveWins >= 3)
        {
            return changeOfRating + 100;
        }
        return changeOfRating;
    }

    protected override decimal CalculateLosePoints(decimal changeOfRating)
    {
        _consecutiveWins = 0;
        return changeOfRating;
    }
}