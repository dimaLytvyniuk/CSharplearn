namespace Mileage_Calculator
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartMileage = new System.Windows.Forms.NumericUpDown();
            this.EndMileage = new System.Windows.Forms.NumericUpDown();
            this.MoneyToOwn = new System.Windows.Forms.Label();
            this.ToCalculate = new System.Windows.Forms.Button();
            this.ToDisplayMiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StartMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMileage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Mileage";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ending Mileage";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Owed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StartMileage
            // 
            this.StartMileage.Location = new System.Drawing.Point(121, 26);
            this.StartMileage.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.StartMileage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartMileage.Name = "StartMileage";
            this.StartMileage.Size = new System.Drawing.Size(112, 20);
            this.StartMileage.TabIndex = 3;
            this.StartMileage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EndMileage
            // 
            this.EndMileage.Location = new System.Drawing.Point(121, 68);
            this.EndMileage.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.EndMileage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EndMileage.Name = "EndMileage";
            this.EndMileage.Size = new System.Drawing.Size(108, 20);
            this.EndMileage.TabIndex = 4;
            this.EndMileage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MoneyToOwn
            // 
            this.MoneyToOwn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyToOwn.Location = new System.Drawing.Point(118, 118);
            this.MoneyToOwn.Name = "MoneyToOwn";
            this.MoneyToOwn.Size = new System.Drawing.Size(111, 26);
            this.MoneyToOwn.TabIndex = 5;
            // 
            // ToCalculate
            // 
            this.ToCalculate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ToCalculate.Location = new System.Drawing.Point(12, 183);
            this.ToCalculate.Name = "ToCalculate";
            this.ToCalculate.Size = new System.Drawing.Size(114, 23);
            this.ToCalculate.TabIndex = 6;
            this.ToCalculate.Text = "Calculate";
            this.ToCalculate.UseVisualStyleBackColor = true;
            this.ToCalculate.Click += new System.EventHandler(this.ToCalculate_Click);
            // 
            // ToDisplayMiles
            // 
            this.ToDisplayMiles.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ToDisplayMiles.Location = new System.Drawing.Point(158, 183);
            this.ToDisplayMiles.Name = "ToDisplayMiles";
            this.ToDisplayMiles.Size = new System.Drawing.Size(114, 23);
            this.ToDisplayMiles.TabIndex = 7;
            this.ToDisplayMiles.Text = "Display Miles";
            this.ToDisplayMiles.UseVisualStyleBackColor = true;
            this.ToDisplayMiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ToDisplayMiles);
            this.Controls.Add(this.ToCalculate);
            this.Controls.Add(this.MoneyToOwn);
            this.Controls.Add(this.EndMileage);
            this.Controls.Add(this.StartMileage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mileage Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.StartMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMileage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown StartMileage;
        private System.Windows.Forms.NumericUpDown EndMileage;
        private System.Windows.Forms.Label MoneyToOwn;
        private System.Windows.Forms.Button ToCalculate;
        private System.Windows.Forms.Button ToDisplayMiles;
    }
}

