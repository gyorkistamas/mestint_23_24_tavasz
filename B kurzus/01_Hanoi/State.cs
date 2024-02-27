using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Hanoi
{
    internal class State : ICloneable
    {
        public const int DiscCount = 3;
        public int[] Discs { get; set; }

        public State()
        {
            Discs = new int[DiscCount];
        }

        public bool IsTargetState()
        {
            foreach (var disc in Discs)
            {
                if (disc != 2)
                    return false;
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is State))
                return false;

            State other = obj as State;

            for (int i = 0;i < DiscCount; i++)
            {
                if (other.Discs[i] != this.Discs[i])
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder pole1 = new StringBuilder("Pole 1: ");
            StringBuilder pole2 = new StringBuilder("\nPole 2: ");
            StringBuilder pole3 = new StringBuilder("\nPole 3: ");

            for(int i = DiscCount - 1; i >=0; i--)
            {
                switch(Discs[i])
                {
                    case 0:
                        pole1.Append($"{i + 1} ");
                        break;

                    case 1:
                        pole2.Append($"{i + 1} ");
                        break;

                    case 2:
                        pole3.Append($"{i + 1} ");
                        break;
                }
            }
            return pole1.Append(pole2).Append(pole3).ToString();
        }

        public object Clone()
        {
            State newState = new State();
            for (int i = 0; i < DiscCount; i++)
            {
                newState.Discs[i] = this.Discs[i];
            }

            return newState;
        }
    }
}
