using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookShop.Views.Admin
{
    public partial class Suppliers : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
            if (!IsPostBack)
            {
                ShowProducts();
                GetCategories();
                GetManufactors();
            }

        }
        private void ShowProducts()
        {
            string Query = "Select * from ProducTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            //ProductList.HeaderRow.Cells[1].Text = "No";
            //ProductList.HeaderRow.Cells[2].Text = "product Name";
            //ProductList.HeaderRow.Cells[3].Text = "Factory Number";
            //ProductList.HeaderRow.Cells[4].Text = "Address";
        }

        private void GetCategories()
        {
            string Query = "Select * from CategoryTb1";
            PCatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            PCatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            PCatCb.DataSource = Con.GetData(Query);
            PCatCb.DataBind();
        }

        private void GetManufactors()
        {
            string Query = "Select * from ManufactoryTb1";
            PManufacCb.DataTextField = Con.GetData(Query).Columns["ManufactName"].ToString();
            PManufacCb.DataValueField = Con.GetData(Query).Columns["ManufactId"].ToString();
            PManufacCb.DataSource = Con.GetData(Query);
            PManufacCb.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufacCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || QtyTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufacCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "insert into ProducTb1 values('{0}',{1},{2},{3},{4})";
                    Query = string.Format(Query, PName, PManufact, PCat, Quantity,Price);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "product information added";
                    PNameTb.Value = "";
                    PManufacCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PManufacCb.SelectedValue = ProductList.SelectedRow.Cells[3].Text;
            PCatCb.SelectedValue = ProductList.SelectedRow.Cells[4].Text;
            QtyTb.Value=ProductList.SelectedRow.Cells[5].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[6].Text;
            if (PNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufacCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || QtyTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufacCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "update ProducTb1 set PName='{0}', PManufact = {1},PCategory ={2},PQty={3},PPrice={4} where PId={5}";
                    Query = string.Format(Query, PName, PManufact, PCat, Quantity, Price, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "product information Edited";
                    PNameTb.Value = "";
                    PManufacCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
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
                if (PNameTb.Value == "" || PManufacCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || QtyTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufacCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "delete from ProducTb1 where PId={0}";
                    Query = string.Format(Query, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "product information Deleted";
                    PNameTb.Value = "";
                    PManufacCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}