using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights
{
    public class AvenueHeightsProfile : System.Web.Profile.ProfileBase
    {

        public Int32 WorkflowIterationID
        {
            get
            {
                try
                {
                    if (base["WorkflowIterationID"] == null) base["WorkflowIterationID"] = 0;
                    return Convert.ToInt32(base["WorkflowIterationID"]);
                }
                catch (System.Configuration.SettingsPropertyNotFoundException ex)
                {
                    return 0;
                }
            }
            set
            {
                base["WorkflowIterationID"] = value;
                this.Save();
            }
        }

        public Int32 WorkflowTaskID
        {
            get
            {
                try
                {
                    if (base["WorkflowTaskID"] == null) base["WorkflowTaskID"] = 0;
                    return Convert.ToInt32(base["WorkflowTaskID"]);
                }
                catch (System.Configuration.SettingsPropertyNotFoundException ex)
                {
                    return 0;
                }
            }
            set
            {
                base["WorkflowTaskID"] = value;
                this.Save();
            }
        }

        public Int32 UserID
        {
            get
            {
                try
                {
                    if (base["UserID"] == null) base["UserID"] = 0;
                    return Convert.ToInt32(base["UserID"]);
                }
                catch (System.Configuration.SettingsPropertyNotFoundException ex)
                {
                    return 0;
                }
            }
            set
            {
                base["UserID"] = value;
                this.Save();
            }
        }

        public static AvenueHeightsProfile GetProfile(String UserName)
        {
            return (AvenueHeightsProfile)System.Web.Profile.ProfileBase.Create(UserName);
        }
    }
}
