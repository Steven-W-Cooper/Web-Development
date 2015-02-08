using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class StoryType : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        #region Enum

        public enum E_StoryType
        {
            Bug = 1,
            Task = 2,
            Work = 3,
            Research = 4,
            Problem = 5
        }

        #endregion

        private Avenue.Workflow.Data.StoryType _StoryType;

        #region Properties

        private Avenue.Workflow.Data.StoryType AccessStoryType
        {
            get { return _StoryType; }
            set { _StoryType = value; }
        }

        public Int32 StoryTypeID
        {
            get { return AccessStoryType.StoryTypeID; }
        }

        public String StoryTypeName
        {
            get { return AccessStoryType.StoryTypeName; }
            set { AccessStoryType.StoryTypeName = value; }
        }

        #endregion

        #region Constructors

        public StoryType()
            : base()
        {
            AccessStoryType = new Data.StoryType();
        }

        public StoryType(Int32 StoryTypeID)
            : base()
        {
            AccessStoryType = new Data.StoryType(StoryTypeID);
        }

        public StoryType(Avenue.Heights.Data.AvenueData DataStoryType)
            : base()
        {
            AccessStoryType = (Avenue.Workflow.Data.StoryType)DataStoryType;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.StoryTypes aStoryTypes = new StoryTypes(this);
            return (System.Collections.IList)aStoryTypes;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.StoryType xT = null;
            if (typeof(StoryType) == obj.GetType())
            {
                xT = (StoryType)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((StoryType)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(StoryType other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 StoryTypeID)
        {
            AccessStoryType.Get(StoryTypeID);
            return this;
        }

        public void Insert()
        {
            AccessStoryType.Insert();
        }

        public void Update()
        {
            AccessStoryType.Update();
        }

        public void Delete()
        {
            AccessStoryType.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("StoryType{0}", this.AccessStoryType);
        }

        public override bool Equals(object obj)
        {
            if (typeof(StoryType) == obj.GetType())
            {
                StoryType xT = null;
                xT = (Access.StoryType)obj;
                return (xT.StoryTypeID.Equals(this.StoryTypeID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class StoryTypeComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public StoryTypeComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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
