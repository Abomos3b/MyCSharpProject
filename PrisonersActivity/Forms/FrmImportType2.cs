using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using PrisonersActivity.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using ZGTools.ZTools;
using ZGTools;
using ZGTools.ZExtensions;
using System.Globalization;

namespace PrisonersActivity.Forms
{
    public partial class FrmImportType2 : ZForm
    {
        private DataTable _dtImportedItems;
        private DataTable _dtLive;
        public int ZAdd { get; private set; }
        private List<string> _complst = [];
        private List<string> _nationalidlst = [];
        private bool _check = true;
        private DataTable _dtnatio;

        public FrmImportType2()
        {
            InitializeComponent();
        }

        private void FrmImport_Load(object sender, EventArgs e)
        {
            zGridView1.OptionsView.ColumnAutoWidth = false;
            zGridView1.ZRowsFormatOddEven();
            zGridView1.ZFormatFontsAll(btnSave.Font);
            progressBarControl1.CustomDisplayText += ProgressBarControl1_CustomDisplayText;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            backgroundWorker2.DoWork += BackgroundWorker2_DoWork;
            backgroundWorker2.RunWorkerCompleted += BackgroundWorker2_RunWorkerCompleted;

            zGridView1.CustomSummaryCalculate += ZGridView1_CustomSummaryCalculate;

        }

