using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class User : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        private Avenue.Workflow.Data.User _User;

        private Avenue.Workflow.Access.Theme _UserThemeID;

        #region Properties

        private Avenue.Workflow.Data.User AccessUser
        {
            get { return _User; }
            set { _User = value; }
        }

        public Int32 UserID
        {
            get { return AccessUser.UserID; }
        }

        public String UserFirstName
        {
            get { return AccessUser.UserFirstName; }
            set { AccessUser.UserFirstName = value; }
        }

        public String UserLastName
        {
            get { return AccessUser.UserLastName; }
            set { AccessUser.UserLastName = value; }
        }

        public String UserName
        {
            get { return AccessUser.UserName; }
            set { AccessUser.UserName = value; }
        }

        public String UserEmail
        {
            get { return AccessUser.UserEmail; }
            set { AccessUser.UserEmail = value; }
        }

        public Access.Theme UserThemeID
        {
            get
            {
                if (_UserThemeID == null)
                {
                    _UserThemeID = new Theme();
                    _UserThemeID.Get(AccessUser.UserID);
                }
                return _UserThemeID;
            }
            set
            {
                _UserThemeID = value;
                AccessUser.UserThemeID = value.ThemeID;
            }
        }

        public Guid? UserAspNetMembership
        {
            get { return AccessUser.UserAspNetMembership; }
            set { AccessUser.UserAspNetMembership = value.Value; }
        }

        public byte[] UserPicture
        {
            get { return AccessUser.UserPicture; }
            set { AccessUser.UserPicture = value; }
        }

        #endregion

        #region Constructors

        public User()
            : base()
        {
            AccessUser = new Data.User();
        }

        public User(Int32 UserID)
            : base()
        {
            AccessUser = new Data.User(UserID);
        }

        public User(Avenue.Heights.Data.AvenueData DataUser)
            : base()
        {
            AccessUser = (Avenue.Workflow.Data.User)DataUser;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.Users aUsers = new Users(this);
            return (System.Collections.IList)aUsers;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.User xT = null;
            if (typeof(User) == obj.GetType())
            {
                xT = (User)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((User)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(User other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 UserID)
        {
            AccessUser.Get(UserID);
            return this;
        }

        public void Insert()
        {
            AccessUser.Insert();
        }

        public void Update()
        {
            AccessUser.Update();
        }

        public void Delete()
        {
            AccessUser.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("User{0}", this.AccessUser);
        }

        public override bool Equals(object obj)
        {
            if (typeof(User) == obj.GetType())
            {
                User xT = null;
                xT = (Access.User)obj;
                return (xT.UserID.Equals(this.UserID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class UserComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public UserComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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

        public class UserEqualityComparer : Object, System.Collections.Generic.IEqualityComparer<Access.User>
        {
            public Boolean Equals(User x, User y)
            {
                if (x.UserID.Equals(y.UserID)) return true;
                else return false;
            }

            public Int32 GetHashCode(User obj)
            {
               return base.GetHashCode();
            }
        }

        #endregion

        #region Other Properties

        private Iterations _IterationsPartOf;

        private Iterations _IterationsOwn;

        private Tasks _AllTasks;

        public Iterations IterationsPartOf
        {
            get
            {
                if (_IterationsPartOf == null)
                {
                    UserIterations tmp = new UserIterations().GetByUserID(this.UserID);
                    _IterationsPartOf = tmp.SelectDistinctIterations();
                }
                return _IterationsPartOf;
            }
        }

        public Iterations IterationsOwn
        {
            get
            {
                if (_IterationsOwn == null)
                {
                    _IterationsOwn = new Iterations().GetByIterationOwner(this.UserID);
                }
                return _IterationsOwn;
            }
        }

        public Tasks AllTasks
        {
            get
            {
                if (_AllTasks == null)
                {
                    _AllTasks = new Tasks().GetByTaskAssignedUser(this.UserID);
                }
                return _AllTasks;
            }
        }

        public Tasks CompletedTasks
        {
            get { return new Tasks(AllTasks.Where(f => f.TaskStatusID.TaskStatusID == (Int32)TaskStatus.E_TaskStatuses.Completed)); }
        }

        public Tasks UnCompletedTasks
        {
            get { return new Tasks(AllTasks.Where(f => f.TaskStatusID.TaskStatusID != (Int32)TaskStatus.E_TaskStatuses.Completed)); }
        }

        #endregion
    }
}
