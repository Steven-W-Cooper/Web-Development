<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="Avenue_Workflow.ah.co.uk.Controls.NavBar" %>

    <div class="navbar">
        <div class="navbar-inner">

            <button class="btn btn-navbar" data-target=".nav-collapse" data-toggle="collapse" type="button">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
                <asp:ImageButton ID="iLogo" runat="server" CssClass="brand" ImageUrl="~/Images/Avenue-Workflow-logo-white.gif" Style="width: 50px; cursor:pointer"/>
            <div class="nav-collapse navbar-text collapse " style="margin-left:50px;">
                <ul class="nav">
                    <li class="dropdown">
                        <asp:Repeater ID="rIterationList" runat="server">
                            <HeaderTemplate>
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <strong>
                                        <asp:Label ID="lblCurrentIteration" runat="server" /></strong>
                                    <i class="icon-list icon-white"></i>
                                </a>
                                <ul class="dropdown-menu">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <a id="aIteration" runat="server" href="#">
                                        <i id="iIteration" runat="server"></i>&nbsp;<asp:Label ID="lblIterationName" runat="server" />
                                        <asp:HiddenField ID="hfIterationID" runat="server" />
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                </ul>
                </li>
                </ul>
                <span style="padding: 0px 0px 0px 10px">
                    <asp:Literal ID="lIterationTimePeriod" runat="server"></asp:Literal></span>
                <ul class="nav pull-right">
                    <li class="visible-desktop">
                        <asp:Image ID="iProfilePicture" runat="server" ImageUrl="~/Images/pikachu.png" CssClass="display-picture" />
                    </li>
                    <li class="divider-vertical"></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <strong>
                                <asp:Image ID="iProfilePicture2" runat="server" ImageUrl="Images/pikachu.png" CssClass="display-picture-collapse hidden-desktop" />
                                <asp:Label ID="lblDisplayName" runat="server" /></strong>
                            <i class="icon-cog icon-white"></i>
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                                <a id="aHome" runat="server" href="../Main.aspx">Home</a>
                            </li>
                            <li>
                                <a id="aAdmin" runat="server" href="../Admin/Admin.aspx">Admin
                                </a>
                            </li>
                            <li>
                                <a id="aSignOut" runat="server" href="#">Sign Out
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