        private void ZGridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (sender is not ZGridView { GridControl.DataSource: DataTable { Rows.Count: > 0 } dt }) return;
            switch (e.SummaryProcess)
            {
                case CustomSummaryProcess.Start:
                    e.TotalValue = 0;
                    return;
                case CustomSummaryProcess.Finalize:
                    if (e.Item is GridSummaryItem { FieldName: "IsValid" } newitem)
                    {
                        var valid = dt.Select("IsValid=false");
                        e.TotalValue = valid.Length;
                        newitem.DisplayFormat = $@"غير صالح: {valid.Length}";
                    }
                    break;
            }
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ZEntry.ZSafeInvoke(this, () =>
            {

                progressBarControl1.Visible = false;
                zGridControl1.DataSource = null;
                ZEntry.ShowAlert("تم الحفظ بنجاح");
            });
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var dl = new Dal();
            _dtnatio = new Db().GetNationalities();
            foreach (DataRow dr in _dtImportedItems.Rows)
            {
                if(!Convert.ToBoolean(dr["IsValid"])) continue;
                 

                var compuretnum = dr[0].ToString().ZForSqlTruncate(50);
                var name = dr[1].ToString().ZForSqlTruncate(150);
                var suitno = dr[2].ToString().ZForSqlTruncate(50);
                var nationalid = dr[3].ToString().ZForSqlTruncate(50);
                var nationality = dr[4].ToString();
                var datein = dr[5].ToString();
                var dateout = dr[6].ToString();
                var isOut = "false";
                var outmonth = 0;
                var outyear = 0;
                var dateoutdate = "null";



                if (dateout.Trim().Length > 0 && DateTime.TryParse(dateout, out _))
                {
                    isOut = "true";
                    outmonth = Convert.ToDateTime(dateout).Month;
                    outyear = Convert.ToDateTime(dateout).Year;
                    dateoutdate = $"'{Convert.ToDateTime(dateout):yyyy-MM-dd}'";
                }
                var nationalityid = 0;
                if (nationality.Trim().Length > 0)
                {
                    var drs = _dtnatio.Select($"nationalityname='{nationality}'");
                    if (drs.Length > 0) nationalityid = Convert.ToInt32(drs[0]["nationalityid"]);
                }

                ZEntry.ZSafeInvoke(this, progressBarControl1.PerformStep);
                var txtq = $@"INSERT INTO tblMain
    ( compnumber, pname,  enterdate,  isactive, IsOut, OutMonth, outYear, outdate, nationadlid, nationalityid, istransferd, SuidName)
VALUES
    ('{compuretnum}', '{name}',  '{Convert.ToDateTime(datein):yyyy-MM-dd}',  true, {isOut}, {outmonth}, {outyear}, {dateoutdate}, '{nationalid}', {(nationalityid < 0 ? "NULL" : nationalityid)}, false, '{suitno}')";
                dl.ExcuteCommand(txtq);
                ZEntry.ZSafeInvoke(this, () => dr["Status"] = "تم");
                ZAdd++;

            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           

            ZEntry.ZSafeInvoke(this, () =>
            {
                progressBarControl1.Visible = false;
                zGridControl1.DataSource = _dtImportedItems;
                zGridView1.ZClearBeforeSaving();
                if (!zGridView1.ZLoadedBefore)
                {
                    zGridView1.ZConditoionalFormatAddRed("IsValid", "IsValid=false", true);
                    zGridView1.ZConditoionalFormatAddGreen("IsValid", "Status='تم'", true);
                    zGridView1.ZColHandle("IsValid", "صف صالح");
                    zGridView1.ZColHandle("Status", "الحالة");
                    zGridView1.ZColHandle("CompNo", "رقم الحاسب الآلي");
                    zGridView1.ZColHandle("pName", "الاسم");
                    zGridView1.ZColHandle("SuitNo", "الجناح");
                    zGridView1.ZColHandle("idno", "رقم الهوية");
                    zGridView1.ZColHandle("nationality", "الجنسية");
                    zGridView1.ZColHandle("DateEnter", "تاريخ الدخول");
                    zGridView1.ZColHandle("DateOut", "تاريخ الخروج");





                    zGridView1.ZAddSequenceColumnWithFooter();
                    zGridView1.ZLoadedBefore = true;
                    zGridView1.ZColumnAddSummary("IsValid", SummaryItemType.Custom);


                }
                zGridView1.BestFitColumns();
                zGridView1.ZClearFocus();

                var isvalid = _dtImportedItems.Select("IsValid=false").Length <= 0;
                if (!isvalid)
                {
                    ZEntry.ShowErrorMessage("يوجد بيانات غير صحيحة يجب تصحيحها ثم إعادة الرفع");
                    btnSave.Visible = true;
                    btnSave.Text=@"حفظ الصالح فقط";
                    btnShowinvalid.Visible = true;
                }
                else
                {
                    btnSave.Visible = true;
                    btnSave.Text = @"حفظ";

                    btnShowinvalid.Visible = false;
                }



            });
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_dtImportedItems is not { Rows.Count: > 0 })
            {
                ZEntry.ShowErrorMessage("لا توجد بيانات");
                return;
            }
            _complst = [];
            _nationalidlst = [];
           
         
            foreach (DataRow dr in _dtImportedItems.Rows)
            {
               
                ZEntry.ZSafeInvoke(this, progressBarControl1.PerformStep);
                var compuretnum = dr[0].ToString();
                var name = dr[1].ToString();
                //var suitno = dr[2].ToString();
                var nationalid = dr[3].ToString();
                //var nationality = dr[4].ToString();
                var datein = dr[5].ToString();
                var dateout = dr[6].ToString();
                var isvalid = true;
                var status = "";
                var isInt = long.TryParse(compuretnum, out _);
                if (!isInt)
                {
                    isvalid = false;
                    status = "رقم الحاسب الآلي ليس برقم|";
                }
                else
                {
                    if (!ClsVarslocal.Settings.CanRepeatCompNum && _dtLive is { Rows.Count: > 0 })
                    {
                        var rows = _dtLive.Select($"compnumber='{compuretnum}'");
                        if (rows.Length > 0)
                        {
                            isvalid = false;
                            status += "رقم الحاسب الآلي موجود مسبقا في قاعدة البيانات|";
                        }
                        if (_complst.Contains(compuretnum.ToLower().Trim()))
                        {
                            isvalid = false;
                            status += "رقم الحاسب الآلي مكرر|";
                        }
                        else _complst.Add(compuretnum.ToLower().Trim());
                    }

                }




                if (string.IsNullOrWhiteSpace(name))
                {
                    isvalid = false;
                    status += "الاسم فارغ|";
                }
                if (name.Length > 150)
                {
                    isvalid = false;
                    status += "الاسم أطول من 150|";
                }
                if (nationalid.Length > 50)
                {
                    isvalid = false;
                    status += "رقم الهوية أطول من 50|";
                }
                //var isnationalid = long.TryParse(nationalid, out _);
                //if (!isnationalid || nationalid.Length != 10)
                //{
                //    isvalid = false;
                //    status += "رقم الهوية غير صحيح|";

                //}

                var rowsnational = _dtLive.Select($"nationadlid='{nationalid}'");
                if (rowsnational.Length > 0)
                {
                    isvalid = false;
                    status += "رقم الهوية موجود مسبقا في قاعدة البيانات|";

                }
                if (_nationalidlst.Contains(nationalid.ToLower().Trim()))
                {
                    isvalid = false;
                    status += "رقم الهوية مكرر|";

                }
                else _nationalidlst.Add(nationalid.ToLower().Trim());



                var dateindata = GetDateFromstring(datein, "yyyy-MM-dd");
                if (!dateindata.done)
                {
                    isvalid = false;
                    status += "صيغة عمود الدخول غير صحيحة|";
                }
                if (dateout.Trim().Length > 0 && dateout.Trim() != "في السجن" )
                {
                    //check id datetime
                    var dateoutdata = GetDateFromstring(dateout, "yyyy-MM-dd");
                    if (!dateoutdata.done || !dateoutdata.date.HasValue)
                    {
                        isvalid = false;
                        status += "صيغة عمود الخروج غير صحيحة|";
                    }
                    else
                    {

                        if (dateindata.date != null && Convert.ToInt32(dateoutdata.date.Value.ToString("yyyyMMdd")) < Convert.ToInt32(dateindata.date.Value.ToString("yyyyMMdd")))
                        {
                            isvalid = false;
                            status += "تاريخ الخروج قبل تاريخ الدخول|";

                        }
                    }
                }


                dr["IsValid"] = isvalid;
                dr["Status"] = status;
                //dr[0]= compuretnum.Trim();
            }
        }

