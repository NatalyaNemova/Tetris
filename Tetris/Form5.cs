using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form5 : Form
    {
        private string user;
        private bool ratingWay;
        private long score;
        List<Rating> ratings;


        public Form5(string user, bool type, long score)
        {
            this.user = user;
            this.ratingWay = type;
            this.score = score;
            InitializeComponent();
            ratings = FileSystem.FormListOfRatings();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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
            if(result==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (Rating rating in ratings.ToArray())
            {
                if (ratingWay != rating.type || rating.user == "Admin")
                    ratings.Remove(rating);
            }
            
                //сортировка по убыванию
                for (int i = 0; i < ratings.ToArray().Length - 1; i++)
                {
                    for (int j = 0; j < ratings.ToArray().Length - i - 1; j++)
                    {
                        if (ratings[j + 1].score > ratings[j].score)
                        {
                            ratings.Insert(j + 2, ratings[j]);
                            ratings.RemoveAt(j);
                        }

                    }
                }
                int length = ratings.ToArray().Length;
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                    if (i >= length)
                        i = length - 1;
                    if (ratings[i].user == ratings[j].user && ratings[i].score < ratings[j].score)
                    {
                        if (i != j)
                        {
                            ratings.RemoveAt(i);
                            length = ratings.ToArray().Length;
                        }
                    }
                    else if (ratings[i].user == ratings[j].user && ratings[i].score >= ratings[j].score)
                        if (i != j)
                        {
                            ratings.RemoveAt(j);
                            length = ratings.ToArray().Length;
                        }
                }
                }

            if (ratings.Count < 11)
            {
                foreach (Rating rating in ratings)
                {
                    label2.Text += rating.user + "\n";
                    label4.Text += rating.score + "\n";
                }
            }
            else
            {
                for(int i=0;i<11;i++)
                {
                    label2.Text += ratings[i].user + "\n";
                    label4.Text += ratings[i].score + "\n";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            Form4 settingsForm = new Form4(user, ratingWay, 0);
            settingsForm.Show();
        }
    }
}
