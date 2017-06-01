namespace Breakfast_for
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.addLumber = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nextLumberjack = new System.Windows.Forms.Button();
            this.nextInLine = new System.Windows.Forms.Label();
            this.addFlapjacks = new System.Windows.Forms.Button();
            this.radioBanana = new System.Windows.Forms.RadioButton();
            this.radioBrowned = new System.Windows.Forms.RadioButton();
            this.radioSoggy = new System.Windows.Forms.RadioButton();
            this.radioCrispy = new System.Windows.Forms.RadioButton();
            this.howMany = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lumberjack name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(129, 21);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(106, 20);
            this.name.TabIndex = 1;
            // 
            // addLumber
            // 
            this.addLumber.Location = new System.Drawing.Point(12, 66);
            this.addLumber.Name = "addLumber";
            this.addLumber.Size = new System.Drawing.Size(249, 26);
            this.addLumber.TabIndex = 2;
            this.addLumber.Text = "Add Lumberjack";
            this.addLumber.UseVisualStyleBackColor = true;
            this.addLumber.Click += new System.EventHandler(this.addLumber_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Breakfast line";
            // 
            // line
            // 
            this.line.FormattingEnabled = true;
            this.line.Location = new System.Drawing.Point(10, 143);
            this.line.MultiColumn = true;
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(119, 238);
            this.line.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nextLumberjack);
            this.groupBox1.Controls.Add(this.nextInLine);
            this.groupBox1.Controls.Add(this.addFlapjacks);
            this.groupBox1.Controls.Add(this.radioBanana);
            this.groupBox1.Controls.Add(this.radioBrowned);
            this.groupBox1.Controls.Add(this.radioSoggy);
            this.groupBox1.Controls.Add(this.radioCrispy);
            this.groupBox1.Controls.Add(this.howMany);
            this.groupBox1.Location = new System.Drawing.Point(146, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 310);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feed a Lumberjack";
            // 
            // nextLumberjack
            // 
            this.nextLumberjack.Location = new System.Drawing.Point(14, 271);
            this.nextLumberjack.Name = "nextLumberjack";
            this.nextLumberjack.Size = new System.Drawing.Size(106, 24);
            this.nextLumberjack.TabIndex = 7;
            this.nextLumberjack.Text = "Next Lumberjack";
            this.nextLumberjack.UseVisualStyleBackColor = true;
            this.nextLumberjack.Click += new System.EventHandler(this.nextLumberjack_Click);
            // 
            // nextInLine
            // 
            this.nextInLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nextInLine.Location = new System.Drawing.Point(14, 206);
            this.nextInLine.Name = "nextInLine";
            this.nextInLine.Size = new System.Drawing.Size(100, 36);
            this.nextInLine.TabIndex = 6;
            this.nextInLine.Text = "label3";
            // 
            // addFlapjacks
            // 
            this.addFlapjacks.Location = new System.Drawing.Point(12, 152);
            this.addFlapjacks.Name = "addFlapjacks";
            this.addFlapjacks.Size = new System.Drawing.Size(108, 23);
            this.addFlapjacks.TabIndex = 5;
            this.addFlapjacks.Text = "Add Flapjacks";
            this.addFlapjacks.UseVisualStyleBackColor = true;
            this.addFlapjacks.Click += new System.EventHandler(this.addFlapjacks_Click);
            // 
            // radioBanana
            // 
            this.radioBanana.AutoSize = true;
            this.radioBanana.Location = new System.Drawing.Point(7, 129);
            this.radioBanana.Name = "radioBanana";
            this.radioBanana.Size = new System.Drawing.Size(62, 17);
            this.radioBanana.TabIndex = 4;
            this.radioBanana.TabStop = true;
            this.radioBanana.Text = "Banana";
            this.radioBanana.UseVisualStyleBackColor = true;
            // 
            // radioBrowned
            // 
            this.radioBrowned.AutoSize = true;
            this.radioBrowned.Location = new System.Drawing.Point(7, 105);
            this.radioBrowned.Name = "radioBrowned";
            this.radioBrowned.Size = new System.Drawing.Size(67, 17);
            this.radioBrowned.TabIndex = 3;
            this.radioBrowned.TabStop = true;
            this.radioBrowned.Text = "Browned";
            this.radioBrowned.UseVisualStyleBackColor = true;
            // 
            // radioSoggy
            // 
            this.radioSoggy.AutoSize = true;
            this.radioSoggy.Location = new System.Drawing.Point(7, 82);
            this.radioSoggy.Name = "radioSoggy";
            this.radioSoggy.Size = new System.Drawing.Size(55, 17);
            this.radioSoggy.TabIndex = 2;
            this.radioSoggy.TabStop = true;
            this.radioSoggy.Text = "Soggy";
            this.radioSoggy.UseVisualStyleBackColor = true;
            // 
            // radioCrispy
            // 
            this.radioCrispy.AutoSize = true;
            this.radioCrispy.Location = new System.Drawing.Point(7, 58);
            this.radioCrispy.Name = "radioCrispy";
            this.radioCrispy.Size = new System.Drawing.Size(53, 17);
            this.radioCrispy.TabIndex = 1;
            this.radioCrispy.TabStop = true;
            this.radioCrispy.Text = "Crispy";
            this.radioCrispy.UseVisualStyleBackColor = true;
            // 
            // howMany
            // 
            this.howMany.Location = new System.Drawing.Point(6, 31);
            this.howMany.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howMany.Name = "howMany";
            this.howMany.Size = new System.Drawing.Size(67, 20);
            this.howMany.TabIndex = 0;
            this.howMany.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 434);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.line);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLumber);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button addLumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox line;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button nextLumberjack;
        private System.Windows.Forms.Label nextInLine;
        private System.Windows.Forms.Button addFlapjacks;
        private System.Windows.Forms.RadioButton radioBanana;
        private System.Windows.Forms.RadioButton radioBrowned;
        private System.Windows.Forms.RadioButton radioSoggy;
        private System.Windows.Forms.RadioButton radioCrispy;
        private System.Windows.Forms.NumericUpDown howMany;
    }
}

