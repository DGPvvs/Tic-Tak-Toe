using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Players.Contracts;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Game
{
	public class TicTakTokGame
	{
		private IPlayer firstPlayer;
		private IPlayer secondPlayer;
		private GameWinnerLogic winerLogic;

		public TicTakTokGame(IPlayer firstPlayer, IPlayer secondPlayer)
		{
			this.SecondPlayer = secondPlayer;
			this.FirstPlayer = firstPlayer;
			this.winerLogic = new GameWinnerLogic();
		}

		public IPlayer FirstPlayer
		{
			get => this.firstPlayer;
			private set => this.firstPlayer = value;
		}
		public IPlayer SecondPlayer
		{
			get => this.secondPlayer;
			private set => this.secondPlayer = value;
		}

		public GameWinnerLogic WinerLogic => this.winerLogic;

		public GameResult Play()
		{
			BoardGame board = new BoardGame();
			IPlayer currentPlayer = this.FirstPlayer;
			Symbol symbol = Symbol.X; 

			while (!(this.WinerLogic.IsGameOver(board)))
			{
				IndexBoard move = currentPlayer.Play(board, symbol);
				board.PlaceSymbol(move, symbol);

				if (currentPlayer == this.FirstPlayer)
				{
					currentPlayer = this.SecondPlayer;
					symbol = Symbol.O;
				}
				else
				{
					currentPlayer = this.FirstPlayer;
					symbol = Symbol.X;
				}

			}

			Symbol winner = this.WinerLogic.GetWinner(board);

			return new GameResult(winner, board);
		}

				
	}
}
