namespace Lab2
{
    public abstract class Program
    {
        public static void Main()
        {
            GameFactory factory = new GameFactory();

            StandardGameAccount player1 = new StandardGameAccount("Max", 466);
            ReducedLossGameAccount player2 = new ReducedLossGameAccount("Fernando", 183);
            WinningStreakGameAccount player3 = new WinningStreakGameAccount("Carlos", 171);

            Game standardGame = factory.CreateStandardGame(25);
            Game trainingGame = factory.CreateTrainingGame();
            Game randomGame = factory.CreateRandomRatingGame();

            player1.WinGame(standardGame);
            player3.LoseGame(trainingGame);
            player2.WinGame(randomGame);
            
            Game standardGame2 = factory.CreateStandardGame(33);
            Game trainingGame2 = factory.CreateTrainingGame();
            Game randomGame2 = factory.CreateRandomRatingGame();
            
            player3.LoseGame(standardGame2);
            player1.WinGame(trainingGame2);
            player2.LoseGame(randomGame2);

            Console.WriteLine($"{player1.UserName}'s Stats:");
            Console.WriteLine(player1.GetStats());

            Console.WriteLine($"{player2.UserName}'s Stats:");
            Console.WriteLine(player2.GetStats());
            
            Console.WriteLine($"{player3.UserName}'s Stats:");
            Console.WriteLine(player3.GetStats());
        }
    }
}