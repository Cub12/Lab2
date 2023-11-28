namespace Lab2;

public class GameStatistics
{
    public bool Won { get; }
    public decimal ChangeOfRating { get; }
    public int GameIndex { get; }

    public GameStatistics(bool won, decimal changeOfRating, int gameIndex)
    {
        Won = won;
        ChangeOfRating = changeOfRating;
        GameIndex = gameIndex;
    }
}