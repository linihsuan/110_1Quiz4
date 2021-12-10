using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _110_1Quiz4
{
    public partial class Connection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Connstr = "Data Source=(localdb)\\ProjectsV13;" +
                               "Initial Catalog=Test;Integrated Security=True;" +
                               "Connect Timeout=30;Encrypt=False;" +
                               "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                               "User ID = sa; Password = 12345;";

            try
            {
                SqlConnection o_SQLCon = new SqlConnection(s_Connstr);

                SqlCommand o_Com = new SqlCommand("Select * from Users", o_SQLCon);
                o_SQLCon.Open();
                SqlDataReader o_R = o_Com.ExecuteReader();
                for (; o_R.Read();)
                {
                    for (int i_Col = 0; i_Col < o_R.FieldCount; i_Col++)
                    {
                        Response.Write("&nbsp;&nbsp;" + o_R[i_Col].ToString());
                    }
                    Response.Write("<br />");
                }
                o_SQLCon.Close();
            }

            catch (Exception o_Ex)
            {
                Response.Write(o_Ex.ToString());
            }
        }
    }
}
