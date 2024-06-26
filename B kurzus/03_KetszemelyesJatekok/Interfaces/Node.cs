﻿using System;
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

        public List<Node> Children { get; set;}

        public int OperatorIndex { get; set; }

        public Node(State state, Node parent = null)
        {
            Parent = parent;
            State = state;
            OperatorIndex = 0;
            Depth = 0;
            Children = new List<Node>();

            if (Parent != null)
                Depth = Parent.Depth + 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Node)) return false;

            Node other = obj as Node;

            return State.Equals(other.State);
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
                sb.AppendLine("------------------");
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

            return Children[0].GetHeuristics(currentPlayer) - Depth;
        }

        public void SortChildrenMiniMax(char currentPlayer, bool isCurrentPlayer = true)
        {
            foreach(Node node in Children)
            {
                node.SortChildrenMiniMax(currentPlayer, !isCurrentPlayer);
            }
            if (isCurrentPlayer)
            {
                // Csökkenő sorrendbe rendezés, hogy a legnagyobb heursztikéval rendelkező állapot legyen elől
                Children.Sort((x, y) =>
                y.GetHeuristics(currentPlayer).CompareTo(x.GetHeuristics(currentPlayer)));
            }
            else
            {
                Children.Sort((x, y) =>
                x.GetHeuristics(currentPlayer).CompareTo(y.GetHeuristics(currentPlayer)));
            }
        }

        public int Count()
        {

            int count = 0;

            foreach (Node node in Children)
            {
                count = count + node.Count();
            }

            count++;

            return count;
        }
    }
}
