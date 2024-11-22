namespace Calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Input = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_mclear = new System.Windows.Forms.Button();
            this.button_msave = new System.Windows.Forms.Button();
            this.button_msub = new System.Windows.Forms.Button();
            this.button_madd = new System.Windows.Forms.Button();
            this.button_sqrt = new System.Windows.Forms.Button();
            this.button_raise = new System.Windows.Forms.Button();
            this.button_mul = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_sub = new System.Windows.Forms.Button();
            this.button_mod = new System.Windows.Forms.Button();
            this.button_6 = new System.Windows.Forms.Button();
            this.button_5 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_div = new System.Windows.Forms.Button();
            this.button_9 = new System.Windows.Forms.Button();
            this.button_8 = new System.Windows.Forms.Button();
            this.button_7 = new System.Windows.Forms.Button();
            this.button_cos = new System.Windows.Forms.Button();
            this.button_sin = new System.Windows.Forms.Button();
            this.button_dot = new System.Windows.Forms.Button();
            this.button_00 = new System.Windows.Forms.Button();
            this.button_0 = new System.Windows.Forms.Button();
            this.button_solve = new System.Windows.Forms.Button();
            this.inversButt = new System.Windows.Forms.Button();
            this.button_c = new System.Windows.Forms.Button();
            this.RoundingMode = new System.Windows.Forms.TrackBar();
            this.label = new System.Windows.Forms.Label();
            this.memoNum = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundingMode)).BeginInit();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Input.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input.ForeColor = System.Drawing.Color.White;
            this.Input.Location = new System.Drawing.Point(9, 7);
            this.Input.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Input.Name = "Input";
            this.Input.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Input.Size = new System.Drawing.Size(508, 60);
            this.Input.TabIndex = 0;
            this.Input.Text = "0";
            this.Input.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Input.Click += new System.EventHandler(this.Input_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.button_mclear);
            this.flowLayoutPanel1.Controls.Add(this.button_msave);
            this.flowLayoutPanel1.Controls.Add(this.button_msub);
            this.flowLayoutPanel1.Controls.Add(this.button_madd);
            this.flowLayoutPanel1.Controls.Add(this.button_sqrt);
            this.flowLayoutPanel1.Controls.Add(this.button_raise);
            this.flowLayoutPanel1.Controls.Add(this.button_mul);
            this.flowLayoutPanel1.Controls.Add(this.button_3);
            this.flowLayoutPanel1.Controls.Add(this.button_2);
            this.flowLayoutPanel1.Controls.Add(this.button_1);
            this.flowLayoutPanel1.Controls.Add(this.button_sub);
            this.flowLayoutPanel1.Controls.Add(this.button_mod);
            this.flowLayoutPanel1.Controls.Add(this.button_6);
            this.flowLayoutPanel1.Controls.Add(this.button_5);
            this.flowLayoutPanel1.Controls.Add(this.button_4);
            this.flowLayoutPanel1.Controls.Add(this.button_add);
            this.flowLayoutPanel1.Controls.Add(this.button_div);
            this.flowLayoutPanel1.Controls.Add(this.button_9);
            this.flowLayoutPanel1.Controls.Add(this.button_8);
            this.flowLayoutPanel1.Controls.Add(this.button_7);
            this.flowLayoutPanel1.Controls.Add(this.button_cos);
            this.flowLayoutPanel1.Controls.Add(this.button_sin);
            this.flowLayoutPanel1.Controls.Add(this.button_dot);
            this.flowLayoutPanel1.Controls.Add(this.button_00);
            this.flowLayoutPanel1.Controls.Add(this.button_0);
            this.flowLayoutPanel1.Controls.Add(this.button_solve);
            this.flowLayoutPanel1.Controls.Add(this.inversButt);
            this.flowLayoutPanel1.Controls.Add(this.button_c);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 72);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 280);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button_mclear
            // 
            this.button_mclear.BackColor = System.Drawing.Color.Gray;
            this.button_mclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_mclear.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mclear.ForeColor = System.Drawing.Color.White;
            this.button_mclear.Location = new System.Drawing.Point(328, 2);
            this.button_mclear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_mclear.Name = "button_mclear";
            this.button_mclear.Size = new System.Drawing.Size(76, 41);
            this.button_mclear.TabIndex = 0;
            this.button_mclear.Text = "MC";
            this.button_mclear.UseVisualStyleBackColor = false;
            this.button_mclear.Click += new System.EventHandler(this.button_mclear_Click);
            // 
            // button_msave
            // 
            this.button_msave.BackColor = System.Drawing.Color.Gray;
            this.button_msave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_msave.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_msave.ForeColor = System.Drawing.Color.White;
            this.button_msave.Location = new System.Drawing.Point(248, 2);
            this.button_msave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_msave.Name = "button_msave";
            this.button_msave.Size = new System.Drawing.Size(76, 41);
            this.button_msave.TabIndex = 1;
            this.button_msave.Text = "MS";
            this.button_msave.UseVisualStyleBackColor = false;
            this.button_msave.Click += new System.EventHandler(this.button_msave_Click);
            // 
            // button_msub
            // 
            this.button_msub.BackColor = System.Drawing.Color.Gray;
            this.button_msub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_msub.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_msub.ForeColor = System.Drawing.Color.White;
            this.button_msub.Location = new System.Drawing.Point(168, 2);
            this.button_msub.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_msub.Name = "button_msub";
            this.button_msub.Size = new System.Drawing.Size(76, 41);
            this.button_msub.TabIndex = 2;
            this.button_msub.Text = "M-";
            this.button_msub.UseVisualStyleBackColor = false;
            this.button_msub.Click += new System.EventHandler(this.button_msub_Click);
            // 
            // button_madd
            // 
            this.button_madd.BackColor = System.Drawing.Color.Gray;
            this.button_madd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_madd.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_madd.ForeColor = System.Drawing.Color.White;
            this.button_madd.Location = new System.Drawing.Point(88, 2);
            this.button_madd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_madd.Name = "button_madd";
            this.button_madd.Size = new System.Drawing.Size(76, 41);
            this.button_madd.TabIndex = 3;
            this.button_madd.Text = "M+";
            this.button_madd.UseVisualStyleBackColor = false;
            this.button_madd.Click += new System.EventHandler(this.button_madd_Click);
            // 
            // button_sqrt
            // 
            this.button_sqrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_sqrt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_sqrt.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sqrt.ForeColor = System.Drawing.Color.White;
            this.button_sqrt.Location = new System.Drawing.Point(8, 2);
            this.button_sqrt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sqrt.Name = "button_sqrt";
            this.button_sqrt.Size = new System.Drawing.Size(76, 41);
            this.button_sqrt.TabIndex = 4;
            this.button_sqrt.Text = "√";
            this.button_sqrt.UseVisualStyleBackColor = false;
            this.button_sqrt.Click += new System.EventHandler(this.button_sqrt_Click);
            // 
            // button_raise
            // 
            this.button_raise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_raise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_raise.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_raise.ForeColor = System.Drawing.Color.White;
            this.button_raise.Location = new System.Drawing.Point(328, 47);
            this.button_raise.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_raise.Name = "button_raise";
            this.button_raise.Size = new System.Drawing.Size(76, 41);
            this.button_raise.TabIndex = 18;
            this.button_raise.Text = "^";
            this.button_raise.UseVisualStyleBackColor = false;
            this.button_raise.Click += new System.EventHandler(this.button_raise_Click);
            // 
            // button_mul
            // 
            this.button_mul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_mul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_mul.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mul.ForeColor = System.Drawing.Color.White;
            this.button_mul.Location = new System.Drawing.Point(248, 47);
            this.button_mul.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_mul.Name = "button_mul";
            this.button_mul.Size = new System.Drawing.Size(76, 41);
            this.button_mul.TabIndex = 13;
            this.button_mul.Text = "×";
            this.button_mul.UseVisualStyleBackColor = false;
            this.button_mul.Click += new System.EventHandler(this.button_mul_Click);
            // 
            // button_3
            // 
            this.button_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_3.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_3.ForeColor = System.Drawing.Color.White;
            this.button_3.Location = new System.Drawing.Point(168, 47);
            this.button_3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(76, 41);
            this.button_3.TabIndex = 17;
            this.button_3.Text = "3";
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_2
            // 
            this.button_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_2.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_2.ForeColor = System.Drawing.Color.White;
            this.button_2.Location = new System.Drawing.Point(88, 47);
            this.button_2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(76, 41);
            this.button_2.TabIndex = 16;
            this.button_2.Text = "2";
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_1
            // 
            this.button_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_1.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_1.ForeColor = System.Drawing.Color.White;
            this.button_1.Location = new System.Drawing.Point(8, 47);
            this.button_1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(76, 41);
            this.button_1.TabIndex = 15;
            this.button_1.Text = "1";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_sub
            // 
            this.button_sub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_sub.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sub.ForeColor = System.Drawing.Color.White;
            this.button_sub.Location = new System.Drawing.Point(328, 92);
            this.button_sub.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sub.Name = "button_sub";
            this.button_sub.Size = new System.Drawing.Size(76, 41);
            this.button_sub.TabIndex = 9;
            this.button_sub.Text = "-";
            this.button_sub.UseVisualStyleBackColor = false;
            this.button_sub.Click += new System.EventHandler(this.button_sub_Click);
            // 
            // button_mod
            // 
            this.button_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_mod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_mod.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mod.ForeColor = System.Drawing.Color.White;
            this.button_mod.Location = new System.Drawing.Point(248, 92);
            this.button_mod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_mod.Name = "button_mod";
            this.button_mod.Size = new System.Drawing.Size(76, 41);
            this.button_mod.TabIndex = 19;
            this.button_mod.Text = "%";
            this.button_mod.UseVisualStyleBackColor = false;
            this.button_mod.Click += new System.EventHandler(this.button_mod_Click);
            // 
            // button_6
            // 
            this.button_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_6.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_6.ForeColor = System.Drawing.Color.White;
            this.button_6.Location = new System.Drawing.Point(168, 92);
            this.button_6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(76, 41);
            this.button_6.TabIndex = 12;
            this.button_6.Text = "6";
            this.button_6.UseVisualStyleBackColor = true;
            this.button_6.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_5
            // 
            this.button_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_5.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_5.ForeColor = System.Drawing.Color.White;
            this.button_5.Location = new System.Drawing.Point(88, 92);
            this.button_5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(76, 41);
            this.button_5.TabIndex = 11;
            this.button_5.Text = "5";
            this.button_5.UseVisualStyleBackColor = true;
            this.button_5.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_4
            // 
            this.button_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_4.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_4.ForeColor = System.Drawing.Color.White;
            this.button_4.Location = new System.Drawing.Point(8, 92);
            this.button_4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(76, 41);
            this.button_4.TabIndex = 10;
            this.button_4.Text = "4";
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_add.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(328, 137);
            this.button_add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(76, 41);
            this.button_add.TabIndex = 8;
            this.button_add.Text = "+";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_div
            // 
            this.button_div.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_div.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_div.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_div.ForeColor = System.Drawing.Color.White;
            this.button_div.Location = new System.Drawing.Point(248, 137);
            this.button_div.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_div.Name = "button_div";
            this.button_div.Size = new System.Drawing.Size(76, 41);
            this.button_div.TabIndex = 14;
            this.button_div.Text = "÷";
            this.button_div.UseVisualStyleBackColor = false;
            this.button_div.Click += new System.EventHandler(this.button_div_Click);
            // 
            // button_9
            // 
            this.button_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_9.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_9.ForeColor = System.Drawing.Color.White;
            this.button_9.Location = new System.Drawing.Point(168, 137);
            this.button_9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(76, 41);
            this.button_9.TabIndex = 7;
            this.button_9.Text = "9";
            this.button_9.UseVisualStyleBackColor = true;
            this.button_9.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_8
            // 
            this.button_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_8.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_8.ForeColor = System.Drawing.Color.White;
            this.button_8.Location = new System.Drawing.Point(88, 137);
            this.button_8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(76, 41);
            this.button_8.TabIndex = 6;
            this.button_8.Text = "8";
            this.button_8.UseVisualStyleBackColor = true;
            this.button_8.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_7
            // 
            this.button_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_7.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_7.ForeColor = System.Drawing.Color.White;
            this.button_7.Location = new System.Drawing.Point(8, 137);
            this.button_7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(76, 41);
            this.button_7.TabIndex = 5;
            this.button_7.Text = "7";
            this.button_7.UseVisualStyleBackColor = true;
            this.button_7.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_cos
            // 
            this.button_cos.BackColor = System.Drawing.Color.Gray;
            this.button_cos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cos.Font = new System.Drawing.Font("OCR A Extended", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cos.ForeColor = System.Drawing.Color.White;
            this.button_cos.Location = new System.Drawing.Point(328, 182);
            this.button_cos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_cos.Name = "button_cos";
            this.button_cos.Size = new System.Drawing.Size(76, 41);
            this.button_cos.TabIndex = 26;
            this.button_cos.Text = "cos";
            this.button_cos.UseVisualStyleBackColor = false;
            this.button_cos.Click += new System.EventHandler(this.button_cos_Click);
            // 
            // button_sin
            // 
            this.button_sin.BackColor = System.Drawing.Color.Gray;
            this.button_sin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_sin.Font = new System.Drawing.Font("OCR A Extended", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sin.ForeColor = System.Drawing.Color.White;
            this.button_sin.Location = new System.Drawing.Point(248, 182);
            this.button_sin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sin.Name = "button_sin";
            this.button_sin.Size = new System.Drawing.Size(76, 41);
            this.button_sin.TabIndex = 25;
            this.button_sin.Text = "sin";
            this.button_sin.UseVisualStyleBackColor = false;
            this.button_sin.Click += new System.EventHandler(this.button_sin_Click);
            // 
            // button_dot
            // 
            this.button_dot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_dot.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dot.ForeColor = System.Drawing.Color.White;
            this.button_dot.Location = new System.Drawing.Point(168, 182);
            this.button_dot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_dot.Name = "button_dot";
            this.button_dot.Size = new System.Drawing.Size(76, 41);
            this.button_dot.TabIndex = 23;
            this.button_dot.Text = ".";
            this.button_dot.UseVisualStyleBackColor = true;
            this.button_dot.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_00
            // 
            this.button_00.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_00.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_00.ForeColor = System.Drawing.Color.White;
            this.button_00.Location = new System.Drawing.Point(88, 182);
            this.button_00.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_00.Name = "button_00";
            this.button_00.Size = new System.Drawing.Size(76, 41);
            this.button_00.TabIndex = 22;
            this.button_00.Text = "00";
            this.button_00.UseVisualStyleBackColor = true;
            this.button_00.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_0
            // 
            this.button_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_0.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_0.ForeColor = System.Drawing.Color.White;
            this.button_0.Location = new System.Drawing.Point(8, 182);
            this.button_0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(76, 41);
            this.button_0.TabIndex = 21;
            this.button_0.Text = "0";
            this.button_0.UseVisualStyleBackColor = true;
            this.button_0.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button_solve
            // 
            this.button_solve.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button_solve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_solve.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_solve.ForeColor = System.Drawing.Color.White;
            this.button_solve.Location = new System.Drawing.Point(248, 227);
            this.button_solve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_solve.Name = "button_solve";
            this.button_solve.Size = new System.Drawing.Size(156, 41);
            this.button_solve.TabIndex = 24;
            this.button_solve.TabStop = false;
            this.button_solve.Text = "=";
            this.button_solve.UseVisualStyleBackColor = false;
            this.button_solve.Click += new System.EventHandler(this.button_solve_Click);
            // 
            // inversButt
            // 
            this.inversButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.inversButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inversButt.Font = new System.Drawing.Font("OCR A Extended", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inversButt.ForeColor = System.Drawing.Color.White;
            this.inversButt.Location = new System.Drawing.Point(168, 227);
            this.inversButt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inversButt.Name = "inversButt";
            this.inversButt.Size = new System.Drawing.Size(76, 41);
            this.inversButt.TabIndex = 27;
            this.inversButt.Text = "+/-";
            this.inversButt.UseVisualStyleBackColor = false;
            this.inversButt.Click += new System.EventHandler(this.inversButt_Click);
            // 
            // button_c
            // 
            this.button_c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_c.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_c.Font = new System.Drawing.Font("OCR A Extended", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_c.ForeColor = System.Drawing.Color.White;
            this.button_c.Location = new System.Drawing.Point(8, 227);
            this.button_c.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_c.Name = "button_c";
            this.button_c.Size = new System.Drawing.Size(156, 41);
            this.button_c.TabIndex = 20;
            this.button_c.Text = "C";
            this.button_c.UseVisualStyleBackColor = false;
            this.button_c.Click += new System.EventHandler(this.button_c_onclick);
            // 
            // RoundingMode
            // 
            this.RoundingMode.AccessibleDescription = "";
            this.RoundingMode.AutoSize = false;
            this.RoundingMode.LargeChange = 1;
            this.RoundingMode.Location = new System.Drawing.Point(418, 72);
            this.RoundingMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RoundingMode.Maximum = 2;
            this.RoundingMode.Name = "RoundingMode";
            this.RoundingMode.Size = new System.Drawing.Size(98, 34);
            this.RoundingMode.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label.Location = new System.Drawing.Point(419, 106);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(98, 29);
            this.label.TabIndex = 3;
            this.label.Text = "Memo:";
            // 
            // memoNum
            // 
            this.memoNum.AutoSize = true;
            this.memoNum.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoNum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.memoNum.Location = new System.Drawing.Point(420, 135);
            this.memoNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.memoNum.Name = "memoNum";
            this.memoNum.Size = new System.Drawing.Size(0, 24);
            this.memoNum.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(526, 378);
            this.Controls.Add(this.memoNum);
            this.Controls.Add(this.label);
            this.Controls.Add(this.RoundingMode);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Input);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoundingMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Input;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_msave;
        private System.Windows.Forms.Button button_msub;
        private System.Windows.Forms.Button button_madd;
        private System.Windows.Forms.Button button_sqrt;
        private System.Windows.Forms.Button button_7;
        private System.Windows.Forms.Button button_8;
        private System.Windows.Forms.Button button_9;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_sub;
        private System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Button button_5;
        private System.Windows.Forms.Button button_6;
        private System.Windows.Forms.Button button_mul;
        private System.Windows.Forms.Button button_div;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.Button button_2;
        private System.Windows.Forms.Button button_3;
        private System.Windows.Forms.Button button_mclear;
        private System.Windows.Forms.Button button_raise;
        private System.Windows.Forms.Button button_mod;
        private System.Windows.Forms.Button button_c;
        private System.Windows.Forms.Button button_0;
        private System.Windows.Forms.Button button_00;
        private System.Windows.Forms.Button button_dot;
        private System.Windows.Forms.Button button_solve;
        private System.Windows.Forms.TrackBar RoundingMode;
        private System.Windows.Forms.Button button_sin;
        private System.Windows.Forms.Button button_cos;
        private System.Windows.Forms.Button inversButt;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label memoNum;
    }
}

