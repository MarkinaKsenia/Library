namespace Library
{
    partial class Debt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.noDebt = new System.Windows.Forms.Label();
            this.haveDebt = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summ = new System.Windows.Forms.Label();
            this.sumOutput = new System.Windows.Forms.Label();
            this.rub = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 100);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(301, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Библиотека";
            // 
            // noDebt
            // 
            this.noDebt.AutoSize = true;
            this.noDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noDebt.Location = new System.Drawing.Point(285, 287);
            this.noDebt.Name = "noDebt";
            this.noDebt.Size = new System.Drawing.Size(346, 26);
            this.noDebt.TabIndex = 6;
            this.noDebt.Text = "У ВАС НЕТ ЗАДОЛЖЕННОСТИ!";
            this.noDebt.Click += new System.EventHandler(this.label2_Click);
            // 
            // haveDebt
            // 
            this.haveDebt.AutoSize = true;
            this.haveDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.haveDebt.ForeColor = System.Drawing.Color.Red;
            this.haveDebt.Location = new System.Drawing.Point(12, 103);
            this.haveDebt.Name = "haveDebt";
            this.haveDebt.Size = new System.Drawing.Size(409, 26);
            this.haveDebt.TabIndex = 7;
            this.haveDebt.Text = "У ВАС ИМЕЕТСЯ ЗАДОЛЖЕННОСТЬ!";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(853, 361);
            this.dataGridView1.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Фамилия Автора";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Имя Автора";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Название книги";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Сумма к выплате (руб.)";
            this.Column4.Name = "Column4";
            // 
            // summ
            // 
            this.summ.AutoSize = true;
            this.summ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.summ.Location = new System.Drawing.Point(540, 103);
            this.summ.Name = "summ";
            this.summ.Size = new System.Drawing.Size(162, 26);
            this.summ.TabIndex = 9;
            this.summ.Text = "Общая сумма:";
            // 
            // sumOutput
            // 
            this.sumOutput.AutoSize = true;
            this.sumOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumOutput.ForeColor = System.Drawing.Color.Red;
            this.sumOutput.Location = new System.Drawing.Point(708, 103);
            this.sumOutput.Name = "sumOutput";
            this.sumOutput.Size = new System.Drawing.Size(70, 26);
            this.sumOutput.TabIndex = 10;
            this.sumOutput.Text = "label2";
            // 
            // rub
            // 
            this.rub.AutoSize = true;
            this.rub.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rub.Location = new System.Drawing.Point(784, 103);
            this.rub.Name = "rub";
            this.rub.Size = new System.Drawing.Size(54, 26);
            this.rub.TabIndex = 11;
            this.rub.Text = "руб.";
            // 
            // Debt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 506);
            this.Controls.Add(this.rub);
            this.Controls.Add(this.sumOutput);
            this.Controls.Add(this.summ);
            this.Controls.Add(this.haveDebt);
            this.Controls.Add(this.noDebt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Debt";
            this.Text = "Debt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label noDebt;
        private System.Windows.Forms.Label haveDebt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label summ;
        private System.Windows.Forms.Label sumOutput;
        private System.Windows.Forms.Label rub;
    }
}