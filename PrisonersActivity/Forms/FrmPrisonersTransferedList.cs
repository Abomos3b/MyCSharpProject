using DevExpress.XtraGrid.Views.Grid;
using PrisonersActivity.BE;
using System;
using System.Collections.Generic;
using System.Data;
using ZGTools;
using ZGTools.Forms;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmPrisonersTransferedList : ZForm
    {
        public FrmPrisonersTransferedList()
        {
            InitializeComponent();
        }

        private void FrmPrisonersTransferedList_Load(object sender, EventArgs e)
        {
            zGridView1.ZRowsFormatOddEven();
            zGridView1.OptionsView.ColumnAutoWidth = false;
            zGridView1.ZFormatFontsAll(btnExport.Font);
            zGridView1.OptionsFind.AlwaysVisible=true;
            var dt= new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "لم يتم الصرف");
            dt.Rows.Add(2, "تم الصرف");
            dt.Rows.Add(3, "الكل");
            zSearchLookupedit1.ZSetup(dt, "Id","Name","اختر نوع البحث", btnExport.Font, ["Id"], new Dictionary<string, string> { { "Name","النوع"} });
            zSearchLookupedit1.EditValue=1;
            zGridView1.PopupMenuShowing += ZGridView1_PopupMenuShowing;
        }

        private void ZGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType is not GridMenuType.Row ||
                e.HitInfo?.HitTest != DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell ||
                zGridControl1.DataSource == null ||
                zGridView1.GetFocusedDataRow() is not { } dr) return;

            if (!Convert.ToBoolean(dr["isdone"]))
            {
                zGridView1.ZAddMenuItem("صرف المبلغ للسجين", null, "spreadsheet/financial;Size16x16", (_, _) =>
                {
                    var frm = new FrmTextInput(250, "الملاحظات");
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;


                    var pname = dr["pname"].ToString();
                    var compnumber = dr["compnumber"].ToString();
                    var msg = "هل أنت صرف المبلغ للسجين: " + pname + " رقم الحاسب الآلي: " + compnumber;
                    if (!ZEntry.ShowQuestionNew(this, msg)) return;
                    var txtq = $@"UPDATE tblMainTemp SET isdone = true, donedate='{DateTime.Today:yyyy-MM-dd}', donenotes='{frm.ZText}' WHERE tempid = {dr["tempid"]}";
                    new Dal().ExcuteCommand(txtq);
                    Print(dr);
                    LoadData();
                    ZEntry.ShowAlert("تم السداد بنجاح");

                }, false, e);
            }

            


        }

        private void Print(DataRow dr)
        {
            var ds = new DataSet1();
            ds.dtPrisiners.Rows.Add();
            var li = ds.dtPrisiners.Rows.Count - 1;
            ds.dtPrisiners.Rows[li]["seq"] = 1;
            ds.dtPrisiners.Rows[li]["CompNumber"] = dr["compnumber"];
            ds.dtPrisiners.Rows[li]["pName"] = dr["pname"];
            ds.dtPrisiners.Rows[li]["EnterDate"] = DateTime.Today;
            ds.dtPrisiners.Rows[li]["TotalAmount"] = dr["totalamount"];

             
            var rt = new RprtPrisoners("تاريخ الصرف");
            rt.DataSource = ds;
            rt.Parameters["par1"].Value = ClsVarslocal.Settings.ReportHeader;
            var det = @"صرف السجناء بإدارة ";
            det += $@"{ClsVarslocal.Settings.PrisonName} ";
            rt.Parameters["par2"].Value = $@"({det})";
            rt.Parameters["par3"].Value = ClsVarslocal.Settings.Footer1;
            rt.Parameters["par4"].Value = ClsVarslocal.Settings.Footer1Teir;
            rt.Parameters["par5"].Value = ClsVarslocal.Settings.Footer2;
            rt.Parameters["par6"].Value = ClsVarslocal.Settings.Footer2Teir;
            rt.Parameters["par7"].Value = ClsVarslocal.Settings.Footer3;
            rt.Parameters["par8"].Value = ClsVarslocal.Settings.Footer3Teir;
            rt.Parameters["par9"].Value = ClsVarslocal.Settings.Footer4;
            rt.Parameters["par10"].Value = ClsVarslocal.Settings.Footer4Teir;
            rt.Parameters["par11"].Value = "عدد السجلات: " + 1;
            var frm = new FrmPrintPreviewSingle(rt, "السداد");
            FrmHomePage.GetInstance().ClsZMdiDocMgr.SetChild(frm);
        }

        private void zSearchLookupedit1_EditValueChanged(object sender, EventArgs e)
        {
            zGridView1.ZResetBeforeDatasource();
        }

        private void btnLoad_Click(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            zGridView1.ZResetBeforeDatasource();
            if (!ZEntry.ZCheckSrchlookup(zSearchLookupedit1, "اختر نوع البحث")) return;

            var type = Convert.ToInt32(zSearchLookupedit1.EditValue);
            var txtfilter = type switch
            {
                1 => " where isdone=false",
                2 => " where isdone=true",
                _ => ""
            };

            var txtMain = $@"
select m.id, m.compnumber,m.pname,m.nationadlid, m.enterdate, n.nationalityname
, mt.dayscount, mt.totalamount
, mt.custodyoffice, mt.custodynotes
, mt.isdone
, mt.donedate
, mt.donenotes
, mt.tempid
 from tblMainTemp mt 
inner join tblMain m on mt.mainid= m.id
left outer join tblnationalities n on m.nationalityid= n.nationalityid
{txtfilter}
order by mt.tempid";
            zGridControl1.DataSource = new Dal().Select(txtMain);
            zGridView1.ZAddSequenceColumnWithFooter();
            zGridView1.ZHideColumns(["id", "tempid"]);
            zGridView1.ZColHandle("compnumber", "رقم الحاسب الآلي");
            zGridView1.ZColHandle("pname", "اسم السجين");
            zGridView1.ZColHandle("enterdate", "تاريخ الدخول");
            zGridView1.ZColHandle("nationality", "الجنسية");
            zGridView1.ZColHandle("nationadlid", "رقم الهوية");
            zGridView1.ZColHandle("custodyoffice", "المسؤول");
            zGridView1.ZColHandle("custodynotes", "ملاحظات النقل");
            zGridView1.ZColHandle("isdone", "تم الصرف");
            zGridView1.ZColHandle("donedate", "تاريخ الصرف");
            zGridView1.ZColHandle("donenotes", "ملاحظات الصرف");
            zGridView1.ZColHandle("totalamount", "المبلغ");
            zGridView1.ZColHandle("dayscount", "الايام");
            zGridView1.ZColHandle("nationalityname", "الجنسية");
            zGridView1.ZConditoionalFormatAddRed("isdone", "[isdone]=false", false);
            zGridView1.ZConditoionalFormatAddGreen("isdone", "[isdone]=true", false);

           


            zGridView1.BestFitColumns();
            zGridView1.ZClearFocus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!ZEntry.ZCheckSrchlookup(zSearchLookupedit1, "اختر نوع البحث")) return;
            zGridView1.ZClearBeforeSaving();
            if(zGridControl1.DataSource is not DataTable { Rows.Count:> 0 } dt)
            {
                ZEntry.ShowErrorMessage("لا يوجد بيانات للطباعة", "خطأ", true);
                return;
            }
            int typeid= Convert.ToInt32(zSearchLookupedit1.EditValue);
            string caption = typeid switch
            {
                1 => "تاريخ النقل",
                2 => "تاريخ الصرف",
                _ => "الصرف/ النقل"
            };
            var ds = new DataSet1();

            foreach (DataRow dr in dt.Rows)
            {
                ds.dtPrisiners.Rows.Add();
                var li = ds.dtPrisiners.Rows.Count - 1;
                ds.dtPrisiners.Rows[li]["seq"] = 1;
                ds.dtPrisiners.Rows[li]["CompNumber"] = dr["compnumber"];
                ds.dtPrisiners.Rows[li]["pName"] = dr["pname"];
                ds.dtPrisiners.Rows[li]["EnterDate"] = DateTime.Today;
                ds.dtPrisiners.Rows[li]["TotalAmount"] = dr["totalamount"];
                ds.dtPrisiners.Rows[li]["Signature"] = Convert.ToBoolean(dr["isdone"])?"نعم":"لا";

            }

            var rt = new RprtPrisoners(caption, "تم الصرف");
            rt.DataSource = ds;
            rt.Parameters["par1"].Value = ClsVarslocal.Settings.ReportHeader;
            var det = zSearchLookupedit1.ZGetColumnDisplayMember().ToString();
            det += $@" {ClsVarslocal.Settings.PrisonName} ";
            rt.Parameters["par2"].Value = $@"({det})";
            rt.Parameters["par3"].Value = ClsVarslocal.Settings.Footer1;
            rt.Parameters["par4"].Value = ClsVarslocal.Settings.Footer1Teir;
            rt.Parameters["par5"].Value = ClsVarslocal.Settings.Footer2;
            rt.Parameters["par6"].Value = ClsVarslocal.Settings.Footer2Teir;
            rt.Parameters["par7"].Value = ClsVarslocal.Settings.Footer3;
            rt.Parameters["par8"].Value = ClsVarslocal.Settings.Footer3Teir;
            rt.Parameters["par9"].Value = ClsVarslocal.Settings.Footer4;
            rt.Parameters["par10"].Value = ClsVarslocal.Settings.Footer4Teir;
            rt.Parameters["par11"].Value = "عدد السجلات: " + dt.Rows.Count;
            var frm = new FrmPrintPreviewSingle(rt, zSearchLookupedit1.ZGetColumnDisplayMember().ToString());
            FrmHomePage.GetInstance().ClsZMdiDocMgr.SetChild(frm);
        }
    }
}