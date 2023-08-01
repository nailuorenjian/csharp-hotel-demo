<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="bookShop.Views.Customer.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function printBill() {
            var PGrid = document.getElementById('<%=ShoppingList.ClientID%>')
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width=1024, height=768, tollbar=0,scrollbars = 1, statusz=0,resizable =1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
        //    PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">

        <h1 class="col-md-4">shop</h1>

    <div class="form-floating">
        <div><label class="form-label text-success" for="">product name</label></div>     
      <input type="text" class="form-control" autocomplete ="off" runat="server" id="PnameTb" /> 
    </div>

    <div class="form-floating">
        <div><label class="form-label text-success" for="">price</label></div>
      <input type="text" class="form-control" autocomplete ="off" runat="server" id="PriceTb" />
    </div>

     <div class="form-floating">
         <div><label class="form-label text-success" for="">amount</label></div>
      <input type="text" class="form-control" autocomplete ="off" runat="server" id="QtyTb" />
    </div>
        <div class="row">
         <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
        <asp:Button Text="add to shopingcar" runat="server" class="btn-success btn" ID="AddToBillBtn" OnClick="AddToBillBtn_Click" />
        </div>
        <br />
    <div class="col-md-8">
        <h4>shop list</h4>
                    <asp:GridView ID="ProductList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="ProductList_SelectedIndexChanged"  >
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
        <div class="col-md-8">
        <h4>shopingcar</h4>
                    <asp:GridView ID="ShoppingList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"  >
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
            <div class="form-floating">
         <asp:Label runat="server" ID="GrdTotalTb" CssClass="text-danger"></asp:Label>
          <asp:Button Text="print bill" OnClientClick="printBill()" runat="server" class="btn-success btn" ID="PrintBtn" />
      </div>
     </div>
          </div>

</asp:Content>
    