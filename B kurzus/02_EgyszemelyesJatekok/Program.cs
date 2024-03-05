using _02_EgyszemelyesJatekok.Interfaces;
using _02_EgyszemelyesJatekok.Solvers;
using _02_EgyszemelyesJatekok.StateRepresentations.Hanoi;

namespace _02_EgyszemelyesJatekok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new TrialAndErrorWithRestart(
                new HanoiOperatorGenerator(),
                new HanoiState(), 10
                );

            solver.Solve();

            Console.ReadLine();
        }
    }
}
