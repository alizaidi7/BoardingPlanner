namespace BoardingPlanner
{
    partial class ViewPlanning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPlanning));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVessel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTechGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacementOperation = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpCOC = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTechnicalGroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHKID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSerialNumber,
            this.colHKID,
            this.colName,
            this.colRank,
            this.colVessel,
            this.colTechGroup,
            this.colCOC,
            this.colReplacement,
            this.colRemarks,
            this.colReplacementOperation,
            this.colEdit});
            this.dataGridView1.Location = new System.Drawing.Point(0, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1293, 324);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.FillWeight = 70F;
            this.colSerialNumber.HeaderText = "Serial #";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 70;
            // 
            // colHKID
            // 
            this.colHKID.DataPropertyName = "HKID";
            this.colHKID.FillWeight = 60F;
            this.colHKID.HeaderText = "HKID";
            this.colHKID.Name = "colHKID";
            this.colHKID.ReadOnly = true;
            this.colHKID.Width = 60;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 150F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colRank
            // 
            this.colRank.DataPropertyName = "Rank";
            this.colRank.FillWeight = 80F;
            this.colRank.HeaderText = "Rank";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            this.colRank.Width = 80;
            // 
            // colVessel
            // 
            this.colVessel.DataPropertyName = "Vessel";
            this.colVessel.FillWeight = 130F;
            this.colVessel.HeaderText = "Vessel Name";
            this.colVessel.Name = "colVessel";
            this.colVessel.ReadOnly = true;
            this.colVessel.Width = 130;
            // 
            // colTechGroup
            // 
            this.colTechGroup.DataPropertyName = "TechnicalGroup";
            this.colTechGroup.FillWeight = 90F;
            this.colTechGroup.HeaderText = "Tech Group";
            this.colTechGroup.Name = "colTechGroup";
            this.colTechGroup.ReadOnly = true;
            this.colTechGroup.Width = 90;
            // 
            // colCOC
            // 
            this.colCOC.DataPropertyName = "COCStr";
            this.colCOC.FillWeight = 80F;
            this.colCOC.HeaderText = "COC";
            this.colCOC.Name = "colCOC";
            this.colCOC.ReadOnly = true;
            this.colCOC.Width = 80;
            // 
            // colReplacement
            // 
            this.colReplacement.DataPropertyName = "Replacement";
            this.colReplacement.FillWeight = 150F;
            this.colReplacement.HeaderText = "Replacement";
            this.colReplacement.Name = "colReplacement";
            this.colReplacement.ReadOnly = true;
            this.colReplacement.Width = 150;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.FillWeight = 250F;
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.Width = 250;
            // 
            // colReplacementOperation
            // 
            this.colReplacementOperation.HeaderText = "Action";
            this.colReplacementOperation.Name = "colReplacementOperation";
            this.colReplacementOperation.ReadOnly = true;
            this.colReplacementOperation.Text = "Execute Replacement";
            this.colReplacementOperation.ToolTipText = "Execute Replacement";
            this.colReplacementOperation.UseColumnTextForLinkValue = true;
            this.colReplacementOperation.Width = 150;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 70F;
            this.colEdit.HeaderText = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "Edit";
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.UseColumnTextForLinkValue = true;
            this.colEdit.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpCOC);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTechnicalGroup);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtVessel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRank);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtHKID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1293, 69);
            this.panel1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1095, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1176, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpCOC
            // 
            this.dtpCOC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCOC.Location = new System.Drawing.Point(1122, 8);
            this.dtpCOC.Name = "dtpCOC";
            this.dtpCOC.Size = new System.Drawing.Size(129, 20);
            this.dtpCOC.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1073, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "COC";
            // 
            // txtTechnicalGroup
            // 
            this.txtTechnicalGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTechnicalGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTechnicalGroup.Location = new System.Drawing.Point(924, 8);
            this.txtTechnicalGroup.Name = "txtTechnicalGroup";
            this.txtTechnicalGroup.Size = new System.Drawing.Size(129, 20);
            this.txtTechnicalGroup.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(818, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Technical Group";
            // 
            // txtVessel
            // 
            this.txtVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtVessel.Location = new System.Drawing.Point(669, 8);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.Size = new System.Drawing.Size(129, 20);
            this.txtVessel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vessel";
            // 
            // txtRank
            // 
            this.txtRank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRank.Location = new System.Drawing.Point(462, 8);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(129, 20);
            this.txtRank.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rank";
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(260, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(129, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtHKID
            // 
            this.txtHKID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtHKID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHKID.Location = new System.Drawing.Point(56, 8);
            this.txtHKID.Name = "txtHKID";
            this.txtHKID.Size = new System.Drawing.Size(129, 20);
            this.txtHKID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HKID";
            // 
            // ViewPlanning
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewPlanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Plannings";
            this.Load += new System.EventHandler(this.ViewPlanning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTechnicalGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVessel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHKID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpCOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVessel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTechGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewLinkColumn colReplacementOperation;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
    }
}