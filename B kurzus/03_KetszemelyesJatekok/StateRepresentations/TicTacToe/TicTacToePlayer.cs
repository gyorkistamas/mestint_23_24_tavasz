using _03_KetszemelyesJatekok.Interfaces;
using _03_KetszemelyesJatekok.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.StateRepresentations.TicTacToe
{
    public class TicTacToePlayer
    {
        public Solver Solver { get; set; }

        public TicTacToePlayer()
        {
            Solver = new MiniMax(new TicTacToeOperatorGenerator(), 1);
        }

        public void Play()
        {
            State state = new TicTacToeState();

            Console.WriteLine(state);

            while(state.GetStatus() == Status.PLAYING)
            {
                Operator o;
                do
                {
                    int x = 0;
                    do
                    {
                        Console.Write("X: ");
                    } while(!int.TryParse(Console.ReadLine(), out x));

                    int y = 0;
                    do
                    {
                        Console.Write("Y: ");
                    } while (!int.TryParse(Console.ReadLine(), out y));

                    o = new TicTacToeOperator(x - 1, y - 1, TicTacToeState.PLAYER1);


                } while (!o.IsApplicable(state));

                state = o.Apply(state);

                Console.WriteLine(state);

                if (CheckStatus(state)) break;

                state = Solver.NextMove(state);

                Console.WriteLine(state);

                if (CheckStatus(state)) break;
            }
        }

        private bool CheckStatus(State state)
        {
            if (state.GetStatus() == Status.PLAYER1WINS)
            {
                Console.WriteLine("Player 1 wins!");
                return true;
            }

            if (state.GetStatus() == Status.PLAYER2WINS)
            {
                Console.WriteLine("Player 2 wins!");
                return true;
            }

            if (state.GetStatus() == Status.DRAW)
            {
                Console.WriteLine("DRAW!");
                return true;
            }

            return false;
        }
    }
}
