using System.Timers;
using static Coursework.Common;
using Timer = System.Timers.Timer;

namespace Coursework
{
    public partial class GameForm : Form
    {
        byte[] matrix = new byte[stateSize];
        Timer timer = new Timer(maxTime);
        public static bool isTimerExpired = false;

        public GameForm()
        {
            InitializeComponent();
            AddCustomComponents();
        }

        //����� ������ ������� ���
        private void playButton_Click(object sender, EventArgs e)
        {
            bool isErr = false;

            for (int i = 0; i < stateSize; i++)
            {
                customTextBoxContainer[i].CustomValidate();
                if (!customTextBoxContainer[i].isError)
                {
                    matrix[i] = byte.Parse(customTextBoxContainer[i].Text);
                }
                else
                {
                    isErr = true;
                }
            }
            State newState = new State(matrix);

            foreach (var item in customTextBoxContainer)
            {
                item.isError = false;
                item.CustomValidate();
                if (!item.isError && matrix.Count(num => num == int.Parse(item.Text)) > 1)
                {
                    item.isError = true;
                    item.ShowError("���� ����� ������������");
                    isErr = true;
                }
            }

            if (isErr)
            {
                ErrorTextBox.Text = "���� ��� �� � �������, ��������� ������� ������";
                ErrorTextBox.Visible = true;
            }
            else if (!newState.IsSolvable())
            {
                ErrorTextBox.Text = "���� ��� ��������� ����'�����";
                ErrorTextBox.Visible = true;
            }
            else
            {
                ErrorTextBox.Visible = false;
                int index = Array.IndexOf(matrix, (byte)0);
                for (int i = 0; i < stateSize; i++)
                {
                    if (i != index)
                    {
                        tilesContainer[i].Text = customTextBoxContainer[i].Text;
                    }
                    else
                    {
                        tilesContainer[i].Text = "";

                        rewriteZeroNeighbors(i);
                    }
                }
                IncreaseMovesCounter(false);
            }
        }

        //����� ������ ��������� ��������� ������� ������
        private void generateButton_Click(object sender, EventArgs e)
        {
            matrix = new byte[stateSize];
            ErrorTextBox.Visible = false;

            List<byte> numbers = new List<byte>();
            for (int i = 0; i < stateSize; i++)
            {
                numbers.Add((byte)i);
            }

            Random rand = new Random();

            for (int i = 0; i < stateSize; i++)
            {
                int index = rand.Next(numbers.Count);
                customTextBoxContainer[i].Text = numbers[index].ToString();
                matrix[i] = numbers[index];
                numbers.Remove(numbers[index]);
            }
        }

