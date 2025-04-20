using PrisonersActivity.BE;
using System;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using ZGTools.ZTools;
using ZGTools;
using ZGTools.Forms;
using ZGTools.ZExtensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZGTools.Funs;

namespace PrisonersActivity.Forms
{
    public partial class FrmPrisonersList : ZForm
    {
        public FrmPrisonersList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddNew();
            frm.ShowDialog();
            if (frm.ZAddedNew > 0) LoadData();
        }

        private void LoadData()
        {
            zGridView1.ZClearBeforeSaving();
            zGridView1.ZResetBeforeDatasource();
            if (dateEdit1.EditValue == null)
            {
                ZEntry.ShowErrorMessage("الرجاء اختيار الشهر أولا");
                return;
            }


            var txtq = $@"SELECT m.id, m.compnumber,m.pname,m.nationadlid, m.enterdate
, m.outdate   , n.nationalityname nationality, (select nt2.note from tblNotes nt2 where 
nt2.pid=m.id
order by nt2.id desc
limit 1
) note
, m.isout IsOutCol
, m.SuidName
FROM
  tblMain m
left outer join tblnationalities n on m.nationalityid= n.nationalityid
WHERE
  m.isactive = true and m.istransferd=false and m.isout=false and enterdate<'{dateEdit1.DateTime:yyyy-MM-dd}'  
  or 
  m.isactive = true and m.istransferd=false and m.isout=true and m.OutMonth={dateEdit1.DateTime.Month} and m.outYear={dateEdit1.DateTime.Year}
  
ORDER BY m.isout, m.id
";
            var dt = new Dal().Select(txtq);
            dt.Columns.Add("DaysInThisMonth", typeof(int));
            DateTime lastdatetocompare;
            int daysinmonth;
            if (Convert.ToInt32(dateEdit1.DateTime.ToString("yyyyMM")) < Convert.ToInt32(DateTime.Today.ToString("yyyyMM")))
            {
                lastdatetocompare = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, DateTime.DaysInMonth(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month));
                daysinmonth = DateTime.DaysInMonth(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month);
            }
            else
            {
                lastdatetocompare = DateTime.Today;
                daysinmonth = DateTime.Today.Day;
            }


            foreach (DataRow dr in dt.Rows)
            {

                var indate = Convert.ToDateTime(dr["enterdate"]);
                var outdate = dr["outdate"] is DBNull ? lastdatetocompare : Convert.ToDateTime(dr["outdate"]);
                if (dr["outdate"] is not DBNull && Convert.ToDateTime(dr["outdate"]) <= DateTime.Today && dateEdit1.DateTime.Year == DateTime.Today.Year && dateEdit1.DateTime.Month == DateTime.Today.Month)
                {
                    dr["DaysInThisMonth"] = (Convert.ToDateTime(dr["outdate"]) - new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).Days;
                }
                else
                {
                    var daysinjail = (outdate - indate).Days;
                    if (daysinjail >= daysinmonth) daysinjail = daysinmonth;
                    dr["DaysInThisMonth"] = daysinjail;
                }



            }

            zGridControl1.DataSource = dt;

            zGridView1.ZColHandle("compnumber", "رقم الحاسب الآلي");
            zGridView1.ZColHandle("pname", "اسم السجين");
            zGridView1.ZColHandle("enterdate", "تاريخ الدخول");
            zGridView1.ZColHandle("outdate", "تاريخ الخروج");
            zGridView1.ZColHandle("nationality", "الجنسية");
            zGridView1.ZColHandle("nationadlid", "رقم الهوية");
            zGridView1.ZColHandle("note", "ملاحظات");
            zGridView1.ZColHandle("DaysInThisMonth", "عدد أيام الإعاشة");
            zGridView1.ZColHandle("IsOutCol", "مفرج عنه");
            zGridView1.ZColHandle("SuidName", "الجناح");
            zGridView1.ZAddCalculatedColumn("ColSum", "إجمالي الإعاشة", DevExpress.Data.UnboundColumnType.Decimal, $@"[DaysInThisMonth]*{ClsVarslocal.Settings.DayAmount}", 2, 9);
            zGridView1.Columns["note"].VisibleIndex = 11;
            zGridView1.ZConditoionalFormatAddRed("IsOutCol", "[IsOutCol]=true", true);
            zGridView1.ZColumnAddSummary("ColSum");

            zGridView1.ZHideColumn("id");
            zGridView1.ZAddSequenceColumnWithFooter();
            zGridView1.BestFitColumns();


