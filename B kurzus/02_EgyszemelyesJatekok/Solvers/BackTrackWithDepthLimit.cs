using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class BackTrackWithDepthLimit : Solver
    {
        // Szükséges adatok eltárolása
        public int DepthLimit { get; set; }

        public State StartingState { get; set; }

        public Node CurrentNode { get; set; }

        public BackTrackWithDepthLimit(OperatorGenerator operatorGenerator, State startingState, int depthLimit)
            :base(operatorGenerator)
        {
            StartingState = startingState;
            DepthLimit = depthLimit;
        }

        // Következő operátor választása
        public Operator SelectOperator()
        {
            int index = CurrentNode.OperatorIndex++;
            while (index < OperatorGenerator.Operators.Count)
            {
                if (OperatorGenerator.Operators[index].IsApplicable(CurrentNode.State))
                {
                    return OperatorGenerator.Operators[index];
                }
                index = CurrentNode.OperatorIndex++;
            }

            return null;
        }


        public override void Solve()
        {
            CurrentNode = new Node(StartingState);
            // Addig megyünk, amíg végig nem értünk a gráfon VAGY célállapotot nem találtunk.
            while(CurrentNode != null && !CurrentNode.IsTargetNode())
            {
                // Mélységvizsgálat, visszalépés ha kell
                if (CurrentNode.Depth >=  DepthLimit)
                {
                    CurrentNode = CurrentNode.Parent;
                }
                // Követekző csomópont létrehozása
                Operator o = SelectOperator();
                if (o != null)
                {
                    State newState = o.Apply(CurrentNode.State);
                    CurrentNode = new Node(newState, CurrentNode);
                }
                else
                {
                    CurrentNode = CurrentNode.Parent;
                }
            }
            if (CurrentNode != null)
            {
                Console.WriteLine("Solution found!");
                Console.WriteLine(CurrentNode);
            }
            else { Console.WriteLine("Solution not found!"); }
        }
    }
}
