<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="SampleWebApplication.ListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScritMgrCustomer" />

        <asp:UpdatePanel runat="server" ID="UpdPnlCustomer">
            <ContentTemplate>
                <div id="DivLstViewCustomer">
                    <asp:ListView runat="server" ID="LVCustomer" 
                        OnItemCanceling="LVCustomer_ItemCanceling" OnItemCommand="LVCustomer_ItemCommand" OnItemDeleting="LVCustomer_ItemDeleting" 
                        OnItemEditing="LVCustomer_ItemEditing" OnItemInserting="LVCustomer_ItemInserting" OnItemUpdating="LVCustomer_ItemUpdating"
                        InsertItemPosition="LastItem">
                        <LayoutTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th></th>
                                                    <th>First Name</th>
                                                    <th>Last Name</th>
                                                    <th>City</th>
                                                    <th>Country</th>
                                                    <th>Phone No</th>
                                                </tr>
                                                <tr id="itemPlaceHolder" runat="server"></tr>
                                            </thead>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td id="Td3" runat="server" ></td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton Text="Edit" runat="server" ID="LnkEdit" CommandName="Edit" />
                                    &nbsp;| &nbsp;
                             <asp:LinkButton Text="Delete" runat="server" ID="LnkDelete" CommandName="Delete" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="LblId" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("FirstName") %>' runat="server" ID="LblFirstName" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("LastName") %>' runat="server" ID="LblLastName" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("City") %>' runat="server" ID="LblCity" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="LblCountry" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="LblPhone" /></td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton Text="Update" runat="server" ID="LnkUpdate"  CommandName="Update"/>
                                    &nbsp;|&nbsp;
                            <asp:LinkButton Text="Cancel" runat="server" ID="LnkCancel" CommandName="Cancel" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="LblId" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("FirstName") %>' runat="server" ID="TxtFirstName" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("LastName") %>' runat="server" ID="TxtLastName" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("City") %>' runat="server" ID="TxtCity" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("Country") %>' runat="server" ID="TxtCountry" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("Phone") %>' runat="server" ID="TxtPhone" />
                                </td>
                            </tr>
                        </EditItemTemplate>

                        <InsertItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton Text="Add" runat="server" ID="LnkAdd" CommandName="Insert" />
                                    &nbsp;|&nbsp;
                            <asp:LinkButton Text="Clear" runat="server" ID="LnkClear"  CommandName="Clear"/>
                                </td>
                                <td>
                                    <asp:Label Text="" runat="server" ID="LblId" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("FirstName") %>' runat="server" ID="TxtFirstName" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("LastName") %>' runat="server" ID="TxtLastName" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("City") %>' runat="server" ID="TxtCity" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("Country") %>' runat="server" ID="TxtCountry" />
                                </td>
                                <td>
                                    <asp:TextBox Text='<%# Eval("Phone") %>' runat="server" ID="TxtPhone" />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                    </asp:ListView>
                </div>

                <asp:DataPager ID="PgrCustomer" PagedControlID="LVCustomer" PageSize="10" runat="server" OnPreRender="PgrCustomer_PreRender">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" />
                    </Fields>
                </asp:DataPager>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
