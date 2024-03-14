using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Project_FLK
{
    public partial class Product_Details : System.Web.UI.Page
    { 
        ConCls ob = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select * from Product where Product_Id="+Session["pid"]+"";
            SqlDataReader dr = ob.Fn_DataReader(sel);
            while(dr.Read())
            {
                Label1.Text = dr["Product_Name"].ToString();
                Label2.Text = dr["Product_Price"].ToString();
                Label3.Text = dr["Product_Description"].ToString();
                Image1.ImageUrl = dr["Product_Image"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Cart_id) from Cart";
            string cartid = ob.Fn_Scalar(sel);
            int cart_id = 0;
            if(cartid=="")
            {
                cart_id = 1;

            }
            else
            { 
                int newcartid = Convert.ToInt32(cartid);
                cart_id = newcartid + 1;

            }
            string s = "select Product_Price from product where Product_Id=" + Session["pid"] + "";
            string p = ob.Fn_Scalar(s).ToString();
            int totalprice = Convert.ToInt32(p) * Convert.ToInt32(TextBox1.Text);
            string total_price = Convert.ToString(totalprice);
            string str="insert into Cart values("+cart_id+",'"+Session["userid"]+"','"+Session["pid"]+"','"+TextBox1.Text+"')";
            int j = ob.Fn_Nonquery(s);
            if(j!=0)
            {
                Label5.Text = "Added To Cart";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }
    }
}