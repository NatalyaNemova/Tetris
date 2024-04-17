using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form3 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Figure currentFigure;
        Figure nextFigure;
        Timer timer = new Timer();
        DateTime date;
        int levelNumber;
        bool isMusic;
        bool ratingWay;
        long score;
        long scoretime;
        string user;
        SettingOfLevel settingOfLevel;//= FileSystem.FormListOfSettings()[levelNumber]; // уровень сложности
        List<Figure> figures;
        List<Cup> cups = FileSystem.FormListOfCups();
        List<Rating> ratings = FileSystem.FormListOfRatings();
        int canvasWidth;
        int canvasHeight;
        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        int[,] canvasDotArray;
        int dotSize = 18;
        private WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();





        public Form3(int levelNumber, bool isMusic, bool ratingWay, string user, long score)
        {
            this.levelNumber = levelNumber;
            settingOfLevel = FileSystem.FormListOfSettings()[levelNumber];
            this.isMusic = isMusic;
            this.ratingWay = ratingWay;
            this.user = user;
            this.score = score;
            this.scoretime = score;
            InitializeComponent();
            date = DateTime.Now;
            panel1.Visible = settingOfLevel.IsDisplay;
            canvasWidth = cups[settingOfLevel.Cup].Width;
            canvasHeight = cups[settingOfLevel.Cup].Height;
            this.KeyPreview = true;
            if (isMusic)
            {
                playMusic();
            }
            loadCanvas();

            currentFigure = getRandomShapeWithCenterAligned();
            nextFigure = getNextFigure();
            timer.Tick += Timer_Tick;
            switch (settingOfLevel.Speed)
            {
                case 0:
                    timer.Interval = 1000;
                    break;
                case 1:
                    timer.Interval = 500;
                    break;
                case 2:
                    timer.Interval = 300;
                    break;
                default:
                    break;
            }
            timer.Start();


        }

            public Cup cupByLevel(List<Cup> cups)
        {
            var cup = cups[settingOfLevel.Cup];
            return cup;
        }

        public void loadCanvas()
        {
            figures = FileSystem.FormListOfFigures(); // фигуры
            foreach (Figure figure in figures.ToArray())
            {
                if (figure.Level != settingOfLevel.Level)
                {
                    figures.Remove(figure);
                }
                else figure.dropFigure();
            }


            // Resize the picture box based on the dotsize and canvas size
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            canvasGraphics = Graphics.FromImage(canvasBitmap);
            if (settingOfLevel.IsGrid)
            {
                drawGrid(canvasGraphics);
            }
            canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);


            // Load bitmap into picture box
            pictureBox1.Image = canvasBitmap;

            // Initialize canvas dot array. by default all elements are zero
            canvasDotArray = new int[canvasWidth, canvasHeight];

        }

        public void drawGrid(Graphics g)
        {
            for (int i = 0; i <= canvasHeight; i++)
            {
                g.DrawLine(Pens.White, new Point(0, 0 + i * dotSize), new Point(0 + canvasWidth * dotSize, 0 + i * dotSize));
            }
            for (int i = 0; i <= canvasWidth; i++)
            {
                g.DrawLine(Pens.White, new Point(0 + i * dotSize, 0), new Point(0 + i * dotSize, 0 + canvasHeight * dotSize));
            }
            g.DrawLine(Pens.White, new Point(0 - 1, canvasHeight * dotSize - 1), new Point(0 + canvasWidth * dotSize - 1, 0 + canvasHeight * dotSize - 1));
            g.DrawLine(Pens.White, new Point(0 + canvasWidth * dotSize - 1, 0 - 1), new Point(0 + canvasWidth * dotSize - 1, 0 + canvasHeight * dotSize - 1));

        }

        int currentX;
        int currentY;
        private Figure getRandomShapeWithCenterAligned()
        {
            switch (settingOfLevel.Speed)
            {
                case 0:
                    timer.Interval = 1000;
                    break;
                case 1:
                    timer.Interval = 500;
                    break;
                case 2:
                    timer.Interval = 300;
                    break;
                default:
                    break;
            }
            

            var figure = figures[new Random().Next(figures.Count)];

            // Calculate the x and y values as if the shape lies in the center
            currentX = Convert.ToInt32(canvasWidth / 2);
            currentY = -figure.Constructor.GetLength(1);

            return figure;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Figure getNextFigure()
        {
            var figure = getRandomShapeWithCenterAligned();
            // Codes to show the next shape in the side panel
            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);
            nextShapeGraphics.FillRectangle(Brushes.Transparent, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);
            // Find the ideal position for the shape in the side panel
            var startX = (6 - figure.Constructor.GetLength(0)) / 2;
            var startY = (6 - figure.Constructor.GetLength(1)) / 2;

            for (int i = 0; i < figure.Constructor.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Constructor.GetLength(1); j++)
                {
                    nextShapeGraphics.FillRectangle(figure.Constructor[i, j] == 1 ? figure.colorSet() : Brushes.LightGray, // цвет следующей
                    (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return figure;
        }
        Bitmap workingBitmap;
        Graphics workingGraphics;
        //long scoretime = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!ratingWay)
            {
                long tick = DateTime.Now.Ticks - date.Ticks;
                DateTime stopWatch = new DateTime();
                stopWatch = stopWatch.AddTicks(tick);
                label1.Visible = true;
                label1.Text = "Время: " + String.Format("{0:mm:ss}", stopWatch);
                scoretime = stopWatch.Minute*60*1000 + stopWatch.Second*1000 + stopWatch.Millisecond;
                scoretime /= 1000;
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Очки: " + score;
            }

            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            // if shape reached bottom or touched any other shapes
             if (!isMoveSuccess)
            {
                // copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);
                updateCanvasDotArrayWithCurrentShape();

                // get next shape
                currentFigure = nextFigure;
                nextFigure = getNextFigure();

                clearFilledRowsAndUpdateScore();
            }

            if (settingOfLevel.IsGrid)
            {
                drawGrid(canvasGraphics);
            }

        }

        

        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0)
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;

            // check if it reaches the bottom or side bar
            if (newX < 0 || newX + currentFigure.Constructor.GetLength(1) > canvasWidth || newY + currentFigure.Constructor.GetLength(0) > canvasHeight)
                return false;

            // check if it touches any other blocks
            for (int i = 0; i < currentFigure.Constructor.GetLength(1); i++)
            {
                for (int j = 0; j < currentFigure.Constructor.GetLength(0); j++)
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] == 1 && currentFigure.Constructor[j, i] == 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }

        private void drawShape()
        {

            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);
            for (int i = 0; i < currentFigure.Constructor.GetLength(1); i++)
            {
                for (int j = 0; j < currentFigure.Constructor.GetLength(0); j++)
                {
                    if (currentFigure.Constructor[j, i] == 1)
                        workingGraphics.FillRectangle(currentFigure.colorSet(), (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize); // цвет летящей фигуры
                }
            }
            pictureBox1.Image = workingBitmap;
        }
        private void updateCanvasDotArrayWithCurrentShape()
        {

            if (checkIfGameOver())
            {
                for (int i = 0; i < currentFigure.Constructor.GetLength(1); i++)
                {
                    for (int j = 0; j < currentFigure.Constructor.GetLength(0); j++)
                    {
                        if (currentFigure.Constructor[j, i] == 1)
                        {
                            canvasDotArray[currentX + i, currentY + j] = 1;
                        }
                    }
                }
            }
        }
        private bool checkIfGameOver()
        {
            if (currentY < 0)
            {
                timer.Tick -= Timer_Tick;
                timer.Stop();
                WMP.controls.stop();
                Close();
                DialogResult result = MessageBox.Show("Конец игры", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    
                    if (ratingWay) 
                    {
                        Rating rating1 = new Rating(user, ratingWay, score*(levelNumber+1));
                        ratings.Add(rating1);
                    using (FileStream fs = new FileStream("rating.rat", FileMode.Open))
                            formatter.Serialize(fs, ratings);
                        Form5 rating = new Form5(user,ratingWay,score* (levelNumber + 1));
                        rating.Show();
                    }
                    else
                    {
                        Rating rating1 = new Rating(user, ratingWay, scoretime*(levelNumber + 1));
                        ratings.Add(rating1);
                        using (FileStream fs = new FileStream("rating.rat", FileMode.Open))
                            formatter.Serialize(fs, ratings);
                        Form5 rating = new Form5(user, ratingWay, scoretime*(levelNumber + 1));
                        rating.Show();
                    }
                    
                    
                }
                return false;
            }
            else return true;
        }


        //int score;
        public void clearFilledRowsAndUpdateScore()
        {
            // check through each rows
            for (int i = 0; i < canvasHeight; i++)
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--)
                {
                    if (canvasDotArray[j, i] == 0)
                        break;
                }

                if (j == -1)
                {
                    // update score and level values and labels
                    score++;
                    label2.Text = "Очки " + (settingOfLevel.Level+1)*score;
                    // increase the speed
                    timer.Interval -= 10;

                    // update the dot array based on the check
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = 0;
                    }
                }
            }

            // Draw panel based on the updated array values
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(
                    canvasDotArray[i, j] == 1 ? Brushes.Black : Brushes.LightGray,
                    i * dotSize, j * dotSize, dotSize, dotSize
                    );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }
        private void playMusic()
        {
            isMusic = true;
            WMP.URL = @"sound.mp3";
            WMP.controls.play();
            WMP.settings.setMode("loop", true);
        }

        private void Form3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            var verticalMove = 0;
            var horizontalMove = 0;

            // calculate the vertical and horizontal move values
            // based on the key pressed
            switch (e.KeyCode)
            {
                // move shape left
                case Keys.Left:
                    verticalMove--;
                    break;

                // move shape right
                case Keys.Right:
                    verticalMove++;
                    break;

                // move shape down faster
                case Keys.Down:
                    timer.Interval = 10;
                    break;

                // rotate the shape clockwise
                case Keys.Up:

                    currentFigure.turn();
                    int offset = canvasWidth - (currentX + currentFigure.Constructor.GetLength(1));
                    if (offset < 0)
                    {
                        for (int i = 0; i < Math.Abs(offset); i++)
                            verticalMove--;
                    }
                    if (currentX < 0)
                    {
                        for (int i = 0; i < Math.Abs(currentX) + 1; i++)
                            verticalMove++;
                    }
                    break;
                default:
                    return;
            }
            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            // if the player was trying to rotate the shape, but
            // that move was not possible - rollback the shape
            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentFigure.rollback();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMP.controls.stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Пауза")
            {
                timer.Stop();
                WMP.controls.pause();
                button1.Text = "Продолжить";
            }
            else
            {
                timer.Start();
                WMP.controls.play();
                button1.Text = "Пауза";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
