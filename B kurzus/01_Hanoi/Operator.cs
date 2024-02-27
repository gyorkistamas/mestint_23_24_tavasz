using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Hanoi
{
    internal class Operator
    {
        public int From { get; set; }
        public int To { get; set; }

        public Operator(int from, int to)
        {
            From = from;
            To = to;
        }

        public bool IsApplicable(State state)
        {
            return From != To &&
                FromPoleHasAnyDisc(state) &&
                !PoleHasSmallerDisc(state);
        }

        private bool FromPoleHasAnyDisc(State state)
        {
            return GetFromIndex(state) > -1;
        }

        private int GetFromIndex(State state)
        {
            for (int i = 0; i < State.DiscCount; i++)
            {
                if (state.Discs[i] == From)
                    return i;
            }
            return -1;
        }

        private bool PoleHasSmallerDisc(State state)
        {
            for (int i = GetFromIndex(state) - 1; i >= 0; i--)
            {
                if (state.Discs[i] == To)
                    return true;
            }

            return false;
        }

        public State Apply(State state)
        {
            State newState = state.Clone() as State;
            newState.Discs[GetFromIndex(state)] = To;

            return newState;
        }
    }
}
