using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow
{
    public class WorkflowPage : Avenue.Heights.AvenueHeightsPage
    {
        private Access.User _CurrentUser;
        
        private Access.Iteration _CurrentIteration;

        private Access.Task _CurrentTask;

        private Access.IterationTypes _IterationTypes;

        private Access.StoryTypes _StoryTypes;

        private Access.TaskStatuses _TaskStatuses;

        private Access.Themes _Themes;

        public Access.User CurrentUser
        {
            get
            {
                if (_CurrentUser == null) _CurrentUser = new Access.User(UserID);
                return _CurrentUser;
            }
        }

        public Access.Iteration CurrentIteration
        {
            get
            {
                if (_CurrentIteration == null) _CurrentIteration = new Access.Iteration(WorkflowIterationID);
                return _CurrentIteration;
            }
            set
            {
                _CurrentIteration = value;
                WorkflowIterationID = value.IterationID;
            }
        }

        public Access.Task CurrentTask
        {
            get
            {
                if (_CurrentTask == null) _CurrentTask = new Access.Task(WorkflowTaskID);
                return _CurrentTask;
            }
            set
            {
                _CurrentTask = value;
                WorkflowTaskID = value.TaskID; }
            }

        public Access.Story CurrentStory
        {
            get { return CurrentTask.StoryID; }
        }

        public Access.IterationTypes IterationTypes
        {
            get
            {
                if (_IterationTypes == null) _IterationTypes = new Access.IterationTypes().GetAll();
                return _IterationTypes;
            }
        }

        public Access.StoryTypes StoryTypes
        {
            get
            {
                if (_StoryTypes == null) _StoryTypes = new Access.StoryTypes().GetAll();
                return _StoryTypes;
            }
        }

        public Access.TaskStatuses TaskStatuses
        {
            get
            {
                if (_TaskStatuses == null) _TaskStatuses = new Access.TaskStatuses().GetAll();
                return _TaskStatuses;
            }
        }

        public Access.Themes Themes
        {
            get
            {
                if (_Themes == null) _Themes = new Access.Themes().GetAll();
                return _Themes;
            }
        }
    }

    public partial class WorkflowControl : Avenue.Heights.AvenueHeightsControl
    {
        private Access.User _CurrentUser;

        private Access.Iteration _CurrentIteration;

        public Access.User CurrentUser
        {
            get
            {
                if (_CurrentUser == null) _CurrentUser = new Access.User(UserID);
                return _CurrentUser;
            }
            set
            {
                _CurrentUser = value;
                UserID = value.UserID;
            }
        }

        public Access.Iteration CurrentIteration
        {
            get
            {
                if (_CurrentIteration == null) _CurrentIteration = new Access.Iteration(WorkflowIterationID);
                return _CurrentIteration;
            }
            set
            {
                _CurrentIteration = value;
                WorkflowIterationID = value.IterationID;
            }
        }
        
        protected void Page_PreInit(object sender, EventArgs e)
        {
          if(CurrentIteration.IterationID != 0)  CurrentIteration.addNewIterationTimePeriods();
        }
    }
}
