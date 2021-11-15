<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuOverview.aspx.cs" Inherits="OSGS.StuOverview" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/bootstrap-table.css">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>   
    <script src="js/bootstrap-table.js"></script>
    <style type="text/css">
        .caption  
        { 
           text-align:center
        }

        .auto-style1 {
            margin-left:200px;
            border-collapse: collapse;
            max-width: 80%;
            margin-bottom: 20px;
        }
        .selection{
            margin-left:200px;
        }
    </style>
    </head>
<body class="background" style="background-color:rgba(220,220,220,0.35);">
    <form id="form3" runat="server">
    <h1 style="margin-top:100px; text-align:center">
        <asp:Label ID="title" runat="server">Welcome, Teacher! </asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Logout" runat="server" Height="37px" Text="Log Out" Font-Size="Large" Width="113px" OnClientClick="javascript:window.location.replace('Login.aspx'); return false;"/>
    </h1>

        <p>&nbsp;</p>
        <asp:RadioButtonList CssClass="selection" ID="RadioButtonList1" runat="server" Height="40px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="879px" RepeatDirection="Horizontal" CellSpacing="50">
            <asp:ListItem Selected="True" Value="0" class="btn btn-primary btn-lg">&nbsp;&nbsp;Student Account Management</asp:ListItem>
            <asp:ListItem Value="1" class="btn btn-primary btn-lg">&nbsp;&nbsp;Assignment Management</asp:ListItem>
            <asp:ListItem Value="2" class="btn btn-primary btn-lg">&nbsp;&nbsp;Register New</asp:ListItem>
        </asp:RadioButtonList>
        <p>&nbsp;</p>

        <h1 style="margin-left:200px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="cid" DataValueField="cid" Font-Size="XX-Large" AutoPostBack="True">
            </asp:DropDownList>
        </h1>

        <h1 style="margin-top:50px; text-align:center">
        <asp:GridView CssClass="auto-style1" ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="stuid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="296px" Width="1527px" AllowPaging="True" Font-Size="X-Large" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="stuid" HeaderText="stuid" ReadOnly="True" SortExpression="stuid" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="sName" HeaderText="sName" SortExpression="sName" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="psw" HeaderText="psw" SortExpression="psw" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="emailAddress" HeaderText="emailAddress" SortExpression="emailAddress" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
   
        </h1>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSGSConnectionString %>" SelectCommand="SELECT S.stuid, S.sName, S.psw, S.emailAddress
FROM Student AS S
JOIN Course AS C
ON S.stuid = C.stuid 
WHERE C.cid = @cid AND C.tid = @tid" UpdateCommand="UPDATE Student
SET sName = @sName, psw=@psw, emailAddress=@emailAddress
WHERE stuid = @stuid" DeleteCommand="DELETE FROM Course
WHERE stuid = @stuid AND tid = @tid">
            <DeleteParameters>
                <asp:Parameter Name="stuid" />
                <asp:QueryStringParameter Name="tid" QueryStringField="tid" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="cid" PropertyName="SelectedValue" />
                <asp:QueryStringParameter Name="tid" QueryStringField="tid" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="sName" />
                <asp:Parameter Name="psw" />
                <asp:Parameter Name="emailAddress" />
                <asp:Parameter Name="stuid" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OSGSConnectionString %>" SelectCommand="SELECT DISTINCT cid 
FROM Course 
WHERE tid = @tid">
            <SelectParameters>
                <asp:QueryStringParameter Name="tid" QueryStringField="tid" />
            </SelectParameters>
        </asp:SqlDataSource>
        <p>
            &nbsp;</p>
        </form>
   
</body>
</html>