            zGridView1.ZClearFocus();


        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            zGridView1.OptionsView.ColumnAutoWidth = false;
            zGridView1.ZRowsFormatOddEven();
            zGridView1.ZFormatFontsAll(btnAdd.Font);
            zGridView1.PopupMenuShowing += ZGridView1_PopupMenuShowing;
            zGridView1.OptionsBehavior.Editable = false;
            zGridView1.OptionsBehavior.ReadOnly = true;
            dateEdit1.Properties.Mask.EditMask = @"Y";
            dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            dateEdit1.EditValue = DateTime.Today;
            dateEdit1.Properties.MaxValue = DateTime.Today;
            zGridView1.OptionsFind.AlwaysVisible = true;
        }



        private void ZGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType is not GridMenuType.Row ||
                e.HitInfo?.HitTest != DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell ||
                zGridControl1.DataSource == null ||
                zGridView1.GetFocusedDataRow() is not { } dr) return;


            zGridView1.ZAddMenuItem("تعديل بيانات السجين", null, "dashboards/editnames;Size16x16", (_, _) =>
            {
                var id = Convert.ToInt32(dr["id"]);
                var frm = new FrmAddNew(id);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dr["compnumber"] = frm.ZCompNo;
                    dr["pname"] = frm.ZName;
                    dr["nationadlid"] = frm.ZId;
                    dr["enterdate"] = frm.ZEnterDate;
                    dr["nationality"]= frm.ZNationality;
                    dr["SuidName"] = frm.ZSuidName;
                    dr["note"]= frm.Znotes;

                }


            }, false, e);


            zGridView1.ZAddMenuItem("حذف السجين", null, "icon%20builder/actions_delete;Size16x16", (_, _) =>
            {
                var pname = dr["pname"].ToString();
                var compnumber = dr["compnumber"].ToString();
                var msg = "هل أنت متأكد من حذف السجين: " + pname + " رقم الحاسب الآلي: " + compnumber;
                if (!ZEntry.ShowQuestionNew(this, msg)) return;
                var txtq = $@"UPDATE tblMain SET isactive = false, deactivateddate='{DateTime.Today:yyyy-MM-dd}' WHERE id = {dr["id"]}";
                new Dal().ExcuteCommand(txtq);
                LoadData();
                ZEntry.ShowAlert("تم الحذف بنجاح");

            }, false, e);
            if (dr["outdate"] == null || dr["outdate"] is DBNull)
            {
                zGridView1.ZAddMenuItem("تسجيل خروج السجين", null, "outlook%20inspired/arrowbearleft;Size16x16", (_, _) =>
                {

                    var date = ZEntry.ShowMessageDate("تاريخ الخروج", "الرجاء ادخال تاريخ الخروج", mindate: Convert.ToDateTime(dr["enterdate"]), maxDate: DateTime.Today);
                    if (date == null) return;

                    var pname = dr["pname"].ToString();
                    var compnumber = dr["compnumber"].ToString();
                    var msg = "هل أنت متأكد من تسجيل خروج السجين: " + pname + " رقم الحاسب الآلي: " + compnumber;
                    if (!ZEntry.ShowQuestionNew(this, msg)) return;
                    var txtq = $@"UPDATE tblMain SET outdate = '{date:yyyy-MM-dd}', IsOut=true,OutMonth={date.Value.Month}, outYear={date.Value.Year} WHERE id = {dr["id"]}";
                    new Dal().ExcuteCommand(txtq);
                    LoadData();
                    ZEntry.ShowAlert("تم تسجيل الخروج بنجاح");

                }, true, e);


                zGridView1.ZAddMenuItem("تحويل السجين", null, "business%20objects/bo_transition;Size16x16", (_, _) =>
                {


                    var pname = dr["pname"].ToString();
                    var compnumber = dr["compnumber"].ToString();
                    var ampunt = Convert.ToInt32(dr["DaysInThisMonth"]) * ClsVarslocal.Settings.DayAmount;
                    var idno = dr["nationadlid"].ToString();
                    var frm = new FrmTransfer(pname, compnumber, idno, ampunt) { StartPosition = System.Windows.Forms.FormStartPosition.CenterParent };
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                    new Dal().ExcuteCommand($@"update tblMain set istransferd=true, outdate = '{frm.ZDate:yyyy-MM-dd}', IsOut=true,OutMonth={frm.ZDate.Month}, outYear={frm.ZDate.Year} where id = {dr["id"]}");
                    new Dal().ExcuteCommand($@"INSERT INTO tblMainTemp
    (mainid, dayscount, custodyoffice, custodynotes, isdone, donedate, donenotes, totalamount, transfereddate, userdate)
VALUES
    ( {dr["id"]}, {Convert.ToInt32(dr["DaysInThisMonth"])}, '{frm.Zcustdy}', '{frm.ZNotes}', false, null, null, {ampunt},  '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{frm.ZDate:yyyy-MM-dd}')");
                    LoadData();
                    ZEntry.ShowAlert("تم تحويل السجين بنجاح");

                }, true, e);
            }


            zGridView1.ZAddMenuItem("إضافة ملاحظات", null, "snap/snapinsertheader;Size16x16", (_, _) =>
            {
                var frm = new FrmTextInput(150, "الملاحظات");

                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK || frm.ZText == null || frm.ZText.Trim().Length <= 0 || !ZEntry.ShowQuestionNew(this, "هل أنت متأكد من إضافة الملاحظات؟")) return;
                var txtq1 = $@"INSERT INTO tblNotes (pid, note, addedddate) VALUES ({dr["id"]}, '{frm.ZText.ZForSqlTruncate(149)}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
                new Dal().ExcuteCommand(txtq1);
                dr["note"] = frm.ZText;

                ZEntry.ShowAlert("تم إضافة الملاحظات بنجاح");

            }, true, e);
            zGridView1.ZAddMenuItem("عرض الملاحظات", null, "business%20objects/bo_note;Size16x16", (_, _) =>
            {
                var dt = new Dal().Select($@"select n.addedddate, n.note from tblNotes n 
where n.pid=
            {dr["id"]}
order by n.id desc
            ");

                if (dt is not { Rows.Count: > 0 })
                {
                    ZEntry.ShowErrorMessage("لا يوجد ملاحظات");
                    return;
                }
                var frm = new FrmZShowDt(dt, "ملاحظات " + dr["nationadlid"], new ReadOnlyDictionary<string, string>(new Dictionary<string, string> { { "addedddate", "تاريخ الإضافة" }, { "note", "الملاحظات" } }));
                string zuniqe = "frmnotes_" + dr["id"];
                frm.ZUniqueName = zuniqe;
                FrmHomePage.GetInstance().ClsZMdiDocMgr.SetChild(frm);
                var tip = new ZFormTip
                {
                    Header = @"الاسم= " + dr["pname"],
                    C1 = @"هوية=" + dr["nationadlid"],
                    C2 = @"رقم حاسب آلي=" + dr["compnumber"]
                };

                FrmHomePage.GetInstance().ClsZMdiDocMgr.FrmUpdateZtoolTip(zuniqe, tip);

            }, false, e);

        }

        private void btnReaload_Click(object sender, EventArgs e) => LoadData();

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue == null || zGridControl1.DataSource is not DataTable { Rows.Count: > 0 })
            {
                ZEntry.ShowErrorMessage("اختر التاريخ ويجب ان توجد بيانات");
                return;
            }
            zGridView1.ZExportToExcel("الإعاشة لشهر " + dateEdit1.DateTime.ToString("yyyy-MM"), simplebrowse: true);
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            zGridView1.ZClearBeforeSaving();
            if (dateEdit1.EditValue == null)
            {
                ZEntry.ShowErrorMessage("الرجاء اختيار الشهر أولا");
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
                ds.dtPrisiners.Rows.Add();
                var li = ds.dtPrisiners.Rows.Count - 1;
                ds.dtPrisiners.Rows[li]["seq"] = 1;
                ds.dtPrisiners.Rows[li]["CompNumber"] = dr["compnumber"];
                ds.dtPrisiners.Rows[li]["pName"] = dr["pname"];
                ds.dtPrisiners.Rows[li]["EnterDate"] = dr["enterdate"];
                ds.dtPrisiners.Rows[li]["TotalAmount"] = Convert.ToInt32(dr["DaysInThisMonth"]) * ClsVarslocal.Settings.DayAmount;
            }
            var rt = new RprtPrisoners();
            rt.DataSource = ds;
            rt.Parameters["par1"].Value = ClsVarslocal.Settings.ReportHeader;
            var det = @"إعاشة السجناء بإدارة ";
            det += $@"{ClsVarslocal.Settings.PrisonName} ";
            det += $@"من تاريخ {new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1):yyyy/MM/dd} م  ";
            det += $@"إلى تاريخ {new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, DateTime.DaysInMonth(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month)):yyyy/MM/dd} م";

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


            var frm = new FrmPrintPreviewSingle(rt, "الإعاشة");
            FrmHomePage.GetInstance().ClsZMdiDocMgr.SetChild(frm);



        }



        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            zGridView1.ZClearBeforeSaving();
            zGridView1.ZResetBeforeDatasource();
        }
    }

}