        protected internal static (bool done, string newdate, DateTime? date) GetDateFromstring(string date, string outformat)
        {
             date = date.Replace(oldValue: "/", newValue: "-");
            date = date.Replace(oldValue: ".", newValue: "-");
            if (!date.Contains(value: "-")) return (false, "Not Valid Date,1", null);
            var arr = date.Split(separator: ["-"], options: StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length != 3) return (false, "Invalid Date length,1", null);
            var formats = new Dictionary<int, string>
        {
           
            { 2, "yyyy-MM-dd" },
           

        };

            var outday = "";
            var outMonth = "";
            var outyear = "";


            foreach (var f in formats.Keys.Where(predicate: f => DateTime.TryParseExact(s: date, format: formats[key: f], provider: null, style: DateTimeStyles.None, result: out _)))
            {
                var localF = formats[key: f].Replace(oldValue: " hh:mm:ss tt", newValue: "").Replace(oldValue: " HH:mm:ss", newValue: "");
                var arrp = localF.Split(separator: ["-"], options: StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < arrp.Length; i++)
                {

                    if (arrp[i].ToLower().StartsWith(value: "d")) outday = arr[i];
                    if (arrp[i].ToLower().StartsWith(value: "m")) outMonth = arr[i];
                    if (arrp[i].ToLower().StartsWith(value: "y")) outyear = arr[i];
                }

            }
            if (outday == "" || outMonth == "" || outyear == "") return (false, "Empty Values,1", null);
            if (outday.Length > 2) outday = outday.Substring(startIndex: 0, length: 2);
            if (outMonth.Length > 2) outMonth = outMonth.Substring(startIndex: 0, length: 2);
            if (outyear.Length > 4) outyear = outyear.Substring(startIndex: 0, length: 4);

            var newd = new DateTime(year: Convert.ToInt32(value: outyear), month: Convert.ToInt32(value: outMonth), day: Convert.ToInt32(value: outday));
            return (true, newd.ToString(format: outformat, provider: CultureInfo.InvariantCulture), newd);


        }

