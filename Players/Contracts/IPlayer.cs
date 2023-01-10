using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Players.Contracts
{
	public interface IPlayer
	{
		public IndexBoard Play(BoardGame board, Symbol symbol);
		void Play(Func<BoardGame> isAny);
	}
}
