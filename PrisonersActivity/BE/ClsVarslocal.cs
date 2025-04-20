using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using ZGTools;

namespace PrisonersActivity.BE
{
    internal class ClsVarslocal
    {

        private static Image _logo;
        private static bool _logoLoaded;

        internal static ZSettings Settings { get; private set; }


        public static Image GetLogo()
        {
            if (_logoLoaded)
            {
                return _logo;
            }
            _logoLoaded = true;

            var logopath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logo.jpg");
            _logo = File.Exists(logopath) ? Image.FromFile(logopath) : null;
            return _logo;
        }

        public static void LoadSettings()
        {
            var dt = new Dal().Select("select setname, ifnull(tblsettings.setval,'')setval from tblsettings");
            Settings = new ZSettings();
            foreach (DataRow dr in dt.Rows)
            {
                var val = dr["setval"].ToString();

                if (string.Equals(dr["setname"].ToString(), "DayAmount", StringComparison.OrdinalIgnoreCase))
                {
                    var isDeciaml = decimal.TryParse(val, out var dec);
                    Settings.DayAmount = isDeciaml ? dec : 5;
                }
                else if (string.Equals(dr["setname"].ToString(), "PrisonName", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.PrisonName = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer1", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer1 = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer2", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer2 = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer3", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer3 = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer4", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer4 = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer1Teir", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer1Teir = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer2Teir", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer2Teir = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer3Teir", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer3Teir = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "Footer4Teir", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.Footer4Teir = val;
                }

                else if (string.Equals(dr["setname"].ToString(), "ReportHeader", StringComparison.OrdinalIgnoreCase))
                {
                    Settings.ReportHeader = val;
                }
                else if (string.Equals(dr["setname"].ToString(), "CanRepeatCompNum", StringComparison.OrdinalIgnoreCase) )
                {
                    Settings.CanRepeatCompNum = val=="1";
                }
            }
        }

        public static void InstallFont()
        {
            if(!new ClsVarslocal().IsFontInstalled("Tajawal"))
            {
                var fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tajawal-Regular.ttf");
                if (File.Exists(fontPath))
                {
                    var pfc = new PrivateFontCollection();
                    pfc.AddFontFile(fontPath);
                    ZEntry.ShowAlert("تم تثبيت الخط بنجاح", "نجاح");
                }
            }
        }
        private bool IsFontInstalled(string fontName)
        {
            using var testFont = new Font(fontName, 8);
            return 0 == string.Compare(
                fontName,
                testFont.Name,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
