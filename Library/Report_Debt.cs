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
    public partial class Report_Debt : Form
    {
        public Report_Debt()
        {
            InitializeComponent();
        }

        private void Report_Debt_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "LibraryDataSet.Debt". При необходимости она может быть перемещена или удалена.
            this.DebtTableAdapter.Fill(this.LibraryDataSet.Debt);

            this.reportViewer1.RefreshReport();
        }
    }
}
