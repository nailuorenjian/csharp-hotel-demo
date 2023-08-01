using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace bookShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
        }

        public static string UName = "";
        public static int User;
        protected void LoginBtn_Click1(object sender, EventArgs e)
        {
            if (UnameTb.Value == "" || PasswordTb.Value == "")
            {
                ErrMsg.Text = "please input name or pw";
            }else if (UnameTb.Value == "test" && PasswordTb.Value == "password")
            {
                Response.Redirect("Admin/brands.aspx");
            }else
            {
                string Query = "select * from CustomerTb1 where CustEmail = '{0}' and CustAddress = '{1}'";
                Query = string.Format(Query, UnameTb.Value, PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if(dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "pw or name error";
                }
                else
                {
                    UName = UnameTb.Value;
                    User = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Customer/Billing.aspx");
                }
            }
        }
    }
}