        private void ProgressBarControl1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || sender is not ProgressBarControl p || p.EditValue == null) return;
            var txtq = _check ? "التحقق من " : "استيراد";
            e.DisplayText = $" جاري {txtq} البيانات  {p.Position} / {progressBarControl1.Properties.Maximum} ({Convert.ToInt32(p.Position * 100 / (progressBarControl1.Properties.Maximum == 0 ? 1 : progressBarControl1.Properties.Maximum))} %)";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            zGridControl1.DataSource = null;
            btnSave.Visible = false;
            btnShowinvalid.Visible = false;
            _check = true;
            var f = ZEntry.ZOpenFileDialogExcel(true);
            if (f is not { Exists: true }) return;
            _dtImportedItems = null;
            _dtImportedItems = ZEntry.ZExcelToDataTable(f.FullName, firstLineisHeader: true);

            if (_dtImportedItems is not { Rows.Count: > 0 })
            {
                ZEntry.ShowErrorMessage("لا توجد بيانات");
                return;
            }
            if (_dtImportedItems.Columns.Count < 9)
            {
                ZEntry.ShowErrorMessage("عدد الأعمدة غير صحيح");
                return;
            }
            _dtImportedItems.Columns[0].ColumnName = "CompNo";
            _dtImportedItems.Columns[1].ColumnName = "pName";
            _dtImportedItems.Columns[2].ColumnName = "SuitNo";
            _dtImportedItems.Columns[3].ColumnName = "idno";
            _dtImportedItems.Columns[4].ColumnName = "nationality";
            _dtImportedItems.Columns[5].ColumnName = "DateEnter";
            _dtImportedItems.Columns[6].ColumnName = "DateOut";
            var drValid = _dtImportedItems.Select($@"idno<>'' and idno <>'الهوية'");
            if (drValid.Length == 0)
            {
                ZEntry.ShowErrorMessage("لا توجد بيانات");
                return;
            }
            _dtImportedItems = drValid.CopyToDataTable();



            var drnationalities = _dtImportedItems.AsEnumerable().GroupBy(r => r.Field<string>(_dtImportedItems.Columns[4].ColumnName)).Select(g => g.First());
            var dataRows = drnationalities as DataRow[] ?? drnationalities.ToArray();
            if (dataRows.Any())
            {
                var db = new Db();
                _dtnatio = db.GetNationalities();
                foreach (var dr in dataRows)
                {
                    if (dr[0] == null || dr[0].ToString().Trim().Length == 0) continue;
                    var existonlive = _dtnatio.Select($@"nationalityname='{dr[0]}'");
                    if (existonlive.Length == 0)
                    {
                        db.InsertNationality(dr[0].ToString());
                    }
                }


            }



            _dtLive = new Dal().Select("select compnumber, nationadlid from tblMain where isactive=true");


            _dtImportedItems.Columns.Add("IsValid", typeof(bool));
            _dtImportedItems.Columns.Add("Status", typeof(string));

            progressBarControl1.EditValue = 0;
            progressBarControl1.Visible = true;
            progressBarControl1.Properties.Maximum = _dtImportedItems.Rows.Count;
            progressBarControl1.Properties.Step = 1;


            backgroundWorker1.RunWorkerAsync();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dtImportedItems is not { Rows: { Count: > 0 } })
            {
                ZEntry.ShowErrorMessage("لا توجد بيانات");
                return;
            }
            zGridView1.ZClearBeforeSaving();
            if (!ZEntry.ShowQuestionNew(this, "هل أنت متأكد من الحفظ؟")) return;
            progressBarControl1.EditValue = 0;
            progressBarControl1.Visible = true;
            progressBarControl1.Properties.Maximum = _dtImportedItems.Rows.Count;
            progressBarControl1.Properties.Step = 1;
            _check = false;
            btnSave.Visible = false;
            simpleButton1.Visible = false;
            btnShowinvalid.Visible= false;
            backgroundWorker2.RunWorkerAsync();
        }



        private void btnShowinvalid_Click(object sender, EventArgs e)
        {
            zGridView1.ActiveFilterString = "IsValid=false";
        }
    }
}