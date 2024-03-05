using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.StateRepresentations.Hanoi
{
    public class HanoiOperator : Operator
    {
        public int From { get; set; }
        public int To { get; set; }

        public HanoiOperator(int from, int to)
        {
            From = from;
            To = to;
        }

        public State Apply(State state)
        {
            if (state == null || !(state is HanoiState))
                throw new Exception("Not Hanoi state");

            HanoiState newState = state.Clone() as HanoiState;

            newState.Discs[GetFromIndex(newState)] = To;

            return newState;
        }

        public bool IsApplicable(State state)
        {
            if (state == null || !(state is HanoiState))
                throw new Exception("Not Hanoi state");

            HanoiState newState = state as HanoiState;

            return From != To &&
                FromPoleHasAnyDisc(newState) &&
                !ToPoleHasSmallerDiscs(newState);
        }

        private bool FromPoleHasAnyDisc(HanoiState state)
        {
            return GetFromIndex(state) > -1;
        }

        private int GetFromIndex(HanoiState state)
        {
            for (int i = 0; i < HanoiState.DiscsNumber; i++)
            {
                if (state.Discs[i] == From)
                    return i;
            }

            return -1;
        }

        private bool ToPoleHasSmallerDiscs(HanoiState state)
        {
            for (int i = GetFromIndex(state) - 1; i >= 0; i--)
            {
                if (state.Discs[i] == To)
                    return true;
            }

            return false;
        }
    }
}
