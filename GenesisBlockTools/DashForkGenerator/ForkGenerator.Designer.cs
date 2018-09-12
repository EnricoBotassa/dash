namespace DashForkGenerator
{
    partial class ForkGenerator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForkGenerator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Btn_GenesisGen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UD_Second = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.ChBox_BlockMain = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChBox_BlockRegTest = new System.Windows.Forms.CheckBox();
            this.UD_Minute = new System.Windows.Forms.NumericUpDown();
            this.ChBox_BlockTest = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UD_Hour = new System.Windows.Forms.NumericUpDown();
            this.DT_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_SeedPhrase = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBox_CBold = new System.Windows.Forms.TextBox();
            this.TextBox_CPrefix = new System.Windows.Forms.TextBox();
            this.TextBox_CName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBox_CoinName = new System.Windows.Forms.TextBox();
            this.Timer_Log = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ChBox_TestNetSpork = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ChBox_MainSpork = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Btn_KeyPairGen = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ChBox_TestAlert = new System.Windows.Forms.CheckBox();
            this.ChBox_MainAlert = new System.Windows.Forms.CheckBox();
            this.ChBox_Main = new System.Windows.Forms.CheckBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.GUITimer = new System.Windows.Forms.Timer(this.components);
            this.OutputConsole = new ConsoleControl.ConsoleControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Hour)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Btn_GenesisGen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.UD_Second);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ChBox_BlockMain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ChBox_BlockRegTest);
            this.groupBox1.Controls.Add(this.UD_Minute);
            this.groupBox1.Controls.Add(this.ChBox_BlockTest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UD_Hour);
            this.groupBox1.Controls.Add(this.DT_StartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBox_SeedPhrase);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 276);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(669, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genesis block params";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 25);
            this.label12.TabIndex = 19;
            this.label12.Text = "REGTEST:";
            // 
            // Btn_GenesisGen
            // 
            this.Btn_GenesisGen.Location = new System.Drawing.Point(547, 117);
            this.Btn_GenesisGen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_GenesisGen.Name = "Btn_GenesisGen";
            this.Btn_GenesisGen.Size = new System.Drawing.Size(116, 58);
            this.Btn_GenesisGen.TabIndex = 10;
            this.Btn_GenesisGen.Text = "Generate";
            this.Btn_GenesisGen.UseVisualStyleBackColor = true;
            this.Btn_GenesisGen.Click += new System.EventHandler(this.Btn_GenesisGen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "s";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "TEST:";
            // 
            // UD_Second
            // 
            this.UD_Second.Location = new System.Drawing.Point(433, 145);
            this.UD_Second.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UD_Second.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.UD_Second.Name = "UD_Second";
            this.UD_Second.Size = new System.Drawing.Size(61, 30);
            this.UD_Second.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "MAIN:";
            // 
            // ChBox_BlockMain
            // 
            this.ChBox_BlockMain.AutoSize = true;
            this.ChBox_BlockMain.Enabled = false;
            this.ChBox_BlockMain.Location = new System.Drawing.Point(85, 196);
            this.ChBox_BlockMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_BlockMain.Name = "ChBox_BlockMain";
            this.ChBox_BlockMain.Size = new System.Drawing.Size(18, 17);
            this.ChBox_BlockMain.TabIndex = 14;
            this.ChBox_BlockMain.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "m";
            // 
            // ChBox_BlockRegTest
            // 
            this.ChBox_BlockRegTest.AutoSize = true;
            this.ChBox_BlockRegTest.Enabled = false;
            this.ChBox_BlockRegTest.Location = new System.Drawing.Point(381, 196);
            this.ChBox_BlockRegTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_BlockRegTest.Name = "ChBox_BlockRegTest";
            this.ChBox_BlockRegTest.Size = new System.Drawing.Size(18, 17);
            this.ChBox_BlockRegTest.TabIndex = 16;
            this.ChBox_BlockRegTest.UseVisualStyleBackColor = true;
            // 
            // UD_Minute
            // 
            this.UD_Minute.Location = new System.Drawing.Point(317, 145);
            this.UD_Minute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UD_Minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.UD_Minute.Name = "UD_Minute";
            this.UD_Minute.Size = new System.Drawing.Size(61, 30);
            this.UD_Minute.TabIndex = 6;
            // 
            // ChBox_BlockTest
            // 
            this.ChBox_BlockTest.AutoSize = true;
            this.ChBox_BlockTest.Enabled = false;
            this.ChBox_BlockTest.Location = new System.Drawing.Point(213, 196);
            this.ChBox_BlockTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_BlockTest.Name = "ChBox_BlockTest";
            this.ChBox_BlockTest.Size = new System.Drawing.Size(18, 17);
            this.ChBox_BlockTest.TabIndex = 15;
            this.ChBox_BlockTest.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "h";
            // 
            // UD_Hour
            // 
            this.UD_Hour.Location = new System.Drawing.Point(213, 145);
            this.UD_Hour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UD_Hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.UD_Hour.Name = "UD_Hour";
            this.UD_Hour.Size = new System.Drawing.Size(61, 30);
            this.UD_Hour.TabIndex = 4;
            this.UD_Hour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DT_StartDate
            // 
            this.DT_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_StartDate.Location = new System.Drawing.Point(9, 145);
            this.DT_StartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DT_StartDate.Name = "DT_StartDate";
            this.DT_StartDate.Size = new System.Drawing.Size(175, 30);
            this.DT_StartDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Genesis block start date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seed phrase for genesis block:";
            // 
            // TextBox_SeedPhrase
            // 
            this.TextBox_SeedPhrase.Location = new System.Drawing.Point(9, 75);
            this.TextBox_SeedPhrase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_SeedPhrase.Name = "TextBox_SeedPhrase";
            this.TextBox_SeedPhrase.Size = new System.Drawing.Size(655, 30);
            this.TextBox_SeedPhrase.TabIndex = 0;
            this.TextBox_SeedPhrase.Text = "My first crypto currency";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.TextBox_CBold);
            this.groupBox2.Controls.Add(this.TextBox_CPrefix);
            this.groupBox2.Controls.Add(this.TextBox_CName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TextBox_CoinName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(669, 132);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Common params";
            // 
            // TextBox_CBold
            // 
            this.TextBox_CBold.Enabled = false;
            this.TextBox_CBold.Location = new System.Drawing.Point(419, 91);
            this.TextBox_CBold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_CBold.Name = "TextBox_CBold";
            this.TextBox_CBold.Size = new System.Drawing.Size(225, 30);
            this.TextBox_CBold.TabIndex = 7;
            this.TextBox_CBold.Text = "NEWCOIN";
            // 
            // TextBox_CPrefix
            // 
            this.TextBox_CPrefix.Enabled = false;
            this.TextBox_CPrefix.Location = new System.Drawing.Point(419, 55);
            this.TextBox_CPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_CPrefix.Name = "TextBox_CPrefix";
            this.TextBox_CPrefix.Size = new System.Drawing.Size(225, 30);
            this.TextBox_CPrefix.TabIndex = 6;
            this.TextBox_CPrefix.Text = "newcoin";
            // 
            // TextBox_CName
            // 
            this.TextBox_CName.Enabled = false;
            this.TextBox_CName.Location = new System.Drawing.Point(419, 18);
            this.TextBox_CName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_CName.Name = "TextBox_CName";
            this.TextBox_CName.Size = new System.Drawing.Size(225, 30);
            this.TextBox_CName.TabIndex = 5;
            this.TextBox_CName.Text = "Newcoin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Bold name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Prefix name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Main name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "New altcoin name:";
            // 
            // TextBox_CoinName
            // 
            this.TextBox_CoinName.Location = new System.Drawing.Point(9, 75);
            this.TextBox_CoinName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_CoinName.Name = "TextBox_CoinName";
            this.TextBox_CoinName.Size = new System.Drawing.Size(225, 30);
            this.TextBox_CoinName.TabIndex = 0;
            this.TextBox_CoinName.Text = "newcoin";
            this.TextBox_CoinName.TextChanged += new System.EventHandler(this.TextBox_CoinName_TextChanged);
            // 
            // Timer_Log
            // 
            this.Timer_Log.Tick += new System.EventHandler(this.Timer_Log_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox4.Controls.Add(this.ChBox_TestNetSpork);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.ChBox_MainSpork);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.Btn_KeyPairGen);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.ChBox_TestAlert);
            this.groupBox4.Controls.Add(this.ChBox_MainAlert);
            this.groupBox4.Controls.Add(this.ChBox_Main);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 139);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(669, 132);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key pairs";
            // 
            // ChBox_TestNetSpork
            // 
            this.ChBox_TestNetSpork.AutoSize = true;
            this.ChBox_TestNetSpork.Enabled = false;
            this.ChBox_TestNetSpork.Location = new System.Drawing.Point(399, 89);
            this.ChBox_TestNetSpork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_TestNetSpork.Name = "ChBox_TestNetSpork";
            this.ChBox_TestNetSpork.Size = new System.Drawing.Size(18, 17);
            this.ChBox_TestNetSpork.TabIndex = 29;
            this.ChBox_TestNetSpork.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(208, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(181, 25);
            this.label17.TabIndex = 28;
            this.label17.Text = "TESTNETSPORK:";
            // 
            // ChBox_MainSpork
            // 
            this.ChBox_MainSpork.AutoSize = true;
            this.ChBox_MainSpork.Enabled = false;
            this.ChBox_MainSpork.Location = new System.Drawing.Point(165, 89);
            this.ChBox_MainSpork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_MainSpork.Name = "ChBox_MainSpork";
            this.ChBox_MainSpork.Size = new System.Drawing.Size(18, 17);
            this.ChBox_MainSpork.TabIndex = 27;
            this.ChBox_MainSpork.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 25);
            this.label16.TabIndex = 26;
            this.label16.Text = "MAINSPORK:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(401, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 25);
            this.label13.TabIndex = 25;
            this.label13.Text = "MAIN:";
            // 
            // Btn_KeyPairGen
            // 
            this.Btn_KeyPairGen.Location = new System.Drawing.Point(547, 68);
            this.Btn_KeyPairGen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_KeyPairGen.Name = "Btn_KeyPairGen";
            this.Btn_KeyPairGen.Size = new System.Drawing.Size(116, 58);
            this.Btn_KeyPairGen.TabIndex = 11;
            this.Btn_KeyPairGen.Text = "Generate";
            this.Btn_KeyPairGen.UseVisualStyleBackColor = true;
            this.Btn_KeyPairGen.Click += new System.EventHandler(this.Btn_KeyPairGen_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 25);
            this.label14.TabIndex = 24;
            this.label14.Text = "TESTALERT:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 25);
            this.label15.TabIndex = 23;
            this.label15.Text = "MAINALERT:";
            // 
            // ChBox_TestAlert
            // 
            this.ChBox_TestAlert.AutoSize = true;
            this.ChBox_TestAlert.Enabled = false;
            this.ChBox_TestAlert.Location = new System.Drawing.Point(353, 42);
            this.ChBox_TestAlert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_TestAlert.Name = "ChBox_TestAlert";
            this.ChBox_TestAlert.Size = new System.Drawing.Size(18, 17);
            this.ChBox_TestAlert.TabIndex = 21;
            this.ChBox_TestAlert.UseVisualStyleBackColor = true;
            // 
            // ChBox_MainAlert
            // 
            this.ChBox_MainAlert.AutoSize = true;
            this.ChBox_MainAlert.Enabled = false;
            this.ChBox_MainAlert.Location = new System.Drawing.Point(157, 42);
            this.ChBox_MainAlert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_MainAlert.Name = "ChBox_MainAlert";
            this.ChBox_MainAlert.Size = new System.Drawing.Size(18, 17);
            this.ChBox_MainAlert.TabIndex = 20;
            this.ChBox_MainAlert.UseVisualStyleBackColor = true;
            // 
            // ChBox_Main
            // 
            this.ChBox_Main.AutoSize = true;
            this.ChBox_Main.Enabled = false;
            this.ChBox_Main.Location = new System.Drawing.Point(477, 42);
            this.ChBox_Main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBox_Main.Name = "ChBox_Main";
            this.ChBox_Main.Size = new System.Drawing.Size(18, 17);
            this.ChBox_Main.TabIndex = 22;
            this.ChBox_Main.UseVisualStyleBackColor = true;
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // GUITimer
            // 
            this.GUITimer.Interval = 10;
            this.GUITimer.Tick += new System.EventHandler(this.GUITimar_Tick);
            // 
            // OutputConsole
            // 
            this.OutputConsole.IsInputEnabled = true;
            this.OutputConsole.Location = new System.Drawing.Point(3, 22);
            this.OutputConsole.Margin = new System.Windows.Forms.Padding(6);
            this.OutputConsole.Name = "OutputConsole";
            this.OutputConsole.SendKeyboardCommandsToProcess = false;
            this.OutputConsole.ShowDiagnostics = false;
            this.OutputConsole.Size = new System.Drawing.Size(985, 764);
            this.OutputConsole.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox3.Controls.Add(this.OutputConsole);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(678, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(997, 786);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // ForkGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1680, 789);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ForkGenerator";
            this.Text = "Dash fork generator";
            this.Activated += new System.EventHandler(this.ForkGenerator_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForkGenerator_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Hour)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DT_StartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_SeedPhrase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown UD_Second;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown UD_Minute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UD_Hour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBox_CoinName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_CBold;
        private System.Windows.Forms.TextBox TextBox_CPrefix;
        private System.Windows.Forms.TextBox TextBox_CName;
        private System.Windows.Forms.Timer Timer_Log;
        private System.Windows.Forms.CheckBox ChBox_BlockRegTest;
        private System.Windows.Forms.CheckBox ChBox_BlockTest;
        private System.Windows.Forms.CheckBox ChBox_BlockMain;
        private System.Windows.Forms.Button Btn_GenesisGen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Btn_KeyPairGen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ChBox_TestAlert;
        private System.Windows.Forms.CheckBox ChBox_MainAlert;
        private System.Windows.Forms.CheckBox ChBox_Main;
        private System.Windows.Forms.CheckBox ChBox_TestNetSpork;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox ChBox_MainSpork;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Timer GUITimer;
        private ConsoleControl.ConsoleControl OutputConsole;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

