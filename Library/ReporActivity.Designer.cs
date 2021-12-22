namespace Library
{
    partial class ReporActivity
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
            this.Activity_ReaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Activity_ReaderTableAdapter = new Library.LibraryDataSetTableAdapters.Activity_ReaderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Activity_ReaderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Activity_ReaderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Library.Report1.rdlc";
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
            // Activity_ReaderBindingSource
            // 
            this.Activity_ReaderBindingSource.DataMember = "Activity_Reader";
            this.Activity_ReaderBindingSource.DataSource = this.LibraryDataSet;
            // 
            // Activity_ReaderTableAdapter
            // 
            this.Activity_ReaderTableAdapter.ClearBeforeFill = true;
            // 
            // ReporActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporActivity";
            this.Text = "ReporActivity";
            this.Load += new System.EventHandler(this.ReporActivity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Activity_ReaderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Activity_ReaderBindingSource;
        private LibraryDataSet LibraryDataSet;
        private LibraryDataSetTableAdapters.Activity_ReaderTableAdapter Activity_ReaderTableAdapter;
    }
}