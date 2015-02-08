<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="Avenue_Workflow.ah.co.uk.Admin.UserDetails" EnableEventValidation="true" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Agile Workflow Design</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="Agile Workflow Design" name="description" />
    <meta content="Steven William Cooper" name="author" />

    <!-- Include bootstrap files -->
    <link rel="stylesheet" href="../javascript/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="../javascript/bootstrap/css/bootstrap-responsive.css" />
    <link rel="stylesheet" href="../javascript/css/agile-workflow.css" />

    <style type="text/css">
        body {
            padding-bottom: 40px;
        }

        .sidebar-nav {
            padding: 9px 0;
        }

        @media (max-width: 980px) {
            /* Enable use of floated navbar text */
            .navbar-text.pull-right {
                float: none;
                padding-left: 5px;
                padding-right: 5px;
            }
        }
    </style>
</head>
<body>
    <form runat="server">
        <ahc:NavBar ID="cNavBar" runat="server" />

        <div class="container-fluid">
            <div class="row-fluid" style="margin-top: 0;">
                <ahc:AdminNav ID="cAdminNav" runat="server" />
                <!--/span-->
                <div class="span8">
                    <div class="hero-unit" style="padding: 10px;">

                        <img src="../Images/pikachu.png" width="75px" style="padding-left: 20px;" />

                        <span style="margin-left: 50px;"><strong>
                            <asp:Label ID="lblDisplayName" runat="server" /></strong></span>

                        <span style="margin-left: 100px;">Iterations Owned: </span><strong style="color: rgb(232,67,16);">
                            <asp:Label ID="lblTotalIterationsOwned" runat="server" /></strong>

                        <span style="margin-left: 100px;">Iterations In: </span><strong style="color: rgb(232,67,16);">
                            <asp:Label ID="lblTotalIterationsIn" runat="server" /></strong>

                    </div>
                        <div class="row-fluid" style="margin-top: 0;">
                            <div class="span7">
                                <div class="hero-unit">
                                    <h3 style="margin: 0 0 10px 0;"><strong>Edit Details</strong></h3>
                                    <div style="margin-bottom: 10px;">First Name:
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-block-level" placeholder="First Name" Width="65%" Style="float: right; margin-bottom: 0px;" /></div>
                                    <div style="margin-bottom: 10px;">Last Name:
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="input-block-level" placeholder="Last Name" Width="65%" Style="float: right; margin-bottom: 0px;" /></div>
                                    <div style="margin-bottom: 10px;">User Name:
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input-block-level" placeholder="Display Name" Width="65%" Style="float: right; margin-bottom: 0px;" Enabled="false" /></div>
                                    <div style="margin-bottom: 10px;">E-Mail:
                                        <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="input-block-level" placeholder="Email Address" Width="65%" Style="float: right; margin-bottom: 0px;" /></div>
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-large btn-info" Text="Save" />
                                    <label>
                                        <strong style="color: red;">
                                            <asp:Label ID="lblMessage" runat="server" /></strong>
                                    </label>
                                </div>
                            </div>
                            <div class="span5">
                                <div class="hero-unit">
                                    <h3 style="margin: 0 0 10px 0;"><strong>Change Password</strong></h3>
                                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="input-block-level" placeholder="Old Password" />
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-block-level" placeholder="New Password" />
                                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="input-block-level" placeholder="Confirm New Password" />
                                    <asp:Button ID="btnSavePassword" runat="server" CssClass="btn btn-large btn-info" Text="Save" />
                                    <label>
                                        <strong style="color: red;">
                                            <asp:Label ID="lblMessage2" runat="server" /></strong>
                                    </label>
                                </div>
                            </div>
                        </div>
                    <div class="row-fluid" style="margin-top: 0;">
                        <div class="span12">
                            <div class="hero-unit">
                                <span style="margin: 0 0 10px 0;"><strong>Tasks</strong></span>
                                <span style="margin-left: 100px;">Assigned: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblAssigned" runat="server" /></strong>
                                <span style="margin-left: 100px;">In Progress: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblInProgress" runat="server" /></strong>
                                <span style="margin-left: 100px;">Completed: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblCompleted" runat="server" /></strong>
                            </div>
                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->

        </div>

        <script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
        <script src="../javascript/bootstrap/js/jquery.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-transition.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-alert.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-modal.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-dropdown.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-scrollspy.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-tab.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-tooltip.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-popover.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-button.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-collapse.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-carousel.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-typeahead.js"></script>
        <script src="../javascript/bootstrap/js/bootstrap-affix.js"></script>
    </form>
</body>
</html>

