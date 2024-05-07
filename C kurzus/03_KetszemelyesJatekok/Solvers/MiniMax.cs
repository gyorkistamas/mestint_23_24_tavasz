using _03_KetszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.Solvers
{
    public class MiniMax : Solver
    {
        public int Depth { get; set; }

        public MiniMax(OperatorGenerator operatorGenerator, int depth)
            :base(operatorGenerator)
        {
            Depth = depth;
        }


        public override State NextMove(State state)
        {
            Node node = new Node(state);

            ExtendNode(node);

            node.SortChildrenMiniMax(state.CurrentPlayer);

            return node.Children[0].State;

        }

        private void ExtendNode(Node node)
        {
            if (node.GetStatus() != Status.PLAYING || node.Depth >= Depth) return;

            foreach (Operator op in Operators)
            {
                if (op.IsApplicable(node.State))
                {
                    State newState = op.Apply(node.State);
                    Node newNode = new Node(newState, node);
                    node.Children.Add(newNode);
                    ExtendNode(newNode);
                }
            }
        }
    }
}
