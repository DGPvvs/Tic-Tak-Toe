using System;
using TicTakTok.Game;
using TicTakTok.Players;
using TicTakTok.Players.Contracts;
using TicTakTok.Utilities.Enums;

namespace TicTakTok
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "TicTakTok 1.0";
			bool isLoopExit = false;
			IPlayer player1 = null;
			IPlayer player2 = null;

			while (!isLoopExit)
			{
				Console.WriteLine("Game");
				Console.WriteLine("1. Player vs Player");
				Console.WriteLine("2. Player vs RandomPlayer");
				Console.WriteLine("3. Player vs AIPlayer");
				Console.WriteLine("4. RandomPlayer vs Player");
				Console.WriteLine("5. RandomPlayer vs RandomPlayer");
				Console.WriteLine("6. RandomPlayer vs AIPlayer");
				Console.WriteLine("7. AIPlayer vs Player");
				Console.WriteLine("8. AIPlayer vs RandomPlayer");
				Console.WriteLine("9. AIPlayer vs AIPlayer");
				Console.WriteLine("10. Exit");

				Console.Write("Pleace input game");
				string line = Console.ReadLine();
				switch (line)
				{
					case "1":
						player1 = new ConsolePlayer();
						player2 = new ConsolePlayer();
						break;
					case "2":
						player1 = new ConsolePlayer();
						player2 = new RandomPlayer();
						break;
					case "3":
						player1 = new ConsolePlayer();
						player2 = new AIPlayer();
						break;
					case "4":
						player1 = new RandomPlayer();
						player2 = new ConsolePlayer();
						break;
					case "5":
						player1 = new RandomPlayer();
						player2 = new RandomPlayer();
						break;
					case "6":
						player1 = new RandomPlayer();
						player2 = new AIPlayer();
						break;
					case "7":
						player1 = new AIPlayer();
						player2 = new ConsolePlayer();
						break;
					case "8":
						player1 = new AIPlayer();
						player2 = new RandomPlayer();
						break;
					case "9":
						player1 = new AIPlayer();
						player2 = new AIPlayer();
						break;
					case "10":
						isLoopExit = true;
						break;

					default:
						Console.WriteLine("Wrong input! pleace choise again!");
						Console.ReadLine();
						Console.Clear();
						break;
				}

				if (line != "10")
				{
					if (line == "5" || line == "9")
					{
						Simulate(player1, player2, 10);
					}
					else
					{
						PlayGame(player1, player2);
						Console.Clear();
					}
				}
			}			
		}

		private static void Simulate(IPlayer player1, IPlayer player2, int count)
		{
			int x = 0;
			int o = 0;
			int drow = 0;
			int firstWin = 0;
			int secondWin = 0;

			IPlayer firstPlayer = player1;
			IPlayer secondPlayer = player2;

			for (int i = 0; i < count; i++)
			{
				TicTakTokGame game = new TicTakTokGame(firstPlayer, secondPlayer);
				GameResult result = game.Play();

				if (result.Winner == Symbol.X)
				{
					x++;
				}
				else if (result.Winner == Symbol.O)
				{
					o++;
				}
				else
				{
					drow++;
				}
				if ((result.Winner == Symbol.X) && (firstPlayer.Equals(player1)))
				{
					firstWin++;
				}
				if ((result.Winner == Symbol.O) && (firstPlayer.Equals(player1)))
				{
					secondWin++;
				}
				if ((result.Winner == Symbol.X) && (firstPlayer.Equals(player2)))
				{
					secondWin++;
				}
				if ((result.Winner == Symbol.O) && (firstPlayer.Equals(player2)))
				{
					firstWin++;
				}

				(firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
			}

			Console.WriteLine($"Count: {count}");
			Console.WriteLine($"Drow result: {drow}");
			Console.WriteLine($"X result: {x}");
			Console.WriteLine($"O result: {o}");
			Console.WriteLine($"{player1.GetType().Name} win: {firstWin}");
			Console.WriteLine($"{player2.GetType().Name} win: {secondWin}");

		}

		private static void PlayGame(IPlayer player1, IPlayer player2)
		{
			TicTakTokGame game = new TicTakTokGame(player1, player2);

			GameResult result = game.Play();
			Console.WriteLine("GameOver!");
			if (result.Winner == Symbol.Empty)
			{
				Console.WriteLine("Not winner!");
			}
			else
			{
				Console.WriteLine($"Winner is {result.Winner}");
			}

			Console.WriteLine(result.Board.ToString());
			Console.ReadLine();
		}
	}
}
