namespace Tetris
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveFig = new System.Windows.Forms.Button();
            this.buttonFigLeft = new System.Windows.Forms.Button();
            this.buttonFigRight = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFigure = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelW = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.buttonSaveCup = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCup = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonSaveLevel = new System.Windows.Forms.Button();
            this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
            this.buttonLevelLeft = new System.Windows.Forms.Button();
            this.pictureBoxLevel = new System.Windows.Forms.PictureBox();
            this.buttonLevelRight = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(662, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Вернуться к окну входа";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(206, 28);
            this.toolStripLabel2.Text = "Вернуться к окну входа";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(125, 28);
            this.toolStripLabel3.Text = "Выйти из игры";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 594);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.tabPage1.BackgroundImage = global::Tetris.Properties.Resources._1619508945_5_phonoteka_org_p_tetris_fon_51;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.comboBoxFigure);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 563);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игровые фигуры";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Tetris.Properties.Resources.Без_имени_2;
            this.panel1.Controls.Add(this.buttonSaveFig);
            this.panel1.Controls.Add(this.buttonFigLeft);
            this.panel1.Controls.Add(this.buttonFigRight);
            this.panel1.Controls.Add(this.labelLevel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(28, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 512);
            this.panel1.TabIndex = 6;
            // 
            // buttonSaveFig
            // 
            this.buttonSaveFig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.buttonSaveFig.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveFig.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSaveFig.Location = new System.Drawing.Point(150, 394);
            this.buttonSaveFig.Name = "buttonSaveFig";
            this.buttonSaveFig.Size = new System.Drawing.Size(300, 55);
            this.buttonSaveFig.TabIndex = 18;
            this.buttonSaveFig.Text = "Сохранить";
            this.buttonSaveFig.UseVisualStyleBackColor = false;
            this.buttonSaveFig.Click += new System.EventHandler(this.buttonSaveFigure_Click_1);
            // 
            // buttonFigLeft
            // 
            this.buttonFigLeft.BackColor = System.Drawing.Color.White;
            this.buttonFigLeft.BackgroundImage = global::Tetris.Properties.Resources.toLeft1;
            this.buttonFigLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonFigLeft.Location = new System.Drawing.Point(81, 164);
            this.buttonFigLeft.Name = "buttonFigLeft";
            this.buttonFigLeft.Size = new System.Drawing.Size(44, 50);
            this.buttonFigLeft.TabIndex = 5;
            this.buttonFigLeft.UseVisualStyleBackColor = false;
            this.buttonFigLeft.Click += new System.EventHandler(this.buttonLeftFigure_Click);
            // 
            // buttonFigRight
            // 
            this.buttonFigRight.BackgroundImage = global::Tetris.Properties.Resources.toRight1;
            this.buttonFigRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonFigRight.Location = new System.Drawing.Point(492, 164);
            this.buttonFigRight.Name = "buttonFigRight";
            this.buttonFigRight.Size = new System.Drawing.Size(44, 50);
            this.buttonFigRight.TabIndex = 4;
            this.buttonFigRight.UseVisualStyleBackColor = true;
            this.buttonFigRight.Click += new System.EventHandler(this.buttonRightFigure_Click);
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLevel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelLevel.Location = new System.Drawing.Point(388, 358);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(62, 17);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(147, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Уровень сложности:";
            // 
            // comboBoxFigure
            // 
            this.comboBoxFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFigure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxFigure.FormattingEnabled = true;
            this.comboBoxFigure.Items.AddRange(new object[] {
            "Просмотр игровой фигуры",
            "Создание игровой фигуры",
            "Редактирование игровой фигуры",
            "Удаление игровой фигуры"});
            this.comboBoxFigure.Location = new System.Drawing.Point(84, 26);
            this.comboBoxFigure.Name = "comboBoxFigure";
            this.comboBoxFigure.Size = new System.Drawing.Size(484, 25);
            this.comboBoxFigure.TabIndex = 5;
            this.comboBoxFigure.SelectedIndexChanged += new System.EventHandler(this.comboBoxFigure_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.tabPage2.BackgroundImage = global::Tetris.Properties.Resources._1619508945_5_phonoteka_org_p_tetris_fon_51;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.comboBoxCup);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(654, 569);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Игровые стаканы";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Tetris.Properties.Resources.Без_имени_2;
            this.panel2.Controls.Add(this.labelW);
            this.panel2.Controls.Add(this.labelH);
            this.panel2.Controls.Add(this.buttonSaveCup);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.buttonLeft);
            this.panel2.Controls.Add(this.buttonRight);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelWidth);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(46, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 478);
            this.panel2.TabIndex = 8;
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelW.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelW.Location = new System.Drawing.Point(355, 376);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(62, 17);
            this.labelW.TabIndex = 19;
            this.labelW.Text = "label1";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelH.Location = new System.Drawing.Point(355, 350);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(62, 17);
            this.labelH.TabIndex = 18;
            this.labelH.Text = "label1";
            // 
            // buttonSaveCup
            // 
            this.buttonSaveCup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.buttonSaveCup.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveCup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSaveCup.Location = new System.Drawing.Point(139, 420);
            this.buttonSaveCup.Name = "buttonSaveCup";
            this.buttonSaveCup.Size = new System.Drawing.Size(300, 55);
            this.buttonSaveCup.TabIndex = 17;
            this.buttonSaveCup.Text = "Сохранить";
            this.buttonSaveCup.UseVisualStyleBackColor = false;
            this.buttonSaveCup.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(153, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 324);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.Color.White;
            this.buttonLeft.BackgroundImage = global::Tetris.Properties.Resources.toLeft1;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(38, 148);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(44, 50);
            this.buttonLeft.TabIndex = 8;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.White;
            this.buttonRight.BackgroundImage = global::Tetris.Properties.Resources.toRight1;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.ForeColor = System.Drawing.Color.White;
            this.buttonRight.Location = new System.Drawing.Point(478, 148);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(44, 50);
            this.buttonRight.TabIndex = 7;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(150, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Высота стакана:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(388, 425);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(0, 17);
            this.labelWidth.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(150, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ширина стакана:";
            // 
            // comboBoxCup
            // 
            this.comboBoxCup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCup.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCup.FormattingEnabled = true;
            this.comboBoxCup.Items.AddRange(new object[] {
            "Просмотр игрового стакана",
            "Создание игрового стакана",
            "Редактирование игрового стакана",
            "Удаление игрового стакана"});
            this.comboBoxCup.Location = new System.Drawing.Point(84, 29);
            this.comboBoxCup.Name = "comboBoxCup";
            this.comboBoxCup.Size = new System.Drawing.Size(484, 25);
            this.comboBoxCup.TabIndex = 7;
            this.comboBoxCup.SelectedIndexChanged += new System.EventHandler(this.comboBoxCup_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.BackgroundImage = global::Tetris.Properties.Resources._1619508945_5_phonoteka_org_p_tetris_fon_51;
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.comboBoxLevel);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(654, 569);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки уровней сложности";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(82, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Уровень сложности:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::Tetris.Properties.Resources.Без_имени_2;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.buttonSaveLevel);
            this.panel3.Controls.Add(this.comboBoxSpeed);
            this.panel3.Controls.Add(this.buttonLevelLeft);
            this.panel3.Controls.Add(this.pictureBoxLevel);
            this.panel3.Controls.Add(this.buttonLevelRight);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(3, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(648, 483);
            this.panel3.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(83, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 66);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим отображения следующей падающей фигуры";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(264, 29);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(164, 21);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Не отображается";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(21, 30);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(137, 21);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Отображается";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(84, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 66);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим отображения игровой сетки";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(264, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(164, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Не отображается";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(137, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Отображается";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonSaveLevel
            // 
            this.buttonSaveLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.buttonSaveLevel.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveLevel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSaveLevel.Location = new System.Drawing.Point(201, 392);
            this.buttonSaveLevel.Name = "buttonSaveLevel";
            this.buttonSaveLevel.Size = new System.Drawing.Size(264, 55);
            this.buttonSaveLevel.TabIndex = 16;
            this.buttonSaveLevel.Text = "Сохранить настройки";
            this.buttonSaveLevel.UseVisualStyleBackColor = false;
            this.buttonSaveLevel.Click += new System.EventHandler(this.buttonSaveLevel_Click);
            // 
            // comboBoxSpeed
            // 
            this.comboBoxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpeed.FormattingEnabled = true;
            this.comboBoxSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxSpeed.Location = new System.Drawing.Point(393, 172);
            this.comboBoxSpeed.Name = "comboBoxSpeed";
            this.comboBoxSpeed.Size = new System.Drawing.Size(173, 25);
            this.comboBoxSpeed.TabIndex = 15;
            // 
            // buttonLevelLeft
            // 
            this.buttonLevelLeft.BackColor = System.Drawing.Color.White;
            this.buttonLevelLeft.BackgroundImage = global::Tetris.Properties.Resources.toLeft1;
            this.buttonLevelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLevelLeft.Location = new System.Drawing.Point(201, 79);
            this.buttonLevelLeft.Name = "buttonLevelLeft";
            this.buttonLevelLeft.Size = new System.Drawing.Size(30, 37);
            this.buttonLevelLeft.TabIndex = 14;
            this.buttonLevelLeft.UseVisualStyleBackColor = false;
            this.buttonLevelLeft.Click += new System.EventHandler(this.buttonLevelLeft_Click);
            // 
            // pictureBoxLevel
            // 
            this.pictureBoxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLevel.Location = new System.Drawing.Point(278, 31);
            this.pictureBoxLevel.Name = "pictureBoxLevel";
            this.pictureBoxLevel.Size = new System.Drawing.Size(110, 135);
            this.pictureBoxLevel.TabIndex = 11;
            this.pictureBoxLevel.TabStop = false;
            this.pictureBoxLevel.Click += new System.EventHandler(this.pictureBoxLevel_Click);
            this.pictureBoxLevel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLevel_Paint);
            // 
            // buttonLevelRight
            // 
            this.buttonLevelRight.BackColor = System.Drawing.Color.White;
            this.buttonLevelRight.BackgroundImage = global::Tetris.Properties.Resources.toRight1;
            this.buttonLevelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLevelRight.Location = new System.Drawing.Point(431, 79);
            this.buttonLevelRight.Name = "buttonLevelRight";
            this.buttonLevelRight.Size = new System.Drawing.Size(30, 37);
            this.buttonLevelRight.TabIndex = 9;
            this.buttonLevelRight.UseVisualStyleBackColor = false;
            this.buttonLevelRight.Click += new System.EventHandler(this.buttonLevelRight_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(80, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Скоростной режим падения фигур:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agave", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(80, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Выберите игровой стакан:";
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxLevel.Location = new System.Drawing.Point(281, 32);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(287, 25);
            this.comboBoxLevel.TabIndex = 7;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(662, 625);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxFigure;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCup;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Button buttonFigLeft;
        private System.Windows.Forms.Button buttonFigRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSpeed;
        private System.Windows.Forms.Button buttonLevelLeft;
        private System.Windows.Forms.PictureBox pictureBoxLevel;
        private System.Windows.Forms.Button buttonLevelRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSaveLevel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonSaveCup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Button buttonSaveFig;
        private System.Windows.Forms.Label labelW;
    }
}