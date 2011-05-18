using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PesquisaBing bing = new PesquisaBing();
        //bing.search("", 10);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = "Im very macho";
    }
}