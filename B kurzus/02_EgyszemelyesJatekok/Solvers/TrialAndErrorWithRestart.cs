using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Solvers
{
    public class TrialAndErrorWithRestart : Solver
    {
        public Random rnd = new Random();

        public State StartingState;

        public State CurrentState;

        public int MaxRestarts;

        public TrialAndErrorWithRestart(OperatorGenerator operatorGenerator, State startingState, int maxRestarts)
            :base(operatorGenerator)
        {
            StartingState = startingState;
            MaxRestarts = maxRestarts;
        }

        private int[] GetRandomisedIndexes()
        {
            List<int> indexes = new List<int>();

            while (indexes.Count < OperatorGenerator.Operators.Count)
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

            foreach (int index in indexes)
            {
                if (OperatorGenerator.Operators[index].IsApplicable(CurrentState))
                {
                    return OperatorGenerator.Operators[index];
                }
            }

            return null;
        }



        public override void Solve()
        {
            int step = 0;
            int currentRestarts = 0;
            CurrentState = StartingState.Clone() as State;
            Console.WriteLine($"Step: {step}\n");
            Console.WriteLine(CurrentState);
            Console.WriteLine("---------------");
            while(!CurrentState.IsTargetState() && currentRestarts < MaxRestarts)
            {
                Operator o = SelectOperator();
                if (o == null)
                {
                    currentRestarts++;
                    step = 0;
                    CurrentState = StartingState.Clone() as State;
                    Console.WriteLine("Dead end, restarting...");
                }
                else
                {
                    CurrentState = o.Apply(CurrentState);
                }
                Console.WriteLine($"Step: {++step}\n");
                Console.WriteLine(CurrentState);
                Console.WriteLine("---------------");
            }

            if (CurrentState.IsTargetState())
            {
                Console.WriteLine("Solved");
            }
            else
            {
                Console.WriteLine("Failed to solve!");
            }
        }
    }
}
