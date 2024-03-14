using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Project_FLK
{
    public partial class UserHome : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string str = "select * from Category where Category_Status='In Stock'";
                DataSet ds = obj.Fn_DataSet(str);
                DataList1.DataSource = ds;
                DataList1.DataBind();

            }

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int caid = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = caid;
            Response.Redirect("View_Product.aspx");
        }
    }
}