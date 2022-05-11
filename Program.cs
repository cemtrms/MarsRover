using MarsRover;

class Program
{
    static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine().Split();
        int maxX = int.Parse(tokens[0]);
        int maxY = int.Parse(tokens[1]);
        do
        {
            var positionLine = Console.ReadLine();
            if (string.IsNullOrEmpty(positionLine))
                break;
            Rover rover = ParseRover(positionLine);
            var moveLine = Console.ReadLine();

            foreach (char move in moveLine)
            {
                switch (move)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    case 'M':
                        rover.Forward();
                        rover.Limit(maxX, maxY);
                        break;
                }
            }
            Console.WriteLine(rover);
        } while (true);
    }
    private static Rover ParseRover(string positionLine)
    {
        var positionTokens = positionLine.Split();
        int[] pos = new int[]
        {
            int.Parse(positionTokens[0]),
            int.Parse(positionTokens[1]),
        };
        char heading = positionTokens[2][0];
        return new Rover(pos, heading);
    }
}