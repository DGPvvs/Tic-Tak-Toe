using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Players.Contracts;
using TicTakTok.Utilities.Enums;
using TicTakTok.Utilities.Exceptions;

namespace TicTakTok.Players
{
	public class ConsolePlayer : IPlayer
	{
		public IndexBoard Play(BoardGame board, Symbol sym)
		{
			this.DisplayBoard(board);

			bool isExitLoop = false;
			
			IndexBoard position = null;

			while (!isExitLoop)
			{
				Console.WriteLine($"{sym}Enter position (N, N)");
				string line = Console.ReadLine();

				try
				{
					position = new IndexBoard(line);
					isExitLoop = true;
				}
				catch (InvalidArgumentException iAE)
				{
					Console.WriteLine(iAE.Message);
				}

				if (board.GetemptyPositions().Any(x => x.CompareTo(position) == 0))
				{
					isExitLoop = true;
				}
				else
				{
					Console.WriteLine("This position is not available!");
					isExitLoop = false;
				}
			}

			return position;
		}

		public void Play(Func<BoardGame> isAny)
		{
			throw new NotImplementedException();
		}

		private void DisplayBoard(BoardGame board)
		{
			Console.WriteLine(board.ToString());
		}
	}
}
