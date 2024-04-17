using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form2 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        List<Figure> figures = new List<Figure>();
        SettingOfLevel[] settings = new SettingOfLevel[3];
        List<Cup> cups = new List<Cup>();
        string pathToFileOfSettings, pathToFileOfFigures, pathToFileOfCups;
        List<Constructor> squares = new List<Constructor>();
        ComboBox comboBoxCreateFig = new ComboBox();
        MyTextBox textBoxW = new MyTextBox(), textBoxH = new MyTextBox();
        Pen pen = new Pen(Color.White, 2), dashPen = new Pen(Color.Gray, 1);
        Rectangle rectangle;
        int[,] arrayOfSquares = new int[5, 5];
        int currentFigureIndex, currentCupIndex, yourChoice;
        bool isGrid, isDisplay, isOkW = false, isOkH = false;
        public Form2(List<Figure> figures, SettingOfLevel[] settings, List<Cup> cups, string pathToFileOfSettings, string pathToFileOfFigures, string pathToFileOfCups)
        {
            InitializeComponent();
            currentFigureIndex = 0;
            yourChoice = -1;
            this.figures = figures;
            this.settings = settings;
            this.cups = cups;
            this.pathToFileOfCups = pathToFileOfCups;
            this.pathToFileOfFigures = pathToFileOfFigures;
            this.pathToFileOfSettings = pathToFileOfSettings;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    PictureBox square = new PictureBox();
                    square.Paint += new PaintEventHandler(pictureBox_Paint);
                    void pictureBox_Paint(object sender, PaintEventArgs e)
                    {
                        ControlPaint.DrawBorder(e.Graphics, square.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
                    }
                    square.Location = new Point(j * 60 + 180, i * 60 + 14);
                    square.Size = new Size(60, 60);
                    panel1.Controls.Add(square);
                    Constructor newSquare = new Constructor(square, i, j, false);
                    squares.Add(newSquare);
                }
            }
            comboBoxFigure.SelectedIndex = 0;
            textBoxW.Location = new Point(370, 376);
            textBoxW.Size = new Size(80, 55);
            panel2.Controls.Add(textBoxW);
            textBoxH.Location = new Point(370, 350);
            textBoxH.Size = new Size(80, 55);
            panel2.Controls.Add(textBoxH);
            comboBoxCreateFig.Location = new Point(380, 349);
            comboBoxCreateFig.Size = new Size(100, 20);
            comboBoxCreateFig.DropDownStyle = ComboBoxStyle.DropDownList;
            panel1.Controls.Add(comboBoxCreateFig);
            buttonRight.FlatAppearance.BorderSize = 0;
            buttonRight.FlatStyle = FlatStyle.Flat;
            buttonLeft.FlatAppearance.BorderSize = 0;
            buttonLeft.FlatStyle = FlatStyle.Flat;
            buttonFigRight.FlatAppearance.BorderSize = 0;
            buttonFigRight.FlatStyle = FlatStyle.Flat;
            buttonFigLeft.FlatAppearance.BorderSize = 0;
            buttonFigLeft.FlatStyle = FlatStyle.Flat;
            buttonLevelRight.FlatAppearance.BorderSize = 0;
            buttonLevelRight.FlatStyle = FlatStyle.Flat;
            buttonLevelLeft.FlatAppearance.BorderSize = 0;
            buttonLevelLeft.FlatStyle = FlatStyle.Flat;
            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            textBoxH.DelayedTextChanged += new EventHandler(textBoxH_Enter);
            textBoxW.DelayedTextChanged += new EventHandler(textBoxW_Enter);
            radioButton1.CheckedChanged += new EventHandler(radioButtonsGrid_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButtonsGrid_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButtonsDisplay_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButtonsDisplay_CheckedChanged);
        }
        public class Constructor
        {
            public PictureBox Square { get; set; }
            public int CoordX { get; set; }
            public int CoordY { get; set; }
            public bool IsPressed { get; set; }
            public Constructor(PictureBox square, int coordX, int coordY, bool isPressed)
            {
                Square = square;
                CoordX = coordX;
                CoordY = coordY;
                IsPressed = isPressed;
            }
        }
        //private void toolStripLabel1_Click(object sender, EventArgs e)
        //{
        //    Close();
        //    Form6 formInfo = new Form6(this);
        //    formInfo.Show();
        //}
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Close();
            Form1 formMain = new Form1();
            formMain.Show();
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void comboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFigure.SelectedIndex)
            {
                case 0:
                    WatchFigure();
                    break;
                case 1:
                    CreateFigure();
                    break;
                case 2:
                    EditFigure();
                    break;
                case 3:
                    DeleteFigure();
                    break;
            }
        }
        private void WatchFigure()
        {
            comboBoxFigure.Enabled = true;
            CheckButtonFigure();
            buttonFigRight.Show();
            buttonFigLeft.Show();
            buttonSaveFig.Hide();
            labelLevel.Show();
            comboBoxCreateFig.Hide();
            foreach (Constructor square in squares)
            {
                square.Square.BackColor = Color.White;
                square.IsPressed = false;
                square.Square.Click -= new EventHandler(pictureBox_Click);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (figures[currentFigureIndex].Constructor[i, j] == 1)
                    {
                        foreach (Constructor square in squares)
                        {
                            if (square.CoordX == i && square.CoordY == j)
                            {
                                square.Square.BackColor = Color.Pink;
                                square.IsPressed = true;
                                break;
                            }
                        }
                    }
                }
            }
            labelLevel.Text = (figures[currentFigureIndex].Level + 1).ToString();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            foreach (Constructor square in squares)
            {
                if (square.Square == picture)
                {
                    if (square.IsPressed)
                    {
                        picture.BackColor = Color.White;
                        square.IsPressed = false;
                        arrayOfSquares[square.CoordX, square.CoordY] = 0;
                        break;
                    }
                    else
                    {
                        picture.BackColor = Color.Pink;
                        square.IsPressed = true;
                        arrayOfSquares[square.CoordX, square.CoordY] = 1;
                        break;
                    }
                }
            }       
        }
        private void buttonLeftFigure_Click(object sender, EventArgs e)
        {
            if (currentFigureIndex > 0)
                currentFigureIndex--;
            WatchFigure();
        }
        private void buttonRightFigure_Click(object sender, EventArgs e)
        {
            if (currentFigureIndex < figures.Count)
                currentFigureIndex++;
            WatchFigure();
        }
        private void CheckButtonFigure()
        {
            if (currentFigureIndex == 0)
                buttonFigLeft.Enabled = false;
            else
                buttonFigLeft.Enabled = true;
            if (currentFigureIndex == figures.Count - 1)
                buttonFigRight.Enabled = false;
            else
                buttonFigRight.Enabled = true;
        }
        private void CreateFigure()
        {
            comboBoxFigure.Enabled = false;
            buttonFigRight.Hide();
            buttonFigLeft.Hide();
            labelLevel.Hide();
            buttonSaveFig.Show();
            comboBoxCreateFig.Show();
            if (comboBoxCreateFig.Items.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                    comboBoxCreateFig.Items.Add(i + 1);
            }
            comboBoxCreateFig.SelectedIndex = 0;
            foreach (Constructor square in squares)
            {
                square.Square.Click += new EventHandler(pictureBox_Click);
                square.Square.BackColor = Color.White;
                square.IsPressed = false;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    arrayOfSquares[i, j] = 0;
            }
        }
        private void EditFigure()
        {
            comboBoxFigure.Enabled = false;
            buttonFigRight.Hide();
            buttonFigLeft.Hide();
            labelLevel.Hide();
            buttonSaveFig.Show();
            comboBoxCreateFig.Show();
            if (comboBoxCreateFig.Items.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                    comboBoxCreateFig.Items.Add(i + 1);
            }
            comboBoxCreateFig.SelectedIndex = figures[currentFigureIndex].Level;
            foreach (Constructor square in squares)
            {
                square.Square.Click += new EventHandler(pictureBox_Click);
                square.Square.BackColor = Color.White;
                square.IsPressed = false;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    arrayOfSquares[i, j] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (figures[currentFigureIndex].Constructor[i, j] == 1)
                    {
                        arrayOfSquares[i, j] = 1;
                        foreach (Constructor square in squares)
                        {
                            if (square.CoordX == i && square.CoordY == j)
                            {
                                square.Square.BackColor = Color.Pink;
                                square.IsPressed = true;
                            }
                        }
                    }
                }
            }
        }
        private void buttonSaveFigure_Click_1(object sender, EventArgs e)
        {
            bool isCreated = false;
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arrayOfSquares[i, j] == 1)
                        counter++;
                }
            }
            bool isWhole = IsWholeFigure(counter);
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].Constructor == arrayOfSquares && figures[i].Level == comboBoxCreateFig.SelectedIndex)
                    isCreated = true;
            }
            if (counter == 0)
            {
                MessageBox.Show("Фигура не выделена. Данное действие невозможно");
                //currentFigureIndex = 0;
                //comboBoxFigure.SelectedIndex = 0;
            }
            else if (!isWhole)
            {
                MessageBox.Show("Фигура не является целостной. Данное действие невозможно");
                //currentFigureIndex = 0;
                //comboBoxFigure.SelectedIndex = 0;
            }
            else
            {
                Figure newFigure = new Figure(comboBoxCreateFig.SelectedIndex, (int [,])arrayOfSquares.Clone());
                Figure tempFigure, tempNewFigure = (Figure)newFigure.Clone();
                tempNewFigure = tempNewFigure.dropFigure();
                for (int i = 0; i < figures.Count; i++)
                {
                    tempFigure = (Figure)figures[i].Clone();
                    tempFigure = tempFigure.dropFigure();
                    if (IsEqualFigure(tempNewFigure, tempFigure))
                    {
                        isCreated = true;
                        break;
                    }
                    tempFigure.turn();
                    if (IsEqualFigure(tempNewFigure, tempFigure))
                    {
                        isCreated = true;
                        break;
                    }
                    tempFigure.turn();
                    if (IsEqualFigure(tempNewFigure, tempFigure))
                    {
                        isCreated = true;
                        break;
                    }
                    tempFigure.turn();
                    if (IsEqualFigure(tempNewFigure, tempFigure))
                    {
                        isCreated = true;
                        break;
                    }
                }
                if (isCreated)
                {
                    MessageBox.Show("Такая фигура уже существует. Данное действие невозможно");
                    //currentFigureIndex = 0;
                    //comboBoxFigure.SelectedIndex = 0;
                }
                else
                {
                    if (comboBoxFigure.SelectedIndex == 1)
                        figures.Add(newFigure);
                    if (comboBoxFigure.SelectedIndex == 2)
                        figures[currentFigureIndex] = newFigure;
                    using (FileStream fs = new FileStream(pathToFileOfFigures, FileMode.Open))
                        formatter.Serialize(fs, figures);
                    currentFigureIndex = 0;
                    comboBoxFigure.SelectedIndex = 0;
                }
            }
        }
        private bool IsWholeFigure(int counter)
        {
            int tempCounter = 0, tmp;
            for (int i = 0; i < 5; i++)
            {
                tmp = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (arrayOfSquares[i, j] == 1 && counter != 1)
                    {
                        if (i == 0 && j >= 0 && j < 4 && counter - tempCounter > 1) //1 и 2
                        {
                            if (arrayOfSquares[i + 1, j] == 0 && arrayOfSquares[i, j + 1] == 0 && tmp == 0)
                                return false;
                            else
                            {
                                tempCounter++;
                                if (arrayOfSquares[i + 1, j] == 1)
                                    tmp++;
                            }
                        }
                        else if (i == 0 && j == 4 && arrayOfSquares[i + 1, j] == 0 && counter - tempCounter > 1) //3
                        {
                            if (arrayOfSquares[i + 1, j] == 0 && arrayOfSquares[i, j + 1] == 0 && tmp == 0)
                                return false;
                            else
                            {
                                tempCounter++;
                                if (arrayOfSquares[i + 1, j] == 1)
                                    tmp++;
                            }
                        }
                        else if (i > 0 && i < 4 && j >= 0 && j < 4 && counter - tempCounter > 1) //4 и 5
                        {
                            if (arrayOfSquares[i + 1, j] == 0 && arrayOfSquares[i, j + 1] == 0 && tmp == 0)
                                return false;
                            else
                            {
                                tempCounter++;
                                if (arrayOfSquares[i + 1, j] == 1)
                                    tmp++;
                            }
                        }
                        else if (i > 0 && i < 4 && j == 4 && counter - tempCounter > 1 && tmp == 0) //6
                        {
                            if (arrayOfSquares[i + 1, j] == 0)
                                return false;
                            else
                            {
                                tempCounter++;
                                tmp++;
                            }
                        }
                        else if (i == 4 && j == 0 && arrayOfSquares[i, j + 1] == 0 && counter - tempCounter > 1) //7
                            return false;
                        else if (i == 4 && j > 0 && j < 4 && arrayOfSquares[i, j + 1] == 0 && counter - tempCounter > 1) //8
                            return false;
                        else if (i == 4 && j == 4 && arrayOfSquares[i, j] == 0 && counter - tempCounter > 1) //9
                            return false;
                        else
                            tempCounter++;
                    }
                }
            }
            return true;
        }
        private bool IsEqualFigure(Figure figure1, Figure figure2)
        {
            if (figure1.Level == figure2.Level && figure1.Constructor.GetLength(0) == figure2.Constructor.GetLength(0) && figure1.Constructor.GetLength(1) == figure2.Constructor.GetLength(1))
            {
                for (int i = 0; i < figure1.Constructor.GetLength(0); i++)
                {
                    for (int j = 0; j < figure1.Constructor.GetLength(1); j++)
                    {
                        if (figure1.Constructor[i, j] != figure2.Constructor[i, j])
                            return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
        private void DeleteFigure()
        {
            int counter = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[currentFigureIndex].Level == figures[i].Level && figures[i] != figures[currentFigureIndex])
                    counter++;
            }
            if (counter > 0)
            {
                figures.RemoveAt(currentFigureIndex);
                using (FileStream fs = new FileStream(pathToFileOfFigures, FileMode.Open))
                    formatter.Serialize(fs, figures);
                MessageBox.Show("Игровая фигура удалена из коллекции");
            }
            else
                MessageBox.Show("Игровая фигура является единственной в коллекции данного уровня сложности. Удаление невозможно");
            currentFigureIndex = 0;
            comboBoxFigure.SelectedIndex = 0;
        }
        private void comboBoxCup_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCup.SelectedIndex)
            {
                case 0:
                    WatchCup();
                    break;
                case 1:
                    CreateCup();
                    break;
                case 2:
                    EditCup();
                    break;
                case 3:
                    DeleteCup();
                    break;
            }
        }
        private void WatchCup()
        {
            comboBoxCup.Enabled = true;
            isOkH = false;
            isOkW = false;
            CheckButtonCup();
            buttonSaveCup.Hide();
            textBoxH.Hide();
            textBoxW.Hide();
            buttonRight.Show();
            buttonLeft.Show();
            labelH.Show();
            labelW.Show();
            labelH.Text = cups[currentCupIndex].Height.ToString();
            labelW.Text = cups[currentCupIndex].Width.ToString();
            pictureBox1.Refresh();
        }
        private void CheckButtonCup()
        {
            if (currentCupIndex == 0)
                buttonLeft.Enabled = false;
            else
                buttonLeft.Enabled = true;
            if (currentCupIndex == cups.Count - 1)
                buttonRight.Enabled = false;
            else
                buttonRight.Enabled = true;
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (currentCupIndex > 0)
                currentCupIndex--;
            WatchCup();
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (currentCupIndex < cups.Count)
                currentCupIndex++;
            WatchCup();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int widthForDash = pictureBox1.Size.Width / 22;
            int heightForDash = pictureBox1.Size.Height / 27;
            if ((comboBoxCup.SelectedIndex == 0 || comboBoxCup.SelectedIndex == 2) && !isOkH && !isOkW)
            {
                rectangle = new Rectangle((pictureBox1.Size.Width - cups[currentCupIndex].Width * widthForDash) / 2, (pictureBox1.Size.Height - cups[currentCupIndex].Height * heightForDash) / 2, cups[currentCupIndex].Width * widthForDash, cups[currentCupIndex].Height * heightForDash);
                e.Graphics.DrawRectangle(pen, rectangle);
            }
            else if (isOkH && isOkW)
            {
                rectangle = new Rectangle((pictureBox1.Size.Width - Convert.ToInt32(textBoxW.Text) * widthForDash) / 2, (pictureBox1.Size.Height - Convert.ToInt32(textBoxH.Text) * heightForDash) / 2, Convert.ToInt32(textBoxW.Text) * widthForDash, Convert.ToInt32(textBoxH.Text) * heightForDash);
                e.Graphics.DrawRectangle(pen, rectangle);
            }
            for (int i = 0; i < pictureBox1.Size.Width; i += widthForDash)
                e.Graphics.DrawLine(dashPen, new Point(widthForDash + i, 0), new Point(widthForDash + i, pictureBox1.Size.Height));
            for (int i = 0; i < pictureBox1.Size.Height; i += heightForDash)
                e.Graphics.DrawLine(dashPen, new Point(0, heightForDash + i), new Point(pictureBox1.Size.Width, heightForDash + i));
            e.Dispose();
        }
        private void CreateCup()
        {
            comboBoxCup.Enabled = false;
            textBoxH.Clear();
            textBoxW.Clear();
            labelH.Hide();
            labelW.Hide();
            buttonSaveCup.Show();
            textBoxH.Show();
            textBoxW.Show();
            buttonRight.Hide();
            buttonLeft.Hide();
            pictureBox1.Refresh();
        }
        private void EditCup()
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (currentCupIndex == settings[i].Cup)
                    counter++;
            }
            if (counter == 0)
            {
                comboBoxCup.Enabled = false;
                labelH.Hide();
                labelW.Hide();
                buttonSaveCup.Show();
                textBoxH.Show();
                textBoxW.Show();
                buttonRight.Hide();
                buttonLeft.Hide();
                pictureBox1.Refresh();
                isOkH = false;
                isOkW = false;
                textBoxW.Text = cups[currentCupIndex].Width.ToString();
                textBoxH.Text = cups[currentCupIndex].Height.ToString();
            }
            else
            {
                MessageBox.Show("Игровой стакан присвоен уровню сложности. Редактирование невозможно");
                comboBoxCup.SelectedIndex = 0;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxW.Text) && !string.IsNullOrWhiteSpace(textBoxH.Text))
            {
                int width = Convert.ToInt32(textBoxW.Text);
                int height = Convert.ToInt32(textBoxH.Text);
                bool isCreated = false;
                for (int i = 0; i < cups.Count; i++)
                {
                    if (cups[i].Height == height && cups[i].Width == width)
                        isCreated = true;
                }
                if (isCreated)
                {
                    MessageBox.Show("Такой стакан уже существует");
                    if (comboBoxCup.SelectedIndex == 2)
                    {
                        isOkH = true;
                        isOkW = true;
                    }
                }
                else
                {
                    Cup newCup = new Cup(height, width);
                    if (comboBoxCup.SelectedIndex == 1)
                        cups.Add(newCup);
                    if (comboBoxCup.SelectedIndex == 2)
                        cups[currentCupIndex] = newCup;
                    using (FileStream fs = new FileStream(pathToFileOfCups, FileMode.Open))
                        formatter.Serialize(fs, cups);
                    comboBoxCup.SelectedIndex = 0;
                }
            }
            else
                MessageBox.Show("Заполните поля высоты и ширины");
        }
        private void DeleteCup()
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (currentCupIndex == settings[i].Cup)
                    counter++;
            }
            if (counter == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (currentCupIndex < settings[i].Cup)
                        settings[i].Cup = settings[i].Cup - 1;
                }
                cups.RemoveAt(currentCupIndex);
                using (FileStream fs = new FileStream(pathToFileOfCups, FileMode.Open))
                    formatter.Serialize(fs, cups);
                using (FileStream fs = new FileStream(pathToFileOfSettings, FileMode.Open))
                    formatter.Serialize(fs, settings);
                MessageBox.Show("Игровой стакан удален из коллекции");
            }
            else
                MessageBox.Show("Игровой стакан присвоен уровню сложности. Удаление невозможно");
            currentCupIndex = 0;
            comboBoxCup.SelectedIndex = 0;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                currentFigureIndex = 0;
                WatchFigure();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                currentCupIndex = 0;
                comboBoxCup.SelectedIndex = 0;
                WatchCup();
            }
            else
            {
                currentCupIndex = 0;
                comboBoxLevel.SelectedIndex = 0;
                BasicSettingOfLevel();
            }
        }
        private void BasicSettingOfLevel()
        {
            currentCupIndex = settings[comboBoxLevel.SelectedIndex].Cup;
            yourChoice = currentCupIndex;
            CheckButtonLevel();
            comboBoxSpeed.SelectedIndex = settings[comboBoxLevel.SelectedIndex].Speed;
            if (settings[comboBoxLevel.SelectedIndex].IsGrid)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            if (settings[comboBoxLevel.SelectedIndex].IsDisplay)
            {
                radioButton4.Checked = true;
                radioButton3.Checked = false;
            }
            else
            {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
            }
        }
        private void CheckButtonLevel()
        {
            if (currentCupIndex == 0)
                buttonLevelLeft.Enabled = false;
            else
                buttonLevelLeft.Enabled = true;
            if (currentCupIndex == cups.Count - 1)
                buttonLevelRight.Enabled = false;
            else
                buttonLevelRight.Enabled = true;
            pictureBoxLevel.Refresh();
        }
        private void buttonSaveLevel_Click(object sender, EventArgs e)
        {
            SettingOfLevel newSetting = new SettingOfLevel(comboBoxLevel.SelectedIndex, currentCupIndex, comboBoxSpeed.SelectedIndex, isGrid, isDisplay);
            settings[comboBoxLevel.SelectedIndex] = newSetting;
            using (FileStream fs = new FileStream(pathToFileOfSettings, FileMode.Open))
                formatter.Serialize(fs, settings);
            MessageBox.Show("Изменения успешно сохранены");
            //currentCupIndex = 0;
            //comboBoxLevel.SelectedIndex = 0;
        }
        private void pictureBoxLevel_Paint(object sender, PaintEventArgs e)
        {
            int widthForDash = pictureBoxLevel.Size.Width / 22;
            int heightForDash = pictureBoxLevel.Size.Height / 27;
            rectangle = new Rectangle((pictureBoxLevel.Size.Width - cups[currentCupIndex].Width * widthForDash) / 2, (pictureBoxLevel.Size.Height - cups[currentCupIndex].Height * heightForDash) / 2, cups[currentCupIndex].Width * widthForDash, cups[currentCupIndex].Height * heightForDash);
            e.Graphics.DrawRectangle(pen, rectangle);
            widthForDash = pictureBoxLevel.Size.Width / 12;
            heightForDash = pictureBoxLevel.Size.Height / 17;
            for (int i = 0; i < pictureBoxLevel.Size.Width; i += widthForDash)
                e.Graphics.DrawLine(dashPen, new Point(widthForDash + i, 0), new Point(widthForDash + i, pictureBoxLevel.Size.Height));
            for (int i = 0; i < pictureBoxLevel.Size.Height; i += heightForDash)
                e.Graphics.DrawLine(dashPen, new Point(0, heightForDash + i), new Point(pictureBoxLevel.Size.Width, heightForDash + i));
            e.Dispose();
        }



        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasicSettingOfLevel();
        }
        private void pictureBoxLevel_Click(object sender, EventArgs e)
        {
            yourChoice = currentCupIndex;
        }
        private void buttonLevelLeft_Click(object sender, EventArgs e)
        {
            if (currentCupIndex > 0)
                currentCupIndex--;
            CheckButtonLevel();
        }
        private void buttonLevelRight_Click(object sender, EventArgs e)
        {
            if (currentCupIndex < cups.Count)
                currentCupIndex++;
            CheckButtonLevel();
        }
        private void radioButtonsGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                isGrid = true;
            else if (radioButton2.Checked)
                isGrid = false;
        }
        private void radioButtonsDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                isDisplay = true;
            else if (radioButton3.Checked)
                isDisplay = false;
        }
        private void textBoxH_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                if (Convert.ToInt32(textBox.Text) < 15 || Convert.ToInt32(textBox.Text) > 25)
                    throw new ArgumentException("Высота стакана должна находиться в диапазоне от 15 до 25 клеток");
                else
                {
                    isOkH = true;
                    pictureBox1.Refresh();
                }
            }
            catch (Exception exp)
            {
                if (exp is FormatException)
                    MessageBox.Show("Введите число");
                if (exp is ArgumentException)
                    MessageBox.Show(exp.Message);
                isOkH = false;
                if (comboBoxCup.SelectedIndex == 2)
                    textBoxH.Text = cups[currentCupIndex].Height.ToString();
                else
                    textBoxH.Clear();
                pictureBox1.Refresh();
            }
        }
        private void textBoxW_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                if (Convert.ToInt32(textBox.Text) < 10 || Convert.ToInt32(textBox.Text) > 20)
                    throw new ArgumentException("Ширина стакана должна находиться в диапазоне от 10 до 20 клеток");
                else
                {
                    isOkW = true;
                    pictureBox1.Refresh();
                }
            }
            catch (Exception exp)
            {
                if (exp is FormatException)
                    MessageBox.Show("Введите число");
                if (exp is ArgumentException)
                    MessageBox.Show(exp.Message);
                isOkW = false;
                if (comboBoxCup.SelectedIndex == 2)
                    textBoxW.Text = cups[currentCupIndex].Width.ToString();
                else
                    textBoxW.Clear();
                pictureBox1.Refresh();
            }
        }
        public class MyTextBox : TextBox
        {
            private Timer m_delayedTextChangedTimer;
            public event EventHandler DelayedTextChanged;
            public MyTextBox() : base()
            {
                DelayedTextChangedTimeout = 2 * 1000; // 2 seconds
            }
            protected override void Dispose(bool disposing)
            {
                if (m_delayedTextChangedTimer != null)
                {
                    m_delayedTextChangedTimer.Stop();
                    if (disposing)
                        m_delayedTextChangedTimer.Dispose();
                }
                base.Dispose(disposing);
            }
            public int DelayedTextChangedTimeout { get; set; }
            protected virtual void OnDelayedTextChanged(EventArgs e)
            {
                DelayedTextChanged?.Invoke(this, e);
            }
            protected override void OnTextChanged(EventArgs e)
            {
                InitializeDelayedTextChangedEvent();
                base.OnTextChanged(e);
            }
            private void InitializeDelayedTextChangedEvent()
            {
                if (m_delayedTextChangedTimer != null)
                    m_delayedTextChangedTimer.Stop();
                if (m_delayedTextChangedTimer == null || m_delayedTextChangedTimer.Interval != this.DelayedTextChangedTimeout)
                {
                    m_delayedTextChangedTimer = new Timer();
                    m_delayedTextChangedTimer.Tick += new EventHandler(HandleDelayedTextChangedTimerTick);
                    m_delayedTextChangedTimer.Interval = this.DelayedTextChangedTimeout;
                }
                m_delayedTextChangedTimer.Start();
            }
            private void HandleDelayedTextChangedTimerTick(object sender, EventArgs e)
            {
                Timer timer = sender as Timer;
                timer.Stop();
                OnDelayedTextChanged(EventArgs.Empty);
            }
        }
    }
}
