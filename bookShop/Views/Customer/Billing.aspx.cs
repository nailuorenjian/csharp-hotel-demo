using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookShop.Views.Customer
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
            if (!IsPostBack)
            {
                ShowProducts();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("No"),
                    new DataColumn("product name"),
                    new DataColumn("price"),
                    new DataColumn("number"),
                    new DataColumn("total price"),
                });
                ViewState["bill"] = dt;
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            ShoppingList.DataSource = ViewState["bill"];
            ShoppingList.DataBind();
        }
        private void ShowProducts()
        {
            string Query = "Select * from ProducTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
        }

        int key = 0;
        int stock = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PnameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[6].Text;
            stock = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text);
            if (PnameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }

        int GrdTotal = 0;
        int Amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if (PnameTb.Value == "" || QtyTb.Value == "" || PriceTb.Value == "")
            {
                ErrMsg.Text = "no Data";
            }
            else
            {
                int total = Convert.ToInt32(QtyTb.Value) * Convert.ToInt32(PriceTb.Value);
                DataTable dt = (DataTable)ViewState["bill"];
                dt.Rows.Add(ShoppingList.Rows.Count + 1,
                    PnameTb.Value.Trim(),
                    PriceTb.Value.Trim(),
                    QtyTb.Value.Trim(),
                    total);

                ViewState["bill"] = dt;

                this.BindGrid();
                GrdTotal = 0;
                for (int i = 0; i < ShoppingList.Rows.Count; i++)
                {
                    GrdTotal = GrdTotal + Convert.ToInt32(ShoppingList.Rows[i].Cells[5].Text);
                }
                Amount = GrdTotal;
                GrdTotalTb.Text = "$" + GrdTotal;
                PnameTb.Value = "";
                QtyTb.Value = "";
                PriceTb.Value = "";
            }
           
        }
    }
}