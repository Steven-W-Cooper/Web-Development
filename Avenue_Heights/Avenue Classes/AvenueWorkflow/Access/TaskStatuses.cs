using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class TaskStatuses : System.Collections.Generic.List<Access.TaskStatus>
    {
        #region Constructors

        public TaskStatuses()
            : base()
        {

        }

        public TaskStatuses(Avenue.Heights.Data.AvenueCollection DataTaskStatuses)
            : base()
        {
            Generate(DataTaskStatuses);
        }

        public TaskStatuses(Access.TaskStatus[] AccessTaskStatuses)
            : base()
        {
            this.AddRange(AccessTaskStatuses);
        }

        public TaskStatuses(System.Collections.Generic.IEnumerable<Access.TaskStatus> AccessTaskStatuses)
            : base()
        {
            this.AddRange(AccessTaskStatuses);
        }

        public TaskStatuses(Access.TaskStatus ATaskStatus)
            : base()
        {
            this.Add(ATaskStatus);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataTaskStatuses)
        {
            foreach (Data.TaskStatus aTaskStatus in DataTaskStatuses)
            {
                base.Add(new Access.TaskStatus(aTaskStatus));
            }
        }

        #region Get

        public Access.TaskStatuses Get(Int32 TaskStatusID)
        {
            Data.TaskStatus aTaskStatus = new Data.TaskStatus(TaskStatusID);
            this.Add(new Access.TaskStatus(aTaskStatus));
            return this;
        }

        public Access.TaskStatuses GetAll()
        {
            Data.TaskStatuses DataTaskStatuses = new Data.TaskStatuses();
            DataTaskStatuses.GetAll();
            Generate(DataTaskStatuses);
            return this;
        }
        #endregion
    }
}
