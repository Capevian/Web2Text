using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{
    LoginDAL login = new LoginDAL();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool res = false;

        if (tbEmail1.Text.Equals(tbEmail2.Text))
        {
            if (tbPass1.Text.Equals(tbPass2.Text))
            {
                res = login.insert(tbUsername.Text, tbEmail1.Text, tbPass1.Text);

                if (res)
                {
                    Response.Redirect("Login.aspx?reg=1");
                }
                else
                {
                    fatalError.Text = "Já existe um utilizador com esse username";
                }
            }
            else
            {
                fatalError.Text = "Ocorreu um erro inesperado. Tente novamente";
            }
        }
        else
        {
            fatalError.Text = "Ocorreu um erro inesperado. Tente novamente";
        }
    }
}