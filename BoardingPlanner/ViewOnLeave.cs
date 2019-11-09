using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardingPlanner
{
    public partial class ViewOnLeave : Form
    {
        public ViewOnLeave()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = DBLayer.Instance.GetOnLeave((txtHKID.Text == string.Empty) ? 0 : Convert.ToInt32(txtHKID.Text), txtName.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = data;
        }

    }
}
