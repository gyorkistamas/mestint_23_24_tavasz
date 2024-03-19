using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class BackTrackWithBranchLimit : Solver
    {
        public int DepthLimit { get; set; }

        public Node CurrentNode {  get; set; }

        public State StartingState {  get; set; }

        public Node Path {  get; set; }

        public int CurrentDepthLimit {  get; set; }

        public BackTrackWithBranchLimit(OperatorGenerator operatorGenerator, State startingState, int depthLimit)
            :base(operatorGenerator)
        {
            StartingState = startingState;
            DepthLimit = depthLimit;
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

        private void CheckCurrentNode()
        {
            if (CurrentNode.IsTargetNode())
            {
                if (Path == null || Path.Depth > CurrentNode.Depth)
                {
                    Path = CurrentNode;
                    CurrentDepthLimit = CurrentNode.Depth;
                    CurrentNode = CurrentNode.Parent;
                }
            }
        }

        public override void Solve()
        {
            CurrentDepthLimit = DepthLimit;
            Path = null;
            CurrentNode = new Node(StartingState);
            while (CurrentNode != null)
            {
                if (CurrentNode.HasLoop() || CurrentNode.Depth >= CurrentDepthLimit)
                {
                    CurrentNode = CurrentNode.Parent;
                    continue;
                }
                Operator o = SelectOperator();
                if (o != null)
                {
                    State newState = o.Apply(CurrentNode.State);
                    CurrentNode = new Node(newState, CurrentNode);
                    CheckCurrentNode();
                }
                else
                {
                    CurrentNode = CurrentNode.Parent;
                }
            }
            if (Path != null)
            {
                Console.WriteLine("Solution found!");
                Console.WriteLine(Path);
            }
            else { Console.WriteLine("No solution found!"); }
        }
    }
}
