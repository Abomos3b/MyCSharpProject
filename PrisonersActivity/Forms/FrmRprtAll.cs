using PrisonersActivity.BE;
using System;
using System.Data;
using ZGTools;
using ZGTools.Forms;
using ZGTools.ZTools;

namespace PrisonersActivity.Forms
{
    public partial class FrmRprtAll : ZForm
    {
        public FrmRprtAll()
        {
            InitializeComponent();
        }

        private void FrmRprtAll_Load(object sender, EventArgs e)
        {
            HanleOtherControls(false);
            zGridView1.ZRowsFormatOddEven();
            zGridView1.OptionsView.ColumnAutoWidth = false;
            zGridView1.ZFormatFontsAll(btnExport.Font);
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "المحذوفين");
            dt.Rows.Add(2, "المفرج عنهم");
            dt.Rows.Add(3, "القائمين");
            dt.Rows.Add(4, "المنقولين تم الصرف لهم");
            dt.Rows.Add(5, "المنقولين لم يتم الصرف لهم");

            zSearchLookupedit1.ZSetup(dt,"Id","Name","نوع التقرير", btnExport.Font, ["Id"], new System.Collections.Generic.Dictionary<string, string> { { "Name","التقرير"} });

        }

        private void HanleOtherControls(bool b)
        {
            zDatesRangeH1.Visible = b;
            btnExport.Visible = b;
            btnLoad.Visible = b;
            btnPrint.Visible = b;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (zSearchLookupedit1.EditValue == null)
            {
                ZEntry.ShowErrorMessage("اختر نوع التقرير");
                zSearchLookupedit1.Focus();
                zSearchLookupedit1.ShowPopup();
                return;
            }
            var dates = "الكل";
            if (zDatesRangeH1.ZResult != null)
            {
                dates = zDatesRangeH1.D1.ToString("yyyy-MM-dd") + " " + zDatesRangeH1.D2.ToString("yyyy-MM-dd");
            }
            zGridView1.ZExportToExcel((zSearchLookupedit1.ZGetColumnDisplayMember() ?? "") + dates, true, true);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            zGridView1.ZResetBeforeDatasource();
            if (!ZEntry.ZCheckSrchlookup(zSearchLookupedit1, "اختر نوع البحث")) return;

            var typeid = Convert.ToInt32(zSearchLookupedit1.EditValue);
            var txtq = typeid switch
            {
                1 => GetAll(false, false),
                2 => GetAll(true, true),
                3 => GetAll(true, false),
                4 => GetTransferre(true),
                5 => GetTransferre(false),
                _ => @""
            };
            var dt = new Dal().Select(txtq);
            zGridControl1.DataSource = dt;
            zGridView1.ZAddSequenceColumnWithFooter();
            zGridView1.Columns["transdate"].Caption = typeid switch
            {
                1 => @"تاريخ الحذف",
                2 => @"تاريخ الخروج",
                3 => @"تاريخ الدخول",
                4 => @"تاريخ الصرف",
                5 => @"تاريخ النقل",
                _ => zGridView1.Columns["transdate"].Caption
            };
            zGridView1.ZColHandle("CompNumber", "رقم الحاسب الآلي");
            zGridView1.ZColHandle("pName", "اسم السجين");
            zGridView1.ZColHandle("enterdate", "تاريخ الدخول");
            zGridView1.ZColHandle("idno", "رقم الهوية");
            zGridView1.ZColHandle("outdate", "تاريخ الخروج");
            zGridView1.ZColHandle("SuidName", "الجناح");

            zGridView1.ZColHandle("nationalityname", "الجنسية");
            zGridView1.ZColHandle("totaldays", "الأيام");
            zGridView1.BestFitColumns();
            zGridView1.ZClearFocus();
        }

