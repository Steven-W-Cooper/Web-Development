using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Theme : Avenue.Heights.Access.AvenueData, Avenue.Heights.Access.IAvenueData, System.ComponentModel.IListSource, System.IComparable
    {
        #region Enum

        public enum E_Theme
        {
            Red = 1,
            Blue = 2,
            Yellow = 3,
            Green = 4,
            Orange = 5
        }

        #endregion

        private Avenue.Workflow.Data.Theme _Theme;

        #region Properties

        private Avenue.Workflow.Data.Theme AccessTheme
        {
            get { return _Theme; }
            set { _Theme = value; }
        }

        public Int32 ThemeID
        {
            get { return AccessTheme.ThemeID; }
        }

        public String ThemeName
        {
            get { return AccessTheme.ThemeName; }
            set { AccessTheme.ThemeName = value; }
        }

        #endregion

        #region Constructors

        public Theme()
            : base()
        {
            AccessTheme = new Data.Theme();
        }

        public Theme(Int32 ThemeID)
            : base()
        {
            AccessTheme = new Data.Theme(ThemeID);
        }

        public Theme(Avenue.Heights.Data.AvenueData DataTheme)
            : base()
        {
            AccessTheme = (Avenue.Workflow.Data.Theme)DataTheme;
        }

        #endregion

        #region IListSource

        public Boolean ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            Avenue.Workflow.Access.Themes aThemes = new Themes(this);
            return (System.Collections.IList)aThemes;
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(this);
            Avenue.Workflow.Access.Theme xT = null;
            if (typeof(Theme) == obj.GetType())
            {
                xT = (Theme)obj;
                return this.CompareTo(xT, pdc["[DEFAULTPROPERTY]"]);
            }
            else return this.CompareTo((Theme)obj, pdc["[DEFAULTPROPERTY]"]);
        }

        public Int32 CompareTo(Theme other, System.ComponentModel.PropertyDescriptor Prop)
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

        public Avenue.Heights.Access.AvenueData Get(Int32 ThemeID)
        {
            AccessTheme.Get(ThemeID);
            return this;
        }

        public void Insert()
        {
            AccessTheme.Insert();
        }

        public void Update()
        {
            AccessTheme.Update();
        }

        public void Delete()
        {
            AccessTheme.Delete();
        }

        #endregion

        #region Override

        public override String ToString()
        {
            return String.Format("Theme{0}", this.AccessTheme);
        }

        public override bool Equals(object obj)
        {
            if (typeof(Theme) == obj.GetType())
            {
                Theme xT = null;
                xT = (Access.Theme)obj;
                return (xT.ThemeID.Equals(this.ThemeID));
            }
            else return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region IComparer

        public class ThemeComparer : System.Collections.IComparer
        {
            private System.ComponentModel.PropertyDescriptor _sortProperty;

            private System.ComponentModel.ListSortDirection _sortDirection;

            public ThemeComparer(System.ComponentModel.PropertyDescriptor initProp, System.ComponentModel.ListSortDirection initDirection)
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
