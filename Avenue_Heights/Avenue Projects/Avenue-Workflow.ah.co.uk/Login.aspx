<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Avenue_Workflow.ah.co.uk.Login" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Agile Workflow Design</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="Agile Workflow Design" name="description" />
    <meta content="Steven William Cooper" name="author" />

    <!-- Include bootstrap files -->-+
    <link rel="stylesheet" href="javascript/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="javascript/bootstrap/css/bootstrap-responsive.css" />
    <link rel="stylesheet" href="javascript/css/agile-workflow.css" />

    <style type="text/css">
        body {
            padding-top: 5%;
        }

        .form-signin {
            max-width: 300px;
            padding: 19px 29px 29px;
            margin: 0 auto 20px;
            background-color: rgb(232, 67, 17);
            border: 1px solid #e5e5e5;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            box-shadow: 0 1px 2px rgba(0,0,0,.05);
        }

            .form-signin .form-signin-heading,
            .form-signin .checkbox {
                margin-bottom: 10px;
            }

            .form-signin input[type="text"],
            .form-signin input[type="password"] {
                font-size: 16px;
                height: auto;
                margin-bottom: 15px;
                padding: 7px 9px;
            }
    </style>
</head>
<body>

    <div class="container">
        <form runat="server" class="form-signin">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="Images/Avenue-Heights-logo-white.png" Style="margin-bottom: 10px;" />
            <asp:Panel ID="pnlLogIn" runat="server">
                  <asp:Login ID="aLogin" runat="server" BorderPadding="6" LoginButtonText="Login" TitleText="" FailureText="Login Failed">
                    <LoginButtonStyle />
                    <TextBoxStyle />
                    <LayoutTemplate>
                        <asp:TextBox ID="UserName" runat="server" CssClass="input-block-level" placeholder="User Name" />
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Please Enter a User Name" ValidationGroup="Login"></asp:RequiredFieldValidator>

                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-block-level" placeholder="Password" />
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Please Enter a Password" ValidationGroup="Login"></asp:RequiredFieldValidator>

                <label class="checkbox">
                    <asp:CheckBox ID="RememberMe" runat="server" value="remember-me" />
                    Remember me
                </label>
                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-large btn-info" CommandName="Login" ValidationGroup="Login" Text="Login"/>
                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-large btn-info pull-right" Text="Register" /></br>
                <label>
                    <asp:Button ID="btnForgotPassword" runat="server" CssClass="btn btn-link" Style="padding: 0; margin-top: 15px;" Text="Forgot Password?" />
                    <strong style="color: black; margin: 0 20px 0 0;"><asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal></strong>
                </label>
                    </LayoutTemplate>
                </asp:Login>
                <strong style="color: black; margin: 0 20px 0 0;"><asp:Literal ID="lblMessage" runat="server"></asp:Literal></strong>
            </asp:Panel>
            <asp:Panel ID="pnlRegister" runat="server" Visible="false">
                <asp:Panel ID="pnlRegister1" runat="server">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-block-level" placeholder="First Name" />
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="input-block-level" placeholder="Last Name" />
                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-large btn-info" Text="Next" /><br />
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Text="Please Enter First Name" ControlToValidate="txtFirstName" /><br />
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" Text="Please Enter Last Name" ControlToValidate="txtLastName" />
                </asp:Panel>
                <asp:Panel ID="pnlRegister2" runat="server" Visible="false">
                    <label style="margin: 10px 0; color: white; cursor: default;">
                        UserName:<strong style="color: black;"><asp:Label ID="lblUserName" runat="server"/></strong>
                    </label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-block-level" placeholder="Email" />
                    <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="input-block-level" placeholder="Confirm Email" />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-block-level" placeholder="Password" />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-block-level" placeholder="Confirm Password" />
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-large btn-info" Text="Back" />
                    <asp:Button ID="btnComplete" runat="server" CssClass="btn btn-large btn-info pull-right" Text="Complete" /><br />
                    <strong style="color: black; margin: 0 20px 0 0;"><asp:Label ID="lblMessage2" runat="server" /></strong>
                </asp:Panel>
            </asp:Panel>
        </form>
    </div>

    <script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
    <script src="javascript/bootstrap/js/jquery.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-transition.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-alert.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-modal.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-dropdown.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-scrollspy.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-tab.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-tooltip.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-popover.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-button.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-collapse.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-carousel.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-typeahead.js"></script>
    <script src="javascript/bootstrap/js/bootstrap-affix.js"></script>

</body>
</html>

