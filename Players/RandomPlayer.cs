using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Players.Contracts;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Players
{
	public class RandomPlayer : IPlayer
	{
		private Random rnd;

		public RandomPlayer()
		{
			this.rnd = new Random();
		}
		public IndexBoard Play(BoardGame board, Symbol sym)
		{
			List<IndexBoard> aviablePosition = board.GetemptyPositions().ToList();
			return aviablePosition[rnd.Next(aviablePosition.Count)];
		}

		public void Play(Func<BoardGame> isAny)
		{
			throw new NotImplementedException();
		}
	}
}
