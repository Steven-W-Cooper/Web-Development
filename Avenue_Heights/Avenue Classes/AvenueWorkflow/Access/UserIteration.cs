using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class UserIteration : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.UserIteration _UserIteration;

        private Avenue.Workflow.Access.User _UserID;

        private Avenue.Workflow.Access.Iteration _IterationID;

        #region Properties

        private Avenue.Workflow.Data.UserIteration AccessUserIteration
        {
            get { return _UserIteration; }
            set { _UserIteration = value; }
        }

        public Int32 UserIterationID
        {
            get { return AccessUserIteration.UserIterationID; }
        }

        public Access.User UserID
        {
            get
            {
                if (_UserID == null)
                {
                    _UserID = new Access.User();
                    _UserID.Get(AccessUserIteration.UserID);
                }
                return _UserID;
            }
            set
            {
                _UserID = value;
                AccessUserIteration.UserID = value.UserID;
            }
        }

        public Access.Iteration IterationID
        {
            get
            {
                if (_IterationID == null)
                {
                    _IterationID = new Iteration();
                    _IterationID.Get(AccessUserIteration.IterationID);
                }
                return _IterationID;
            }
            set
            {
                _IterationID = value;
                AccessUserIteration.IterationID = value.IterationID;
            }
        }

        #endregion

        #region Constructors

        public UserIteration()
            : base()
        {
            AccessUserIteration = new Data.UserIteration();
        }

        public UserIteration(Int32 UserIterationID)
            : base()
        {
            AccessUserIteration = new Data.UserIteration(UserIterationID);
        }

        public UserIteration(Avenue.Heights.Data.AvenueData DataUserIteration)
            : base()
        {
            AccessUserIteration = (Avenue.Workflow.Data.UserIteration)DataUserIteration;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.UserIterations aUserIterations = new UserIterations(this);
            return (System.Collections.IList)aUserIterations;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.UserIteration xT = null;
            if (typeof(UserIteration) == obj.GetType())
            {
                xT = (UserIteration)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((UserIteration)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(UserIteration other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 UserIterationID)
        {
            AccessUserIteration.Get(UserIterationID);
            return this;
        }

        public void Insert()
        {
            AccessUserIteration.Insert();
        }

        public void Update()
        {
            AccessUserIteration.Update();
        }

        public void Delete()
        {
            AccessUserIteration.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("UserIteration{0}", this.AccessUserIteration);
        }

        public override bool Equals(object obj)
        {
            if (typeof(UserIteration) == obj.GetType())
            {
                UserIteration xT = null;
                xT = (Access.UserIteration)obj;
                return (xT.UserIterationID.Equals(this.UserIterationID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class UserIterationComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public UserIterationComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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
