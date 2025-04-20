namespace PrisonersActivity.Forms
{
    partial class FrmAddNew
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCompNum = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Datein = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.zSearchLookupedit1 = new ZGTools.ZTools.ZSearchLookupedit();
            this.zSearchLookupedit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSuidName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datein.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datein.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuidName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(518, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "رقم الحاسب الآلي";
            // 
            // txtCompNum
            // 
            this.txtCompNum.Location = new System.Drawing.Point(38, 13);
            this.txtCompNum.Name = "txtCompNum";
            this.txtCompNum.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompNum.Properties.Appearance.Options.UseFont = true;
            this.txtCompNum.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtCompNum.Properties.MaskSettings.Set("mask", "d");
            this.txtCompNum.Properties.MaxLength = 50;
            this.txtCompNum.Properties.NullValuePrompt = "رقم الحاسب الآلي";
            this.txtCompNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCompNum.Size = new System.Drawing.Size(457, 28);
            this.txtCompNum.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 47);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.MaxLength = 150;
            this.txtName.Properties.NullValuePrompt = "الاسم";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(457, 28);
            this.txtName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(518, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 22);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "الاسم";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(178, 121);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(121, 22);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "تاريخ دخول السجن";
            // 
            // Datein
            // 
            this.Datein.EditValue = null;
            this.Datein.Location = new System.Drawing.Point(38, 118);
            this.Datein.Name = "Datein";
            this.Datein.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datein.Properties.Appearance.Options.UseFont = true;
            this.Datein.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Datein.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Datein.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Datein.Size = new System.Drawing.Size(134, 28);
            this.Datein.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.simpleButton1.Location = new System.Drawing.Point(38, 243);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 39);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "الغاء";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.ImageUri.Uri = "Apply;Size16x16";
            this.simpleButton2.Location = new System.Drawing.Point(293, 243);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(200, 39);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "حفظ وإضافة جديد";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.ImageUri.Uri = "Undo;Size16x16";
            this.simpleButton3.Location = new System.Drawing.Point(140, 243);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(132, 39);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "حفظ وخروح";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(341, 81);
            this.txtid.Name = "txtid";
            this.txtid.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Properties.Appearance.Options.UseFont = true;
            this.txtid.Properties.MaxLength = 10;
            this.txtid.Properties.NullValuePrompt = "رقم الهوية";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(154, 28);
            this.txtid.TabIndex = 2;
            this.txtid.Leave += new System.EventHandler(this.txtid_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(518, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 22);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "رقم الهوية";
            // 
            // zSearchLookupedit1
            // 
            this.zSearchLookupedit1.Location = new System.Drawing.Point(341, 118);
            this.zSearchLookupedit1.Name = "zSearchLookupedit1";
            this.zSearchLookupedit1.Properties.AllowMouseWheel = false;
            this.zSearchLookupedit1.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zSearchLookupedit1.Properties.Appearance.Options.UseFont = true;
            this.zSearchLookupedit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zSearchLookupedit1.Properties.PopupView = this.zSearchLookupedit1View;
            this.zSearchLookupedit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.zSearchLookupedit1.Size = new System.Drawing.Size(153, 28);
            this.zSearchLookupedit1.TabIndex = 3;
            this.zSearchLookupedit1.ZPopupLoadedBefore = false;
            // 
            // zSearchLookupedit1View
            // 
            this.zSearchLookupedit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.zSearchLookupedit1View.Name = "zSearchLookupedit1View";
            this.zSearchLookupedit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.zSearchLookupedit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(518, 121);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 22);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "الجنسية";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(38, 152);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.MaxLength = 149;
            this.memoEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.memoEdit1.Size = new System.Drawing.Size(457, 85);
            this.memoEdit1.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(518, 154);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 22);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "ملاحظات";
            // 
            // txtSuidName
            // 
            this.txtSuidName.Location = new System.Drawing.Point(37, 81);
            this.txtSuidName.Name = "txtSuidName";
            this.txtSuidName.Properties.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuidName.Properties.Appearance.Options.UseFont = true;
            this.txtSuidName.Properties.MaxLength = 50;
            this.txtSuidName.Properties.NullValuePrompt = "الجناح";
            this.txtSuidName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuidName.Size = new System.Drawing.Size(135, 28);
            this.txtSuidName.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(178, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 22);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "الجناح";
            // 
            // FrmAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 297);
            this.Controls.Add(this.txtSuidName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.zSearchLookupedit1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.Datein);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCompNum);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ImageUri.Uri = "outlook%20inspired/newemployee;Size16x16";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة جديد";
            this.Load += new System.EventHandler(this.FrmAddNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCompNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datein.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datein.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSearchLookupedit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuidName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCompNum;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit Datein;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.TextEdit txtid;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private ZGTools.ZTools.ZSearchLookupedit zSearchLookupedit1;
        private DevExpress.XtraGrid.Views.Grid.GridView zSearchLookupedit1View;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSuidName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}