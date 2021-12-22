using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class ReporActivity : Form
    {
        public ReporActivity()
        {
            InitializeComponent();
        }

        private void ReporActivity_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "LibraryDataSet.Activity_Reader". При необходимости она может быть перемещена или удалена.
            this.Activity_ReaderTableAdapter.Fill(this.LibraryDataSet.Activity_Reader);

            this.reportViewer1.RefreshReport();
        }
    }
}
