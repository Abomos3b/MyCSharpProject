namespace PrisonersActivity.Forms
{
    partial class FrmRprtAll
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.zDatesRangeH1 = new ZGTools.ZeenyControls.ZDatesRangeH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.zSearchLookupedit1 = new ZGTools.ZTools.ZSearchLookupedit();
            this.zSearchLookupedit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zGridControl1 = new ZGTools.ZTools.ZGridControl();
            this.zGridView1 = new ZGTools.ZTools.ZGridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Controls.Add(this.zDatesRangeH1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.zSearchLookupedit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(846, 48);
            this.panelControl1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ImageOptions.ImageUri.Uri = "ExportToXLS;Size16x16";
            this.btnExport.Location = new System.Drawing.Point(5, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(26, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.ImageUri.Uri = "Print;Size16x16";
            this.btnPrint.Location = new System.Drawing.Point(79, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.ImageOptions.ImageUri.Uri = "Refresh;Size16x16";
            this.btnLoad.Location = new System.Drawing.Point(179, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "تحميل";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // zDatesRangeH1
            // 
            this.zDatesRangeH1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zDatesRangeH1.Location = new System.Drawing.Point(273, 9);
            this.zDatesRangeH1.Name = "zDatesRangeH1";
            this.zDatesRangeH1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zDatesRangeH1.Size = new System.Drawing.Size(248, 34);
            this.zDatesRangeH1.TabIndex = 2;
            this.zDatesRangeH1.ZCalenderFont = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zDatesRangeH1.ZMenuFont = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zDatesRangeH1.ZMenuHoverdColor = System.Drawing.Color.Blue;
            this.zDatesRangeH1.ZParent = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(775, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "نوع التقرير";
            // 
            // zSearchLookupedit1
            // 
            this.zSearchLookupedit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zSearchLookupedit1.Location = new System.Drawing.Point(541, 10);
            this.zSearchLookupedit1.Name = "zSearchLookupedit1";
            this.zSearchLookupedit1.Properties.AllowMouseWheel = false;
            this.zSearchLookupedit1.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zSearchLookupedit1.Properties.Appearance.Options.UseFont = true;
            this.zSearchLookupedit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zSearchLookupedit1.Properties.PopupView = this.zSearchLookupedit1View;
            this.zSearchLookupedit1.Size = new System.Drawing.Size(217, 28);
            this.zSearchLookupedit1.TabIndex = 0;
            this.zSearchLookupedit1.ZPopupLoadedBefore = false;
            this.zSearchLookupedit1.EditValueChanged += new System.EventHandler(this.zSearchLookupedit1_EditValueChanged);
            // 
            // zSearchLookupedit1View
            // 
            this.zSearchLookupedit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.zSearchLookupedit1View.Name = "zSearchLookupedit1View";
            this.zSearchLookupedit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.zSearchLookupedit1View.OptionsView.ShowGroupPanel = false;
            // 
            // zGridControl1
            // 
            this.zGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zGridControl1.Location = new System.Drawing.Point(0, 48);
            this.zGridControl1.MainView = this.zGridView1;
            this.zGridControl1.Name = "zGridControl1";
            this.zGridControl1.Size = new System.Drawing.Size(846, 328);
            this.zGridControl1.TabIndex = 5;
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
            // FrmRprtAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 376);
            this.Controls.Add(this.zGridControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ImageUri.Uri = "business%20objects/bo_report;Size16x16";
            this.Name = "FrmRprtAll";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مركز التقارير";
            this.Load += new System.EventHandler(this.FrmRprtAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ZGTools.ZeenyControls.ZDatesRangeH zDatesRangeH1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ZGTools.ZTools.ZSearchLookupedit zSearchLookupedit1;
        private DevExpress.XtraGrid.Views.Grid.GridView zSearchLookupedit1View;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private ZGTools.ZTools.ZGridControl zGridControl1;
        private ZGTools.ZTools.ZGridView zGridView1;
    }
}