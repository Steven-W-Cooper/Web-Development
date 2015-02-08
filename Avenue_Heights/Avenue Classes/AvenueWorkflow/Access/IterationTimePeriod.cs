using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class IterationTimePeriod : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.IterationTimePeriod _IterationTimePeriod;

        private Avenue.Workflow.Access.Iteration _IterationID;

        #region Properties

        private Avenue.Workflow.Data.IterationTimePeriod AccessIterationTimePeriod
        {
            get { return _IterationTimePeriod; }
            set { _IterationTimePeriod = value; }
        }

        public Int32 IterationTimePeriodID
        {
            get { return AccessIterationTimePeriod.IterationTimePeriodID; }
        }

        public Access.Iteration IterationID
        {
            get
            {
                if (_IterationID == null)
                {
                    _IterationID = new Iteration();
                    _IterationID.Get(AccessIterationTimePeriod.IterationID);
                }
                return _IterationID;
            }
            set
            {
                _IterationID = value;
                AccessIterationTimePeriod.IterationID = value.IterationID;
            }
        }

        public DateTime IterationTimePeriodStartDate
        {
            get { return AccessIterationTimePeriod.IterationTimePeriodStartDate; }
            set { AccessIterationTimePeriod.IterationTimePeriodStartDate = value; }
        }

        public DateTime IterationTimePeriodEndDate
        {
            get { return AccessIterationTimePeriod.IterationTimePeriodEndDate; }
            set { AccessIterationTimePeriod.IterationTimePeriodEndDate = value; }
        }

        #endregion

        #region Constructors

        public IterationTimePeriod()
            : base()
        {
            AccessIterationTimePeriod = new Data.IterationTimePeriod();
        }

        public IterationTimePeriod(Int32 IterationTimePeriodID)
            : base()
        {
            AccessIterationTimePeriod = new Data.IterationTimePeriod(IterationTimePeriodID);
        }

        public IterationTimePeriod(Avenue.Heights.Data.AvenueData DataIterationTimePeriod)
            : base()
        {
            AccessIterationTimePeriod = (Avenue.Workflow.Data.IterationTimePeriod)DataIterationTimePeriod;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.IterationTimePeriods aIterationTimePeriods = new IterationTimePeriods(this);
            return (System.Collections.IList)aIterationTimePeriods;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.IterationTimePeriod xT = null;
            if (typeof(IterationTimePeriod) == obj.GetType())
            {
                xT = (IterationTimePeriod)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((IterationTimePeriod)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(IterationTimePeriod other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 IterationTimePeriodID)
        {
            AccessIterationTimePeriod.Get(IterationTimePeriodID);
            return this;
        }

        public void Insert()
        {
            AccessIterationTimePeriod.Insert();
        }

        public void Update()
        {
            AccessIterationTimePeriod.Update();
        }

        public void Delete()
        {
            AccessIterationTimePeriod.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("IterationTimePeriod{0}", this.AccessIterationTimePeriod);
        }

        public override bool Equals(object obj)
        {
            if (typeof(IterationTimePeriod) == obj.GetType())
            {
                IterationTimePeriod xT = null;
                xT = (Access.IterationTimePeriod)obj;
                return (xT.IterationTimePeriodID.Equals(this.IterationTimePeriodID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class IterationTimePeriodComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public IterationTimePeriodComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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

        public Access.Stories Stories
        {
            get { return new Stories().GetByIterationTimePeriodID(this.IterationTimePeriodID); }
        }

        #endregion

        #region Other Methods

        public Access.Story AddStory(String StoryDescription, Access.StoryType StoryType)
        {
            Access.Story AccessStory = new Story();
            AccessStory.IterationID = this.IterationID;
            AccessStory.IterationTimePeriodID = this;
            AccessStory.StoryDescription = StoryDescription;
            AccessStory.StoryTypeID = StoryType;
            AccessStory.Insert();
            return AccessStory;
        }

        #endregion
    }
}
