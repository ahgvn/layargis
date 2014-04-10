using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtURL.Text = ConfigurationManager.AppSettings["ags"];
    }
    protected void btnStore_Click(object sender, EventArgs e)
    {
        ConfigurationManager.AppSettings.Set("ags", txtURL.Text);
    }
}