using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk.Admin
{
    public partial class Iteration : Avenue.Workflow.WorkflowPage
    {

        private Avenue.Workflow.Access.Iteration _aIteration;
        public Avenue.Workflow.Access.Iteration aIteration
        {
            get
            {
                if (_aIteration == null)
                    if (Request.QueryString["IterationID"] != null) _aIteration = new Avenue.Workflow.Access.Iteration(Int32.Parse(Request.QueryString["IterationID"]));
                    else _aIteration = new Avenue.Workflow.Access.Iteration();

                return _aIteration;
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("http://avenue-workflow.ah.co.uk");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdminNav();
                BindIterationTypes();
                BindIteration();
                BindUsers();
                BindStatistics();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            rUsers.ItemDataBound += rUsers_ItemDataBound;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Add Iteration")
            {
                Avenue.Workflow.Access.Iteration newIteration = new Avenue.Workflow.Access.Iteration();
                newIteration.IterationDescription = txtIterationDescription.Text;
                newIteration.DefaultIterationTimePeriod = Int32.Parse(txtDefaultTimePeriod.Text);
                newIteration.IterationTypeID = new Avenue.Workflow.Access.IterationType(Int32.Parse(ddlIterationTypes.SelectedValue));
                newIteration.IterationOwner = CurrentUser;

                newIteration.Insert();

                DateTime tempTime = DateTime.Parse(txtIterationStartDate.Text);
                for (int i = 1; i <= 5; i++)
                {
                    Avenue.Workflow.Access.IterationTimePeriod newITP = new Avenue.Workflow.Access.IterationTimePeriod();
                    newITP.IterationID = newIteration;
                    newITP.IterationTimePeriodStartDate = tempTime;
                    if (newIteration.DefaultIterationTimePeriod.HasValue)
                    {
                        tempTime = tempTime.AddDays(((double)newIteration.DefaultIterationTimePeriod.Value) * 7);
                        newITP.IterationTimePeriodEndDate = tempTime.AddSeconds(-1);
                        newITP.Insert();
                    }
                }

                Response.Redirect(String.Format("Iteration.aspx?IterationID={0}", newIteration.IterationID));
            }
            else if (((Button)sender).Text == "Save")
            {
                aIteration.IterationDescription = txtIterationDescription.Text;
                aIteration.DefaultIterationTimePeriod = Int32.Parse(txtIterationDescription.Text);

                aIteration.Update();

                lblMessage.Text = "Updated";
            }
        }

        public void BindAdminNav()
        {
            if (aIteration.IterationID != 0) cAdminNav.iterationID = aIteration.IterationID;
        }

        public void BindIteration()
        {
            if (aIteration.IterationID != 0)
            {
                txtIterationStartDate.Visible = false;
                lblDformat.Visible = false;
                if (CurrentUser.IterationsOwn.Contains(aIteration))
                {
                    lblIterationHeader.Text = aIteration.IterationDescription;
                    txtIterationDescription.Text = aIteration.IterationDescription;
                    txtDefaultTimePeriod.Text = aIteration.DefaultIterationTimePeriod.Value.ToString();
                    ddlIterationTypes.SelectedValue = aIteration.IterationTypeID.IterationTypeID.ToString();
                }
                else
                {
                    ddlIterationTypes.Enabled = false;
                    txtIterationDescription.Enabled = false;
                    txtDefaultTimePeriod.Enabled = false;
                    if (aIteration.DefaultIterationTimePeriod.HasValue) txtDefaultTimePeriod.Text = aIteration.DefaultIterationTimePeriod.Value.ToString();
                    HideTextBoxes();
                }


            }
            else
            {
                lblIterationHeader.Text = "New Iteration";
                btnSave.Text = "Add Iteration";

                HideDetails();
            }
        }

        public void BindUsers()
        {
            Avenue.Workflow.Access.Users iterationUsers = aIteration.Users;
            rUsers.DataSource = iterationUsers;
            rUsers.DataBind();
        }
        public void HideDetails()
        {
            Users.Visible = false;
            Stories.Visible = false;
            Tasks.Visible = false;
        }

        public void HideTextBoxes()
        {
            ddlIterationTypes.Visible = false;
            txtDefaultTimePeriod.Visible = false;
            txtIterationDescription.Visible = false;
            btnSave.Visible = false;
        }

        public void BindIterationTypes()
        {
            ddlIterationTypes.DataSource = IterationTypes;
            ddlIterationTypes.DataBind();

            ddlIterationTypes.Items.Insert(0, (new ListItem("Select Iteration Type", "0")));
        }

        public void BindStatistics()
        {
            Avenue.Workflow.Access.Stories lStories = aIteration.IterationTimePeriods.getCurrentTimePeriod().Stories;
            Avenue.Workflow.Access.Tasks lTasks = new Avenue.Workflow.Access.Tasks();
            Int32 sInProgress = 0, sCompleted = 0;
            if (lStories.Count() > 0)
            {
                foreach (Avenue.Workflow.Access.Story aStory in lStories)
                {
                    if (aStory.Tasks.Count() != 0)
                    {
                        Int32 tInProgress = aStory.Tasks.SelectByInProgress().Count();
                        Int32 tCompleted = aStory.Tasks.SelectByCompleted().Count();
                        lblTasksInProgess.Text = tInProgress.ToString();
                        lblTasksCompleted.Text = tCompleted.ToString();
                        lblTasksTotal.Text = aStory.Tasks.Count().ToString();

                        if (tInProgress > 0) sInProgress++;
                        else if (tCompleted > 0) sCompleted++;
                    }
                }
            }
            else lblTasksCompleted.Text = lblTasksInProgess.Text = lblTasksTotal.Text = "0";

            lblStoriesTotal.Text = lStories.Count().ToString();
            lblStoriesInProgress.Text = sInProgress.ToString();
            lblStoriesCompleted.Text = sCompleted.ToString();
        }

        void rUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Avenue.Workflow.Access.User aUser = (Avenue.Workflow.Access.User)e.Item.DataItem;
                Label lblUser = (Label)e.Item.FindControl("lblUser");
                lblUser.Text = aUser.UserName;
            }
        }
    }
}