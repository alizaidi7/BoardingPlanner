using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardingPlanner
{
    public partial class ImportData : Form
    {
        IEnumerable<PlannerDTO> data;

        public ImportData()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Excel Files|*.xls;*.xlsx;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.FileName;
                this.data = Utilities.GetExcelData(txtPath.Text);
                dataGridView1.DataSource = data.ToList();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DBLayer.Instance.ImportData(data);
                MessageBox.Show("Data imported successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
