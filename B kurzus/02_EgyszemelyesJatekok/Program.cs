using _02_EgyszemelyesJatekok.Interfaces;
using _02_EgyszemelyesJatekok.Solvers;
using _02_EgyszemelyesJatekok.StateRepresentations.Hanoi;

namespace _02_EgyszemelyesJatekok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new BackTrackWithBranchLimit(
                new HanoiOperatorGenerator(),
                new HanoiState(), 100
                );

            solver.Solve();

            Console.ReadLine();
        }
    }
}
