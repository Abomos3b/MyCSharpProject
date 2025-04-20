using PrisonersActivity.BE;
using System;
using ZGTools;
using ZGTools.ZExtensions;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmAddNew : ZForm
    {
        private readonly int _pid;
        public int ZAddedNew { get; private set; }

        public string ZCompNo { get; private set; }
        public string ZName { get; private set; }
        public string ZId { get; private set; }
        public string ZNationality { get; private set; }
        public DateTime ZEnterDate { get; private set; }
        public string ZSuidName { get; private set; }
        public string Znotes { get; private set; }




        public FrmAddNew(int pid = 0)
        {
            _pid = pid;
            InitializeComponent();
            if (pid == 0) Datein.Properties.MaxValue = DateTime.Today;
            else
            {
                simpleButton2.Visible = false;
                Text = @"تعديل بيانات السجين";
                IconOptions.ImageUri.Uri = "dashboards/editnames;Size16x16";
            }


        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }


        private void LoadDataToEdit(int pid)
        {
            var txtq = $@"select m.compnumber, m.pname
, m.nationadlid, m.SuidName, m.nationalityid, m.enterdate
 from tblMain m
where m.id={pid}";
            var dt = new Dal().Select(txtq);
            if (dt.Rows.Count > 0)
            {
                txtCompNum.EditValue = dt.Rows[0]["compnumber"];
                txtName.EditValue = dt.Rows[0]["pname"];
                txtid.EditValue = dt.Rows[0]["nationadlid"];
                zSearchLookupedit1.EditValue = dt.Rows[0]["nationalityid"];
                Datein.EditValue = dt.Rows[0]["enterdate"];
                txtSuidName.EditValue = dt.Rows[0]["SuidName"];
            }
            simpleButton2.Visible = false;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (_pid == 0)
            {
                if (Save()) Close();
            }
            else
            {
                if (!SaveUpdate()) return;
                ZCompNo = txtCompNum.Text;
                ZName = txtName.Text;
                ZId = txtid.Text;
                ZNationality = (zSearchLookupedit1.ZGetColumnDisplayMember()??"").ToString();
                ZEnterDate = Datein.DateTime;
                ZSuidName = txtSuidName.Text;
                Znotes = memoEdit1.Text;


                DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        private bool IsValidData()
        {
            if (!ZEntry.ZCheckTextBoxString(txtCompNum, "الرجاء ادخال رقم الحاسب الآلي")) return false;
            var isint = long.TryParse(txtCompNum.Text, out var compnum);
            if (!isint)
            {
                ZEntry.ShowErrorMessage("الرجاء ادخال رقم صحيح");
                return false;
            }
            //var idIsInt = long.TryParse(txtid.Text, out _);
            //if (!idIsInt)
            //{
            //    ZEntry.ShowErrorMessage("رقم الهوية يجب ان يكون رقم صحيح");
            //    return false;
            //}
           
            if (zSearchLookupedit1.EditValue == null)
            {
                ZEntry.ShowErrorMessage("الرجاء اختيار الجنسية");
                return false;
            }


            if (!ZEntry.ZCheckTextBoxString(txtName, "الرجاء ادخال اسم السجين")) return false;
            if (!ZEntry.ZCheckDateEdit(Datein, "الرجاء ادخال تاريخ الدخول")) return false;
            if (!ZEntry.ShowQuestionNew(this, "هل أنت متأكد من الحفظ؟")) return false;
            if (!ClsVarslocal.Settings.CanRepeatCompNum)
            {

                var txtq1 = $@"SELECT count(*) FROM tblMain WHERE compnumber = '{compnum}' and isactive=true and id<>{_pid}";
                var dt = new Dal().Select(txtq1);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        ZEntry.ShowErrorMessage("رقم الحاسب الآلي موجود مسبقاً", "خطأ", true);
                        return false;
                    }
                }

            }
            return IsavalidId();
        }

        private bool SaveUpdate()
        {
            if (!IsValidData()) return false;


            var txtq = $@"
UPDATE tblMain 
SET compnumber='{txtCompNum.Text}'
, pname='{txtName.Text}'
, enterdate='{Datein.DateTime:yyyy-MM-dd}'
, nationadlid= '{txtid.Text}'
, nationalityid= {zSearchLookupedit1.ZGetColumn()}
, SuidName= '{txtSuidName.Text}'
WHERE id={_pid}";


            var addedd = new Dal().ExcuteCommand(txtq);
            if (addedd)
            {
                AddNote();

                ZEntry.ShowAlert("تم الحفظ بنجاح", "نجاح");
                ZAddedNew++;
                return true;
            }
            ZEntry.ShowErrorMessage("حدث خطأ أثناء الحفظ", "خطأ", true);
            return false;
        }

        private bool Save()
        {
            if (!IsValidData()) return false;

            var txtq = $@"INSERT INTO tblMain
    ( compnumber, pname,  enterdate,  isactive, IsOut, OutMonth, outYear, nationadlid, nationalityid, SuidName, istransferd)
VALUES
    ('{txtCompNum.Text}', '{txtName.Text}',  '{Datein.DateTime:yyyy-MM-dd}',  true, false, 0, 0, '{txtid.Text}', {zSearchLookupedit1.ZGetColumn()}, '{txtSuidName.Text}', false)";

            var addedd = new Dal().ExcuteCommand(txtq);
            if (addedd)
            {
                AddNote();

                ZEntry.ShowAlert("تم الحفظ بنجاح", "نجاح");
                ZAddedNew++;
                return true;
            }
            ZEntry.ShowErrorMessage("حدث خطأ أثناء الحفظ", "خطأ", true);
            return false;


        }

        private bool IsavalidId()
        {
            var idIsInt = long.TryParse(txtid.Text, out _);
            if (!idIsInt) return true;
             if(txtid.Text.Length != 10)
            {
                ZEntry.ShowErrorMessage("رقم الهوية يجب أن يكون 10 أرقام");
                return false;
            }


            var txtq1 = $@"SELECT count(*) FROM tblMain WHERE nationadlid = '{txtid.Text}' and isactive=true and id<>{_pid}";
            var dt = new Dal().Select(txtq1);
            if (dt.Rows.Count <= 0) return true;
            if (Convert.ToInt32(dt.Rows[0][0]) <= 0) return true;
            ZEntry.ShowErrorMessage("رقم الهوية موجود مسبقاً", "خطأ", true);
            return false;
        }

        private void AddNote()
        {
            if (memoEdit1.Text.Trim().Length <= 0) return;
            var txtq = $@"SELECT id FROM tblMain WHERE nationadlid = '{txtid.Text}'";
            var dt = new Dal().Select(txtq);
            if (dt.Rows.Count <= 0) return;
            var id = dt.Rows[0][0];
            var txtq1 = $@"INSERT INTO tblNotes (pid, note, addedddate) VALUES ({id}, '{memoEdit1.Text.ZForSql()}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
            new Dal().ExcuteCommand(txtq1);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (Save()) Clear();

        }

        private void Clear()
        {
            txtCompNum.EditValue = null;
            txtName.EditValue = null;
            Datein.EditValue = null;
            txtid.EditValue = null;
            zSearchLookupedit1.EditValue = null;
            memoEdit1.EditValue = null;
            txtSuidName.EditValue = null;
            txtCompNum.Focus();
        }





        private void FrmAddNew_Load(object sender, EventArgs e)
        {
            zSearchLookupedit1.ZSetup(new Db().GetNationalities(), "nationalityid", "nationalityname", "اختر الجنسية", simpleButton1.Font, ["nationalityid"], new System.Collections.Generic.Dictionary<string, string> { { "nationalityname", "الجنسية" } });

            LoadDataToEdit(_pid);

        }

        private void txtid_Leave(object sender, EventArgs e)
        {
            if (txtid.Text.Trim().Length <= 0) return;
            if (txtid.Text.StartsWith("1")) zSearchLookupedit1.EditValue = 1;
            else zSearchLookupedit1.EditValue = null;

        }

     
    }
}