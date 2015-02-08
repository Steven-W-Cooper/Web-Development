using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights
{
    public class AvenueHeightsPage : System.Web.UI.Page
    {

        public System.Web.Security.MembershipUser Member
        {
            get { return System.Web.Security.Membership.GetUser(); }
        }

        public Int32 WorkflowIterationID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowIterationID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowIterationID = value; }
        }

        public Int32 WorkflowTaskID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowTaskID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowTaskID = value; }
        }

        public Int32 UserID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).UserID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).UserID = value; }
        }

    }

    public class AvenueHeightsControl : System.Web.UI.UserControl
    {

        public System.Web.Security.MembershipUser Member
        {
            get { return System.Web.Security.Membership.GetUser(); }
        }

        public Int32 WorkflowIterationID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowIterationID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowIterationID = value; }
        }

        public Int32 WorkflowTaskID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowTaskID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).WorkflowTaskID = value; }
        }

        public Int32 UserID
        {
            get { return ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).UserID; }
            set { ((Avenue.Heights.AvenueHeightsProfile)System.Web.HttpContext.Current.Profile).UserID = value; }
        }
    }
}
