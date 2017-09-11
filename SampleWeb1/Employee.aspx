<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="SampleWeb1.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:HiddenField ID="HdnId" runat="server" />
        <div>
            <table cellpadding="4" cellspacing="2">
                <tr>
                    <td>Employee Id
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtEmpId" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>First Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtFirstName" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>Last Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtLastName" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>Age
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtAge" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>Department
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtDepartment" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>Address
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtAddress" Text="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button Text="Save" runat="server" ID="BtnSave" OnClick="BtnSave_Click"/>
                    </td>
                </tr>
            </table>
        </div>



    </form>

    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.24.min.js"></script>

    <script type="text/javascript">
        //OnClientClick="SaveEmployee();" 
        function SaveEmployee() {
            var employee_data = {
                "Id": $('#HdnId').val(),
                "EmpId": $('#TxtEmpId').val(),
                "EmpName": $('#TxtFirstName').val() + " " + $('#TxtLastName').val(),
                "Age": $('#TxtAge').val(),
                "Department": $('#TxtDepartment').val(),
                "Address": $('#TxtAddress').val()
            };

            $.ajax({
                url: "http://localhost:1812/api/employee/",
                type: "POST",
                data: JSON.stringify(employee_data),
                // data: employee_data,
                dataType: "json",
                contentType: "application/json",
                traditional: true,
                success: function () {
                    location.reload(true);
                },
                fail: function () {
                }
            });
        }

    </script>
</body>
</html>
