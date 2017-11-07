<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechGridView.aspx.cs" Inherits="SampleWebApplication.TechGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.24.min.js"></script>


    <script type="text/javascript">
        // https://forums.asp.net/t/2061928.aspx?How+to+calculate+Gridview+Row+Total+and+Column+total+in+query+

        //function CaluculateRowTotal(currentTexboxClientId, lblRowTotalClientId) {
        //    var lblRowTotal = document.getElementById(lblRowTotalClientId);
        //    var txtCurrent = document.getElementById(currentTexboxClientId);

        //    var currentTexboxValue = parseFloat(document.getElementById(currentTexboxClientId).value);

        //    var currentTexboxValue = parseFloat(txtCurrent.value);

        //    var currentLblRowTotalValue = parseFloat(lblRowTotal.innerHTML);
        //    var totalRowTotal = parseFloat(currentTexboxValue + currentLblRowTotalValue);

        //    lblRowTotal.innerHTML = totalRowTotal;
        //}

        function CalculateColumnTotal(value) {
            if (!isNaN(parseFloat(value))) {
                return parseFloat(value);
            }

            return 0;
        }

        //function CalculateRowTotal(control)
        //{
        //    //calculate total for current row
        //    var val1 = $(control).val();
        //    var val2 = $(control).parent().parent().find(".year2012").val();
        //    var val3 = $(control).parent().parent().find(".year2013").val();
        //    var val4 = $(control).parent().parent().find(".year2014").val();

        //    var rowtotal = parseFloat(val1) + parseFloat(val2) + parseFloat(val3);
        //    $(this).parent().siblings().last().text(rowtotal);
        //}

       
        $(function () {
            $(".year2011").keyup(function () {
                var total = 0;
                $(".year2011").each(function () {
                    total += CalculateColumnTotal($(this).val());
                });

                //  $(".total_of_year_column td").eq(1).text(total);
                $('.tot_year_2011').text(total);

                //calculate total for current row
                var val1 = $(this).val();
                var val2 = $(this).parent().parent().find(".year2012").val();
                var val3 = $(this).parent().parent().find(".year2013").val();
                var val4 = $(this).parent().parent().find(".year2014").val();

                var rowtotal = parseFloat(val1) + parseFloat(val2) + parseFloat(val3) + parseFloat(val4);
                $(this).parent().siblings().last().text(rowtotal);

                //// Final Total                
                var finalTotal = 0;
                $('[class^="tot_year"]').each(function () {
                    var value = $(this).text();
                    finalTotal += parseFloat(value);
                });

                $('.finalTotal').text(finalTotal);
            });

            $(".year2012").keyup(function () {
                var total = 0;
                $(".year2012").each(function () {
                    total += CalculateColumnTotal($(this).val());
                });

                //  $(".total_of_year_column td").eq(2).text(total);
                $('.tot_year_2012').text(total);

                //calculate total for current row
                var val1 = $(this).parent().parent().find(".year2011").val();
                var val2 = $(this).val();
                var val3 = $(this).parent().parent().find(".year2013").val();
                var val4 = $(this).parent().parent().find(".year2014").val();

                var rowtotal = parseFloat(val1) + parseFloat(val2) + parseFloat(val3) + parseFloat(val4);
                $(this).parent().siblings().last().text(rowtotal);

                // Final Total
                var finalTotal = 0;
                $('[class^="tot_year"]').each(function () {
                    var value = $(this).text();
                    finalTotal += parseFloat(value);
                });

                $('.finalTotal').text(finalTotal);
            });

            $(".year2013").keyup(function () {
                var total = 0;
                $(".year2013").each(function () {
                    total += CalculateColumnTotal($(this).val());
                });

                //  $(".total_of_year_column td").eq(3).text(total);
                $('.tot_year_2013').text(total);

                //calculate total for current row
                var val1 = $(this).parent().parent().find(".year2011").val();
                var val2 = $(this).parent().parent().find(".year2012").val();
                var val3 = $(this).val();
                var val4 = $(this).parent().parent().find(".year2014").val();

                var rowtotal = parseFloat(val1) + parseFloat(val2) + parseFloat(val3) + parseFloat(val4);
                $(this).parent().siblings().last().text(rowtotal);

                // Final Total
                var finalTotal = 0;
                $('[class^="tot_year"]').each(function () {
                    var value = $(this).text();
                    finalTotal += parseFloat(value);
                });

                $('.finalTotal').text(finalTotal);
            });

            $(".year2014").keyup(function () {
                var total = 0;
                $(".year2014").each(function () {
                    total += CalculateColumnTotal($(this).val());
                });

                //  $(".total_of_year_column td").eq(4).text(total);
                $('.tot_year_2014').text(total);

                //calculate total for current row
                var val1 = $(this).parent().parent().find(".year2011").val();
                var val2 = $(this).parent().parent().find(".year2012").val();
                var val3 = $(this).parent().parent().find(".year2013").val();
                var val4 = $(this).val();

                var rowtotal = parseFloat(val1) + parseFloat(val2) + parseFloat(val3) + parseFloat(val4);
                $(this).parent().siblings().last().text(rowtotal);

                // Final Total
                var finalTotal = 0;
                $('[class^="tot_year"]').each(function () {
                    var value = $(this).text();
                    finalTotal += parseFloat(value);
                });

                $('.finalTotal').text(finalTotal);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptMgrCompany" />
        <asp:UpdatePanel runat="server" ID="UpdPnlCompany">
            <ContentTemplate>
                <asp:GridView ID="GvCompany" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
                    DataKeyNames="Id" ShowFooter="true" ShowHeader="true" OnRowDataBound="GvCompany_RowDataBound" OnSelectedIndexChanging="GvCompany_SelectedIndexChanging" OnSelectedIndexChanged="GvCompany_SelectedIndexChanged" OnDataBinding="GvCompany_DataBinding" OnRowCommand="GvCompany_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Company Name" SortExpression="Company Name">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="TxtCompanyName" Text='<%# Eval("Name") %>' />
                            </ItemTemplate>

                            <FooterTemplate>
                                <br />
                                <asp:TextBox runat="server" ID="TxtNewCompanyName" Text="" />
                            </FooterTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year_2011" SortExpression="Year_2011">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="TxtYear_2011" Text='<%# Eval("Year_2011") %>' CssClass="year2011" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <b>
                                    <asp:Label runat="server" ID="LblTotalYear_2011" CssClass="tot_year_2011"
                                        Font-Bold="True"/></b>
                                <br />
                                <asp:TextBox runat="server" ID="TxtNewYear_2011" Text="" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year_2012" SortExpression="Year_2012">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="TxtYear_2012" Text='<%# Eval("Year_2012") %>' CssClass="year2012" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <b>
                                    <asp:Label Text='' runat="server" ID="LblTotalYear_2012"  CssClass="tot_year_2012"
                                        Font-Bold="True"/></b>
                                <br />
                                <asp:TextBox runat="server" ID="TxtNewYear_2012" Text="" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year_2013" SortExpression="Year_2013">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="TxtYear_2013" Text='<%# Eval("Year_2013") %>' CssClass="year2013" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <b>
                                    <asp:Label Text='' runat="server" ID="LblTotalYear_2013"  CssClass="tot_year_2013"
                                        Font-Bold="True"/></b>
                                <br />
                                <asp:TextBox runat="server" ID="TxtNewYear_2013" Text="" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year_2014" SortExpression="Year_2014">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="TxtYear_2014" Text='<%# Eval("Year_2014") %>' CssClass="year2014" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <b>
                                    <asp:Label Text="" runat="server" ID="LblTotalYear_2014"  CssClass="tot_year_2014"
                                        Font-Bold="True"/></b>
                                <br />
                                <asp:TextBox runat="server" ID="TxtNewYear_2014" Text="" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Row Total" SortExpression="Row Total">
                            <ItemTemplate>
                                <b>
                                    <asp:Label runat="server" ID="LblRowTotal" Text='<%# Eval("RowTotal") %>' CssClass="rowTotal"
                                        Font-Bold="True"/></b>
                            </ItemTemplate>
                            <FooterTemplate>
                                <b>
                                    <asp:Label Text="" runat="server" ID="LblFinalTotal" CssClass="finalTotal" /></b>

                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" SortExpression="">
                            <FooterTemplate>
                                <asp:LinkButton Text="Add" runat="server" ID="LnkAdd" CommandName="Add" />
                            </FooterTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <%--<FooterStyle Font-Bold="True" CssClass="total_of_year_column" />--%>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
        </div>
    </form>
</body>
</html>
