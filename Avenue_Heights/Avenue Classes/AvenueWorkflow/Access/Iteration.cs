using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Iteration : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.Iteration _Iteration;

        private Avenue.Workflow.Access.IterationType _IterationTypeID;

        private Avenue.Workflow.Access.User _IterationOwner;

        #region Properties

        private Avenue.Workflow.Data.Iteration AccessIteration
        {
            get { return _Iteration; }
            set { _Iteration = value; }
        }

        public Int32 IterationID
        {
            get { return AccessIteration.IterationID; }
        }

        public String IterationDescription
        {
            get { return AccessIteration.IterationDescription; }
            set { AccessIteration.IterationDescription = value; }
        }

        public Access.IterationType IterationTypeID
        {
            get
            {
                if (_IterationTypeID == null)
                {
                    _IterationTypeID = new IterationType();
                    _IterationTypeID.Get(AccessIteration.IterationTypeID);
                }
                return _IterationTypeID;
            }
            set
            {
                _IterationTypeID = value;
                AccessIteration.IterationTypeID = value.IterationTypeID;
            }
        }

        public Int32? DefaultIterationTimePeriod
        {
            get { return AccessIteration.DefaultIterationTimePeriod; }
            set { AccessIteration.DefaultIterationTimePeriod = value.Value; }
        }

        public Access.User IterationOwner
        {
            get
            {
                if (_IterationOwner == null)
                {
                    _IterationOwner = new User();
                    _IterationOwner.Get(AccessIteration.IterationOwner);
                }
                return _IterationOwner;
            }
            set
            {
                _IterationOwner = value;
                AccessIteration.IterationOwner = value.UserID;
            }
        }

        #endregion

        #region Constructors

        public Iteration()
            : base()
        {
            AccessIteration = new Data.Iteration();
        }

        public Iteration(Int32 IterationID)
            : base()
        {
            AccessIteration = new Data.Iteration(IterationID);
        }

        public Iteration(Avenue.Heights.Data.AvenueData DataIteration)
            : base()
        {
            AccessIteration = (Avenue.Workflow.Data.Iteration)DataIteration;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.Iterations aIterations = new Iterations(this);
            return (System.Collections.IList)aIterations;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.Iteration xT = null;
            if (typeof(Iteration) == obj.GetType())
            {
                xT = (Iteration)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((Iteration)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(Iteration other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 IterationID)
        {
            AccessIteration.Get(IterationID);
            return this;
        }

        public void Insert()
        {
            AccessIteration.Insert();
            Access.UserIteration newUserIteration = new Access.UserIteration();
            newUserIteration.UserID = this.IterationOwner;
            newUserIteration.IterationID = this;
            newUserIteration.Insert();
        }

        public void Update()
        {
            AccessIteration.Update();
        }

        public void Delete()
        {
            AccessIteration.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("Iteration{0}", this.AccessIteration);
        }

        public override bool Equals(object obj)
        {
            if (typeof(Iteration) == obj.GetType())
            {
                Iteration xT = null;
                xT = (Access.Iteration)obj;
                return (xT.IterationID.Equals(this.IterationID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class IterationComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public IterationComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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

        public class IterationEqualityComparer : Object, System.Collections.Generic.IEqualityComparer<Access.Iteration>
        {
            public Boolean Equals(Iteration x, Iteration y)
            {
                if (x.IterationID.Equals(y.IterationID)) return true;
                else return false;
            }

            public Int32 GetHashCode(Iteration obj)
            {
                return base.GetHashCode();
            }
        }

        #endregion

        #region Other Properties

        private Users _Users;

        private IterationTimePeriods _IterationTimePeriods;

        public Users Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserIterations().GetByIterationID(this.IterationID).SelectDistinctUsers();
                }
                return _Users;
            }
        }

        public IterationTimePeriods IterationTimePeriods
        {
            get
            {
                if (_IterationTimePeriods == null)
                {
                    _IterationTimePeriods = new IterationTimePeriods().GetByIterationID(this.IterationID);
                }
                return _IterationTimePeriods;
            }
        }

        #endregion

        #region Other Functions


        public void addNewIterationTimePeriods()
        {
            Access.IterationTimePeriod aITP = this.IterationTimePeriods.getNewestTimePeriod();
            DateTime fiveWeekAhead = DateTime.Now.AddDays(35);
            if (fiveWeekAhead >= aITP.IterationTimePeriodEndDate)
            {
                Access.IterationTimePeriod newITP = new IterationTimePeriod();
                newITP.IterationTimePeriodStartDate = aITP.IterationTimePeriodEndDate.AddDays(1);
                if (this.DefaultIterationTimePeriod.HasValue) newITP.IterationTimePeriodEndDate = newITP.IterationTimePeriodStartDate.AddDays(((double)this.DefaultIterationTimePeriod) * 7);
                else newITP.IterationTimePeriodEndDate = newITP.IterationTimePeriodStartDate.AddDays(7);

                newITP.Insert();
            }
        }

        #endregion
    }
}
