<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Avenue_Workflow.ah.co.uk.Main" EnableEventValidation="true" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Agile Workflow Design</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="Agile Workflow Design" name="description" />
    <meta content="Steven William Cooper" name="author" />

    <!-- Include bootstrap files -->
    <link rel="stylesheet" href="javascript/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="javascript/bootstrap/css/bootstrap-responsive.css" />
    <link rel="stylesheet" href="javascript/css/agile-workflow.css" />
</head>
<body>
    <form runat="server">

        <ahc:NavBar ID="cNavBar" runat="server" />

        <div class="current-task">
            <div class="task-name pull-left">
                <i id="iTaskType" runat="server" class="icon-briefcase icon-white"></i><strong class="text-border">
                    <asp:Label ID="lblTaskName" runat="server"></asp:Label></strong>
            </div>
            <div class="task-time pull-right">
                <i class="icon-time icon-white"></i><strong class="text-border">
                    <asp:Label ID="lblTaskTime" runat="server"></asp:Label></strong>
            </div>
        </div>
        <div class="navbar" style="position: relative;">
            <div class="navbar-inner">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="search-query filter-search no-border-radius" placeholder="Search" />
                <asp:ImageButton ID="iStoryAdd" runat="server" CssClass="btnAdd" ImageUrl="../Images/Button-Add-icon.png" />
                <div class="progress-filter-bar">
                    <strong style="color: black; padding-left: 10px;">Progression:</strong><div class="progress indent progress-info">
                        <div id="dProgress" runat="server" class="bar"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span5">
                <asp:Repeater ID="rStories" runat="server">
                    <HeaderTemplate>
                        <div class="story header">
                            <span class="summary">Stories</span>
                            <div class="story-badges">
                                Task Total<span class="badge"><asp:Label ID="lblTaskTotal" runat="server"></asp:Label></span>
                                Task Complete<span class="badge badge-success"><asp:Label ID="lblTaskComplete" runat="server"></asp:Label></span>
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="story">
                            <span class="summary"><i id="iStoryType" runat="server" class="icon-white icon-tasks"></i>&nbsp;<asp:Label ID="lblStoryName" runat="server"></asp:Label></span>
                            <div class="button-options">
                                <asp:Button ID="btnOpen" runat="server" CssClass="btnOpen" Text="Open" CommandName="storyOpen" CommandArgument="StoryID" />
                                <asp:Button ID="btnDelete" runat="server" CssClass="btnDelete icon-white icon-remove" CommandName="storyDelete" CommandArgument="StoryID" />
                            </div>
                            <div class="story-badges hidden-tablet">
                                <span class="badge">
                                    <asp:Label ID="lblTaskTotal" runat="server"></asp:Label></span>
                                <span class="badge badge-success">
                                    <asp:Label ID="lblTaskCompleted" runat="server"></asp:Label></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="span5 offset1">
                <div class="accordion" id="accordion2" style="display: none;">
                    <div class="accordion-group">
                        <asp:Repeater ID="rTasks" runat="server">
                            <HeaderTemplate>
                                <div class="accordion-heading">
                                    <a class="accordion-toggle" style="padding: 0px;" data-toggle="collapse" data-parent="#accordion2" href="#collapseOne">
                                        <div class="story header">
                                            <span class="summary"><i id="iStoryType" runat="server" class="icon-tasks icon-white"></i>&nbsp;<asp:Label ID="lblStoryName" runat="server"></asp:Label></span>
                                            <i class="icon-chevron-down icon-white pull-right" style="margin: 12px;"></i>
                                            <div class="story-badges">
                                                Task Total<span class="badge"><asp:Label ID="lblTaskTotal" runat="server"></asp:Label></span>
                                                Task Complete<span class="badge badge-success"><asp:Label ID="lblTaskCompleted" runat="server"></asp:Label></span>
                                            </div>

                                        </div>
                                    </a>
                                </div>


                                <div id="collapseOne" class="accordion-body collapse">
                                    <div class="accordion-inner" style="padding: 0px;">
                                        <div class="task-heading" style="background-color: white;">
                                            <span class="pull-left" style="margin-left: 10px;">Task</span>
                                            <span class="pull-right" style="margin-right: 45px;">Clocked</span>
                                            <span class="pull-right" style="margin-right: 20px;">Est.</span>

                                        </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div id="task-accordion">
                                    <div class="task">

                                        <span class="summary"><i class="icon-plus" style="cursor: pointer;" onclick="expandStory(this);"></i>&nbsp;<asp:Label ID="lblTaskName" runat="server"></asp:Label></span>
                                        <div class="task-info pull-right">
                                            <div class="dropdown pull-right" style="border: 1px solid rgb(180,180,180); padding: 1px;">
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                                    <strong><i class="icon-time"></i></strong>
                                                </a>

                                                <<asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="dropdown-menu pull-right" DataTextField="TaskStatusName" DataValueField="TaskStatusID"></asp:DropDownList>
                                            </div>
                                            <span class="time" style="margin-right: -10px;">
                                                <asp:Label ID="lblTimeEstimated" runat="server"></asp:Label></span>
                                            <span class="time">
                                                <asp:Label ID="lblTimeClocked" runat="server"></asp:Label></span>
                                        </div>
                                        <asp:HiddenField ID="hfTaskID" runat="server" />
                                    </div>
                                    <div class="task-inner collapse">
                                        <div class="task-edit">
                                            <asp:TextBox ID="txtTaskName" runat="server" CssClass="summary"></asp:TextBox>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="btnDelete icon-white icon-remove pull-right" Style="margin: 15px 3px;" CommandName="TaskDelete" CommandArgument="TaskID" />
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnUpdate icon-white icon-ok pull-right" Style="width: 20px;" CommandName="TaskSave" CommandArgument="TaskID" />
                                            <<asp:TextBox ID="txtTimeEstimated" runat="server" CssClass="time pull-right" Style="margin-right: 3px;"></asp:TextBox>
                                            <asp:TextBox ID="txtTimeClocked" runat="server" CssClass="time pull-right" />
                                        </div>
                                    </div>

                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                           </div>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
        </div>
        </div>
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

        <script type="text/javascript">
            $('.carousel').carousel();

            function expandStory(sender) {
                var s = $(sender.parentNode.parentNode.nextElementSibling);
                if (s.hasClass("in")) {
                    s.removeClass("in");
                    $(sender).removeClass("icon-minus");
                    $(sender).addClass("icon-plus");
                }
                else {
                    s.addClass("in");
                    $(sender).removeClass("icon-plus");
                    $(sender).addClass("icon-minus");
                }
            }

            $('.summary').click(function () {
                if ($(this).parent().hasClass("story")) {
                    var story = $(this).parent();
                    if (story.hasClass("header")) return;
                    else {
                        if (story.hasClass("selected")) {
                            story.animate({ marginLeft: "0px" });
                            story.removeClass("selected");
                        }
                        else {
                            story.animate({ marginLeft: "5%" });
                            $('.story.selected').each(function () {
                                $(this).animate({ marginLeft: "0px" });
                                $(this).removeClass("selected");
                            });
                            story.addClass("selected");
                        }
                    }
                }
            });

            $('.btnOpen').click(function () {
                $('#accordion2').show();

                $('#collapseOne').collapse('toggle');
            });
        </script>
    </form>
</body>
</html>
