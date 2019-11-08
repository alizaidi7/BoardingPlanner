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
            plannings = DBLayer.Instance.GetPlannings();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = plannings;
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
                    plannings = DBLayer.Instance.GetPlannings();                    
                    dataGridView1.DataSource = plannings;
                }
            }
        }
    }
}
