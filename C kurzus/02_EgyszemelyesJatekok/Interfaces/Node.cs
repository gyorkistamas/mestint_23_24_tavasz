using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Interfaces
{
    public class Node
    {
        public State State {  get; set; }

        public int Depth { get; set; }

        public Node Parent { get; set; }

        public int OperatorIndex { get; set; }

        public Node(State state, Node parent = null)
        {
            Parent = parent;
            State = state;
            OperatorIndex = 0;

            if (parent == null)
                Depth = 0;
            else
                Depth = parent.Depth + 1;
        }

        public override bool Equals(object? obj)
        {
           if (obj == null || !(obj is Node)) return false;

           Node node = obj as Node;

           return State.Equals(node.State);
        }

        public bool IsTargetNode()
        {
            return State.IsTargetState();
        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            if (Parent != null)
            {
                sr.AppendLine(Parent.ToString());
                sr.AppendLine("----------------------");
            }

            sr.AppendLine($"Depth: {Depth}");
            sr.AppendLine(State.ToString());

            return sr.ToString();
        }

        public bool HasLoop()
        {
            Node temp = this.Parent;
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
