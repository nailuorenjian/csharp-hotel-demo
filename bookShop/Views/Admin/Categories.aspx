<%@ Page Title="typle manager" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="bookShop.Views.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
<div class="container-fluid">
        <div class="row">
            <div class="col">
                   <h3 class="text-center">typle manager</h3>
            </div>
        </div>
     </div>
           <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                   <label class="form-label text-sucess">typle name</label>
                    <input type="text" placeholder="" autocomplete="off" runat="server" id="CatNameTb" class="form-control"  />
                </div>
                 <div class="mb-3">
                   <label class="form-label text-sucess">typle detail</label>
                    <input type="text" placeholder="" autocomplete="off" runat="server" id="DescriptionTb" class="form-control"  />
                </div>
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
                    <div class="mb-4"><asp:Button Text="edit" ID="EditBtn" runat="server" Width="100px" class="btn-warning btn-block btn" OnClick="EditBtn_Click" /></div>
                    <div class="mb-4"><asp:Button Text="save" ID="SaveBtn" runat="server" Width="100px" class="btn-success btn-block btn" OnClick="SaveBtn_Click" /></div>
                    <div class="mb-4"><asp:Button Text="delete" ID="DeleteBtn" runat="server" Width="100px" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
               <div class="col-md-8">
                   <asp:GridView ID="CategoryList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="CategoryList_SelectedIndexChanged" >
                       <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                       <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                       <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                       <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#FFF1D4" />
                       <SortedAscendingHeaderStyle BackColor="#B95C30" />
                       <SortedDescendingCellStyle BackColor="#F1E5CE" />
                       <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
               </div>
        </div>

</asp:Content>