using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.StateRepresentations.Hanoi
{
    public class HanoiOperatorGenerator : OperatorGenerator
    {
        public List<Operator> Operators { get; }

        public HanoiOperatorGenerator()
        {
            Operators = new List<Operator>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        Operators.Add(new HanoiOperator(i, j));
                    }
                }
            }
        }
    }
}
