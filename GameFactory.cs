namespace Lab2;

public class GameFactory
{
    public Game CreateStandardGame(decimal changeOfRating)
    {
        return new StandardGame(changeOfRating);
    }

    public Game CreateTrainingGame()
    {
        return new TrainingGame();
    }

    public Game CreateRandomRatingGame()
    {
        return new RandomRatingGame();
    }
}