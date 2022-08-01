using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        private static int xScore = 0;
        private static int oScore = 0;
        private static char winner = ' ';
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("First to take turn is X so be wise :)");
            Console.WriteLine("To make a move choose a position(from 1 to 3).\nExample:\n1\n2\nWill place the figure on position 1, 2 like so:\n| | | |\n|X| | |\n| | | |");
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
            Run();
        }

        private static void Run()
        {

            var playGrid = new char[3, 3];
            playGrid = SetPlayGrid(playGrid);
            int turnCounter = 0;
            NextMove nextToMove;
            while (true)
            {
                nextToMove = DetermineNextTurn(turnCounter);
                Console.Clear();
                Print(playGrid);
                Console.WriteLine($"\n   RESULT : \n X: {xScore} || O: {oScore}\n");
                Console.WriteLine($"It is {nextToMove}'s turn");
                int[] nextMoveCoordinates = Input(playGrid);
                playGrid = MakeAMove(playGrid, nextMoveCoordinates, nextToMove);
                if (CheckGameStat(playGrid))
                {
                    Console.WriteLine();
                    Console.WriteLine("Do you want to restart (Yes/No) :");
                    var restart = Console.ReadLine().ToLower();
                    if (restart == "yes")
                        Run();
                    else
                        return;
                }
                turnCounter++;
            }
        }
        private static void Winner(char winner, char[,] playGrid)
        {
            if (winner == 'D')
            {
                Console.WriteLine("The game is Draw !");
            }
            else
            {
                Console.WriteLine($"The Winner is {winner}");
            }
            Print(playGrid);
            if (winner == 'X')
                xScore++;
            else if (winner == 'O')
                oScore++;
            else
            {
                xScore++;
                oScore++;
            }
        }
        private static bool CheckGameStat(char[,] playGrid)
        {
            bool isFull = true;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (playGrid[0, y] != ' ' && playGrid[0, y] == playGrid[1, y] && playGrid[0, y] == playGrid[2, y])
                    {
                        var winner = playGrid[0, y];
                        Winner(winner, playGrid);
                        return true;
                    }
                    if (playGrid[y, 0] != ' ' && playGrid[y, 0] == playGrid[y, 1] && playGrid[y, 0] == playGrid[y, 2])
                    {
                        var winner = playGrid[y, 0];
                        Winner(winner, playGrid);
                        return true;
                    }
                }
            }
            if (playGrid[0, 0] != ' ' && playGrid[0, 0] == playGrid[1, 1] && playGrid[0, 0] == playGrid[2, 2])
            {
                var winner = playGrid[0, 0];
                Winner(winner, playGrid);
                return true;
            }
            if (playGrid[0, 2] != ' ' && playGrid[0, 2] == playGrid[1, 1] && playGrid[0, 2] == playGrid[2, 0])
            {
                var winner = playGrid[0, 2];
                Winner(winner, playGrid);
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (playGrid[i, j] == ' ')
                    {
                        isFull = false;

                    }
                }
            }
            if (isFull)
            {
                var winner = 'D';
                Winner(winner, playGrid);
                return true;
            }
            return false;
        }
        private static int[] Input(char[,] playGrid)
        {
            var validInput = false;
            int x = 0;
            int y = 0;
            int xNew = 0;
            int yNew = 0;
            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Select column (1 to 3) :");
                    y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Select row (1 to 3) :");
                    x = int.Parse(Console.ReadLine());
                    if (x > 0 && y > 0 && x <= 3 && y <= 3)
                    {
                        validInput = true;
                    }
                    else
                        Console.WriteLine($"Invalid Input (X and Y must be from 1 to 3) you entered : {x}, {y}\nTry Again !");
                    if (validInput)
                    {
                        xNew = x - 1;
                        //yNew = 2;
                        //if (y == 1)
                        //    yNew = 0;
                        //else if (y == 3)
                        //    yNew = 4;
                        yNew = y - 1;
                        if (playGrid[xNew, yNew] != ' ')
                        {
                            Console.WriteLine($"Invalid Input (On {x}, {y} already has a figure), Try Again !");
                            validInput = false;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("TRY AGAIN !");
                }

            }
            return new int[2] { xNew, yNew };
        }
        private static char[,] MakeAMove(char[,] playGrid, int[] nextMoveCoordinates, NextMove figure)
        {
            int nMX = nextMoveCoordinates[0];
            int nMY = nextMoveCoordinates[1];

            if (playGrid[nMX, nMY] == ' ')
                playGrid[nMX, nMY] = (char)figure;
            return playGrid;
        }
        private static NextMove DetermineNextTurn(int turn)
        {
            if (turn % 2 != 0)
                return NextMove.O;
            else
                return NextMove.X;
        }
        private static char[,] SetPlayGrid(char[,] playGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)//5
                {
                    //if (x % 2 != 0)
                    //    playGrid[i, x] = '|';
                    //else
                    playGrid[i, x] = ' ';
                }
            }
            return playGrid;
        }
        private static void Print(char[,] playGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write("|" + playGrid[i, x]);
                    if (x == 2)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}






//Every Line is Written BY TerminiUsMag!
