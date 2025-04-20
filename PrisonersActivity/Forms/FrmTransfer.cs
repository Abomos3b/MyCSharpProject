using System;
using ZGTools;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmTransfer : ZForm
    {
        public string Zcustdy { get; set; }
        public string ZNotes { get; set; }
        public DateTime ZDate { get; set; }

        public FrmTransfer(string pname, string pcompnum, string idno, decimal amount)
        {
            InitializeComponent();
            txtName.Text = pname;
            txtCompNum.Text = pcompnum;
            txtId.Text = idno;
            txtAmunt.Text = amount.ToString("0.###");
            dateEdit1.Properties.MaxValue = DateTime.Now;
            dateEdit1.Properties.MinValue= DateTime.Today.AddDays(-15);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ZEntry.ZCheckTextBoxString(txtCustdy,"الرجاء ادخال الشخص المسؤؤول")) return;
            if (!ZEntry.ZCheckTextBoxString(txtNotes, "الرجاء ادخال ملاحظات")) return;
            if(!ZEntry.ZCheckDateEdit(dateEdit1, "الرجاء ادخال تاريخ التحويل")) return;
            if(!ZEntry.ShowQuestionNew(this,"هل أنت متأكد من تحويل السجين؟"))  return;
            Zcustdy = txtCustdy.Text;
            ZNotes = txtNotes.Text;
            ZDate = dateEdit1.DateTime;
            DialogResult = System.Windows.Forms.DialogResult.OK;


        }
    }
}