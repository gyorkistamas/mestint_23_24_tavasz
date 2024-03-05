using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class TrialAndError : Solver
    {
        public Random rnd = new Random();

        public State CurrentState;

        public TrialAndError(OperatorGenerator operatorGenerator, State startingState)
            : base(operatorGenerator)
        {
            CurrentState = startingState;
        }

        private int[] GetRandomisedIndexes()
        {
            List<int> indexes = new List<int>();

            while(indexes.Count < OperatorGenerator.Operators.Count)
            {
                int number;
                do
                {
                    number =
                        rnd.Next(0, OperatorGenerator.Operators.Count);
                } while (indexes.Contains(number));
                indexes.Add(number);
            }

            return indexes.ToArray();
        }

        private Operator SelectOperator()
        {
            int[] indexes = GetRandomisedIndexes();

            foreach(int index in indexes)
            {
                if (OperatorGenerator.Operators[index].IsApplicable(CurrentState))
                {
                    return OperatorGenerator.Operators[index];
                }
            }

            throw new Exception("Dead end");
        }


        public override void Solve()
        {
            int step = 0;
            Console.WriteLine($"Step: {step}\n");
            Console.WriteLine(CurrentState);
            Console.WriteLine("--------------------");
            while(!CurrentState.IsTargetState())
            {
                Operator o = SelectOperator();
                CurrentState = o.Apply(CurrentState);
                Console.WriteLine($"Step: {++step}");
                Console.WriteLine(CurrentState);
                Console.WriteLine("------------------");
            }

            Console.WriteLine("Solved!");
        }
    }
}
