using PrisonersActivity.BE;

namespace PrisonersActivity.Forms
{
    public partial class RprtAllData : DevExpress.XtraReports.UI.XtraReport
    {
        public RprtAllData(string txttransdate)
        {
            InitializeComponent();
            xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(ClsVarslocal.GetLogo());
            xrTableCell6.Text = txttransdate;

        }

    }
}
