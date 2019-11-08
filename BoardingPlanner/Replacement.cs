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
    public partial class Replacement : Form
    {
        public int PlanningId { get; set; }
        public Replacement()
        {
            InitializeComponent();

            var autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Staffs.Select(o => o.HKID.ToString()).ToArray());
            txtHKId.AutoCompleteCustomSource = autoCompleteData;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                DBLayer.Instance.ExecureReplacement(PlanningId, Convert.ToInt32(txtHKId.Text), txtName.Text);
                MessageBox.Show("Replacement done successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHKId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHKId.Text))
            {
                var name = DBLayer.Instance.GetStaffName(Convert.ToInt32(txtHKId.Text));
                if (!string.IsNullOrEmpty(name))
                {
                    txtName.Text = name;
                    txtName.Enabled = false;
                }
                else
                {
                    txtName.Enabled = true;
                    txtName.Text = string.Empty;
                }
            }
        }
    }
}
