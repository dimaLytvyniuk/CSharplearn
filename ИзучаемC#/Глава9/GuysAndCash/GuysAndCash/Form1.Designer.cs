namespace GuysAndCash
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.JoeCash = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BobCash = new System.Windows.Forms.Label();
            this.buttonGive = new System.Windows.Forms.Button();
            this.buttonReceive = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BankCash = new System.Windows.Forms.Label();
            this.GiveJoe = new System.Windows.Forms.Button();
            this.GiveBob = new System.Windows.Forms.Button();
            this.saveJoe = new System.Windows.Forms.Button();
            this.loadJoe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Joe has";
            // 
            // JoeCash
            // 
            this.JoeCash.Location = new System.Drawing.Point(131, 31);
            this.JoeCash.Name = "JoeCash";
            this.JoeCash.Size = new System.Drawing.Size(65, 22);
            this.JoeCash.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bob has";
            // 
            // BobCash
            // 
            this.BobCash.Location = new System.Drawing.Point(131, 64);
            this.BobCash.Name = "BobCash";
            this.BobCash.Size = new System.Drawing.Size(65, 22);
            this.BobCash.TabIndex = 3;
            // 
            // buttonGive
            // 
            this.buttonGive.Location = new System.Drawing.Point(15, 175);
            this.buttonGive.Name = "buttonGive";
            this.buttonGive.Size = new System.Drawing.Size(119, 48);
            this.buttonGive.TabIndex = 4;
            this.buttonGive.Text = "Give $10 to Joe";
            this.buttonGive.UseVisualStyleBackColor = true;
            this.buttonGive.Click += new System.EventHandler(this.buttonGive_Click);
            // 
            // buttonReceive
            // 
            this.buttonReceive.Location = new System.Drawing.Point(153, 175);
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(119, 48);
            this.buttonReceive.TabIndex = 5;
            this.buttonReceive.Text = "Receive $5 from Bob";
            this.buttonReceive.UseVisualStyleBackColor = true;
            this.buttonReceive.Click += new System.EventHandler(this.buttonReceive_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "The bank has $100";
            // 
            // BankCash
            // 
            this.BankCash.Location = new System.Drawing.Point(131, 110);
            this.BankCash.Name = "BankCash";
            this.BankCash.Size = new System.Drawing.Size(65, 22);
            this.BankCash.TabIndex = 7;
            // 
            // GiveJoe
            // 
            this.GiveJoe.Location = new System.Drawing.Point(15, 273);
            this.GiveJoe.Name = "GiveJoe";
            this.GiveJoe.Size = new System.Drawing.Size(119, 48);
            this.GiveJoe.TabIndex = 8;
            this.GiveJoe.Text = "Joe gives $10 to Bob ";
            this.GiveJoe.UseVisualStyleBackColor = true;
            this.GiveJoe.Click += new System.EventHandler(this.GiveJoe_Click);
            // 
            // GiveBob
            // 
            this.GiveBob.Location = new System.Drawing.Point(153, 273);
            this.GiveBob.Name = "GiveBob";
            this.GiveBob.Size = new System.Drawing.Size(119, 48);
            this.GiveBob.TabIndex = 9;
            this.GiveBob.Text = "Bob gives $5 to Joe";
            this.GiveBob.UseVisualStyleBackColor = true;
            this.GiveBob.Click += new System.EventHandler(this.GiveBob_Click);
            // 
            // saveJoe
            // 
            this.saveJoe.Location = new System.Drawing.Point(15, 381);
            this.saveJoe.Name = "saveJoe";
            this.saveJoe.Size = new System.Drawing.Size(119, 23);
            this.saveJoe.TabIndex = 10;
            this.saveJoe.Text = "Save Joe";
            this.saveJoe.UseVisualStyleBackColor = true;
            this.saveJoe.Click += new System.EventHandler(this.saveJoe_Click);
            // 
            // loadJoe
            // 
            this.loadJoe.Location = new System.Drawing.Point(153, 381);
            this.loadJoe.Name = "loadJoe";
            this.loadJoe.Size = new System.Drawing.Size(119, 23);
            this.loadJoe.TabIndex = 11;
            this.loadJoe.Text = "Load Joe";
            this.loadJoe.UseVisualStyleBackColor = true;
            this.loadJoe.Click += new System.EventHandler(this.loadJoe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 420);
            this.Controls.Add(this.loadJoe);
            this.Controls.Add(this.saveJoe);
            this.Controls.Add(this.GiveBob);
            this.Controls.Add(this.GiveJoe);
            this.Controls.Add(this.BankCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonReceive);
            this.Controls.Add(this.buttonGive);
            this.Controls.Add(this.BobCash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.JoeCash);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label JoeCash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BobCash;
        private System.Windows.Forms.Button buttonGive;
        private System.Windows.Forms.Button buttonReceive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BankCash;
        private System.Windows.Forms.Button GiveJoe;
        private System.Windows.Forms.Button GiveBob;
        private System.Windows.Forms.Button saveJoe;
        private System.Windows.Forms.Button loadJoe;
    }
}

