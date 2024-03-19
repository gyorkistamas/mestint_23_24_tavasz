using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class BackTrackWithLoopCheck : Solver
    {
        public Node CurrentNode { get; set; }

        public State StartingState { get; set; }

        public BackTrackWithLoopCheck(OperatorGenerator operatorGenerator, State startingState)
            :base(operatorGenerator)
        {
            StartingState = startingState;
        }

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
            while (CurrentNode != null && !CurrentNode.IsTargetNode()) 
            {
                if (CurrentNode.HasLoop())
                {
                    CurrentNode = CurrentNode.Parent;
                }
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
