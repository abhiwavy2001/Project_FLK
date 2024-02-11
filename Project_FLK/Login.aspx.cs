using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_FLK
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls ob = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Registration_id) from Login where username='" + TextBox9.Text + "' and password='" + TextBox10.Text + "'";
            string cid = ob.Fn_Scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Registration_id from Login where username='" + TextBox9.Text + "' and password='" + TextBox10.Text + "'";
                string regid = ob.Fn_Scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Login_type from Login where username='" + TextBox9.Text + "' and password='" + TextBox10.Text + "'";
                string logtype = ob.Fn_Scalar(str2);
                if (logtype == "admin")
                {
                    Label3.Text = "Admin";
                    Response.Redirect("Admin_Home.aspx");

                }
                else if (logtype == "user")
                {
                    Label3.Text = "User";
                    Response.Redirect("User_Home.aspx");
                }
            }
        }
    }
}