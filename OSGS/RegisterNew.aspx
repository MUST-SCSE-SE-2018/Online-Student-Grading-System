<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterNew.aspx.cs" Inherits="OSGS.RegisterNew" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register New</title>
    <link rel="stylesheet" href="css/bootstrap-table.css">
    <link rel="stylesheet" href="css/bootstrap.css"> 
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>   
    <script src="js/bootstrap-table.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 100%;
            position: fixed;
            background-repeat: no-repeat;
            background-position: center;
            background-size: cover;
            -webkit-filter: blur(5px);
            -moz-filter: blur(5px);
            -o-filter: blur(5px);
            -ms-filter: blur(5px);
            filter: blur(5px);
            top: 0;
            left: 0;
            right: 0;
            bottom: -120px;
            z-index: -1;
        }
    </style>
</head>
<body class="background">
    <img class="auto-style1" src="img/bg.jpg"/>
    <form id="form2" runat="server" class="form-horizontal">
       
    <div class="jumbotron">
        <h1>Register A New Student</h1>
         <p>&nbsp;</p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="40px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="565px" RepeatDirection="Horizontal" CellSpacing="50">
            <asp:ListItem Selected="True" Value="0" class="btn btn-primary btn-lg">&nbsp;&nbsp;Register A New Course</asp:ListItem>
            <asp:ListItem Value="1" class="btn btn-primary btn-lg">&nbsp;&nbsp;Register A New Student</asp:ListItem>
        </asp:RadioButtonList>
        <p>&nbsp;</p>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Student ID :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="stuID" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

        <div id ="option" runat="server" visible="false">
            <div class="form-group">
		        <asp:Label CssClass="col-sm-2 control-label" runat="server">Student Name :</asp:Label>
		        <div class="col-sm-10">
			        <asp:TextBox ID="stuName" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		        </div>
	        </div>
        
            <div class="form-group">
		        <asp:Label CssClass="col-sm-2 control-label" runat="server">Password :</asp:Label>
		        <div class="col-sm-10">
			        <asp:TextBox ID="psw" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		        </div>
	        </div>

            <div class="form-group">
		        <asp:Label CssClass="col-sm-2 control-label" runat="server">Email Address :</asp:Label>
		        <div class="col-sm-10">
			        <asp:TextBox ID="email" runat="server" CssClass="form-control" Width="227px" TextMode="Email"></asp:TextBox>
		        </div>
	        </div>
        </div>


        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Register Course ID :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="cID" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Register Course Name :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="cName" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <div class="col-sm-offset-2 col-sm-10">
                <asp:Button runat="server" Text="Register" CssClass="btn btn-default" OnClick="Register_Button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="Cancel_Button" />
		    </div>
	    </div>
                                     
    </div>

    </form>
</body>
</html>
