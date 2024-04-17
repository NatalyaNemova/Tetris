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
    public partial class Form1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string adminLogin = "Admin";
        string adminPassword = "12345";
        string pathToFileOfAccounts = "user.users";
        string pathToFileOfSettings = "level.level";
        string pathToFileOfFigures = "fig.fig";
        string pathToFileOfCups = "cup.cup";
        string pathToInfo = "Site1\\index.html";
        List<User> users = new List<User>();
        List<Figure> figures = new List<Figure>();
        SettingOfLevel[] settings = new SettingOfLevel[3];
        List<Cup> cups = new List<Cup>();
        List<Rating> rating = new List<Rating>();
        public Form1()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxNewPassword.UseSystemPasswordChar = true;
            textBoxCheckPassword.UseSystemPasswordChar = true;
            try
            {
                users = FormListOfAccounts(pathToFileOfAccounts);
            }
            catch (Exception exp)
            {
                if (exp is FileNotFoundException)
                    MessageBox.Show("Невозможно найти файл учетных записей");
                else
                    MessageBox.Show("Файл учетных записей поврежден");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }
            try
            {
                settings = FormListOfSettings(pathToFileOfSettings);
            }
            catch (Exception exp)
            {
                if (exp is FileNotFoundException)
                    MessageBox.Show("Невозможно найти файл уровней сложностей");
                else
                    MessageBox.Show("Файл уровней сложностей поврежден");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }
            try
            {
                figures = FormListOfFigures(pathToFileOfFigures);
            }
            catch (Exception exp)
            {
                if (exp is FileNotFoundException)
                    MessageBox.Show("Невозможно найти файл игровых фигур");
                else
                    MessageBox.Show("Файл игровых фигур поврежден");
            }
            try
            {
                cups = FormListOfCups(pathToFileOfCups);
            }
            catch (Exception exp)
            {
                if (exp is FileNotFoundException)
                    MessageBox.Show("Невозможно найти файл игровых стаканов");
                else
                    MessageBox.Show("Файл игровых стаканов поврежден");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }

            try 
            {
                rating = FileSystem.FormListOfRatings();
            }
            catch(Exception exp) 
            {
                if (exp is FileNotFoundException)
                    MessageBox.Show("Невозможно найти файл рейтинга");
                else
                    MessageBox.Show("Файл рейтинга поврежден");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }
            
                bool exist = File.Exists("sound.mp3");
            if (!exist)
            {
                MessageBox.Show("Невозможно найти файл музыкального сопровождения");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }

            exist = File.Exists(pathToInfo);
            if (!exist)
            {
                MessageBox.Show("Невозможно найти файл справки");
                buttonEnter.Enabled = false;
                buttonRegistrate.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxCheckPassword.Enabled = false;
                textBoxNewLogin.Enabled = false;
                textBoxNewPassword.Enabled = false;
            }

        }
        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            if (!string.IsNullOrWhiteSpace(textBoxNewPassword.Text) && !string.IsNullOrWhiteSpace(textBoxNewLogin.Text) && !string.IsNullOrWhiteSpace(textBoxCheckPassword.Text))
            {
                if (textBoxNewLogin.Text.Length < 11 && textBoxNewLogin.Text.Length > 1)
                {
                    foreach (User user in users)
                    {
                        if (user.Login == textBoxNewLogin.Text)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            isCorrect = false;
                            textBoxNewLogin.Clear();
                            textBoxNewPassword.Clear();
                            textBoxCheckPassword.Clear();
                            break;
                        }
                    }
                    if (isCorrect)
                    {
                        if (textBoxNewPassword.Text.Length < 11 && textBoxNewPassword.Text.Length > 3 && textBoxCheckPassword.Text.Length < 11 && textBoxCheckPassword.Text.Length > 3)
                        {
                            if (textBoxNewPassword.Text == textBoxCheckPassword.Text)
                            {
                                string prohibitedChars = "$%^&*?+=()@`\"\'<>/\\,:;[]{} ";
                                if (textBoxNewLogin.Text.Intersect(prohibitedChars).Any() || textBoxNewPassword.Text.Intersect(prohibitedChars).Any() || textBoxCheckPassword.Text.Intersect(prohibitedChars).Any())
                                {
                                    MessageBox.Show("Введены недопустимые символы");
                                    textBoxNewLogin.Clear();
                                    textBoxNewPassword.Clear();
                                    textBoxCheckPassword.Clear();
                                }
                                else
                                {
                                    User newUser = new User(textBoxNewLogin.Text, textBoxNewPassword.Text);
                                    users.Add(newUser);
                                    try
                                    {
                                        using (FileStream fs = new FileStream(pathToFileOfAccounts, FileMode.Open))
                                            formatter.Serialize(fs, users);
                                        Hide();
                                        Form4 formGame = new Form4(textBoxNewLogin.Text, true, 0);
                                        formGame.Show();
                                    }
                                    catch (Exception exp)
                                    {
                                        if (exp is FileNotFoundException)
                                            MessageBox.Show("Невозможно найти файл учетных записей");
                                        else
                                            MessageBox.Show("Файл учетных записей поврежден");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пароли не совпадают");
                                textBoxNewPassword.Clear();
                                textBoxCheckPassword.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Длина пароля должна составлять не менее 4 и не более 12 символов");
                            textBoxNewPassword.Clear();
                            textBoxCheckPassword.Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Длина логина должна составлять не менее 2 и не более 12 символов");
                    textBoxNewLogin.Clear();
                    textBoxNewPassword.Clear();
                    textBoxCheckPassword.Clear();
                }
            }
            else MessageBox.Show("Заполните поля логин и пароль");
        }
        private void buttonEnter_Click_1(object sender, EventArgs e)
        {
            bool isCreated = false;
            if (!string.IsNullOrWhiteSpace(textBoxPassword.Text) && !string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                foreach (User user in users)
                {
                    if ((textBoxLogin.Text == adminLogin) && (textBoxPassword.Text == adminPassword))
                    {
                        Hide();
                        Form2 formAdmin = new Form2(figures, settings, cups, pathToFileOfSettings, pathToFileOfFigures, pathToFileOfCups);
                        formAdmin.Show();
                        isCreated = true;
                        break;
                    }
                    if (user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Text)
                    {
                        Hide();
                        Form4 formGame = new Form4(textBoxLogin.Text, true,0);
                        formGame.Show();
                        isCreated = true;
                        break;
                    }
                    else if (user.Login == textBoxLogin.Text && user.Password != textBoxPassword.Text)
                    {
                        MessageBox.Show("Неверный пароль");
                        textBoxLogin.Clear();
                        textBoxPassword.Clear();
                        isCreated = true;
                        break;
                    }
                }
                if (!isCreated)
                {
                    MessageBox.Show("Пользователя с таким логином не существует");
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();
                }
            }
            else MessageBox.Show("Заполните поля логин и пароль");
        }
        private List<User> FormListOfAccounts(string path)
        {
            List<User> users = new List<User>();
            if (new FileInfo(path).Length == 0)
            {
                User admin = new User(adminLogin, adminPassword);
                users.Add(admin);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    formatter.Serialize(fs, users);
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
                return (List<User>)formatter.Deserialize(fs);
        }
        private SettingOfLevel[] FormListOfSettings(string path)
        {
            SettingOfLevel[] settings = new SettingOfLevel[3];
            if (new FileInfo(path).Length == 0)
            {
                SettingOfLevel setting = new SettingOfLevel(0, 0, 0, true, true);
                for (int i = 0; i < 3; i++)
                    settings[i] = setting;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    formatter.Serialize(fs, settings);
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
                return (SettingOfLevel[])formatter.Deserialize(fs);
        }
        private List<Figure> FormListOfFigures(string path)
        {
            List<Figure> figures = new List<Figure>();
            if (new FileInfo(path).Length == 0)
            {
                int[,] figureConstructor = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                        figureConstructor[i, j] = 1;
                }
                for (int i = 0; i < 3; i++)
                {
                    Figure figure = new Figure(i, figureConstructor);
                    figures.Add(figure);
                }
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    formatter.Serialize(fs, figures);
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
                return (List<Figure>)formatter.Deserialize(fs);
        }
        private List<Cup> FormListOfCups(string path)
        {
            List<Cup> cups = new List<Cup>();
            if (new FileInfo(path).Length == 0)
            {
                Cup cup = new Cup(25, 20);
                cups.Add(cup);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    formatter.Serialize(fs, cups);
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
                return (List<Cup>)formatter.Deserialize(fs);
        }

        

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 formInfo = new Form6(this, pathToInfo);
            formInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage2"];
        }
    }
    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
    [Serializable]
    public class SettingOfLevel
    {
        public int Level { get; set; }
        public int Cup { get; set; }
        public int Speed { get; set; }
        public bool IsGrid { get; set; }
        public bool IsDisplay { get; set; }
        public SettingOfLevel(int level, int cup, int speed, bool isGrid, bool isDisplay)
        {
            Level = level;
            Cup = cup;
            Speed = speed;
            IsGrid = isGrid;
            IsDisplay = isDisplay;
        }
    }
    [Serializable]
    public class Figure : ICloneable
    {
        public int Level { get; set; }
        public int[,] Constructor { get; set; }
        public Figure(int level, int[,] constuctor)
        {
            Level = level;
            Constructor = constuctor;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public Brush colorSet()
        {
            int lengthSum = Constructor.GetLength(1) + Constructor.GetLength(0);
            int random = lengthSum % 7;
            Brush color=Brushes.Red;
            switch (random)
            {
                case 0:
                    color = Brushes.Red;
                    break;
                case 1:
                    color = Brushes.Orange;
                    break;
                case 2:
                    color = Brushes.Yellow;
                    break;
                case 3:
                    color = Brushes.Green;
                    break;
                case 4:
                    color = Brushes.LightBlue;
                    break;
                case 5:
                    color = Brushes.Blue;
                    break;
                case 6:
                    color = Brushes.Violet;
                    break;
                default:
                    break;
            }
            return color;


        }
        public Figure dropFigure()
        {

            int minI = 5;
            int minJ = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.Constructor[i, j] == 1)
                    {
                        if (i < minI)
                        {
                            minI = i;
                        }
                        if (j < minJ)
                        {
                            minJ = j;
                        }
                    }
                }
            }
            int maxI = 0;
            int maxJ = 0;
            for (int i = 4; i >= 0; i--)
            {
                for (int j = 4; j >= 0; j--)
                {
                    if (this.Constructor[i, j] == 1)
                    {
                        if (i > maxI)
                        {
                            maxI = i;
                        }
                        if (j > maxJ)
                        {
                            maxJ = j;
                        }
                    }
                }
            }
            int newI = maxI - minI + 1;
            int newJ = maxJ - minJ + 1;
            int[,] newConstructor= new int[newI, newJ];

            for (int i = 0; i < newI; i++)
            {
                for (int j = 0; j < newJ; j++)
                {
                    newConstructor[i, j] = this.Constructor[i + minI, j + minJ];
                }
            }
            this.Constructor = newConstructor;
            return this;
        }
        int Width;
        int Height;
        private int[,] backupDots;
        public void turn()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            //backupDots = Constructor;
            Width = Constructor.GetLength(1);
            Height = Constructor.GetLength(0);

            {
                backupDots = new int[Width, Height];
                int newColumn, newRow = 0;
                for (int oldColumn = Width - 1; oldColumn >= 0; oldColumn--)
                {
                    newColumn = 0;
                    for (int oldRow = 0; oldRow < Height; oldRow++)
                    {
                        backupDots[newRow, newColumn] = Constructor[oldRow, oldColumn];
                        newColumn++;
                    }
                    newRow++;
                }
                
                Constructor = backupDots;
            }
            
        }

        // the rolling back occures when player rotating the shape
        // but it will touch other shapes and needs to be rolled back
        public void rollback()
        {
            Constructor = backupDots;
            Width = Constructor.GetLength(1);
            Height = Constructor.GetLength(0);

            var temp = Width;
            Width = Height;
            Height = temp;
        }
    }
    [Serializable]
    public class Cup
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Cup(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }

    [Serializable]
    public class Rating {
        public String user { get; set; }
        public bool type { get; set; }
       public long score { get; set; }
        public Rating(String user, bool type, long score)
        {
            this.user = user;
            this.type = type;
            this.score = score;
        }
    }

}