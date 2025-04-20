using System;
using PrisonersActivity.BE;
using ZGTools;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmSettings : ZForm
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            txtDayAmount.Text = ClsVarslocal.Settings.DayAmount.ToString("0.##");
            txtFooter1.Text = ClsVarslocal.Settings.Footer1;
            txtFooter2.Text = ClsVarslocal.Settings.Footer2;
            txtFooter3.Text = ClsVarslocal.Settings.Footer3;
            txtFooter4.Text = ClsVarslocal.Settings.Footer4;
            txtPrisonName.Text = ClsVarslocal.Settings.PrisonName;
            txtFooter1Teir.Text = ClsVarslocal.Settings.Footer1Teir;
            txtFooter2Teir.Text = ClsVarslocal.Settings.Footer2Teir;
            txtFooter3Teir.Text = ClsVarslocal.Settings.Footer3Teir;
            txtFooter4Teir.Text = ClsVarslocal.Settings.Footer4Teir;
            txtReportHeader.Text = ClsVarslocal.Settings.ReportHeader;
            checkEdit1.Checked= ClsVarslocal.Settings.CanRepeatCompNum;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(!ZEntry.ZCheckTextBoxDecimal(txtDayAmount.Text, ZGTools.Funs.ZEnums.ZTextEditcheckStatus.ZeroOrLessThanzero, out var realamout))
            {
                ZEntry.ShowErrorMessage("يجب ادخال قيمة اليومية بشكل صحيح");
                txtDayAmount.Focus();
                return;
            }
            if(!ZEntry.ZCheckTextBoxString(txtPrisonName,"الرجاء ادخال اسم السجن ")) return;
            if (!ZEntry.ZCheckTextBoxString(txtFooter1, "الرجاء ادخال "+ layoutControlItem3.Text)) return;
            if (!ZEntry.ZCheckTextBoxString(txtFooter2, "الرجاء ادخال " + layoutControlItem4.Text)) return;
            if (!ZEntry.ZCheckTextBoxString(txtFooter3, "الرجاء ادخال " + layoutControlItem5.Text)) return;

            if(!ZEntry.ZCheckTextBoxString(txtFooter1Teir, "الرجاء ادخال رتبة " + layoutControlItem3.Text)) return;
            if (!ZEntry.ZCheckTextBoxString(txtFooter2Teir, "الرجاء ادخال رتبة " + layoutControlItem4.Text)) return;
            if (!ZEntry.ZCheckTextBoxString(txtFooter3Teir, "الرجاء ادخال رتبة " + layoutControlItem5.Text)) return;
            if(!ZEntry.ShowQuestionNew(this,"هل أنت متأكد من الحفظ؟")) return;
            var dl = new Dal();
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{realamout:0.##}' where setName = 'DayAmount'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtPrisonName.Text}' where setName = 'PrisonName'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter1.Text}' where setName = 'Footer1'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter2.Text}' where setName = 'Footer2'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter3.Text}' where setName = 'Footer3'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter4.Text}' where setName = 'Footer4'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter1Teir.Text}' where setName = 'Footer1Teir'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter2Teir.Text}' where setName = 'Footer2Teir'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter3Teir.Text}' where setName = 'Footer3Teir'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtFooter4Teir.Text}' where setName = 'Footer4Teir'");
            dl.ExcuteCommand($@"UPDATE tblsettings SET setval = '{txtReportHeader.Text}' where setName = 'ReportHeader'");
            var txtss= $@"UPDATE tblsettings SET setval = '{(checkEdit1.Checked ? 1 : 0)}' where setName = 'CanRepeatCompNum'";
            dl.ExcuteCommand(txtss);
            ClsVarslocal.LoadSettings();
            ZEntry.ShowAlert("تم الحفظ بنجاح");
            Close();

        }
    }
}