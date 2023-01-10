using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Game;
using TicTakTok.Players.Contracts;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Players
{
	public class AIPlayer : IPlayer
	{
		private GameWinnerLogic winnerLogic;

		public AIPlayer()
		{
			this.winnerLogic = new GameWinnerLogic(); 
		}

		public GameWinnerLogic WinnerLogic => this.winnerLogic;

		public IndexBoard Play(BoardGame board, Symbol sym)
		{
			IndexBoard bestMove = null;
			int bestMoveValue = int.MinValue;

			IEnumerable<IndexBoard> moves = board.GetemptyPositions();

			foreach (IndexBoard move in moves)
			{
				Symbol currentPlayer = Symbol.Empty;
				if (sym == Symbol.X)
				{
					currentPlayer = Symbol.O;
				}
				else
				{
					currentPlayer = Symbol.X;
				}

				board.PlaceSymbol(move, sym);
				int value = this.MiniMax(board, sym, currentPlayer);
				board.PlaceSymbol(move, Symbol.Empty);
				if (value > bestMoveValue)
				{
					bestMoveValue = value;
					bestMove = move;
				}
			}

			return bestMove;
		}

		private int MiniMax(BoardGame board, Symbol player, Symbol currentPlayer)
		{
			if (this.WinnerLogic.IsGameOver(board))
			{
				Symbol winner = this.winnerLogic.GetWinner(board);

				if (winner == player)
				{
					return 1;
				}

				if (winner == Symbol.Empty)
				{
					return 0;
				}

				return -1;
			}

			int bestValue = 0;
			if (currentPlayer == player)
			{
				bestValue = int.MinValue;
			}
			else
			{
				bestValue = int.MaxValue;
			}

			IEnumerable<IndexBoard> options = board.GetemptyPositions();

			foreach (IndexBoard option in options)
			{
				board.PlaceSymbol(option, currentPlayer);

				Symbol newCurrentPlayer = Symbol.Empty;
				if (currentPlayer == Symbol.O)
				{
					newCurrentPlayer = Symbol.X;
				}
				else
				{
					newCurrentPlayer = Symbol.O;
				}

				int value = this.MiniMax(board, player, newCurrentPlayer);
				board.PlaceSymbol(option, Symbol.Empty);

				if (currentPlayer == player)
				{
					bestValue = Math.Max(bestValue, value);
				}
				else
				{
					bestValue = Math.Min(bestValue, value);
				}
			}

			return bestValue;

		}

		public void Play(Func<BoardGame> isAny)
		{
			throw new NotImplementedException();
		}
	}
}
