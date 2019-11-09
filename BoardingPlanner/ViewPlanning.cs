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
    public partial class ViewPlanning : Form
    {
        IList<PlannerDTO> plannings = null;
        public ViewPlanning()
        {
            InitializeComponent();
            var autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Staffs.Select(o => o.HKID.ToString()).ToArray());
            txtHKID.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Staffs.Select(o => o.Name.ToString()).ToArray());
            txtName.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Ranks.Select(o => o.Name.ToString()).ToArray());
            txtRank.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.Vessels.Select(o => o.Name.ToString()).ToArray());
            txtVessel.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(DBLayer.Instance.TechnicalGroups.Select(o => o.Name.ToString()).ToArray());
            txtTechnicalGroup.AutoCompleteCustomSource = autoCompleteData;

            dtpCOC.CustomFormat = "dd-MM-yyyy";
        }

        private void ViewPlanning_Load(object sender, EventArgs e)
        {
            plannings = DBLayer.Instance.GetPlannings(0, string.Empty, string.Empty, string.Empty, string.Empty, DateTime.MinValue);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = plannings;
            dtpCOC.Value = new DateTime(2000, 1, 1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colReplacementOperation.Index && e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[colId.Name].Value);
                Replacement objReplacement = new Replacement();
                objReplacement.PlanningId = id;
                if (objReplacement.ShowDialog() == DialogResult.OK)
                {
                    plannings = DBLayer.Instance.GetPlannings((txtHKID.Text == string.Empty) ? 0 : Convert.ToInt32(txtHKID.Text), txtName.Text, txtRank.Text, txtVessel.Text, txtTechnicalGroup.Text, dtpCOC.Value);
                    dataGridView1.DataSource = plannings;
                }
            }
            if (e.ColumnIndex == colEdit.Index && e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[colId.Name].Value);
                EditPlanning objEditPlanning = new EditPlanning();
                objEditPlanning.PlanningId = id;
                if (objEditPlanning.ShowDialog() == DialogResult.OK)
                {
                    plannings = DBLayer.Instance.GetPlannings((txtHKID.Text == string.Empty) ? 0 : Convert.ToInt32(txtHKID.Text), txtName.Text, txtRank.Text, txtVessel.Text, txtTechnicalGroup.Text, dtpCOC.Value);
                    dataGridView1.DataSource = plannings;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            plannings = DBLayer.Instance.GetPlannings((txtHKID.Text == string.Empty) ? 0 : Convert.ToInt32(txtHKID.Text), txtName.Text, txtRank.Text, txtVessel.Text, txtTechnicalGroup.Text, dtpCOC.Value);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = plannings;
        }
    }
}
