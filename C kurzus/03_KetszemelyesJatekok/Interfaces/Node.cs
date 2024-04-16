using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.Interfaces
{
    public class Node
    {
        public State State { get; set; }

        public int Depth { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; }

        public int OperatorIndex { get; set; }

        public Node(State state, Node parent = null)
        {
            Parent = parent;
            State = state;
            Depth = 0;
            OperatorIndex = 0;
            Children = new List<Node>();
            if (parent != null)
                Depth = Parent.Depth + 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Node)) return false;

            Node other = obj as Node;

            return this.State.Equals(other.State);
        }

        public Status GetStatus()
        {
            return State.GetStatus();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Parent != null)
            {
                sb.AppendLine(Parent.ToString());
                sb.AppendLine("---------------");
            }
            sb.AppendLine($"Depth: {Depth}");
            sb.AppendLine(State.ToString());
            
            return sb.ToString();
        }

        public int GetHeuristics(char currentPlayer)
        {
            if (Children.Count == 0)
            {
                return State.GetHeuristics(currentPlayer);
            }
            return Children[0].GetHeuristics(currentPlayer);
        }

        public void SortChildrenMinimax(char currentPlayer, bool isCurrentPlayer = true)
        {
            foreach(Node node in Children)
            {
                node.SortChildrenMinimax(currentPlayer, !isCurrentPlayer);
            }
            if (isCurrentPlayer)
            {
                Children.Sort((x, y) =>
                y.GetHeuristics(currentPlayer).CompareTo(x.GetHeuristics(currentPlayer)));
            }
            else
            {
                Children.Sort((x, y) =>
                x.GetHeuristics(currentPlayer).CompareTo(y.GetHeuristics(currentPlayer)));
            }
        }
    }
}
