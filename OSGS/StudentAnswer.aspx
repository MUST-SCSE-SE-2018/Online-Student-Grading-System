<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAnswer.aspx.cs" Inherits="OSGS.StudentAnswer" %>

<!-- Designer: 1809853Z-I011-0045 Wang Yuyang, Kennard -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Answer</title>
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
            width: 481px;
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
        <h1>Assignment Answer</h1>
        <p>&nbsp;</p>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server" >Assignment Name :</asp:Label>
		    <asp:Label ID="aname" CssClass="col-sm-2 control-label" runat="server" Width="250px" ForeColor="#3366FF"></asp:Label>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server" >Student ID :</asp:Label>
		    <asp:Label ID="sid" CssClass="col-sm-2 control-label" runat="server" Width="250px" ForeColor="#3366FF"></asp:Label>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server" >Student Name :</asp:Label>
		    <asp:Label ID="stuname" CssClass="col-sm-2 control-label" runat="server" Width="250px" ForeColor="#3366FF"></asp:Label>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server" ForeColor="#FF0066" Width="450px">Attention : Every question is equal weight!</asp:Label>
	    </div>

         <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 1 :</asp:Label>
		    <asp:Label ID="q_cont" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>



        <div id="q_two" runat="server" visible="false">
            <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 2 :</asp:Label>
		    <asp:Label ID="q_cont_two" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans_two" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment_two" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>

        </div>

        <div id="q_three" runat="server" visible="false">
            <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 3 :</asp:Label>
		    <asp:Label ID="q_cont_three" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans_three" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment_three" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>

        </div>

        <div id="q_four" runat="server" visible="false">
            <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 4 :</asp:Label>
		    <asp:Label ID="q_cont_four" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans_four" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment_four" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>

        </div>


        <div id="q_five" runat="server" visible="false">
            <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 5 :</asp:Label>
		    <asp:Label ID="q_cont_five" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans_five" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment_five" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>

        </div>


        <div id="q_six" runat="server" visible="false">
            <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Question 6 :</asp:Label>
		    <asp:Label ID="q_cont_six" CssClass="col-sm-2 control-label" runat="server" Width="350px"></asp:Label>
	    </div>
               
        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Answer :</asp:Label>
		    <div class="col-sm-10">
			    <asp:TextBox ID="ans_six" runat="server" CssClass="auto-style3" Width="450px" Height="80px"></asp:TextBox>
		    </div>
	    </div>

        <div class="form-group">
		    <asp:Label CssClass="col-sm-2 control-label" runat="server">Teacher's Comment :</asp:Label>
		    <asp:Label ID="tcomment_six" CssClass="col-sm-2 control-label" runat="server" Width="350px" ForeColor="#3366FF"></asp:Label>
	    </div>

        </div>

        <div class="form-group">
		    <div class="auto-style2">
                <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="Submit_Button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Back" CssClass="btn btn-default" OnClick="Back_Button" />
		    </div>
	    </div>
                              
    </div>

    </form>
</body>
</html>

