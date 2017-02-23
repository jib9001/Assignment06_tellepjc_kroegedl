<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tellepjc_Assignment06.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table runat="server" id="tableForm">
        <tr>
            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblLoyaltyID" runat="server" Text="Loyalty ID"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlLoyaltyID" runat="server"></asp:DropDownList>

            </td>

            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblDateOfTransaction" runat="server" Text="Date Of Transaction"></asp:Label>
                <asp:TextBox ID="tbxDateOfTransaction" runat="server" onkeypress="return this.value.length<=20"</asp:TextBox>
                </td>

            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblTimeOfTransaction" runat="server" Text="Time Of Transaction"></asp:Label>
                <asp:TextBox ID="tbxTimeOfTransaction" runat="server" onkeypress="return this.value.length<=20"></asp:TextBox>
                </td>
        </tr>

        <tr>

            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblTransactionTypeID" runat="server" Text="Type of Transaction"></asp:Label>
                <asp:DropDownList ID="ddlTransactionTypeID" runat="server"></asp:DropDownList>
                </td>


            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblStoreID" runat="server" Text="Pick a store"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlStoreID" runat="server"></asp:DropDownList>
                </td>

             <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblEmplID" runat="server" Text="Choose an employee"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlEmplID" runat="server"></asp:DropDownList>
                </td>
        </tr>

        <tr>
             <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblProductID" runat="server" Text="Pick a product"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlProductID" runat="server"></asp:DropDownList>
                </td>

             <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblQty" runat="server" Text="Insert the amount of bought"></asp:Label>
                <br />
                 <asp:TextBox ID="tbxQty" runat="server"></asp:TextBox>
                </td>

             <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblPricePerSellableUnitAsMarked" runat="server" Text="What it cost"></asp:Label>
                <br />
                 <asp:TextBox ID="tbxPricePerSellableUnitAsMarked" runat="server" onkeypress="return this.value.length<=15"></asp:TextBox>
                </td>


        </tr>


        <tr>

              <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblPricePerSellableUnitToTheCustomer" runat="server" Text="What you paid"></asp:Label>
                <br />
                 <asp:TextBox ID="tbxPricePerSellableUnitToTheCustomer" runat="server" onkeypress="return this.value.length<=15"></asp:TextBox>
                </td>

              <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblTransactionComment" runat="server" Text="Comments about the transaction"></asp:Label>
                <br />
                 <asp:TextBox ID="tbxTransactionComment" runat="server" onkeypress="return this.value.length<=100"></asp:TextBox>
                </td>

              <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblTransactionDetailComment" runat="server" Text="Comments about the transaction detail"></asp:Label>
                <br />
                 <asp:TextBox ID="tbxtransactionDetailComment" runat="server" onkeypress="return this.value.length<=100"></asp:TextBox>
                </td>

        </tr>

        <tr>


            <td></td>

              <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Label ID="lblCouponDetailID" runat="server" Text="Coupon Used"></asp:Label>
                <br />
                  <asp:DropDownList ID="ddlCouponDetailID" runat="server"></asp:DropDownList>
                </td>
        </tr>


        <tr>


            <td></td>
            <td align="right" style="height: 20%; padding-left: 2%">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit!" />
            </td>
        </tr>
    </table>


    </div>
    </form>
</body>
</html>
