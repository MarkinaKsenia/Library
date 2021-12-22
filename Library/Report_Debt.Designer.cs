namespace Library
{
    partial class Report_Debt
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LibraryDataSet = new Library.LibraryDataSet();
            this.DebtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DebtTableAdapter = new Library.LibraryDataSetTableAdapters.DebtTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebtBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DebtBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Library.Debt_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // LibraryDataSet
            // 
            this.LibraryDataSet.DataSetName = "LibraryDataSet";
            this.LibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DebtBindingSource
            // 
            this.DebtBindingSource.DataMember = "Debt";
            this.DebtBindingSource.DataSource = this.LibraryDataSet;
            // 
            // DebtTableAdapter
            // 
            this.DebtTableAdapter.ClearBeforeFill = true;
            // 
            // Report_Debt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_Debt";
            this.Text = "Report_Debt";
            this.Load += new System.EventHandler(this.Report_Debt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebtBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DebtBindingSource;
        private LibraryDataSet LibraryDataSet;
        private LibraryDataSetTableAdapters.DebtTableAdapter DebtTableAdapter;
    }
}