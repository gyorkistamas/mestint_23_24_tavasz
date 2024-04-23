namespace TicTacToeWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button0_0 = new Button();
            button0_1 = new Button();
            button0_2 = new Button();
            button1_0 = new Button();
            button1_1 = new Button();
            button1_2 = new Button();
            button2_0 = new Button();
            button2_1 = new Button();
            button2_2 = new Button();
            comboBoxDifficulty = new ComboBox();
            buttonNewGame = new Button();
            labelResult = new Label();
            SuspendLayout();
            // 
            // button0_0
            // 
            button0_0.Location = new Point(12, 12);
            button0_0.Name = "button0_0";
            button0_0.Size = new Size(72, 60);
            button0_0.TabIndex = 0;
            button0_0.Text = "Ü";
            button0_0.UseVisualStyleBackColor = true;
            button0_0.Click += UserMoves;
            // 
            // button0_1
            // 
            button0_1.Location = new Point(101, 12);
            button0_1.Name = "button0_1";
            button0_1.Size = new Size(72, 60);
            button0_1.TabIndex = 1;
            button0_1.Text = "Ü";
            button0_1.UseVisualStyleBackColor = true;
            button0_1.Click += UserMoves;
            // 
            // button0_2
            // 
            button0_2.Location = new Point(192, 12);
            button0_2.Name = "button0_2";
            button0_2.Size = new Size(72, 60);
            button0_2.TabIndex = 2;
            button0_2.Text = "Ü";
            button0_2.UseVisualStyleBackColor = true;
            button0_2.Click += UserMoves;
            // 
            // button1_0
            // 
            button1_0.Location = new Point(12, 92);
            button1_0.Name = "button1_0";
            button1_0.Size = new Size(72, 60);
            button1_0.TabIndex = 3;
            button1_0.Text = "Ü";
            button1_0.UseVisualStyleBackColor = true;
            button1_0.Click += UserMoves;
            // 
            // button1_1
            // 
            button1_1.Location = new Point(101, 92);
            button1_1.Name = "button1_1";
            button1_1.Size = new Size(72, 60);
            button1_1.TabIndex = 4;
            button1_1.Text = "Ü";
            button1_1.UseVisualStyleBackColor = true;
            button1_1.Click += UserMoves;
            // 
            // button1_2
            // 
            button1_2.Location = new Point(192, 92);
            button1_2.Name = "button1_2";
            button1_2.Size = new Size(72, 60);
            button1_2.TabIndex = 5;
            button1_2.Text = "Ü";
            button1_2.UseVisualStyleBackColor = true;
            button1_2.Click += UserMoves;
            // 
            // button2_0
            // 
            button2_0.Location = new Point(12, 172);
            button2_0.Name = "button2_0";
            button2_0.Size = new Size(72, 60);
            button2_0.TabIndex = 6;
            button2_0.Text = "Ü";
            button2_0.UseVisualStyleBackColor = true;
            button2_0.Click += UserMoves;
            // 
            // button2_1
            // 
            button2_1.Location = new Point(101, 172);
            button2_1.Name = "button2_1";
            button2_1.Size = new Size(72, 60);
            button2_1.TabIndex = 7;
            button2_1.Text = "Ü";
            button2_1.UseVisualStyleBackColor = true;
            button2_1.Click += UserMoves;
            // 
            // button2_2
            // 
            button2_2.Location = new Point(192, 172);
            button2_2.Name = "button2_2";
            button2_2.Size = new Size(72, 60);
            button2_2.TabIndex = 8;
            button2_2.Text = "Ü";
            button2_2.UseVisualStyleBackColor = true;
            button2_2.Click += UserMoves;
            // 
            // comboBoxDifficulty
            // 
            comboBoxDifficulty.AutoCompleteMode = AutoCompleteMode.Append;
            comboBoxDifficulty.FormattingEnabled = true;
            comboBoxDifficulty.Items.AddRange(new object[] { "Könnyű", "Nehéz" });
            comboBoxDifficulty.Location = new Point(292, 12);
            comboBoxDifficulty.Name = "comboBoxDifficulty";
            comboBoxDifficulty.Size = new Size(191, 28);
            comboBoxDifficulty.TabIndex = 9;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Location = new Point(292, 64);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(191, 29);
            buttonNewGame.TabIndex = 10;
            buttonNewGame.Text = "Új játék kezdése";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += StartGame;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelResult.Location = new Point(12, 264);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(109, 46);
            labelResult.TabIndex = 11;
            labelResult.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 342);
            Controls.Add(labelResult);
            Controls.Add(buttonNewGame);
            Controls.Add(comboBoxDifficulty);
            Controls.Add(button2_2);
            Controls.Add(button2_1);
            Controls.Add(button2_0);
            Controls.Add(button1_2);
            Controls.Add(button1_1);
            Controls.Add(button1_0);
            Controls.Add(button0_2);
            Controls.Add(button0_1);
            Controls.Add(button0_0);
            Name = "Form1";
            Text = "TicTacToe";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button0_0;
        private Button button0_1;
        private Button button0_2;
        private Button button1_0;
        private Button button1_1;
        private Button button1_2;
        private Button button2_0;
        private Button button2_1;
        private Button button2_2;
        private ComboBox comboBoxDifficulty;
        private Button buttonNewGame;
        private Label labelResult;
    }
}
