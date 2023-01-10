using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Game
{
	public class GameResult
	{
		private Symbol winner;
		private readonly BoardGame board;

		public GameResult(Symbol winner, BoardGame board)
		{
			this.winner = winner;
			this.board = board;
		}

		public Symbol Winner => this.winner;

		public BoardGame Board => this.board;
	}
}
