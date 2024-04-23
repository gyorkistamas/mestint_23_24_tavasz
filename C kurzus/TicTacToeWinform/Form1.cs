using _03_KetszemelyesJatekok.Interfaces;
using _03_KetszemelyesJatekok.Solvers;
using _03_KetszemelyesJatekok.StateRepresentations.TicTacToe;

namespace TicTacToeWinform
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
        private void DisableButtons()
        {
            button0_0.Enabled = false;
            button0_1.Enabled = false;
            button0_2.Enabled = false;
            button1_0.Enabled = false;
            button1_1.Enabled = false;
            button1_2.Enabled = false;
            button2_0.Enabled = false;
            button2_1.Enabled = false;
            button2_2.Enabled = false;
        }

        private void SyncState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = Controls.OfType<Button>().FirstOrDefault(
                        b => b.Name == $"button{i}_{j}");

                    button.Text = state.Board[i, j].ToString();

                    if (state.Board[i, j] != ' ')
                        button.Enabled = false;
                    else
                        button.Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartGame(object sender, EventArgs e)
        {
            int difficulty = 0;
            string text = comboBoxDifficulty.Text;

            switch (text)
            {
                case "Könnyû":
                    difficulty = 1;
                    break;
                case "Nehéz":
                    difficulty = 5;
                    break;
                default:
                    difficulty = 2;
                    break;
            }

            solver.Depth = difficulty;

            state = new TicTacToeState();
            SyncState();

            labelResult.Text = "";
        }

        private void UserMoves(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int X = int.Parse(btn.Name.Split('_')[0].Last().ToString());
            int Y = int.Parse(btn.Name.Split('_')[1].Last().ToString());

            TicTacToeOperator op = new TicTacToeOperator(X, Y, 'X');

            if (!op.IsApplicable(state))
            {
                MessageBox.Show("Ez a lépés nem lehetséges!");
                return;
            }

            state = op.Apply(state) as TicTacToeState;

            SyncState();

            if (CheckStatus())
                return;

            DisableButtons();

            state = solver.NextMove(state) as TicTacToeState;

            SyncState();

            CheckStatus();

        }

        private bool CheckStatus()
        {
            switch(state.GetStatus())
            {
                case Status.PLAYER1WINS:
                    labelResult.Text = "Elsõ játékos nyert!";
                    DisableButtons();
                    return true;

                case Status.PLAYER2WINS:
                    labelResult.Text = "Második játékos nyert!";
                    DisableButtons();
                    return true;

                case Status.DRAW:
                    labelResult.Text = "Döntetlen";
                    DisableButtons();
                    return true;
            }

            return false;
        }
    }
}
