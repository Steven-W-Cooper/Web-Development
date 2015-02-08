<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Iteration.aspx.cs" Inherits="Avenue_Workflow.ah.co.uk.Admin.Iteration" EnableEventValidation="true" %>

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
                <div class="span8">
                    <div class="hero-unit" style="padding: 10px;">
                        <i class="icon-book" style="margin-left: 20px;"></i><span style="margin-left: 10px; font-size: x-large;"><strong>
                            <asp:Label ID="lblIterationHeader" runat="server" /></strong></span>
                    </div>
                    <div class="row-fluid" style="margin-top: 0;">
                        <div class="span7">
                            <div class="hero-unit">
                                    <h3 style="margin: 0 0 10px 0;"><strong>Iteration</strong></h3>
                                    <div style="margin-bottom:10px;">Name: <asp:TextBox ID="txtIterationDescription" runat="server" CssClass="input-block-level" placeholder="Iteration Description" Width="65%" style="margin-bottom:0px; float:right;" /></div>
                                    <div style="margin-bottom:10px;">Type: <asp:DropDownList ID="ddlIterationTypes" runat="server" DataTextField="IterationTypeName" DataValueField="IterationTypeID" style="margin-bottom:0px; float:right;"  /></div>
                                    <div style="margin-bottom:10px;"><span style="cursor:help;" title="Iteration Default Time Period">DTP:</span> <div style="float:right; margin-right:-130px;"><asp:TextBox ID="txtDefaultTimePeriod" runat="server" Width="15%" CssClass="input-block-level" placeholder="Default Time Period" style="margin-bottom:0px;"/><span style="margin-left: 10px; color: rgb(232, 67, 16);">Weeks</span></div></div>
                                    <asp:TextBox ID="txtIterationStartDate" runat="server" Style="width: 65%;" CssClass="input-block-level" placeholder="Start Date" /><asp:Label ID="lblDformat" runat="server" style="margin-left: 10px; color: rgb(232, 67, 16);" Text="(DD/MM/YYYY)"></asp:Label>
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-large btn-info" Text="Save" /><asp:Button ID="btnDelete" runat="server" CssClass="btn btn-large btn-danger" Text="Delete" style="margin-left:10px;"/>
                                    <strong style="color: red;">
                                        <asp:Label ID="lblMessage" runat="server" /></strong>
                            </div>

                        </div>
                        <div id="Users" runat="server" class="span5">
                            <div class="hero-unit">
                                <h3 style="margin: 0 0 10px 0;"><strong>Users</strong></h3>
                                <asp:Repeater ID="rUsers" runat="server">
                                    <ItemTemplate>
                                        <div style="margin-bottom: 10px;">
                                            <asp:Image ID="iUserPicture" runat="server" ImageUrl="../Images/bulbasaur.png" Width="30px" /><span style="margin-left: 10px; color: rgb(232,67,16);"><strong><asp:Label ID="lblUser" runat="server" /></strong></span>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div id="Stories" runat="server" class="row-fluid" style="margin-top: 0;">
                        <div class="span12">
                            <div class="hero-unit">
                                <span style="margin: 0 0 10px 0;"><strong>Stories</strong></span>
                                <span style="margin-left: 100px;">Total: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblStoriesTotal" runat="server" /></strong>
                                <span style="margin-left: 100px;">In Progress: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblStoriesInProgress" runat="server" /></strong>
                                <span style="margin-left: 100px;">Completed: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblStoriesCompleted" runat="server" /></strong>
                            </div>
                        </div>
                    </div>
                    <div id="Tasks" runat="server" class="row-fluid" style="margin-top: 0;">
                        <div class="span12">
                            <div class="hero-unit">
                                <span style="margin: 0 0 10px 0;"><strong>Tasks</strong></span>
                                <span style="margin-left: 100px;">Total: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblTasksTotal" runat="server" /></strong>
                                <span style="margin-left: 100px;">In Progress: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblTasksInProgess" runat="server" /></strong>
                                <span style="margin-left: 100px;">Completed: </span><strong style="color: rgb(232,67,16);">
                                    <asp:Label ID="lblTasksCompleted" runat="server" /></strong>
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
