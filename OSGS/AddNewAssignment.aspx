<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewAssignment.aspx.cs" Inherits="OSGS.AddNewAssignment" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Assignment</title>
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
        .auto-style2 {
            left: 0px;
            top: 0px;
            width: 575px;
        }
        .auto-style3 {
            display: block;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
    </style>
</head>
<body class="background">
    <img class="auto-style1" src="img/bg.jpg"/>
    <form id="form2" runat="server" class="form-horizontal">
       
    <div class="jumbotron">
        <h1>Add A New Assignment</h1>
        <p>&nbsp;</p>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Course ID :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="cid" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

         <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Assignment Name :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="aname" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Weight(%) :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="weight" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">DeadLine :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ddl" runat="server" CssClass="form-control" Width="227px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 1:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_one" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group" id="Que2" runat="server" visible="false">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 2:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_two" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group" id="Que3" runat="server" visible="false">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 3:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_three" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group" id="Que4" runat="server" visible="false">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 4:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_four" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group" id="Que5" runat="server" visible="false">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 5:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_five" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group" id="Que6" runat="server" visible="false">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 6:</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="Q_six" runat="server" CssClass="auto-style3" Width="483px" Height="127px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <div class="auto-style2">
                <asp:Button runat="server" Text="Add Question" CssClass="btn btn-default" OnClick="Add_Button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Delete Question" CssClass="btn btn-default" OnClick="Delete_Button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Create" CssClass="btn btn-default" OnClick="Create_Button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Back" CssClass="btn btn-default" OnClick="Back_Button" />
		    </div>
	    </div>
                              
    </div>

    </form>
</body>
</html>
