using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_FLK
{
    public partial class View_User_Details : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Bind_Grid();
            }

        }
        public void Bind_Grid()
        {
            string sel = "select * from User_Tab";
            DataSet ds = obj.Fn_DataSet(sel);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        

       

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int i = e.RowIndex;
        //    int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
        //    TextBox txtstat = (TextBox)GridView1.Rows[i].Cells[10].Controls[0];

        //    string strup = "update User_Tab set User_Status='" + txtstat.Text + "' where User_Id=" + Session["uid"] + "";
        //    obj.Fn_Nonquery(strup);
        //    GridView1.EditIndex = -1;
        //    Bind_Grid();
        //}

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string strup = "update User_Tab set User_Status='Blocked' where User_Id=" +getid + "";
            obj.Fn_Nonquery(strup);
            
            Bind_Grid();



        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string strup = "update User_Tab set User_Status='Active' where User_Id=" + getid + "";
            obj.Fn_Nonquery(strup);

            Bind_Grid();

        }
    }
}