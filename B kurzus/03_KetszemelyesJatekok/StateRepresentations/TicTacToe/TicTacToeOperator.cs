using _03_KetszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.StateRepresentations.TicTacToe
{
    public class TicTacToeOperator : Operator
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public char Player {  get; set; }

        public TicTacToeOperator(int x, int y, char player)
        {
            X = x;
            Y = y;
            Player = player;
        }
        public bool IsApplicable(State state)
        {
            if (state == null || !(state is TicTacToeState)) return false;

            TicTacToeState ticTacToeState = state as TicTacToeState;

            return ticTacToeState.Board[X, Y] == TicTacToeState.BLANK &&
                   ticTacToeState.CurrentPlayer == Player;
        }

        public State Apply(State state)
        {
            if (state == null || !(state is TicTacToeState))
                throw new Exception("Not TicTacToeState");

            TicTacToeState newState = state.Clone() as TicTacToeState;

            newState.Board[X, Y] = Player;
            newState.ChangePlayer();

            return newState;
        }

        
    }
}
