using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bookShop.Views.Admin
{
    public partial class Product : System.Web.UI.Page
    {
        Models.functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.functions();
            ShowManufactors();
        }
        private void ShowManufactors()
        {
            string Query = "Select * from ManufactoryTb1";
            ManufactList.DataSource = Con.GetData(Query);
            ManufactList.DataBind();
            ManufactList.HeaderRow.Cells[1].Text = "No";
            ManufactList.HeaderRow.Cells[2].Text = "Factory Name";
            ManufactList.HeaderRow.Cells[3].Text = "Factory Number";
            ManufactList.HeaderRow.Cells[4].Text = "Address";
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "update ManufactoryTb1 set ManufactName = '{0}', ManufactPermNum = '{1}', ManufactPlace = '{2}' where ManufactId = {3}";
                    Query = string.Format(Query, MName, PermNum, Place, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "product offer information are edited";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "no Data";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "insert into ManufactoryTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, MName, PermNum, Place);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "product offer information added";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ManufactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MNameTb.Value = ManufactList.SelectedRow.Cells[2].Text;
            PermNumTb.Value = ManufactList.SelectedRow.Cells[3].Text;
            PlaceCb.SelectedValue = ManufactList.SelectedRow.Cells[4].Text;
            if (MNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ManufactList.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "choose Data";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "delete from ManufactoryTb1 where ManufactId = {0}";
                    Query = string.Format(Query, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "product offer information are delete";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}