using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Tasks : System.Collections.Generic.List<Access.Task>
    {
        #region Constructors

        public Tasks()
            : base()
        {

        }

        public Tasks(Avenue.Heights.Data.AvenueCollection DataTasks)
            : base()
        {
            Generate(DataTasks);
        }

        public Tasks(Access.Task[] AccessTasks)
            : base()
        {
            this.AddRange(AccessTasks);
        }

        public Tasks(System.Collections.Generic.IEnumerable<Access.Task> AccessTasks)
            : base()
        {
            this.AddRange(AccessTasks);
        }

        public Tasks(Access.Task ATask)
            : base()
        {
            this.Add(ATask);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataTasks)
        {
            foreach (Data.Task aTask in DataTasks)
            {
                base.Add(new Access.Task(aTask));
            }
        }

        #region Get

        public Access.Tasks Get(Int32 TaskID)
        {
            Data.Task aTask = new Data.Task(TaskID);
            this.Add(new Access.Task(aTask));
            return this;
        }

        public Access.Tasks GetByStoryID(Int32 StoryID)
        {
            Data.Tasks DataTasks = new Data.Tasks();
            DataTasks.GetByStoryID(StoryID);
            Generate(DataTasks);
            return this;
        }

        public Access.Tasks GetByTaskStatusID(Int32 TaskStatusID)
        {
            Data.Tasks DataTasks = new Data.Tasks();
            DataTasks.GetByTaskStatusID(TaskStatusID);
            Generate(DataTasks);
            return this;
        }

        public Access.Tasks GetByTaskAssignedUser(Int32 TaskAssignedUser)
        {
            Data.Tasks DataTasks = new Data.Tasks();
            DataTasks.GetByTaskAssignedUser(TaskAssignedUser);
            Generate(DataTasks);
            return this;
        }

        #endregion

        #region Selects

        public Tasks SelectByStory(Story Story)
        {
            return new Tasks(this.Where(f => f.StoryID.StoryID == Story.StoryID));
        }

        public Tasks SelectByTaskStatus(TaskStatus TaskStatus)
        {
            return new Tasks(this.Where(f => f.TaskStatusID.TaskStatusID == TaskStatus.TaskStatusID));
        }

        public Tasks SelectByAssignedUser(User AssignedUser)
        {
            return new Tasks(this.Where(f => f.TaskAssignedUser != null).Where(f => f.TaskAssignedUser.UserID == AssignedUser.UserID));
        }

        public Tasks SelectByCompleted()
        {
            Avenue.Workflow.Access.Tasks newTasks = new Tasks();
            newTasks.AddRange(this.SelectByTaskStatus(new TaskStatus((Int32)Avenue.Workflow.Access.TaskStatus.E_TaskStatuses.Completed)));
            return newTasks;
        }

        public Tasks SelectByInProgress()
        {
            Avenue.Workflow.Access.Tasks newTasks = new Tasks();
            newTasks.AddRange(this.SelectByTaskStatus(new TaskStatus((Int32)Avenue.Workflow.Access.TaskStatus.E_TaskStatuses.ClockedOn)));
            newTasks.AddRange(this.SelectByTaskStatus(new TaskStatus((Int32)Avenue.Workflow.Access.TaskStatus.E_TaskStatuses.Paused)));
            return newTasks;
        }

        #endregion

        #region Filters

        public Tasks FilterByStory(Story Story)
        {
            Tasks tmp = this.SelectByStory(Story);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public Tasks FilterByTaskStatus(TaskStatus TaskStatus)
        {
            Tasks tmp = this.SelectByTaskStatus(TaskStatus);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public Tasks FilterByAssignedUser(User AssignedUser)
        {
            Tasks tmp = this.SelectByAssignedUser(AssignedUser);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        #endregion
    }
}
