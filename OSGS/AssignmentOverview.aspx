<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentOverview.aspx.cs" Inherits="OSGS.AssignmentOverview" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Assignment Overview</title>
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
            margin-left:80px;
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
    <form id="form4" runat="server">
    <h1 style="margin-top:100px; text-align:center">
        <asp:Label ID="title" runat="server">Welcome, Student! </asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Logout" runat="server" Height="37px" Text="Log Out" Font-Size="Large" Width="113px" OnClientClick="javascript:window.location.replace('Login.aspx'); return false;"/>
    </h1>
     
        <p>&nbsp;</p>

        <h1 style="margin-left:200px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="cid" DataValueField="cid" Font-Size="XX-Large" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>   
             &nbsp;&nbsp;
            <asp:Label ID="gpa" runat="server">GPA :</asp:Label>     
        </h1>

        <h1 style="margin-top:50px; text-align:center">
        <asp:GridView CssClass="auto-style1" ID="GridView1" runat="server" DataKeyNames="aid" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="296px" Width="1747px" AllowPaging="True" Font-Size="X-Large" OnSelectedIndexChanged="Detail_Click" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="aid" HeaderText="aid" ReadOnly="True" SortExpression="aid" Visible="false"><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="aname" HeaderText="aname" SortExpression="aname" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="weight(%)" HeaderText="weight(%)" SortExpression="weight(%)" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="q_number" HeaderText="q_number" SortExpression="q_number" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="deadline" HeaderText="deadline" SortExpression="deadline" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="stat" HeaderText="stat" SortExpression="stat" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" ><HeaderStyle CssClass="caption" /></asp:BoundField>
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
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSGSConnectionString %>" SelectCommand="SELECT DISTINCT A.aid, A.aname, A.weight AS [weight(%)], A.q_number, A.deadline, S.grade, S.stat, S.comment
FROM Assignment AS A
LEFT JOIN Submit AS S
ON A.aid = S.aid 
JOIN Course AS C
ON C.cid=A.cid AND C.tid = A.tid AND C.cid = @cid
WHERE S.stuid = @stuid">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="cid" PropertyName="SelectedValue" />
                <asp:QueryStringParameter Name="stuid" QueryStringField="stuid" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OSGSConnectionString %>" SelectCommand="SELECT DISTINCT cid 
FROM Course 
WHERE stuid=@stuid">
            <SelectParameters>
                <asp:QueryStringParameter Name="stuid" QueryStringField="stuid" />
            </SelectParameters>
        </asp:SqlDataSource>
        <p>
            &nbsp;</p>
        </form>

</body>
</html>
