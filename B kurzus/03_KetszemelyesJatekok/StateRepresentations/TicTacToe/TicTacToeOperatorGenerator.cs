using _03_KetszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.StateRepresentations.TicTacToe
{
    public class TicTacToeOperatorGenerator : OperatorGenerator
    {
        public List<Operator> Operators { get; }

        public TicTacToeOperatorGenerator()
        {
            Operators = new List<Operator>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Operators.Add(new TicTacToeOperator(i, j,
                        TicTacToeState.PLAYER1));

                    Operators.Add(new TicTacToeOperator(i, j,
                        TicTacToeState.PLAYER2));
                }
            }
        }
    }
}
