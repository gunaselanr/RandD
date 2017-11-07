<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="SampleWebApplication.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptMgrCustomer" />
        <div id="DivGridView">
            <h2>Grid View Sample</h2>
            <asp:UpdatePanel runat="server" ID="UpdPnlCustomer">
                <ContentTemplate>
                    <asp:GridView ID="GvCustomer" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="Id, FirstName" ShowFooter="true" ShowHeader="true"
                        OnRowCancelingEdit="GvCustomer_RowCancelingEdit" OnRowCommand="GvCustomer_RowCommand" OnRowDeleting="GvCustomer_RowDeleting"
                        OnRowEditing="GvCustomer_RowEditing" OnRowUpdating="GvCustomer_RowUpdating" OnPageIndexChanging="GvCustomer_PageIndexChanging">
                        <Columns>
                            <%--First Name --%>
                            <asp:TemplateField HeaderText="First Name" SortExpression="First Name">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtFirstName" Text='<%# Eval("FirstName") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewFirstName" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblFirstName" Text='<%# Eval("FirstName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%-- Last Name --%>
                            <asp:TemplateField HeaderText="Last Name" SortExpression="Last Name">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtLastName" Text='<%# Eval("LastName") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewLastName" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblLastName1" Text='<%# Eval("LastName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtCity" Text='<%# Eval("City") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewCity" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblCity" Text='<%# Eval("City") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtCountry" Text='<%# Eval("Country") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewCountry" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Phone No" SortExpression="Phone No">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtPhoneNo" Text='<%# Eval("Phone") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewPhoneNo" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblPhoneNo" Text='<%# Eval("Phone") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                <EditItemTemplate>
                                    <asp:LinkButton runat="server" ID="LnkBtnUpdate" Text="Update" CausesValidation="true" CommandName="Update" />
                                    <asp:LinkButton runat="server" ID="LnkBtnCancel" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                </EditItemTemplate>

                                <FooterTemplate>
                                    <asp:LinkButton runat="server" ID="LnkBtnAddNew" Text="Add" CausesValidation="true" CommandName="Add" />
                                </FooterTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="LnkBtnEdit" Text="Edit" CausesValidation="false" CommandName="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true"/>
                        </Columns>

                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
