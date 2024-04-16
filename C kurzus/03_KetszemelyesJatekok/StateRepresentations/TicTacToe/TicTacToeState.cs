using _03_KetszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KetszemelyesJatekok.StateRepresentations.TicTacToe
{
    public class TicTacToeState : State
    {
        public const char BLANK = ' ';
        public const char PLAYER1 = 'X';
        public const char PLAYER2 = 'O';

        public char[,] Board {  get; set; }

        public TicTacToeState()
        {
            Board = new char[3, 3]
            {
                {BLANK, BLANK, BLANK},
                {BLANK, BLANK, BLANK},
                {BLANK, BLANK, BLANK},
            };
            CurrentPlayer = PLAYER1;
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == PLAYER1)
                CurrentPlayer = PLAYER2;
            else
                CurrentPlayer = PLAYER1;
        }

        public override object Clone()
        {
            TicTacToeState newState = new TicTacToeState();

            newState.CurrentPlayer = CurrentPlayer;

            newState.Board = Board.Clone() as char[,];

            return newState;
        }

        public override bool Equals(object? obj)
        {
            if (obj  == null || !(obj is TicTacToeState))
                return false;

            TicTacToeState state = obj as TicTacToeState;

            if (CurrentPlayer != state.CurrentPlayer)
                return false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] != state.Board[i, j])
                        return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    1   2   3");
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("  +---+---+---+");
                sb.Append(string.Format("{0} |", i + 1));
                for (int j = 0; j < 3; j++)
                {
                    sb.Append(string.Format(" {0} |", Board[i, j]));
                }
                sb.AppendLine();
            }
            sb.AppendLine("  +---+---+---+");
            sb.AppendLine($"Current player: {CurrentPlayer}");

            return sb.ToString();
        }


        public override Status GetStatus()
        {
            for (int i = 0; i < 3;i++)
            {
                int rowCount = 0;
                int colCount = 0;
                char rowChar = Board[i, 0];
                char colChar = Board[0, i];

                for (int j = 0; j < 3;j++) 
                {
                    if (Board[i, j] == rowChar) rowCount++;
                    if (Board[j, i] == colChar) colCount++;
                }

                if (rowCount == 3)
                {
                    if (rowChar == PLAYER1) return Status.PLAYER1WINS;
                    if (rowChar == PLAYER2) return Status.PLAYER2WINS;
                }
                if (colCount == 3)
                {
                    if (colChar == PLAYER1) return Status.PLAYER1WINS;
                    if (colChar == PLAYER2) return Status.PLAYER2WINS;
                }
            }

            int diagonalCount = 0;
            int sideDiagonalCount = 0;

            char diagonalChar = Board[0, 0];
            char sideDiagonalChar = Board[0, 2];

            for (int i = 0; i < 3; i++)
            {
                if (Board[i, i] == diagonalChar) diagonalChar++;
                if (Board[i, 2 - i] == sideDiagonalChar) sideDiagonalChar++;
            }

            if (diagonalCount == 3)
            {
                if (diagonalChar == PLAYER1) return Status.PLAYER1WINS;
                if (diagonalChar == PLAYER2) return Status.PLAYER2WINS;
            }

            if (sideDiagonalCount == 3)
            {
                if (sideDiagonalChar == PLAYER1) return Status.PLAYER1WINS;
                if (sideDiagonalChar == PLAYER2) return Status.PLAYER2WINS;
            }

            foreach (char item in Board)
            {
                if (item == BLANK) return Status.PLAYING;
            }

            return Status.DRAW;
        }


        private static int WIN = 100;

        private static int DRAW = 50;

        private static int LOSE = -100;

        private static int POSSIBLE_WIN = 10;

        private static int POSSIBLE_LOSE = -7;

        private static int POSSIBLE_LOSE_AVOIDED = 5;

        private static int NO_WINNING_STAT = -1;

        public override int GetHeuristics(char player)
        {
            if (GetStatus() == Status.PLAYER1WINS && player == PLAYER1) return WIN;
            if (GetStatus() == Status.PLAYER2WINS && player == PLAYER2) return WIN;

            if (GetStatus() == Status.PLAYER1WINS && player != PLAYER1) return LOSE;
            if (GetStatus() == Status.PLAYER2WINS && player != PLAYER2) return LOSE;

            if (GetStatus() == Status.DRAW) return DRAW;

            int result = 0;

            char currentPlayer;
            char otherPlayer;

            if (player == PLAYER1)
            {
                currentPlayer = PLAYER1;
                otherPlayer = PLAYER2;
            }
            else
            {
                currentPlayer = PLAYER2;
                otherPlayer = PLAYER1;
            }

            int currentCount = 0;
            int otherCount = 0;

            for (int i = 0; i < 3; i++)
            {
                currentCount = 0;
                otherCount = 0;

                for(int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == currentPlayer) currentCount++; 
                    if (Board[i, j] == otherPlayer) otherCount++;
                }

                result += CalculatHeuristic(currentCount, otherCount);

                currentCount = 0;
                otherCount = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (Board[j, i] == currentPlayer) currentCount++;
                    if (Board[j, i] == otherPlayer) otherCount++;
                }
                result += CalculatHeuristic(currentCount, otherCount);
            
            }

            currentCount = 0;
            otherCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (Board[i, i] == currentPlayer) currentCount++;
                if (Board[i, i] == otherPlayer) otherCount++;
            }

            result += CalculatHeuristic(currentCount, otherCount);

            currentCount = 0;
            otherCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 2 - i] == currentPlayer) currentCount++;
                if (Board[i, 2 - i] == otherPlayer) otherCount++;
            }

            result += CalculatHeuristic(currentCount, otherCount);

            return result;

        }

        private int CalculatHeuristic(int currentCount, int  otherCount)
        {
            int result = 0;

            if (currentCount == 1 && otherCount == 2) result += POSSIBLE_LOSE_AVOIDED;

            if (currentCount == 2 && otherCount == 0) result += POSSIBLE_WIN;

            if (otherCount == 2 && currentCount == 0) result += POSSIBLE_LOSE;

            if (otherCount == 1) result += NO_WINNING_STAT;

            return result;

        }
    }
}
