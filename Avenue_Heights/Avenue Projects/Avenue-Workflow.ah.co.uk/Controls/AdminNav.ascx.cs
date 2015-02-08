using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk.Controls
{
    public partial class AdminNav : Avenue.Workflow.WorkflowControl
    {

        public Boolean userDetailsPage = false;

        public int iterationID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindIterationsOwned();
            BindIterationsIn();

            if (userDetailsPage) editDetails.Attributes.Add("class", "active");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            rIterationsIn.ItemDataBound += rIterationsIn_ItemDataBound;
            rIterationsOwned.ItemDataBound += rIterationsOwned_ItemDataBound;
        }

      

        public void BindIterationsOwned()
        {
            if (CurrentUser.IterationsOwn.Count > 0)
            {
                rIterationsOwned.DataSource = CurrentUser.IterationsOwn;
                rIterationsOwned.DataBind();
            }
        }

        public void BindIterationsIn()
        {
            if (CurrentUser.IterationsPartOf.Count > 0)
            {
                Avenue.Workflow.Access.Iterations iPartOf = new Avenue.Workflow.Access.Iterations();
                iPartOf.AddRange(CurrentUser.IterationsPartOf.Where(f => !CurrentUser.IterationsOwn.Contains(f)));
                rIterationsIn.DataSource = iPartOf;
                rIterationsIn.DataBind();
            }
        }

        #region Event Handlers

        void rIterationsOwned_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                System.Web.UI.HtmlControls.HtmlAnchor aIterationOwned = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("aIterationOwned"));
                Label lblIterationOwned = (Label)(e.Item.FindControl("lblIterationOwned"));
                Avenue.Workflow.Access.Iteration aIteration = (Avenue.Workflow.Access.Iteration)e.Item.DataItem;
                //System.Web.UI.HtmlControls.HtmlGenericControl li = (System.Web.UI.HtmlControls.HtmlGenericControl)aIterationOwned.Parent ;

                lblIterationOwned.Text = aIteration.IterationDescription;
                aIterationOwned.HRef = String.Format("../Admin/Iteration.aspx?IterationID={0}", aIteration.IterationID);

                //if (iterationID != 0)
                   // if (iterationID == aIteration.IterationID) li.Attributes.Add("class", "active");
            }
        }

        void rIterationsIn_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                System.Web.UI.HtmlControls.HtmlAnchor aIterationIn = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("aIterationIn"));
                Label lblIterationIn = (Label)(e.Item.FindControl("lblIterationIn"));
                Avenue.Workflow.Access.Iteration aIteration = (Avenue.Workflow.Access.Iteration)e.Item.DataItem;
                //System.Web.UI.HtmlControls.HtmlGenericControl li = (System.Web.UI.HtmlControls.HtmlGenericControl)aIterationIn.Parent;

                lblIterationIn.Text = aIteration.IterationDescription;
                aIterationIn.HRef = String.Format("../Admin/Iteration.aspx?IterationID={0}", aIteration.IterationID);

                // if (iterationID != 0)
                //if (iterationID == aIteration.IterationID) li.Attributes.Add("class", "active");
            }
        }

        #endregion
    }
}