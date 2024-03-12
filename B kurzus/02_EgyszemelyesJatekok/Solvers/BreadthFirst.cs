using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class BreadthFirst : Solver
    {
        public Queue<Node> OpenNodes { get; set; }

        public List<Node> ClosedNodes { get; set; }

        public Node CurrentNode { get; set; }

        public Node Path { get; set; }

        public BreadthFirst(OperatorGenerator operatorGenerator, State startingState)
            : base(operatorGenerator)
        {
            OpenNodes = new Queue<Node>();
            ClosedNodes = new List<Node>();

            OpenNodes.Enqueue(new Node(startingState));
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
            Path = null;
            while (OpenNodes.Count > 0)
            {
                CurrentNode = OpenNodes.Dequeue();
                ClosedNodes.Add(CurrentNode);
                if (CurrentNode.IsTargetNode())
                {
                    Path = CurrentNode;
                    break;
                }
                Operator selectedOperator = SelectOperator();
                while (selectedOperator != null)
                {
                    State newState = selectedOperator.Apply(CurrentNode.State);
                    Node newNode = new Node(newState, CurrentNode);
                    
                    if (!OpenNodes.Contains(newNode) && !ClosedNodes.Contains(newNode))
                    {
                        OpenNodes.Enqueue(newNode);
                    }
                    selectedOperator = SelectOperator();
                }
            }
            if (Path == null)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                Console.WriteLine("Solution found:");
                Console.WriteLine("---------------");
                Console.WriteLine(Path);
            }
        }
    }
}
