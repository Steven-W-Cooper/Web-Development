using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class IterationType : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {

        #region Enum

        public enum E_IterationType
        {
            Coursework = 1,
            Subject = 2,
            GroupWork = 3,
            GeneralWork = 4
        }

        #endregion
        private Avenue.Workflow.Data.IterationType _IterationType;

        #region Properties

        private Avenue.Workflow.Data.IterationType AccessIterationType
        {
            get { return _IterationType; }
            set { _IterationType = value; }
        }

        public Int32 IterationTypeID
        {
            get { return AccessIterationType.IterationTypeID; }
        }

        public String IterationTypeName
        {
            get { return AccessIterationType.IterationTypeName; }
            set { AccessIterationType.IterationTypeName = value; }
        }

        #endregion

        #region Constructors

        public IterationType()
            : base()
        {
            AccessIterationType = new Data.IterationType();
        }

        public IterationType(Int32 IterationTypeID)
            : base()
        {
            AccessIterationType = new Data.IterationType(IterationTypeID);
        }

        public IterationType(Avenue.Heights.Data.AvenueData DataIterationType)
            : base()
        {
            AccessIterationType = (Avenue.Workflow.Data.IterationType)DataIterationType;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.IterationTypes aIterationTypes = new IterationTypes(this);
            return (System.Collections.IList)aIterationTypes;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.IterationType xT = null;
            if (typeof(IterationType) == obj.GetType())
            {
                xT = (IterationType)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((IterationType)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(IterationType other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 IterationTypeID)
        {
            AccessIterationType.Get(IterationTypeID);
            return this;
        }

        public void Insert()
        {
            AccessIterationType.Insert();
        }

        public void Update()
        {
            AccessIterationType.Update();
        }

        public void Delete()
        {
            AccessIterationType.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("IterationType{0}", this.AccessIterationType);
        }

        public override bool Equals(object obj)
        {
            if (typeof(IterationType) == obj.GetType())
            {
                IterationType xT = null;
                xT = (Access.IterationType)obj;
                return (xT.IterationTypeID.Equals(this.IterationTypeID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class IterationTypeComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public IterationTypeComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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
