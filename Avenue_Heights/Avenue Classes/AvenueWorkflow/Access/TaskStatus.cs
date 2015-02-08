using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class TaskStatus : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        #region Enum

        public enum E_TaskStatuses
        {
            Paused = 1,
            Completed = 2,
            ToStart = 3,
            ClockedOn = 4
        }

        #endregion
        private Avenue.Workflow.Data.TaskStatus _TaskStatus;

        #region Properties

        private Avenue.Workflow.Data.TaskStatus AccessTaskStatus
        {
            get { return _TaskStatus; }
            set { _TaskStatus = value; }
        }

        public Int32 TaskStatusID
        {
            get { return AccessTaskStatus.TaskStatusID; }
        }

        public String TaskStatusName
        {
            get { return AccessTaskStatus.TaskStatusName; }
            set { AccessTaskStatus.TaskStatusName = value; }
        }

        #endregion

        #region Constructors

        public TaskStatus()
            : base()
        {
            AccessTaskStatus = new Data.TaskStatus();
        }

        public TaskStatus(Int32 TaskStatusID)
            : base()
        {
            AccessTaskStatus = new Data.TaskStatus(TaskStatusID);
        }

        public TaskStatus(Avenue.Heights.Data.AvenueData DataTaskStatus)
            : base()
        {
            AccessTaskStatus = (Avenue.Workflow.Data.TaskStatus)DataTaskStatus;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.TaskStatuses aTaskStatuses = new TaskStatuses(this);
            return (System.Collections.IList)aTaskStatuses;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.TaskStatus xT = null;
            if (typeof(TaskStatus) == obj.GetType())
            {
                xT = (TaskStatus)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((TaskStatus)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(TaskStatus other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 TaskStatusID)
        {
            AccessTaskStatus.Get(TaskStatusID);
            return this;
        }

        public void Insert()
        {
            AccessTaskStatus.Insert();
        }

        public void Update()
        {
            AccessTaskStatus.Update();
        }

        public void Delete()
        {
            AccessTaskStatus.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("TaskStatus{0}", this.AccessTaskStatus);
        }

        public override bool Equals(object obj)
        {
            if (typeof(TaskStatus) == obj.GetType())
            {
                TaskStatus xT = null;
                xT = (Access.TaskStatus)obj;
                return (xT.TaskStatusID.Equals(this.TaskStatusID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class TaskStatusComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public TaskStatusComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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
