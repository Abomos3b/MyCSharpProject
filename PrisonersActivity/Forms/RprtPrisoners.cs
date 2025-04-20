using DevExpress.XtraReports.UI;
using PrisonersActivity.BE;

namespace PrisonersActivity.Forms
{
    public partial class RprtPrisoners : XtraReport
    {
        public RprtPrisoners(string txtcaption = null, string captionsign=null)
        {
            InitializeComponent();
            xrPictureBox1.ImageSource= new DevExpress.XtraPrinting.Drawing.ImageSource(ClsVarslocal.GetLogo());
            if(txtcaption!=null)
            {
                xrTableCell3.Text = txtcaption;
            }
            if(captionsign != null)
            {
                xrTableCell7.Text = captionsign;
            }



        }

    }
}
