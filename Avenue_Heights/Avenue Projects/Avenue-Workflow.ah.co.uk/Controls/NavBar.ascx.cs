using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk.Controls
{
    public partial class NavBar : Avenue.Workflow.WorkflowControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIterationList();
                BindNavBar();

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            iLogo.Click += iLogo_Click;
            rIterationList.ItemDataBound += rIterationList_ItemDataBound;
        }

        void iLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Main.aspx");
        }

        public void BindNavBar()
        {
            lblDisplayName.Text = CurrentUser.UserName;

            if (CurrentIteration.IterationID != 0)
            {
                if (CurrentIteration.IterationTimePeriods.Count != 0)
                {
                    Avenue.Workflow.Access.IterationTimePeriod currentITP = CurrentIteration.IterationTimePeriods.getCurrentTimePeriod();
                    lIterationTimePeriod.Text = String.Format("{0:dddd d MMMM} - {1:dddd d MMMM}", currentITP.IterationTimePeriodStartDate, currentITP.IterationTimePeriodEndDate);
                }
            }
        }

        public void BindIterationList()
        {
            Avenue.Workflow.Access.Iterations userIterations = new Avenue.Workflow.Access.Iterations();
            userIterations.AddRange(CurrentUser.IterationsPartOf);
            if (userIterations.Count == 0) rIterationList.Visible = false;
            else
            {
                if (WorkflowIterationID == 0) WorkflowIterationID = userIterations.First().IterationID;
                rIterationList.DataSource = userIterations;
                rIterationList.DataBind();

            }
        }

        void rIterationList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lblCurrentIteration = (Label)(e.Item.FindControl("lblCurrentIteration"));

                if (CurrentIteration.IterationID == 0)
                {
                    if (CurrentUser.IterationsPartOf.Count > 0)
                    {
                        lblCurrentIteration.Text = CurrentUser.IterationsPartOf.First().IterationDescription;
                    }
                }
                else
                {
                    lblCurrentIteration.Text = CurrentIteration.IterationDescription;
                }
            }
            else if (e.Item.ItemType == ListItemType.Item)
            {
                Label lblIterationName = (Label)(e.Item.FindControl("lblIterationName"));
                HiddenField hfIterationID = (HiddenField)(e.Item.FindControl("hfIterationID"));
                Avenue.Workflow.Access.Iteration aIteration = (Avenue.Workflow.Access.Iteration)e.Item.DataItem;

                lblIterationName.Text = aIteration.IterationDescription;
                hfIterationID.Value = aIteration.IterationID.ToString();
            }
        }
    }
}