using System;
using System.Data;
using PrisonersActivity.BE;
using ZGTools;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmNationality : ZForm
    {
        private bool _isNew;

        public FrmNationality()
        {
            InitializeComponent();
        }

        private void FrmNationality_Load(object sender, EventArgs e)
        {
            zGridView1.ZRowsFormatOddEven();
            zGridView1.OptionsView.ColumnAutoWidth = false;
            zGridView1.ZFormatFontsAll(btnSave.Font);
            zGridView1.OptionsFind.AlwaysVisible = true;
            LoadData();
        }

        private void LoadData()
        {
            zGridView1.ZResetBeforeDatasource();
         
             zGridControl1.DataSource = new Db().GetNationalities();
            zGridView1.ZHideColumn("nationalityid");
            zGridView1.ZColHandle("nationalityname", "الجنسية");
            zGridView1.ZAddSequenceColumnWithFooter();
            zGridView1.ZClearFocus();
            zGridView1.BestFitColumns();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            textEdit1.EditValue = null;
            panelControl2.Visible = true;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            zGridControl1.Enabled = false;
            textEdit1.Focus();
            _isNew = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textEdit1.EditValue = null;
            panelControl2.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            zGridControl1.Enabled = true;
            zGridControl1.Focus();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (zGridControl1.DataSource is not DataTable { Rows.Count: > 0 } ||
                zGridView1.GetFocusedDataRow() is not { } dr)
            {
                ZEntry.ShowErrorMessage("الرجاء اختيار الجنسية أولا");
                return;
            }
            textEdit1.Text = dr["nationalityname"].ToString();
            panelControl2.Visible = true;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            zGridControl1.Enabled = false;
            textEdit1.Focus();
            _isNew = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ZEntry.ZCheckTextBoxString(textEdit1, "الرجاء ادخال اسم الجنسية")) return;
            //check id exist
            if (zGridControl1.DataSource is DataTable { Rows.Count: > 0 } dt)
            {
                var drs = dt.Select($"nationalityname='{textEdit1.Text}'");
                if (drs.Length > 0)
                {
                    ZEntry.ShowErrorMessage("الجنسية موجودة مسبقا");
                    return;
                }

            }
            if (!ZEntry.ShowQuestionNew(this, "هل تريد حفظ التغييرات؟")) return;
            if (_isNew)
            {
                var txtq = $@"INSERT INTO tblnationalities(nationalityname) VALUES('{textEdit1.Text}')";
                new Dal().ExcuteCommand(txtq);
                
            }
            else
            {
                if (zGridControl1.DataSource is not DataTable { Rows.Count: > 0 } ||
                    zGridView1.GetFocusedDataRow() is not { } dr)
                {
                    ZEntry.ShowErrorMessage("الرجاء اختيار الجنسية أولا");
                    return;
                }
                var txtq = $@"UPDATE tblnationalities set nationalityname='{textEdit1.Text}' where nationalityid={dr["nationalityid"]}";
                new Dal().ExcuteCommand(txtq);
            }
            LoadData();
            btnCancel.PerformClick();


        }

    }
}