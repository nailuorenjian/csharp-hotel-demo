using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookShop.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "Select * from CategoryTb1";
            CategoryList.DataSource = Con.GetData(Query);
            CategoryList.DataBind();
            //ManufactList.HeaderRow.Cells[1].Text = "No";
            //ManufactList.HeaderRow.Cells[2].Text = "Factory Name";
            //ManufactList.HeaderRow.Cells[3].Text = "Factory Number";
            //ManufactList.HeaderRow.Cells[4].Text = "Address";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "insert into CategoryTb1 values('{0}','{1}')";
                    Query = string.Format(Query, CName, CDesc);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "product type information added";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value = CategoryList.SelectedRow.Cells[2].Text;
            DescriptionTb.Value = CategoryList.SelectedRow.Cells[3].Text;
            if (CatNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoryList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "update CategoryTb1 set CatName ='{0}', CatDescription ='{1}' where CatId = '{2}'";
                    Query = string.Format(Query, CName, CDesc, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "product typle information edited";
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
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "delete CategoryTb1 where CatId = {0}";
                    Query = string.Format(Query, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    CatNameTb.Value = "";
                    ErrMsg.Text = "product typle information deleted";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}