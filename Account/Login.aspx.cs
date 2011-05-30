﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    LoginDAL login = new LoginDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        

        if (login.findLogin(Login1.UserName,Login1.Password))
        {
           e.Authenticated = true;
           FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
        }
       else
       {
            e.Authenticated = false;
       }
    }
}