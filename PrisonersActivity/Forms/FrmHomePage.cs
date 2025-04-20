using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ZGTools;
using ZGTools.Funs;
using ZGTools.ZRibbon;

namespace PrisonersActivity.Forms
{
    public partial class FrmHomePage : RibbonForm
    {
        public ClsZMdiDocMgr ClsZMdiDocMgr;
        private readonly ZRibbonManager _areenRibbonManager;
        private static FrmHomePage _openForm;
        private readonly string _fName;

        public FrmHomePage()
        {
            if (_openForm == null)
            {

                InitializeComponent();
                LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
                _fName = AppDomain.CurrentDomain.BaseDirectory +"_NewJailsettings";
                ZEntry.ZTabViewColorTabs(ZTabView, HatchStyle.BackwardDiagonal, Color.FromArgb(245, 216, 216), Color.FromArgb(201, 222, 241), Color.FromArgb(165, 249, 197));



               
                FormClosing -= FrmHome_FormClosing;
                FormClosing += FrmHome_FormClosing;

               
                ClsZMdiDocMgr = DefineZMid();

                const string sToredDataFilePaths = "ZDASHBOARD.txt";
                _areenRibbonManager = new ZRibbonManager(ZdocManager, ZTabView, ribbon, 15, [], sToredDataFilePaths);
                LoadQuickAccess();
            }
            else
            {
                GetInstance();
            }
        }

        private void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            SaveStyles();
        }

        public ClsZMdiDocMgr DefineZMid()
        {
            return new ClsZMdiDocMgr(mainFrm: this, zTabView: ZTabView,
                logPath: null, ribbonStatusBar: ribbonStatusBar);
        }
        private void LoadQuickAccess()
        {
            _areenRibbonManager.LoadQuickAccess();


        }
        private void SaveStyles()
        {
            var txt = "";
            txt += $"theme={DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName}{Environment.NewLine}";
            txt += $"skin={DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSvgPaletteName}{Environment.NewLine}";
            txt += $"ribbonstyle={ribbon.RibbonStyle}{Environment.NewLine}";
            System.IO.File.WriteAllText(_fName, txt);
        }
   

        public static FrmHomePage GetInstance()
        {

            if (_openForm != null) return _openForm;
            _openForm = new FrmHomePage();
            _openForm.FormClosed += delegate { _openForm = null; };
            return _openForm;
        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {

            

            if (ZTabView.Documents.Count <= 0) return;
            if (!ZEntry.ShowQuestionNew(this,"هل أنت متأكد من الإغلاق؟" +Environment.NewLine+ ZTabView.Documents.Count)) e.Cancel = true;

        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            BarLocalizer.Active = new ZBarLocalizer();
            LoadTheme();
            //ZSplashMgr.Kill();

        }
        private void LoadTheme()
        {
            barListItem2.ShowChecks = true;
            if (System.IO.File.Exists(_fName))
            {
                var lines = System.IO.File.ReadAllLines(_fName);
                var themeName = "";
                var skinName = "";
                var ribbonstyle = "";


                foreach (var line in lines)
                {
                    if (line.ToLower().StartsWith("theme="))
                    {
                        themeName = line.Replace("theme=", "");
                    }
                    else if (line.ToLower().StartsWith("skin="))
                    {
                        skinName = line.Replace("skin=", "");

                    }
                    else if (line.ToLower().StartsWith("ribbonstyle="))
                    {
                        ribbonstyle = line.Replace("ribbonstyle=", "");

                    }

                }

                if (themeName != "")
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(themeName, skinName);
                }

                if (ribbonstyle != "")
                {
                    if (string.Equals(ribbonstyle, RibbonControlStyle.Default.ToString(),
                            StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.Default;

                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.Office2007.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.Office2007;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.Office2010.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.Office2010;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.Office2013.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.Office2013;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.MacOffice.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.MacOffice;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.TabletOffice.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.TabletOffice;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.OfficeUniversal.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.OfficeUniversal;
                    }
                    else if (string.Equals(ribbonstyle, RibbonControlStyle.Office2019.ToString(),
                                 StringComparison.CurrentCultureIgnoreCase))
                    {
                        ribbon.RibbonStyle = RibbonControlStyle.Office2019;
                    }





                }
                else ribbon.RibbonStyle = RibbonControlStyle.Default;
                for (var i = 0; i < barListItem2.Strings.Count; i++)
                {
                    var s = barListItem2.Strings[i];
                    if (!string.Equals(s, ribbon.RibbonStyle.ToString(),
                            StringComparison.CurrentCultureIgnoreCase)) continue;
                    barListItem2.ItemIndex = i;
                    break;
                }
            }
        }

        private void barListItem2_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            if (e.Item is not BarListItem xitem) return;


            var selectedText = xitem.Strings[e.Index];

            if (string.Equals(selectedText, "Default", StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.Default;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.Office2007.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.Office2007;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.Office2010.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.Office2010;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.Office2013.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.Office2013;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.MacOffice.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.MacOffice;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.TabletOffice.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.TabletOffice;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.OfficeUniversal.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.OfficeUniversal;
            }
            else if (string.Equals(selectedText, RibbonControlStyle.Office2019.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                ribbon.RibbonStyle = RibbonControlStyle.Office2019;
            }
            SaveStyles();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        
            ClsZMdiDocMgr.SetChild(new FrmPrisonersList());
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
             
            ClsZMdiDocMgr.SetChild(new FrmSettings());
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            ClsZMdiDocMgr.SetChild(new FrmImport() { ZUniqueName= "FrmImport" });
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            ClsZMdiDocMgr.SetChild(new FrmNationality());
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClsZMdiDocMgr.SetChild(new FrmPrisonersTransferedList());
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClsZMdiDocMgr.SetChild(new FrmRprtAll());

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClsZMdiDocMgr.SetChild(new FrmImportType2() { ZUniqueName = "FrmImport" });

        }
    }
}