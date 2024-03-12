using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.StateRepresentations.OneThree
{
    public class OneThreeOperatorGenerator : OperatorGenerator
    {
        public List<Operator> Operators { get; }

        public OneThreeOperatorGenerator()
        {
            Operators = new List<Operator>();
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        Operators.Add(new OneThreeOperator(i, j));
                    }
                }
            }
        }
    }
}
