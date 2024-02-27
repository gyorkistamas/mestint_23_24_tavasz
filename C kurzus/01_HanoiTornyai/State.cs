using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HanoiTornyai
{
    internal class State : ICloneable
    {
        public const int DiscsNumber = 3;

        public int[] Discs { get; set; }

        public State()
        {
            Discs = new int[DiscsNumber];
        }

        public bool IsTargetState()
        {
            foreach(int discs in  Discs)
            {
                if (discs != 2)
                    return false;
            }
            return true;
        }

        public object Clone()
        {
            State newState = new State();
            for (int i = 0; i < DiscsNumber; i++)
            {
                newState.Discs[i] = this.Discs[i];
            }

            return newState;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is State))
                return false;

            State other = (State)obj;

            for(int i = 0; i < DiscsNumber;i++) 
            {
                if (this.Discs[i] != other.Discs[i])
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder pole1 = new StringBuilder("Pole 1: ");
            StringBuilder pole2 = new StringBuilder("\nPole 2: ");
            StringBuilder pole3 = new StringBuilder("\nPole 3: ");

            for(int i = DiscsNumber - 1; i >= 0; i--)
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
    }
}
