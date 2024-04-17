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
    public partial class Form4 : Form
    {
        private int levelNumber = 0;
        private bool isMusic = false;
        private bool ratingWay = true;
        private string user;
        private long score;

        public Form4(string user, bool type, long score)
        {
            this.user = user;
            this.ratingWay = type;
            this.score = score;
            InitializeComponent();
            comboBox3.Text = "1";
            comboBox3.SelectedItem = 1;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Close();
            Form1 formMain = new Form1();
            formMain.Show();
        }
        private void radioButtonsMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                isMusic = true;
            else if (radioButton2.Checked)
                isMusic = false;

        }
        private void radioButtonsRatingWay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                ratingWay = true;
            else if (radioButton3.Checked)
                ratingWay = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null ||(radioButton1.Checked == false && radioButton2.Checked == false) ||(radioButton3.Checked == false && radioButton4.Checked == false))
            {
                if (comboBox3.SelectedItem == null)
                    MessageBox.Show("Выберите уровень сложности");
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                    MessageBox.Show("Выберите режим музыкального сопровождения");
                if (radioButton3.Checked == false && radioButton4.Checked == false)
                    MessageBox.Show("Выберите способ подсчета результата");
            }
            else
            {
                Close();
                Form3 runForm = new Form3(levelNumber-1, isMusic, ratingWay, user, score);
                runForm.Show();
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            levelNumber = Convert.ToInt32(comboBox3.SelectedItem);
        }

        //private void toolStripLabel1_Click(object sender, EventArgs e)
        //{
        //    Close();
        //    Form6 formInfo = new Form6(this);
        //    formInfo.Show();
        //}

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        
    }
}
