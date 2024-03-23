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
        //Nyílt csomópontok
        public Stack<Node> OpenNodes { get; set; }

        // Zárt csomópontok
        public List<Node> ClosedNodes { get; set; }

        public Node CurrentNode { get; set; }

        public Node Path { get; set; }

        public DepthFirst(OperatorGenerator operatorGenerator, State startingState)
            :base(operatorGenerator)
        {
            OpenNodes = new Stack<Node>();
            ClosedNodes = new List<Node>();

            OpenNodes.Push(new Node(startingState));
        }

        // Következő operátor választása
        public Operator SelectOperator()
        {
            int index = CurrentNode.OperatorIndex++;
            while( index < OperatorGenerator.Operators.Count )
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
            // Addig megyünk, amíg van nyílt csomópont (tehát amíg nem tártuk fel az össze csomópontot, a.k.a a gráfot)
            while (OpenNodes.Count > 0)
            {
                // Kivesszük a legnagyobb mélységűt
                CurrentNode = OpenNodes.Pop();
                // Kiválasztottuk kiterjesztésre, átrakjuk a zártak közé.
                ClosedNodes.Add(CurrentNode);
                Operator  selectedOperator = SelectOperator();
                // Kiterjesztés: operátort választunk, tesszük ezt addig, amíg van alkalmazható operátor
                while (selectedOperator != null)
                {
                    // Létrehozzuk az új csomópontot
                    State newState = selectedOperator.Apply(CurrentNode.State);
                    Node newNode = new Node(newState, CurrentNode);
                    // Megvizsgáljuk, hogy az újonnan létrejött csomópont célállapot-e, ha igen eltároljuk
                    if (newNode.IsTargetNode())
                    {
                        Path = newNode;
                        break;
                    }
                    // Ha még nem tártuk fel ezt a csomópontot, akkor hozzáadjuk a nyíltakhoz.
                    if (!OpenNodes.Contains(newNode) && !ClosedNodes.Contains(newNode))
                    {
                        OpenNodes.Push(newNode);
                    }
                    selectedOperator = SelectOperator();
                }
            }
            if (Path == null)
            {
                Console.WriteLine("No  solution found!");
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
