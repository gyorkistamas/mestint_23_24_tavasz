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
    
        // Kezdeti limit, jelenlegi csomópont, keződállapot, célállapot, jelenlegi mélységi limit tárolása
        public int DepthLimit { get; set; }
        public Node CurrentNode { get; set; }
        public State StartingState { get; set; }
        public Node Path { get; set; }

        public int CurrentDepthLimit {  get; set; }

        public BackTrackWithBranchLimit(OperatorGenerator operatorGenerator, State startingState, int depthLimit)
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

        // Jelenlegi csomópont vizsgálata
        private void CheckCurrentNode()
        {
            // Ha a csomópont célállapotot tartalmaz
            if (CurrentNode.IsTargetNode())
            {
                // És ha még nincs megoldásunk, vagy ez a megoldás jobb
                if (Path == null || Path.Depth > CurrentNode.Depth)
                {
                    // Akkro eltároljuk az állapotot és megnöveljük a limitet a csomópont értékére
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
            // Addig megyünk amíg fel nem tártuk az egész gráfot: ha visszalépünk a kezdő csúcsból (tehát null lesz) jelenti azt, hogy véggimentünk a gráfon, mivel nincs több alkalmazható operátor.
            while(CurrentNode != null)
            {
                // Körfigyelés, mélységvizsgálat
                if (CurrentNode.HasLoop() || CurrentNode.Depth >= CurrentDepthLimit)
                {
                    // Visszalépés
                    CurrentNode = CurrentNode.Parent;
                    continue;
                }
                // Operátorválasztás, új csúcs létrehozása
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
            else { Console.WriteLine("Solution not found!"); }
        }
    }
}
