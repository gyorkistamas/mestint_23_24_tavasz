using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Interfaces
{
    public class Node
    {
        public State State { get; set; }

        public Node Parent { get; set; }

        public int Depth { get; set; }
        public int OperatorIndex { get; set; }

        public Node(State state, Node parent = null)
        {
            Parent = parent;
            State = state;
            if (parent == null)
            {
                Depth = 0;
            }
            else
            {
                Depth = parent.Depth + 1;
            }
            OperatorIndex = 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Node)) return false;

            Node other = obj as Node;

            return State.Equals(other.State);
        }

        public bool IsTargetNode()
        {
            return State.IsTargetState();
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

        public bool HasLoop()
        {
            Node temp = Parent;
            while (temp != null)
            {
                if (temp.Equals(this))
                    return true;

                temp = temp.Parent;
            }

            return false;
        }
    }
}
