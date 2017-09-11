<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="SampleWeb1.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptMgrEmployee" />
        <div id="DivGridView">
            <h2>Grid View Sample</h2>
            <asp:UpdatePanel runat="server" ID="UpdPnlEmployee">
                <ContentTemplate>
                    <asp:GridView ID="GvEmployee" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="Id, FirstName" ShowFooter="true" ShowHeader="true"
                        OnRowCancelingEdit="GvEmployee_RowCancelingEdit" OnRowCommand="GvEmployee_RowCommand" OnRowDeleting="GvEmployee_RowDeleting"
                        OnRowEditing="GvEmployee_RowEditing" OnRowUpdating="GvEmployee_RowUpdating" OnPageIndexChanging="GvEmployee_PageIndexChanging">
                        <Columns>
                             <%--Emp Id --%>
                            <asp:TemplateField HeaderText="Emp Id" SortExpression="Emp Id">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtEmpId" Text='<%# Eval("EmpId") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewEmpId" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblEmpId" Text='<%# Eval("EmpId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

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

                            <asp:TemplateField HeaderText="Age" SortExpression="Age">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtAge" Text='<%# Eval("Age") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewAge" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblAge" Text='<%# Eval("Age") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Department" SortExpression="Department">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtDepartment" Text='<%# Eval("Department") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewDepartment" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="TxtAddress" Text='<%# Eval("Address") %>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox runat="server" ID="TxtNewAddress" Text="" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="LblAddress" Text='<%# Eval("Address") %>' />
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
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ShowHeader="true" />
                        </Columns>

                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