        //����� ������ �������� ��������� ���
        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                if (lines[0] == signature)
                {
                    string[] numbers = lines[1].Split(" ");
                    for (int i = 0; i < numbers.Length - 1; i++)
                    {
                        if (numbers[i] != "0")
                        {
                            tilesContainer[i].Text = numbers[i];
                        }
                        else
                        {
                            tilesContainer[i].Text = "";

                            rewriteZeroNeighbors(i);
                        }
                        customTextBoxContainer[i].Text = numbers[i];
                        matrix[i] = byte.Parse(numbers[i]);
                    }
                    foreach (var customTextBox in customTextBoxContainer)
                    {
                        customTextBox.CustomValidate();
                    }

                    MovesCounter = int.Parse(lines[2]);
                    MovesCountLabel.Text = "ʳ������ ����: " + MovesCounter;
                }
                else
                {
                    ErrorTextBox.Text = "���� �� ��� ���������� ���� ���������.";
                    ErrorTextBox.Visible = true;
                }
            }
        }

        //����� ������ ���������� ���
        private void saveButton_Click(object sender, EventArgs args)
        {
            saveFileDialog.Filter = "Text (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(signature);

                    string numbers = "";
                    foreach (var tile in tilesContainer)
                    {
                        if (tile.Text == "")
                        {
                            numbers += "0 ";
                        }
                        else
                        {
                            numbers += tile.Text + " ";
                        }
                    }
                    sw.WriteLine(numbers);

                    sw.WriteLine(MovesCounter.ToString());
                }

            }
        }

        //����� ������ ������������� ����'������ ���
        private void solveButton_Click(object sender, EventArgs e)
        {
            timer.Elapsed += TimerTick;
            timer.Enabled = true;

            foreach (var tile in tilesContainer)
            {
                if (tile.Text != "")
                {
                    matrix[tile.tileIndex] = byte.Parse(tile.Text);
                }
                else
                {
                    matrix[tile.tileIndex] = 0;
                }
            }

            State state = new State(matrix);
            AStarMethod method = new AStarMethod();

            List<(EZeroDirection, byte[])> path = method.GetCorrectPath(state);

            if (path.Count == 0)
            {
                timer.Enabled = false;
                isTimerExpired = false;

                return;
            }
            if (isTimerExpired)
            {
                timer.Enabled = false;
                isTimerExpired = false;

                ErrorTextBox.Text = "��� ������������ ����'������ ����������, ������ ���� �� ��������";
                ErrorTextBox.Visible = true;

                return;
            }

            if (generatedButtons.Count != 0)
            {
                pathButtonsRemover();
            }
            pathButtonsGenerator(path);

            for (int i = 0; i < stateSize; i++)
            {
                if (i == 15)
                {
                    tilesContainer[i].Text = "";
                    rewriteZeroNeighbors(i);
                    matrix[i] = 0;
                }
                else
                {
                    tilesContainer[i].Text = (i + 1).ToString();
                    matrix[i] = (byte)(i + 1);
                }
            }

            timer.Enabled = false;
            isTimerExpired = false;
        }

        //����� ��������� ������ ����� �� ����'������� �����
        private void pathButtonsGenerator(List<(EZeroDirection direction, byte[] stateNumbers)> path)
        {
            int count = path.Count;
            string pathVisual = "";

            for (int i = 0; i < count; i++)
            {
                switch (path[i].direction)
                {
                    case EZeroDirection.LeftDirection:
                        pathVisual = "������";
                        break;
                    case EZeroDirection.RightDirection:
                        pathVisual = "����";
                        break;
                    case EZeroDirection.UpDirection:
                        pathVisual = "����";
                        break;
                    case EZeroDirection.DownDirection:
                        pathVisual = "�����";
                        break;
                }
                IncreaseMovesCounter(true);

                Button button = new Button();
                button.Text = (i + 1).ToString() + ". " + pathVisual;
                button.Width = 196;
                button.Height = 30;
                button.Location = new Point(6, 6 + (i * (30 + 6)));
                button.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
                var gg = path[i].stateNumbers;

                int buttonIndex = i;
                int buttonMoves = MovesCounter;
                button.Click += (sender, e) => pathButtonClick(sender, path[buttonIndex].stateNumbers, buttonMoves);

                MovesPanel.Controls.Add(button);
                generatedButtons.Add(button);

            }
        }

        //����� ������ � ������ ����'������� �����
        private void pathButtonClick(object sender, byte[] numbers, int moves)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    tilesContainer[i].Text = numbers[i].ToString();
                }
                else
                {
                    tilesContainer[i].Text = "";

                    rewriteZeroNeighbors(i);
                }
                matrix[i] = numbers[i];
            }

            foreach (var butt in generatedButtons)
            {
                butt.BackColor = Color.White;
                if (butt == sender)
                {
                    butt.BackColor = Color.Azure;
                }
            }

            MovesCounter = moves;
            MovesCountLabel.Text = "ʳ������ ����: " + MovesCounter;
        }

        //����� �������� ������ ����'������� �����
        private void pathButtonsRemover()
        {
            foreach (var button in generatedButtons)
            {
                MovesPanel.Controls.Remove(button);
                button.Dispose();
            }
            generatedButtons.Clear();
        }

        //����� ����������� ��������� ������ ��������
        private void rewriteZeroNeighbors(int tileIndex)
        {
            foreach (var tile in tilesContainer)
            {
                tile.Cursor = Cursors.No;
                tile.FlatAppearance.MouseOverBackColor = Color.White;
                tile.FlatAppearance.MouseDownBackColor = Color.White;
                tile.FlatAppearance.BorderSize = 1;
                tile.FlatAppearance.BorderColor = Color.Black;
                tile.ZeroNeighbor = (false, null);
            }
            int tempSize = sideSize;
            tilesContainer[tileIndex].Cursor = Cursors.Cross;
            tilesContainer[tileIndex].FlatAppearance.BorderSize = 2;
            tilesContainer[tileIndex].FlatAppearance.BorderColor = Color.DarkBlue;
            if (GameTile.GetCoordinatesByIndex(tileIndex).yCord > 0)
            {
                tilesContainer[tileIndex - tempSize].ZeroNeighbor = (true, EZeroDirection.UpDirection);
                tilesContainer[tileIndex - tempSize].Cursor = Cursors.Hand;
                tilesContainer[tileIndex - tempSize].FlatAppearance.MouseOverBackColor = Color.PowderBlue;
            }
            if (GameTile.GetCoordinatesByIndex(tileIndex).yCord < tempSize - 1)
            {
                tilesContainer[tileIndex + tempSize].ZeroNeighbor = (true, EZeroDirection.DownDirection);
                tilesContainer[tileIndex + tempSize].Cursor = Cursors.Hand;
                tilesContainer[tileIndex + tempSize].FlatAppearance.MouseOverBackColor = Color.PowderBlue;
            }
            if (GameTile.GetCoordinatesByIndex(tileIndex).xCord > 0)
            {
                tilesContainer[tileIndex - 1].ZeroNeighbor = (true, EZeroDirection.LeftDirection);
                tilesContainer[tileIndex - 1].Cursor = Cursors.Hand;
                tilesContainer[tileIndex - 1].FlatAppearance.MouseOverBackColor = Color.PowderBlue;
            }
            if (GameTile.GetCoordinatesByIndex(tileIndex).xCord < tempSize - 1)
            {
                tilesContainer[tileIndex + 1].ZeroNeighbor = (true, EZeroDirection.RightDirection);
                tilesContainer[tileIndex + 1].Cursor = Cursors.Hand;
                tilesContainer[tileIndex + 1].FlatAppearance.MouseOverBackColor = Color.PowderBlue;
            }
        }

        //����� ���������� ������ � ���������
        private void TileMove(object sender, EventArgs e)
        {
            GameTile clickedTile = sender as GameTile;

            if (clickedTile != null && clickedTile.ZeroNeighbor.isNeighbor)
            {
                Swap(clickedTile, clickedTile.ZeroNeighbor.direction);
                IncreaseMovesCounter(true);
            }
        }

        //����� ����� ������� ������
        private void Swap(GameTile tile, EZeroDirection? direction)
        {
            GameTile zeroTile = tilesContainer[stateSize - 1];

            switch (direction)
            {
                case EZeroDirection.LeftDirection:
                    zeroTile = tilesContainer[tile.tileIndex + 1];
                    break;
                case EZeroDirection.RightDirection:
                    zeroTile = tilesContainer[tile.tileIndex - 1];
                    break;
                case EZeroDirection.UpDirection:
                    zeroTile = tilesContainer[tile.tileIndex + sideSize];
                    break;
                case EZeroDirection.DownDirection:
                    zeroTile = tilesContainer[tile.tileIndex - sideSize];
                    break;
            }

            string str = zeroTile.Text;
            zeroTile.Text = tile.Text;
            tile.Text = str;

            rewriteZeroNeighbors(tile.tileIndex);
        }

        //����� ���� �������� ���������
        private void IncreaseMovesCounter(bool isIncreased)
        {
            if (isIncreased)
            {
                MovesCounter++;
                MovesCountLabel.Text = "ʳ������ ����: " + MovesCounter;
            }
            else
            {
                MovesCounter = 0;
                MovesCountLabel.Text = "ʳ������ ����: " + MovesCounter;
            }
        }

        //�����, �� ��������� ��� ������� �������� � �������� ���� ������� ������
        private void textBoxState_TextChanged(CustomTextBox tempTextBox, int index)
        {
            tempTextBox.isError = false;
            string str = tempTextBox.Text;
            if (str != "" && int.TryParse(str, out int value) && value >= 0 && value <= 15 &&
                str == str.TrimStart('0') && str == str.Trim() && str != "0")
            {
                byte val = byte.Parse(str);
                if (val != 0 && matrix.Contains(val))
                {
                    matrix[index] = val;
                    tempTextBox.isRepeatable = true;
                    tempTextBox.ShowError("���� ����� ������������");
                }
                else
                {
                    tempTextBox.isRepeatable = false;
                    matrix[index] = val;
                }
                foreach (var customTextBox in customTextBoxContainer)
                {
                    if (customTextBox.isRepeatable && matrix.Count(num => num == byte.Parse(customTextBox.Text)) < 2)
                    {
                        customTextBox.isRepeatable = false;
                        customTextBox.BackColor = Color.White;
                    }
                }
            }
        }

        //����� �������
        private void TimerTick(object source, ElapsedEventArgs e)
        {
            isTimerExpired = true;
        }
        
        //����� ������, �� ������� ���������� ������������
        private void button1_Click(object sender, EventArgs e)
        {
            string title = "���������� ���";
            string message = "��� � 15 � �� �������� �����������, �� ������ 15 ���������� ������, �������������� �� 1 �� 15," +
                " � �����, �� ���������� � 4 ������� ������ � ������ �� 4 ������� ������ ���������, � ���� ���������� (������)" +
                " ��������. ������ ����� ����������� �� ����� �������. ���� ����������� � ����������� ������ � ������� ���������" +
                " ����� ���� ������� �� ������ ���� � ������ �������� ������ �����.\n" +
                "��� ������� ��� ����� ������ � ������� ���� �������� ������ �� �������� ���, �������� ������ ���� ���������� ��" +
                " ���� � ����� �� 0 �� 15. ϳ��� ����� ��� ��������� ������ ����� \"�����\". ���� �������� ���� �� ����'����, �����" +
                " ������������ �� ������ ����, ������ �'������� �������. ���� ����� ����� ��������� �����������, ���������� ������ " +
                "\"��������� �����������\".\n" +
                "��� ������ ������ �����, �� �������� �� ����'������ ���, ��� ��������� �� ������ \"����'����� ���\", ��� �������" +
                "��������, �� ������ ������ ������ �� ����������� ���, ������ ���������� �� ������ ������� �� �����. ���� " +
                "������ ���� ��������, ������ �'������� ������ ����� ����'������. �� �������� ������ ����� ���������, ���" +
                "�������� ���� ��� ���� ����������� ����������\n" +
                "��� ����� ��������, ���������� ������ \"�������� ���\", �� ������� ��� ���������, ���������� ������" +
                "\"³������ ���\".";
            MessageBox.Show(message, title);
        }
    }
}