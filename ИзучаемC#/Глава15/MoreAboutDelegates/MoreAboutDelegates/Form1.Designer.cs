namespace MoreAboutDelegates
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
            this.button_getIngredient = new System.Windows.Forms.Button();
            this.button_getSuzzane = new System.Windows.Forms.Button();
            this.button_getAmy = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_getIngredient
            // 
            this.button_getIngredient.Location = new System.Drawing.Point(31, 38);
            this.button_getIngredient.Name = "button_getIngredient";
            this.button_getIngredient.Size = new System.Drawing.Size(283, 23);
            this.button_getIngredient.TabIndex = 0;
            this.button_getIngredient.Text = "Get the Ingredient";
            this.button_getIngredient.UseVisualStyleBackColor = true;
            this.button_getIngredient.Click += new System.EventHandler(this.button_getIngredient_Click);
            // 
            // button_getSuzzane
            // 
            this.button_getSuzzane.Location = new System.Drawing.Point(31, 101);
            this.button_getSuzzane.Name = "button_getSuzzane";
            this.button_getSuzzane.Size = new System.Drawing.Size(420, 23);
            this.button_getSuzzane.TabIndex = 1;
            this.button_getSuzzane.Text = "Get Suzanne\'s delegate";
            this.button_getSuzzane.UseVisualStyleBackColor = true;
            this.button_getSuzzane.Click += new System.EventHandler(this.button_getSuzzane_Click);
            // 
            // button_getAmy
            // 
            this.button_getAmy.Location = new System.Drawing.Point(31, 167);
            this.button_getAmy.Name = "button_getAmy";
            this.button_getAmy.Size = new System.Drawing.Size(420, 23);
            this.button_getAmy.TabIndex = 2;
            this.button_getAmy.Text = "Get Amy\'s delegate";
            this.button_getAmy.UseVisualStyleBackColor = true;
            this.button_getAmy.Click += new System.EventHandler(this.button_getAmy_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(331, 38);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 261);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_getAmy);
            this.Controls.Add(this.button_getSuzzane);
            this.Controls.Add(this.button_getIngredient);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_getIngredient;
        private System.Windows.Forms.Button button_getSuzzane;
        private System.Windows.Forms.Button button_getAmy;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

