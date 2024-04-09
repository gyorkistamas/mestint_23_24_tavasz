using _03_KetszemelyesJatekok.StateRepresentations.TicTacToe;

namespace _03_KetszemelyesJatekok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToePlayer player = new TicTacToePlayer();

            player.Play();
            Console.ReadLine();
        }
    }
}
