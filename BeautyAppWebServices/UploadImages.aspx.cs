using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeautyAppWebServices
{
    public partial class UploadImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdMasters_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMasters.Checked == true) {
                divmasters.Visible = true;
                divProvidersNServices.Visible=false;
                divProvidersnStyles.Visible = false;
            }
        }

        protected void rdProvidersnService_CheckedChanged(object sender, EventArgs e)
        {
            if (rdProvidersnService.Checked == true)
            {
                divmasters.Visible = false;
                divProvidersNServices.Visible = true;
                divProvidersnStyles.Visible = false;
            }
        }

        protected void rdProvidersnStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdProvidersnStyle.Checked == true)
            {
                divmasters.Visible = false;
                divProvidersNServices.Visible = false;
                divProvidersnStyles.Visible = true;
            }
        }
    }
}