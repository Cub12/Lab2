namespace Lab2;

public abstract class Game
{
    protected decimal ChangeOfRating { get; }

    protected Game(decimal changeOfRating)
    {
        ChangeOfRating = changeOfRating;
    }
    
    public abstract decimal CalculateRating();
}

public class StandardGame : Game
{
    public StandardGame(decimal changeOfRating) : base(changeOfRating) { }

    public override decimal CalculateRating()
    {
        return ChangeOfRating;
    }
}

public class TrainingGame : Game
{
    public TrainingGame() : base(0) { }

    public override decimal CalculateRating()
    {
        return 0;
    }
}

public class RandomRatingGame : Game
{
    public RandomRatingGame() : base(0) { }

    public override decimal CalculateRating()
    {
        Random random = new Random();
        return random.Next(5, 11);
    }
}