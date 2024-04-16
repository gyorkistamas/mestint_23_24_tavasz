using _03_KetszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.Solvers
{
    public class HeuristicSolver : Solver
    {

        public HeuristicSolver(OperatorGenerator operatorGenerator)
            :base(operatorGenerator) { }

        public override State NextMove(State state)
        {
            List<State> states = new List<State>();

            foreach (Operator op in Operators)
            {
                if (op.IsApplicable(state))
                {
                    states.Add(op.Apply(state));
                }
            }

            char player = state.CurrentPlayer;

            // Rendezés csökkenő sorrendben a heurisztika alapján,
            // hogy a legjobb lépés legyen a lista elején
            states.Sort((x, y) =>
            y.GetHeuristics(player).CompareTo(x.GetHeuristics(player)));

            return states[0];
        }
    }
}
