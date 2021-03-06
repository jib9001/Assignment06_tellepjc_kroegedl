﻿<%-- 
 * Connor Tellep and Danny Kroeger
 * Assignment 06
 * IT3047 Web Server App Dev
 * 3/2/2017
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tellepjc_Assignment06.Default" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="tellepjc_Assignment06StyleSheet.css" rel="stylesheet" />
    <title>Assignment 06</title>
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
                        <asp:Calendar ID="calDateOfTransaction" runat="server"></asp:Calendar>
                    </td>

                    <td align="right" style="height: 20%; padding-left: 2%">
                        <asp:Label ID="lblTimeOfTransaction" runat="server" Text="Time Of Transaction"></asp:Label>
                        <asp:TextBox ID="tbxTimeOfTransaction" runat="server" onkeypress="return this.value.length<=19"></asp:TextBox>
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
                        <asp:Label ID="lblPricePerSellableUnitToTheCustomer" runat="server" Text="How much was paid per unit?"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbxPricePerSellableUnitToTheCustomer" runat="server" onkeypress="return this.value.length<=14"></asp:TextBox>
                    </td>


                </tr>


                <tr>

                    <td align="right" style="height: 20%; padding-left: 2%">
                        <asp:Label ID="lblTransactionComment" runat="server" Text="Comments about the transaction"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbxTransactionComment" runat="server" onkeypress="return this.value.length<=99"></asp:TextBox>
                    </td>

                    <td align="right" style="height: 20%; padding-left: 2%">
                        <asp:Label ID="lblTransactionDetailComment" runat="server" Text="Comments about the transaction detail"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbxtransactionDetailComment" runat="server" onkeypress="return this.value.length<=99"></asp:TextBox>
                    </td>

                </tr>


                <tr>


                    <td></td>
                    <td align="right" style="height: 20%; padding-left: 2%">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit!" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
