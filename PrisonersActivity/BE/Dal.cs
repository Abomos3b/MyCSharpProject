using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using ZGTools;
using ZGTools.Funs;

namespace PrisonersActivity.BE
{
    internal class Dal : IDisposable
    {
        public readonly SQLiteConnection Con;
        private readonly string _dbpath;

        public void Dispose()
        {
            Con?.Dispose();
        }
        public Dal()
        {

            _dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB.dll");
            if (!IsDbExist())
            {
                ZEntry.ShowAlert("قاعدة البيانات غير موجودة", "خطأ", ZEnums.ZAlertTypes.Error);
            }
            Con = new SQLiteConnection($@"Data Source={_dbpath};Version=3;");
        }


        private void Open()
        {
            if (!IsDbExist())
            {
                return;
            }
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();

            }
        }
        private void Close()
        {
            if (!IsDbExist())
            {
                return;
            }
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        private bool IsDbExist()
        {
            return File.Exists(_dbpath);
        }
        public DataTable Select(string selectStatment)
        {
            if (!IsDbExist())
            {
                ZEntry.ShowErrorMessage("قاعدة البيانات غير موجودة", "خطأ", true);
                return null;
            }
            var dt = new DataTable();

            var da = new SQLiteDataAdapter(selectStatment, Con);
            da.Fill(dt);

            return dt;
        }
        public SQLiteDataAdapter SelectDataReturnDataAdap(string selectStatment)
        {
            if (!IsDbExist())
            {
                ZEntry.ShowErrorMessage("قاعدة البيانات غير موجودة", "خطأ", true);
                return null;
            }
            var da = new SQLiteDataAdapter(selectStatment, Con);
            return da;
        }
        public DataTable Select(SQLiteCommand cmd)
        {
            if (!IsDbExist())
            {
                ZEntry.ShowErrorMessage("قاعدة البيانات غير موجودة", "خطأ", true);
                return null;
            }
            var dt = new DataTable();

            cmd.Connection = Con;
            var da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        public bool ExcuteCommand(string excutestatment)
        {
            if (!IsDbExist())
            {
                ZEntry.ShowErrorMessage("قاعدة البيانات غير موجودة", "خطأ", true);
                return false;
            }
            Open();

            var sqlcmd = new SQLiteCommand(excutestatment, Con);
            sqlcmd.ExecuteNonQuery();
            Close();
            return true;
        }
        public bool ExcuteCommand(SQLiteCommand cmd)
        {
            if (!IsDbExist())
            {
                ZEntry.ShowErrorMessage("قاعدة البيانات غير موجودة", "خطأ", true);
                return false;
            }
            Open();
            cmd.Connection = Con;
            cmd.ExecuteNonQuery();
            Close();
            return true;

        }

    }
}
