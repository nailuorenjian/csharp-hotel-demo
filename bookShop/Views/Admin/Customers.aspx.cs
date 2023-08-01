using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookShop.Views.Admin
{
    public partial class Customers : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            string Query = "Select * from CustomerTb1";
            CustomerList.DataSource = Con.GetData(Query);
            CustomerList.DataBind();
            //ManufactList.HeaderRow.Cells[1].Text = "No";
            //ManufactList.HeaderRow.Cells[2].Text = "Factory Name";
            //ManufactList.HeaderRow.Cells[3].Text = "Factory Number";
            //ManufactList.HeaderRow.Cells[4].Text = "Address";
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CNameTb.Value;
                    string CEmail = EmailTb.Value;
                    string CPhone = PhoneTb.Value;
                    string CAdd = AddTb.Value;

                    string Query = "insert into CustomerTb1 values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, CName, CEmail, CPhone, CAdd);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "customer information added";
                    CNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void CustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNameTb.Value = CustomerList.SelectedRow.Cells[2].Text;
            EmailTb.Value = CustomerList.SelectedRow.Cells[3].Text;
            PhoneTb.Value = CustomerList.SelectedRow.Cells[4].Text;
            AddTb.Value = CustomerList.SelectedRow.Cells[5].Text;
            if (CNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomerList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CNameTb.Value;
                    string CEmail = EmailTb.Value;
                    string CPhone = PhoneTb.Value;
                    string CAdd = AddTb.Value;

                    string Query = "update CustomerTb1 set CustName ='{0}',CustEmail ='{1}',CustPhone ='{2}',CustAddress ='{3}' where CustId = {4}";
                    Query = string.Format(Query, CName, CEmail, CPhone, CAdd, CustomerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "customer information edited";
                    CNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CNameTb.Value;
                    string CEmail = EmailTb.Value;
                    string CPhone = PhoneTb.Value;
                    string CAdd = AddTb.Value;

                    string Query = "delete from CustomerTb1 where CustId = {0}";
                    Query = string.Format(Query, CustomerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCustomers();
                    ErrMsg.Text = "customer information delete";
                    CNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}