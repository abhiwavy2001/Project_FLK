using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_FLK
{
    public partial class AddCategory : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "";
            s = "~/Category Image/~" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));

            string sel = "insert into Category values('" + TextBox1.Text + "','" + s + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.Fn_Nonquery(sel);
            if (i != 0)
            {
                Label5.Text = "Category Added Successfully";
            }
        }
    }
}