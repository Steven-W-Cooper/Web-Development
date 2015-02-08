using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk
{
    public partial class Main : Avenue.Workflow.WorkflowPage
    {

        Avenue.Workflow.Access.Story _sStory;
        Avenue.Workflow.Access.Story sStory
        {
            get
            {
                return _sStory;
            }
            set
            {
                _sStory = value;
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("http://avenue-workflow.ah.co.uk");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            iStoryAdd.Click += iStoryAdd_Click;
            rStories.ItemDataBound += rStories_ItemDataBound;
            rStories.ItemCommand += rStories_ItemCommand;
            rTasks.ItemDataBound += rTasks_ItemDataBound;
            rTasks.ItemCommand += rTasks_ItemCommand;
        }

        void rTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Avenue.Workflow.Access.Task aTask = new Avenue.Workflow.Access.Task((Int32)e.CommandArgument);

            if (e.CommandName == "TaskSave")
            {
                aTask.TaskClockedTime = Decimal.Parse(((Label)e.Item.FindControl("txtTaskClocked")).Text);
                aTask.TaskEstimatedTime = Decimal.Parse(((Label)e.Item.FindControl("txtTaskEstimated")).Text);
                aTask.TaskDescription = ((Label)e.Item.FindControl("txtTaskName")).Text;
                aTask.Update();
                BindTasks(aTask.StoryID);
            }
            else if (e.CommandName == "TaskDelete")
            {
                aTask.Delete();
                BindTasks(aTask.StoryID);
            }
        }

        void rStories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "storyOpen")
            {
                Avenue.Workflow.Access.Story aStory = new Avenue.Workflow.Access.Story((Int32)e.CommandArgument);
                sStory = aStory;
                BindTasks(aStory);
            }
            else if (e.CommandName == "storyDelete")
            {
                Avenue.Workflow.Access.Story aStory = new Avenue.Workflow.Access.Story((Int32)e.CommandArgument);
                while (aStory.Tasks.Count() != 0)
                {
                    aStory.Tasks.First().Delete();
                }
                aStory.Delete();
            }
        }

        void rTasks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lblStoryName = (Label)e.Item.FindControl("lblStoryName");
                Label lblTaskTotal = (Label)e.Item.FindControl("lblTaskTotal");
                Label lblTaskCompleted = (Label)e.Item.FindControl("lblTaskCompleted");

                lblStoryName.Text = sStory.StoryDescription;
                lblTaskTotal.Text = sStory.Tasks.Count().ToString();
                lblTaskCompleted.Text = sStory.Tasks.SelectByCompleted().Count().ToString();
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Avenue.Workflow.Access.Task aTask = (Avenue.Workflow.Access.Task)e.Item.DataItem;
                Label lblTaskDesc = (Label)e.Item.FindControl("lblTaskName");
                Label lblTimeEstimated = (Label)e.Item.FindControl("lblTimeEstimated");
                Label lblTimeClocked = (Label)e.Item.FindControl("lblTimeClocked");
                TextBox txtTaskName = (TextBox)e.Item.FindControl("txtTaskName");
                TextBox txtTimeEstimated = (TextBox)e.Item.FindControl("txtTimeEstimated");
                TextBox txtTimeClocked = (TextBox)e.Item.FindControl("txtTimeClocked");

                DropDownList ddlTaskStatus = (DropDownList)e.Item.FindControl("ddlTaskStatus");

                ddlTaskStatus.SelectedIndexChanged += ddlTaskStatus_SelectedIndexChanged;

                ddlTaskStatus.DataSource = TaskStatuses;
                ddlTaskStatus.DataBind();

                txtTaskName.Text = lblTaskDesc.Text = aTask.TaskDescription;
                
                if (aTask.TaskEstimatedTime.HasValue)
                    txtTimeEstimated.Text = lblTimeEstimated.Text = aTask.TaskEstimatedTime.Value.ToString();
                if (aTask.TaskClockedTime.HasValue)
                    txtTimeClocked.Text = lblTimeClocked.Text = aTask.TaskClockedTime.Value.ToString();
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

            }
        }

        void ddlTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTaskStatus = (DropDownList)sender;
            RepeaterItem rItem = (RepeaterItem)ddlTaskStatus.BindingContainer;
            HiddenField hfTaskID = (HiddenField)rItem.FindControl("hfTaskID");
            if (ddlTaskStatus.SelectedItem.Value == "4")
            {
                CurrentTask = new Avenue.Workflow.Access.Task((Int32.Parse(hfTaskID.Value)));

                if (!CurrentTask.TaskStartDate.HasValue) CurrentTask.TaskStartDate = DateTime.Now;
                HttpCookie cookie = new HttpCookie("currentTask");
                cookie["TaskID"] = CurrentTask.TaskID.ToString();
                cookie["Time"] = DateTime.Now.ToString();
                Request.Cookies.Add(cookie);
            }
            else if (ddlTaskStatus.SelectedItem.Value == "2")
            {

                if (Request.Cookies["currentTask"] != null)
                {
                    if (hfTaskID.Value == Request.Cookies["currentTask"]["TaskID"])
                    {
                        //Request.Cookies["currentTask"]
                    }
                    //else
                //}
                //else
                //{

                }
            }
        }

        void rStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lblTaskTotal = (Label)e.Item.FindControl("lblTaskTotal");
                Label lblTaskComplete = (Label)e.Item.FindControl("lblTaskComplete");

                Int32 tTotal = 0, tCompleted = 0;
                foreach (Avenue.Workflow.Access.Story aStory in CurrentIteration.IterationTimePeriods.getCurrentTimePeriod().Stories)
                {
                    tTotal += aStory.Tasks.Count();
                    tCompleted += aStory.Tasks.SelectByCompleted().Count();
                }

                lblTaskTotal.Text = tTotal.ToString();
                lblTaskComplete.Text = tCompleted.ToString();
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Avenue.Workflow.Access.Story aStory = (Avenue.Workflow.Access.Story)e.Item.DataItem;
                Label lblStoryName = (Label)e.Item.FindControl("lblStoryName");
                Label lblTaskTotal = (Label)e.Item.FindControl("lblTaskTotal");
                Label lblTaskCompleted = (Label)e.Item.FindControl("lblTaskCompleted");

                lblStoryName.Text = aStory.StoryDescription;
                lblTaskTotal.Text = aStory.Tasks.Count().ToString();
                lblTaskCompleted.Text = aStory.Tasks.SelectByCompleted().Count().ToString();
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

            }
        }

        void iStoryAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (txtSearch.Text != "")
                CurrentIteration.IterationTimePeriods.getCurrentTimePeriod().AddStory(txtSearch.Text, new Avenue.Workflow.Access.StoryType((Int32)Avenue.Workflow.Access.StoryType.E_StoryType.Work));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProgress();
                BindCurrentTask();
                BindStories();
            }
        }

        public void BindCurrentTask()
        {
            if (CurrentTask != null)
            {
                lblTaskName.Text = CurrentTask.TaskDescription;
                if (CurrentTask.TaskClockedTime.HasValue)
                    lblTaskTime.Text = CurrentTask.TaskClockedTime.Value.ToString();
            }
        }

        public void BindProgress()
        {
            if (CurrentUser.AllTasks.Count() > 0)
            {
                Int32 uProgress = 0;
                if (CurrentUser.CompletedTasks.Count > 0)
                    uProgress = (Int32)(CurrentUser.CompletedTasks.Count() / CurrentUser.AllTasks.Count()) * 100;

                dProgress.Style.Add("width", String.Format("{0}%", uProgress));
            }
        }

        public void BindStories()
        {
            rStories.DataSource = CurrentIteration.IterationTimePeriods.getCurrentTimePeriod().Stories;
            rStories.DataBind();
        }

        public void BindTasks(Avenue.Workflow.Access.Story aStory)
        {
            rTasks.DataSource = aStory.Tasks;
            rTasks.DataBind();
        }
    }
}