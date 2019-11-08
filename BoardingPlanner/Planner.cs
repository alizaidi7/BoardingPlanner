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
    public partial class Planner : Form
    {
        public Planner()
        {
            InitializeComponent();
            var autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Staffs.Select(o => o.HKID.ToString()).ToArray());
            txtHKId.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Staffs.Select(o => o.Name.ToString()).ToArray());
            txtName.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Ranks.Select(o => o.Name.ToString()).ToArray());
            txtRank.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Vessels.Select(o => o.Name.ToString()).ToArray());
            txtVesselName.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.TechnicalGroups.Select(o => o.Name.ToString()).ToArray());
            txtTechnicalGroup.AutoCompleteCustomSource = autoCompleteData;

            txtSerialNumber.Text = DBLayer.Instance.GetSerialNumber().ToString();
            dtpCOC.CustomFormat = "dd-MM-yyyy";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHKId.Text == string.Empty)
                {
                    MessageBox.Show("Invalid HKID");
                }
                else if (txtName.Text == string.Empty)
                {
                    MessageBox.Show("Invalid Name");
                }
                else if (txtRank.Text == string.Empty)
                {
                    MessageBox.Show("Invalid Rank");
                }
                else if (txtVesselName.Text == string.Empty)
                {
                    MessageBox.Show("Invalid Vessel Name");
                }
                else if (txtTechnicalGroup.Text == string.Empty)
                {
                    MessageBox.Show("Invalid Technical Group");
                }
                else
                {
                    var dto = new PlannerDTO
                    {
                        COC = dtpCOC.Value,
                        HKID = Convert.ToInt32(txtHKId.Text),
                        Name = txtName.Text,
                        Rank = txtRank.Text,
                        Remarks = txtRemarks.Text,
                        Replacement = txtReplacement.Text,
                        SerialNumber = Convert.ToInt32(txtSerialNumber.Text),
                        TechnicalGroup = txtTechnicalGroup.Text,
                        Vessel = txtVesselName.Text
                    };
                    DBLayer.Instance.CreatePlanning(dto);
                    MessageBox.Show("Planning created successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
