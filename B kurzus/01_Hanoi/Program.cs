namespace _01_Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new State();
            Console.WriteLine(state);
            string input;
            do
            {
                int from;
                int to;

                while (true)
                {
                    Console.WriteLine("From: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out from))
                        break;
                    Console.WriteLine("Invalid input");
                }

                while (true)
                {
                    Console.WriteLine("To: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out to))
                        break;
                    Console.WriteLine("Invalid input");
                }

                Operator op = new Operator(from - 1, to - 1);
                Console.WriteLine("-----------------------------------");
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
            Console.WriteLine("---------------------------");
            Console.WriteLine("Congratulations!");
            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }
    }
}
