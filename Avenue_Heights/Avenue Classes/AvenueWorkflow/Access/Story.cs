using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Story : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.Story _Story;

        private Avenue.Workflow.Access.Iteration _IterationID;

        private Avenue.Workflow.Access.IterationTimePeriod _IterationTimePeriodID;

        private Avenue.Workflow.Access.StoryType _StoryTypeID;

        #region Properties

        private Avenue.Workflow.Data.Story AccessStory
        {
            get { return _Story; }
            set { _Story = value; }
        }

        public Int32 StoryID
        {
            get { return AccessStory.StoryID; }
        }

        public Access.Iteration IterationID
        {
            get
            {
                if (_IterationID == null)
                {
                    _IterationID = new Iteration();
                    _IterationID.Get(AccessStory.IterationID);
                }
                return _IterationID;
            }
            set
            {
                _IterationID = value;
                AccessStory.IterationID = value.IterationID;
            }
        }

        public Access.IterationTimePeriod IterationTimePeriodID
        {
            get
            {
                if (_IterationTimePeriodID == null)
                {
                    if (AccessStory.IterationTimePeriodID.HasValue)
                    {
                        _IterationTimePeriodID = new IterationTimePeriod();
                        _IterationTimePeriodID.Get(AccessStory.IterationTimePeriodID.Value);
                    }
                }
                return _IterationTimePeriodID;
            }
            set
            {
                _IterationTimePeriodID = value;
                AccessStory.IterationTimePeriodID = value.IterationTimePeriodID;
            }
        }

        public String StoryDescription
        {
            get { return AccessStory.StoryDescription; }
            set { AccessStory.StoryDescription = value; }
        }

        public Access.StoryType StoryTypeID
        {
            get
            {
                if (_StoryTypeID == null)
                {
                    _StoryTypeID = new StoryType();
                    _StoryTypeID.Get(AccessStory.StoryTypeID);
                }
                return _StoryTypeID;
            }
            set
            {
                _StoryTypeID = value;
                AccessStory.StoryTypeID = value.StoryTypeID;
            }
        }

        #endregion

        #region Constructors

        public Story()
            : base()
        {
            AccessStory = new Data.Story();
        }

        public Story(Int32 StoryID)
            : base()
        {
            AccessStory = new Data.Story(StoryID);
        }

        public Story(Avenue.Heights.Data.AvenueData DataStory)
            : base()
        {
            AccessStory = (Avenue.Workflow.Data.Story)DataStory;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.Stories aStorys = new Stories(this);
            return (System.Collections.IList)aStorys;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.Story xT = null;
            if (typeof(Story) == obj.GetType())
            {
                xT = (Story)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((Story)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(Story other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 StoryID)
        {
            AccessStory.Get(StoryID);
            return this;
        }

        public void Insert()
        {
            AccessStory.Insert();
        }

        public void Update()
        {
            AccessStory.Update();
        }

        public void Delete()
        {
            AccessStory.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("Story{0}", this.AccessStory);
        }

        public override bool Equals(object obj)
        {
            if (typeof(Story) == obj.GetType())
            {
                Story xT = null;
                xT = (Access.Story)obj;
                return (xT.StoryID.Equals(this.StoryID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class StoryComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public StoryComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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

        #region Other Properties

        public Access.Tasks Tasks
        {
            get { return new Tasks().GetByStoryID(this.StoryID); }
        }

        #endregion

        #region Other Methods

        public Access.Task AddTask(String TaskDescription, User User)
        {
            Access.Task AccessTask = new Task();
            AccessTask.StoryID = this;
            AccessTask.TaskDescription = TaskDescription;
            AccessTask.TaskStatusID = new TaskStatus(((Int32)Avenue.Workflow.Access.TaskStatus.E_TaskStatuses.ToStart));
            AccessTask.TaskAssignedUser = User;
            AccessTask.Insert();
            return AccessTask;
        }

        #endregion
    }
}
