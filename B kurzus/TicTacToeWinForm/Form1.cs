using _03_KetszemelyesJatekok.Interfaces;
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

            switch (text)
            {
                case "K�nny�":
                    difficulty = 1;
                    break;

                case "K�zepes":
                    difficulty = 2;
                    break;

                case "Neh�z":
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

        private void UserMoves(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int x = int.Parse(btn.Name.Split('_')[0].Last().ToString());
            int y = int.Parse(btn.Name.Split('_')[1].Last().ToString());

            TicTacToeOperator op = new TicTacToeOperator(x, y, 'X');

            if (!op.IsApplicable(state))
            {
                MessageBox.Show("Ez a l�p�s nem lehets�ges ebben az �llapotban!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            state = op.Apply(state) as TicTacToeState;

            SyncState();

            if (CheckStatus())
                return;

            DisableButtons();
            // T�lt�s jelz�se

            state = solver.NextMove(state) as TicTacToeState;

            // T�lt�s jelz�s�nek elrejt�se

            SyncState();

            CheckStatus();

        }

        private bool CheckStatus()
        {
            switch(state.GetStatus())
            {
                case Status.PLAYER1WINS:
                    labelResult.Text = "Els� j�t�kos nyert!";
                    DisableButtons();
                    labelResult.ForeColor = Color.Green;
                    return true;

                case Status.PLAYER2WINS:
                    labelResult.Text = "M�sodik j�t�kos nyert!";
                    DisableButtons();
                    labelResult.ForeColor = Color.Red;
                    return true;

                case Status.DRAW:
                    labelResult.Text = "D�ntetlen";
                    DisableButtons();
                    labelResult.ForeColor = Color.Orange;
                    return true;

            }

            return false;
        }
    }
}
