using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Task : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.Task _Task;

        private Avenue.Workflow.Access.Story _StoryID;

        private Avenue.Workflow.Access.TaskStatus _TaskStatusID;

        private Avenue.Workflow.Access.User _TaskAssignedUser;

        #region Properties

        private Avenue.Workflow.Data.Task AccessTask
        {
            get { return _Task; }
            set { _Task = value; }
        }

        public Int32 TaskID
        {
            get { return AccessTask.TaskID; }
        }

        public Access.Story StoryID
        {
            get
            {
                if (_StoryID == null)
                {
                    _StoryID = new Story();
                    _StoryID.Get(AccessTask.StoryID);
                }
                return _StoryID;
            }
            set
            {
                _StoryID = value;
                AccessTask.StoryID = value.StoryID;
            }
        }

        public String TaskDescription
        {
            get { return AccessTask.TaskDescription; }
            set { AccessTask.TaskDescription = value; }
        }

        public DateTime? TaskStartDate
        {
            get { return AccessTask.TaskStartDate; }
            set { AccessTask.TaskStartDate = value; }
        }

        public DateTime? TaskEndDate
        {
            get { return AccessTask.TaskEndDate; }
            set { AccessTask.TaskEndDate = value; }
        }

        public Decimal? TaskEstimatedTime
        {
            get { return AccessTask.TaskEstimatedTime; }
            set { AccessTask.TaskEstimatedTime = value; }
        }

        public Decimal? TaskClockedTime
        {
            get { return AccessTask.TaskClockedTime; }
            set { AccessTask.TaskClockedTime = value; }
        }

        public Access.TaskStatus TaskStatusID
        {
            get
            {
                if (_TaskStatusID == null)
                {
                    _TaskStatusID = new TaskStatus();
                    _TaskStatusID.Get(AccessTask.TaskStatusID);
                }
                return _TaskStatusID;
            }
            set
            {
                _TaskStatusID = value;
                AccessTask.TaskStatusID = value.TaskStatusID;
            }
        }

        public Access.User TaskAssignedUser
        {
            get
            {
                if (_TaskAssignedUser == null)
                {
                    if(AccessTask.TaskAssignedUser.HasValue)
                    {
                    _TaskAssignedUser = new User();
                    _TaskAssignedUser.Get(AccessTask.TaskAssignedUser.Value);
                    }
                }
                return _TaskAssignedUser;
            }
            set
            {
                _TaskAssignedUser = value;
                AccessTask.TaskAssignedUser = value.UserID;
            }
        }

        #endregion

        #region Constructors

        public Task()
            : base()
        {
            AccessTask = new Data.Task();
        }

        public Task(Int32 TaskID)
            : base()
        {
            AccessTask = new Data.Task(TaskID);
        }

        public Task(Avenue.Heights.Data.AvenueData DataTask)
            : base()
        {
            AccessTask = (Avenue.Workflow.Data.Task)DataTask;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.Tasks aTasks = new Tasks(this);
            return (System.Collections.IList)aTasks;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.Task xT = null;
            if (typeof(Task) == obj.GetType())
            {
                xT = (Task)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((Task)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(Task other, System.ComponentModel.PropertyDescriptor Prop)
        {
            Object propertyX;
            Object propertyY;
            if (Prop != null)
            {
                propertyX = Prop.GetValue(this);
                propertyY = Prop.GetValue(other);
                if (propertyX != null && propertyY != null)
                {
                    if (propertyX.Equals(propertyY)) return 1;
                    else return 0;
                }
                else return 0;
            }
            else return 0;
        }

        #endregion

        #region Default Methods

        public Avenue.Heights.Access.AvenueData Get(Int32 TaskID)
        {
            AccessTask.Get(TaskID);
            return this;
        }

        public void Insert()
        {
            AccessTask.Insert();
        }

        public void Update()
        {
            AccessTask.Update();
        }

        public void Delete()
        {
            AccessTask.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("Task{0}", this.AccessTask);
        }

        public override bool Equals(object obj)
        {
            if (typeof(Task) == obj.GetType())
            {
                Task xT = null;
                xT = (Access.Task)obj;
                return (xT.TaskID.Equals(this.TaskID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class TaskComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public TaskComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
                : base()
            {
                _sortProperty = initProp;
                _sortDirection = initDirection;
            }

            public Int32 Compare(Object x, Object y)
            {
                Nullable<Int32> result = null;

                Object PropertyX;
                Object PropertyY;
                if (_sortProperty != null)
                {
                    PropertyX = _sortProperty.GetValue(x);
                    PropertyY = _sortProperty.GetValue(y);
                    if (PropertyX != null && PropertyY != null)
                    {
                        if (PropertyX.Equals(PropertyY)) result = 1;
                        else result = 0;
                    }
                }
                if (_sortDirection == System.ComponentModel.ListSortDirection.Descending) result = -result;
                return result.Value;
            }
        }

        #endregion
    }
}
