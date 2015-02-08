<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNav.ascx.cs" Inherits="Avenue_Workflow.ah.co.uk.Controls.AdminNav" %>

<script type="text/javascript">

    function setActive(a)
    {
        var b = a;
        b.
    }

</script>


<div class="span3">
    <div class="well sidebar-nav">
        <ul class="nav nav-list">
            <li class="nav-header">User</li>
            <li id="editDetails" runat="server"><a href="../Admin/UserDetails.aspx">Edit Details</a></li>

            <asp:Repeater ID="rIterationsOwned" runat="server">
                <HeaderTemplate>
                    <li class="nav-header">Iterations you own</li>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a id="aIterationOwned" runat="server">
                        <asp:Label ID="lblIterationOwned" runat="server" />
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rIterationsIn" runat="server">
                <HeaderTemplate>
                    <li class="nav-header">Iterations you are in</li>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a id="aIterationIn" runat="server">
                        <asp:Label ID="lblIterationIn" runat="server" />
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
            <li class="nav-header">Create New Iteration</li>
            <li><a id="aNewIteration" runat="server" href="~/Admin/Iteration.aspx"><asp:Label ID="lblNewIteration" runat="server" Text="New Iteration" /></a></li>
        </ul>
    </div>
</div>
