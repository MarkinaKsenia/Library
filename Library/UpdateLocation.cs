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
    public partial class UpdateLocation : Form
    {
        public UpdateLocation()
        {
            InitializeComponent();
        }

        private void lOCATIONBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOCATIONBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);

        }

        private void UpdateLocation_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.LOCATION". При необходимости она может быть перемещена или удалена.
            this.lOCATIONTableAdapter.Fill(this.libraryDataSet.LOCATION);

        }
    }
}
