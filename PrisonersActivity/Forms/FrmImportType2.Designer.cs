namespace PrisonersActivity.Forms
{
    partial class FrmImportType2
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnShowinvalid = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.zGridControl1 = new ZGTools.ZTools.ZGridControl();
            this.zGridView1 = new ZGTools.ZTools.ZGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.progressBarControl1);
            this.panelControl1.Controls.Add(this.btnShowinvalid);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(781, 37);
            this.panelControl1.TabIndex = 0;
            // 
            // btnShowinvalid
            // 
            this.btnShowinvalid.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowinvalid.Appearance.Options.UseFont = true;
            this.btnShowinvalid.ImageOptions.ImageUri.Uri = "Preview;Size16x16";
            this.btnShowinvalid.Location = new System.Drawing.Point(192, 2);
            this.btnShowinvalid.Name = "btnShowinvalid";
            this.btnShowinvalid.Size = new System.Drawing.Size(137, 28);
            this.btnShowinvalid.TabIndex = 19;
            this.btnShowinvalid.Text = "عرض الغير صالح";
            this.btnShowinvalid.Visible = false;
            this.btnShowinvalid.Click += new System.EventHandler(this.btnShowinvalid_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(12, 5);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(641, 18);
            this.progressBarControl1.TabIndex = 17;
            this.progressBarControl1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.ImageUri.Uri = "Apply;Size16x16";
            this.btnSave.Location = new System.Drawing.Point(12, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "حفظ ";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.ImageUri.Uri = "ExportToXLS;Size16x16";
            this.simpleButton1.Location = new System.Drawing.Point(676, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "فتح الملف";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // zGridControl1
            // 
            this.zGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zGridControl1.Location = new System.Drawing.Point(0, 37);
            this.zGridControl1.MainView = this.zGridView1;
            this.zGridControl1.Name = "zGridControl1";
            this.zGridControl1.Size = new System.Drawing.Size(781, 385);
            this.zGridControl1.TabIndex = 1;
            this.zGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.zGridView1});
            // 
            // zGridView1
            // 
            this.zGridView1.GridControl = this.zGridControl1;
            this.zGridView1.Name = "zGridView1";
            this.zGridView1.OptionsBehavior.Editable = false;
            this.zGridView1.OptionsBehavior.ReadOnly = true;
            this.zGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.zGridView1.OptionsView.BestFitMaxRowCount = 100;
            this.zGridView1.OptionsView.ColumnAutoWidth = false;
            this.zGridView1.ZAddCopyCell = true;
            this.zGridView1.ZCanZoomInOut = false;
            this.zGridView1.ZLoadedBefore = false;
            // 
            // FrmImportType2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 422);
            this.Controls.Add(this.zGridControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ImageUri.Uri = "dashboards/drilldown;Size16x16";
            this.Name = "FrmImportType2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "استيراد من ملف اكسل قالب الإدارة";
            this.Load += new System.EventHandler(this.FrmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ZGTools.ZTools.ZGridControl zGridControl1;
        private ZGTools.ZTools.ZGridView zGridView1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private DevExpress.XtraEditors.SimpleButton btnShowinvalid;
    }
}