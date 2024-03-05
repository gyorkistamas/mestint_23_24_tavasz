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

        public State CurrentState;

        public State StartingState;

        public int MaxRestarts;

        public TrialAndErrorWithRestart(OperatorGenerator generator, State startingState, int maxRestarts)
            : base(generator)
        {
            StartingState = startingState;
            MaxRestarts = maxRestarts;
        }

        private int[] GetRandomIndexes()
        {
            List<int> indexes = new List<int>();
            while (indexes.Count < OperatorGenerator.Operators.Count)
            {
                int number;
                do
                {
                    number = rnd.Next(0, OperatorGenerator.Operators.Count);
                } while (indexes.Contains(number));
                indexes.Add(number);
            }

            return indexes.ToArray();
        }

        private Operator SelectOperator()
        {
            int[] indexes = GetRandomIndexes();

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
            Console.WriteLine("--------------------");
            while(currentRestarts < MaxRestarts &&
                !CurrentState.IsTargetState())
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
                Console.WriteLine($"Step: {++step}");
                Console.WriteLine(CurrentState);
                Console.WriteLine("--------------------");
            }
            if (CurrentState.IsTargetState())
            {
                Console.WriteLine("Solved");
            }
            else
            {
                Console.WriteLine("Failed to solve");
            }
        }
    }
}
