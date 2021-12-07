<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentManagement.aspx.cs" Inherits="OSGS.AssignmentManagement" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment Management</title>
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
        <asp:Label ID="title" runat="server">Welcome, Teacher! </asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Logout" runat="server" Height="37px" Text="Log Out" Font-Size="Large" Width="113px" OnClientClick="javascript:window.location.replace('Login.aspx'); return false;"/>
    </h1>

        <p>&nbsp;</p>
        <asp:RadioButtonList CssClass="selection" ID="RadioButtonList1" runat="server" Height="40px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="879px" RepeatDirection="Horizontal" CellSpacing="50">
            <asp:ListItem Value="0" class="btn btn-primary btn-lg">&nbsp;&nbsp;Student Account Management</asp:ListItem>
            <asp:ListItem Value="1" class="btn btn-primary btn-lg" Selected="True">&nbsp;&nbsp;Assignment Management</asp:ListItem>
            <asp:ListItem Value="2" class="btn btn-primary btn-lg">&nbsp;&nbsp;Register New</asp:ListItem>
        </asp:RadioButtonList>
        <p>&nbsp;</p>

        <h1 style="margin-left:200px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="cid" DataValueField="cid" Font-Size="XX-Large" AutoPostBack="True">
            </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Add" runat="server" Text="Create A New Assignment" CssClass="btn btn-primary btn-lg" OnClick="Add_Click" />
        </h1>

        <h1 style="margin-top:50px; text-align:center">
        <asp:GridView CssClass="auto-style1" ID="GridView1" runat="server" DataKeyNames="aid,stuid" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="296px" Width="1747px" AllowPaging="True" Font-Size="X-Large" OnSelectedIndexChanged="Detail_Click" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="aid" HeaderText="aid" SortExpression="aid" Visible="false"><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="aname" HeaderText="aname" SortExpression="aname" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="stuid" HeaderText="stuid" SortExpression="stuid" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="sName" HeaderText="sName" SortExpression="sName" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="weight(%)" HeaderText="weight(%)" SortExpression="weight(%)" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="q_number" HeaderText="q_number" SortExpression="q_number" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="deadline" HeaderText="deadline" SortExpression="deadline" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="stat" HeaderText="stat" SortExpression="stat" ><HeaderStyle CssClass="caption" /></asp:BoundField>
                <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" ><HeaderStyle CssClass="caption" /></asp:BoundField>
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
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSGSConnectionString %>" SelectCommand="SELECT A.aid, A.aname, S.stuid, S.sName, A.weight AS [weight(%)], A.q_number, A.deadline, SU.stat, SU.grade, SU.comment
FROM Assignment AS A
JOIN Submit AS SU 
ON SU.aid = A.aid 
JOIN Course AS C
ON C.cid=A.cid AND C.tid = A.tid AND C.cid = @cid AND C.tid = @tid AND SU.stuid = C.stuid
JOIN Student AS S
ON S.stuid = C.stuid" UpdateCommand="UPDATE Assignment
SET aname=@aname, weight=@weight, deadline=@deadline
WHERE aid = @aid" DeleteCommand="DELETE FROM Submit
WHERE aid = @aid;

DELETE FROM Answer
WHERE qid IN
(SELECT Q.qid
 FROM Question AS Q
 JOIN  Assignment AS A
 ON Q.aid = A.aid AND A.aid = @aid);

DELETE FROM Question
WHERE aid = @aid;

DELETE FROM Assignment
WHERE aid = @aid AND tid = @tid">
            <DeleteParameters>
                <asp:Parameter Name="aid" />
                <asp:QueryStringParameter Name="tid" QueryStringField="tid" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="cid" PropertyName="SelectedValue" />
                <asp:QueryStringParameter Name="tid" QueryStringField="tid" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="aname" />
                <asp:Parameter />
                <asp:Parameter Name="deadline" />
                <asp:Parameter Name="aid" />
                <asp:Parameter Name="weight" />
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
