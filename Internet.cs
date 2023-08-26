using System.Net;
using System.Windows.Forms;

namespace AULib
{
    internal class Internet
    {
        public static bool IsAvailable()
        {
            try
            {
                Dns.GetHostEntry("microsoft.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void isNotAvailable()
        {
            MessageBox.Show("Please check your internet connection!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