        private string GetTransferre(bool isdone)
        {
            var dates = "";
            var datefilter = !isdone ? "m.outdate" : "tm.donedate";
            if (zDatesRangeH1.ZResult != null)
            {

                dates = $@" and {datefilter} between '{zDatesRangeH1.D1:yyyy-MM-dd}' and '{zDatesRangeH1.D2:yyyy-MM-dd}'";

            }
            return $@"
select m.compnumber CompNumber, m.pname pName, m.nationadlid idno
, n.nationalityname nationalityname, m.enterdate enterdate
, {datefilter} transdate
, case when  m.outdate is not null  then 
Cast ((JulianDay(m.outdate) - JulianDay(m.enterdate)) As Integer)
else 
Cast ((JulianDay(DATE('now')) - JulianDay(m.enterdate)) As Integer) 
end totaldays
, m.SuidName
from tblMainTemp tm 
inner join tblMain m on tm.mainid= m.id
left outer join tblnationalities n on m.nationalityid= n.nationalityid
where m.istransferd=1
and tm.isdone= {isdone}
{dates}  
order by {datefilter} desc";
        }

        private string GetAll(bool isactive, bool isout)
        {
            var dates = "";
            var datefilter = isactive && isout ? "m.outdate" : isactive ? "m.enterdate" : "m.deactivateddate";
            if (zDatesRangeH1.ZResult != null)
            {
               
                dates = $@" and {datefilter} between '{zDatesRangeH1.D1:yyyy-MM-dd}' and '{zDatesRangeH1.D2:yyyy-MM-dd}'";

            }
            return $@"
select m.compnumber CompNumber, m.pname pName, m.nationadlid idno
, n.nationalityname nationalityname, m.enterdate enterdate
, {datefilter} transdate
, case when  m.outdate is not null  then 
Cast ((JulianDay(m.outdate) - JulianDay(m.enterdate)) As Integer)
else 
Cast ((JulianDay(DATE('now')) - JulianDay(m.enterdate)) As Integer) 
end totaldays
, m.SuidName
from tblMain m
left outer join tblnationalities n on m.nationalityid= n.nationalityid
where m.isactive={isactive}
{(isout ? "and m.IsOut=true " : "")}
{dates}  
order by {datefilter} desc";
        }

        private void zSearchLookupedit1_EditValueChanged(object sender, EventArgs e)
        {
            HanleOtherControls(zSearchLookupedit1.EditValue != null);
            zGridControl1.DataSource=null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            zGridView1.ZClearBeforeSaving();
            if(zSearchLookupedit1.EditValue==null)
            {
                ZEntry.ShowErrorMessage("اختر نوع التقرير");
                zSearchLookupedit1.Focus();
                zSearchLookupedit1.ShowPopup();
                return;
            }

            if (zGridControl1.DataSource is not DataTable { Rows.Count: > 0 } dt)
            {
                ZEntry.ShowErrorMessage("لا يوجد بيانات للطباعة");
                return;
            }

            var ds = new DataSet1();


            foreach (DataRow dr in dt.Rows)
            {
                ds.dtAll.Rows.Add();
                var li = ds.dtAll.Rows.Count - 1;
                ds.dtAll.Rows[li]["seq"] = 1;
                ds.dtAll.Rows[li]["CompNumber"] = dr["CompNumber"];
                ds.dtAll.Rows[li]["pName"] = dr["pName"];
                ds.dtAll.Rows[li]["idno"] = dr["idno"];
                ds.dtAll.Rows[li]["nationalityname"] = dr["nationalityname"];
                ds.dtAll.Rows[li]["enterdate"] = dr["enterdate"];
                ds.dtAll.Rows[li]["transdate"] = dr["transdate"];
                ds.dtAll.Rows[li]["totaldays"] = dr["totaldays"];
            }
            var rt = new RprtAllData(zGridView1.Columns["transdate"].Caption);
            rt.DataSource = ds;
            rt.Parameters["par1"].Value = ClsVarslocal.Settings.ReportHeader;
            var det =zSearchLookupedit1.ZGetColumnDisplayMember().ToString();
           
            det += $@" {ClsVarslocal.Settings.PrisonName} ";
            if (zDatesRangeH1.ZResult != null)
            {
                det += $@" من تاريخ {zDatesRangeH1.D1:yyyy/MM/dd} م  إلى تاريخ {zDatesRangeH1.D2:yyyy/MM/dd} م";
            }
            

            rt.Parameters["par2"].Value = $@"({det})";
            rt.Parameters["par3"].Value = "عدد السجلات: " + dt.Rows.Count;


            var frm = new FrmPrintPreviewSingle(rt, zSearchLookupedit1.ZGetColumnDisplayMember().ToString()) { ZAllowDuplicate=true };
            FrmHomePage.GetInstance().ClsZMdiDocMgr.SetChild(frm);
        }
    }
}