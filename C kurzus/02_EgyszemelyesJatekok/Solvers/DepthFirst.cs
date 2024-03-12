using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class DepthFirst : Solver
    {
        // HF: szélességi keresés megírása (BreadthFirst)
        // 1. Ezt kell megváltoztatni
        public Stack<Node> OpenNodes { get; set; } = new Stack<Node>();
        public List<Node> ClosedNodes { get; set; } = new List<Node>();

        public Node CurrentNode { get; set; }

        public Node Path {  get; set; }

        public DepthFirst(OperatorGenerator operatorGenerator, State startingState)
            : base (operatorGenerator)
        {
            OpenNodes.Push(new Node(startingState));
        }

        public Operator SelectOperator()
        {
            int index = CurrentNode.OperatorIndex++;
            while(index < OperatorGenerator.Operators.Count)
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

            while(OpenNodes.Count > 0)
            {
                // Kivesszük a legmélyebbi csomópontot
                CurrentNode = OpenNodes.Pop();
                // Mivel kiválasztottuk kiterjesztésre, ezért átrakjuk a zártak közé.
                ClosedNodes.Add(CurrentNode);

                // Ide az elágazás

                // Kiterjesztés
                Operator selectedOperator = SelectOperator();
                while(selectedOperator != null)
                {
                    State newState = selectedOperator.Apply(CurrentNode.State);
                    Node newNode = new Node(newState, CurrentNode);
                    // 2. Szélességi esetén: Belsp ciklus elé kerül és nem a newNode-ot vizsgáljuk, hanem CurrentNode-t
                    if (newNode.IsTargetNode())
                    {
                        Path = newNode;
                        break;
                    }
                    if (!OpenNodes.Contains(newNode) && !ClosedNodes.Contains(newNode))
                    {
                        OpenNodes.Push(newNode);
                    }
                    selectedOperator = SelectOperator();
                }
            }

            if (Path != null)
            {
                Console.WriteLine("Solution found: ");
                Console.WriteLine("----------------");
                Console.WriteLine(Path);
            }
            else
            {
                Console.WriteLine("Can't solve!");
            }
        }
    }
}
