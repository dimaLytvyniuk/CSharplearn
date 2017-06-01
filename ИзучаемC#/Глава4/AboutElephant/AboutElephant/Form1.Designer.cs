namespace AboutElephant
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
            this.AboutLioyd = new System.Windows.Forms.Button();
            this.AboutLucinda = new System.Windows.Forms.Button();
            this.ToSwap = new System.Windows.Forms.Button();
            this.haos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AboutLioyd
            // 
            this.AboutLioyd.Location = new System.Drawing.Point(74, 35);
            this.AboutLioyd.Name = "AboutLioyd";
            this.AboutLioyd.Size = new System.Drawing.Size(141, 31);
            this.AboutLioyd.TabIndex = 0;
            this.AboutLioyd.Text = "Lioyd";
            this.AboutLioyd.UseVisualStyleBackColor = true;
            this.AboutLioyd.Click += new System.EventHandler(this.AboutLioyd_Click);
            // 
            // AboutLucinda
            // 
            this.AboutLucinda.Location = new System.Drawing.Point(74, 89);
            this.AboutLucinda.Name = "AboutLucinda";
            this.AboutLucinda.Size = new System.Drawing.Size(141, 31);
            this.AboutLucinda.TabIndex = 1;
            this.AboutLucinda.Text = "Lucinda";
            this.AboutLucinda.UseVisualStyleBackColor = true;
            this.AboutLucinda.Click += new System.EventHandler(this.AboutLucinda_Click);
            // 
            // ToSwap
            // 
            this.ToSwap.Location = new System.Drawing.Point(74, 140);
            this.ToSwap.Name = "ToSwap";
            this.ToSwap.Size = new System.Drawing.Size(141, 31);
            this.ToSwap.TabIndex = 2;
            this.ToSwap.Text = "Swap!";
            this.ToSwap.UseVisualStyleBackColor = true;
            this.ToSwap.Click += new System.EventHandler(this.ToSwap_Click);
            // 
            // haos
            // 
            this.haos.Location = new System.Drawing.Point(74, 188);
            this.haos.Name = "haos";
            this.haos.Size = new System.Drawing.Size(141, 31);
            this.haos.TabIndex = 3;
            this.haos.Text = "HAOS";
            this.haos.UseVisualStyleBackColor = true;
            this.haos.Click += new System.EventHandler(this.haos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.haos);
            this.Controls.Add(this.ToSwap);
            this.Controls.Add(this.AboutLucinda);
            this.Controls.Add(this.AboutLioyd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AboutLioyd;
        private System.Windows.Forms.Button AboutLucinda;
        private System.Windows.Forms.Button ToSwap;
        private System.Windows.Forms.Button haos;
    }
}

