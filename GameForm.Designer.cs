namespace Coursework
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            panel1 = new Panel();
            ErrorTextBox = new TextBox();
            panel4 = new Panel();
            uploadButton = new Button();
            saveButton = new Button();
            solveButton = new Button();
            panel3 = new Panel();
            playButton = new Button();
            generateButton = new Button();
            GamePanel = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            MovesCountLabel = new Label();
            panel5 = new Panel();
            MovesPanel = new Panel();
            label1 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ErrorTextBox);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(27, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 485);
            panel1.TabIndex = 1;
            // 
            // ErrorTextBox
            // 
            ErrorTextBox.BackColor = Color.MistyRose;
            ErrorTextBox.BorderStyle = BorderStyle.None;
            ErrorTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ErrorTextBox.Location = new Point(18, 401);
            ErrorTextBox.Multiline = true;
            ErrorTextBox.Name = "ErrorTextBox";
            ErrorTextBox.ReadOnly = true;
            ErrorTextBox.Size = new Size(199, 65);
            ErrorTextBox.TabIndex = 0;
            ErrorTextBox.Text = "Стан гри неможливо розв'язати";
            ErrorTextBox.TextAlign = HorizontalAlignment.Center;
            ErrorTextBox.Visible = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(uploadButton);
            panel4.Controls.Add(saveButton);
            panel4.Controls.Add(solveButton);
            panel4.Location = new Point(18, 261);
            panel4.Name = "panel4";
            panel4.Size = new Size(199, 127);
            panel4.TabIndex = 1;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(17, 84);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(160, 30);
            uploadButton.TabIndex = 0;
            uploadButton.Text = "Відкрити гру";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(17, 48);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(160, 30);
            saveButton.TabIndex = 1;
            saveButton.Text = "Зберегти гру";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // solveButton
            // 
            solveButton.Location = new Point(17, 12);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(160, 30);
            solveButton.TabIndex = 2;
            solveButton.Text = "Розв'язати гру";
            solveButton.UseVisualStyleBackColor = true;
            solveButton.Click += solveButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(playButton);
            panel3.Controls.Add(generateButton);
            panel3.Location = new Point(18, 19);
            panel3.Name = "panel3";
            panel3.Size = new Size(199, 236);
            panel3.TabIndex = 2;
            // 
            // playButton
            // 
            playButton.Location = new Point(20, 158);
            playButton.Name = "playButton";
            playButton.Size = new Size(160, 30);
            playButton.TabIndex = 0;
            playButton.Text = "Грати";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(20, 194);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(160, 30);
            generateButton.TabIndex = 1;
            generateButton.Text = "Випадково згенерувати";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // GamePanel
            // 
            GamePanel.BackColor = Color.PaleTurquoise;
            GamePanel.Location = new Point(119, 79);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(318, 318);
            GamePanel.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightCyan;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(MovesCountLabel);
            panel2.Controls.Add(GamePanel);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(279, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(813, 485);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(119, 19);
            label2.Name = "label2";
            label2.Size = new Size(189, 45);
            label2.TabIndex = 7;
            label2.Text = "П'ятнашки";
            // 
            // MovesCountLabel
            // 
            MovesCountLabel.AutoSize = true;
            MovesCountLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MovesCountLabel.Location = new Point(119, 429);
            MovesCountLabel.Name = "MovesCountLabel";
            MovesCountLabel.Size = new Size(138, 20);
            MovesCountLabel.TabIndex = 6;
            MovesCountLabel.Text = "Кількість ходів: 0";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(MovesPanel);
            panel5.Controls.Add(label1);
            panel5.Location = new Point(546, 79);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 380);
            panel5.TabIndex = 2;
            // 
            // MovesPanel
            // 
            MovesPanel.AutoScroll = true;
            MovesPanel.Location = new Point(10, 44);
            MovesPanel.Name = "MovesPanel";
            MovesPanel.Size = new Size(220, 326);
            MovesPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(227, 20);
            label1.TabIndex = 1;
            label1.Text = "Список ходів для вирішення:";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(754, 34);
            button1.Name = "button1";
            button1.Size = new Size(32, 30);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1119, 541);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameForm";
            Text = "15-Puzzles";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        //Метод ініціалізації нестандартних об'єктів інтерфейсу
        private void AddCustomComponents()
        {
            Tile16 = new GameTile("");
            Tile1 = new GameTile("1");
            Tile2 = new GameTile("2");
            Tile3 = new GameTile("3");
            Tile4 = new GameTile("4");
            Tile5 = new GameTile("5");
            Tile6 = new GameTile("6");
            Tile7 = new GameTile("7");
            Tile8 = new GameTile("8");
            Tile9 = new GameTile("9");
            Tile10 = new GameTile("10");
            Tile11 = new GameTile("11");
            Tile12 = new GameTile("12");
            Tile13 = new GameTile("13");
            Tile14 = new GameTile("14");
            Tile15 = new GameTile("15");

            textBox16 = new CustomTextBox();
            textBox15 = new CustomTextBox();
            textBox14 = new CustomTextBox();
            textBox13 = new CustomTextBox();
            textBox12 = new CustomTextBox();
            textBox11 = new CustomTextBox();
            textBox10 = new CustomTextBox();
            textBox9 = new CustomTextBox();
            textBox8 = new CustomTextBox();
            textBox7 = new CustomTextBox();
            textBox6 = new CustomTextBox();
            textBox5 = new CustomTextBox();
            textBox4 = new CustomTextBox();
            textBox3 = new CustomTextBox();
            textBox2 = new CustomTextBox();
            textBox1 = new CustomTextBox();

            tilesContainer = new GameTile[] {
                Tile1,
                Tile2,
                Tile3,
                Tile4,
                Tile5,
                Tile6,
                Tile7,
                Tile8,
                Tile9,
                Tile10,
                Tile11,
                Tile12,
                Tile13,
                Tile14,
                Tile15,
                Tile16
            };
            customTextBoxContainer = new CustomTextBox[]
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10,
                textBox11,
                textBox12,
                textBox13,
                textBox14,
                textBox15,
                textBox16
            };
            generatedButtons = new List<Button>();

            rewriteZeroNeighbors(Common.stateSize - 1);

            foreach (var tile in tilesContainer)
            {
                GamePanel.Controls.Add(tile);
                tile.Click += new EventHandler(this.TileMove);
            }

            foreach (var customTextBox in customTextBoxContainer.Select((value, index) => new { value, index }))
            {
                panel3.Controls.Add(customTextBox.value);
                customTextBox.value.TextChanged += (sender, e) => this.textBoxState_TextChanged(customTextBox.value, customTextBox.index);
            }

            // 
            // Tile1
            // 
            Tile1.Location = new Point(22, 22);
            Tile1.Name = "Tile1";
            // 
            // Tile2
            // 
            Tile2.Location = new Point(92, 22);
            Tile2.Name = "Tile2";
            // 
            // Tile3
            // 
            Tile3.Location = new Point(162, 22);
            Tile3.Name = "Tile3";
            // 
            // Tile4
            // 
            Tile4.Location = new Point(232, 22);
            Tile4.Name = "Tile4";
            // 
            // Tile5
            // 
            Tile5.Location = new Point(22, 92);
            Tile5.Name = "Tile5";
            // 
            // Tile6
            // 
            Tile6.Location = new Point(92, 92);
            Tile6.Name = "Tile6";
            // 
            // Tile7
            // 
            Tile7.Location = new Point(162, 92);
            Tile7.Name = "Tile7";
            // 
            // Tile8
            // 
            Tile8.Location = new Point(232, 92);
            Tile8.Name = "Tile8";
            // 
            // Tile9
            // 
            Tile9.Location = new Point(22, 162);
            Tile9.Name = "Tile9";
            // 
            // Tile10
            // 
            Tile10.Location = new Point(92, 162);
            Tile10.Name = "Tile10";
            // 
            // Tile11
            // 
            Tile11.Location = new Point(162, 162);
            Tile11.Name = "Tile11";
            // 
            // Tile12
            // 
            Tile12.Location = new Point(232, 162);
            Tile12.Name = "Tile12";
            // 
            // Tile13
            // 
            Tile13.Location = new Point(22, 232);
            Tile13.Name = "Tile13";
            // 
            // Tile14
            // 
            Tile14.Location = new Point(92, 232);
            Tile14.Name = "Tile14";
            // 
            // Tile15
            // 
            Tile15.Location = new Point(162, 232);
            Tile15.Name = "Tile15";
            // 
            // Tile16
            // 
            Tile16.Location = new Point(232, 232);
            Tile16.Name = "Tile16";

            // 
            // textBox16
            // 
            textBox16.Location = new Point(134, 119);
            textBox16.Name = "textBox16";
            textBox16.TabIndex = 16;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(102, 119);
            textBox15.Name = "textBox15";
            textBox15.TabIndex = 15;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(70, 119);
            textBox14.Name = "textBox14";
            textBox14.TabIndex = 14;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(38, 119);
            textBox13.Name = "textBox13";
            textBox13.TabIndex = 13;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(134, 84);
            textBox12.Name = "textBox12";
            textBox12.TabIndex = 12;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(102, 84);
            textBox11.Name = "textBox11";
            textBox11.TabIndex = 11;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(70, 84);
            textBox10.Name = "textBox10";
            textBox10.TabIndex = 10;
            // 
            // textBox9
            //
            textBox9.Location = new Point(38, 84);
            textBox9.Name = "textBox9";
            textBox9.TabIndex = 9;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(134, 49);
            textBox8.Name = "textBox8";
            textBox8.TabIndex = 8;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(102, 49);
            textBox7.Name = "textBox7";
            textBox7.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(70, 49);
            textBox6.Name = "textBox6";
            textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(38, 49);
            textBox5.Name = "textBox5";
            textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(134, 14);
            textBox4.Name = "textBox4";
            textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(102, 14);
            textBox3.Name = "textBox3";
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(70, 14);
            textBox2.Name = "textBox2";
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(38, 14);
            textBox1.Name = "textBox1";
            textBox1.TabIndex = 1;
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Panel panel4;
        private Button solveButton;
        private Button uploadButton;
        private Button saveButton;
        private Panel panel3;
        private Button playButton;
        private Button generateButton;
        private CustomTextBox textBox1;
        private CustomTextBox textBox16;
        private CustomTextBox textBox15;
        private CustomTextBox textBox14;
        private CustomTextBox textBox13;
        private CustomTextBox textBox12;
        private CustomTextBox textBox11;
        private CustomTextBox textBox10;
        private CustomTextBox textBox9;
        private CustomTextBox textBox8;
        private CustomTextBox textBox7;
        private CustomTextBox textBox6;
        private CustomTextBox textBox5;
        private CustomTextBox textBox4;
        private CustomTextBox textBox3;
        private CustomTextBox textBox2;
        private TextBox ErrorTextBox;
        private Panel GamePanel;
        private Panel panel5;
        private int MovesCounter;
        private GameTile Tile16;
        private GameTile Tile15;
        private GameTile Tile14;
        private GameTile Tile13;
        private GameTile Tile12;
        private GameTile Tile11;
        private GameTile Tile10;
        private GameTile Tile9;
        private GameTile Tile8;
        private GameTile Tile7;
        private GameTile Tile6;
        private GameTile Tile5;
        private GameTile Tile4;
        private GameTile Tile3;
        private GameTile Tile2;
        private GameTile Tile1;
        private GameTile[] tilesContainer;
        private CustomTextBox[] customTextBoxContainer;
        private List<Button> generatedButtons;
        private Label label1;
        private Panel MovesPanel;
        private Label MovesCountLabel;
        private Label label2;
    }
}