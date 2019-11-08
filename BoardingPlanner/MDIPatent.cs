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
    public partial class MDIPatent : Form
    {
        public MDIPatent()
        {
            InitializeComponent();
        }

        private void createPlaninmgToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportData objImportData = new ImportData();
            objImportData.MdiParent = this;
            objImportData.Show();
        }

        private void viewPlanningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planner objPlanner = new Planner();
            objPlanner.MdiParent = this;
            objPlanner.Show(); 
        }

        private void createPlanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewPlanning objPlanning = new ViewPlanning();
            objPlanning.MdiParent = this;
            objPlanning.Show();
        }
    }
}
