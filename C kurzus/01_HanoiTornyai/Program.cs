namespace _01_HanoiTornyai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new State();
            Console.WriteLine(state);
            do
            {
                int from;
                int to;
                while(true)
                {
                    Console.Write("From: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out from))
                        break;
                    Console.WriteLine("Incorrect input");
                }

                while (true)
                {
                    Console.Write("To: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out to))
                        break;
                    Console.WriteLine("Incorrect input");
                }

                Operator op = new Operator(from - 1, to - 1);

                Console.WriteLine("-------------------");

                if (op.IsApplicable(state))
                {
                    state = op.Apply(state);
                    Console.WriteLine(state);
                }
                else
                {
                    Console.WriteLine("The operator is not applicable!");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(state);
                }


            } while (!state.IsTargetState());
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Congratulation!");
            Console.WriteLine("---------------------------- ");
            Console.ReadLine();
        }
    }
}
