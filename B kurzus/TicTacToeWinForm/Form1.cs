using _03_KetszemelyesJatekok.Solvers;
using _03_KetszemelyesJatekok.StateRepresentations.TicTacToe;

namespace TicTacToeWinForm
{
    public partial class Form1 : Form
    {
        MiniMax solver;

        TicTacToeState state;


        public Form1()
        {
            InitializeComponent();

            labelResult.Text = "";
            comboBoxDifficulty.SelectedIndex = 0;

            solver = new MiniMax(new TicTacToeOperatorGenerator(), 0);

            state = new TicTacToeState();

            SyncState();
            DisableButtons();
        }

        private void SyncState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = Controls.OfType<Button>().FirstOrDefault(
                        b => b.Name == $"button{i}_{j}"
                        );

                    button.Text = state.Board[i, j].ToString();

                    if (state.Board[i, j] != ' ')
                        button.Enabled = false;
                    else
                        button.Enabled = true;
                }
            }
        }

        private void DisableButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = Controls.OfType<Button>().FirstOrDefault(
                       b => b.Name == $"button{i}_{j}"
                       );

                    button.Enabled = false;
                }
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            int difficulty = 0;

            string text = comboBoxDifficulty.Text;

            switch(text)
            {
                case "Könnyû":
                    difficulty = 1;
                    break;

                case "Közepes":
                    difficulty = 2;
                    break;

                case "Nehéz": 
                    difficulty = 5;
                    break;

                default:
                    difficulty = 3;
                    break;
            }

            solver.Depth = difficulty;

            state = new TicTacToeState();

            SyncState();
            labelResult.Text = "";
        }
    }
}
