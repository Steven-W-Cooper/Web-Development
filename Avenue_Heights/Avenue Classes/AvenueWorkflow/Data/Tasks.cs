using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Data
{
    public class Tasks : Avenue.Heights.Data.AvenueCollection, Avenue.Heights.Data.IAvenueCollection
    {
        #region Default Functions

        public Avenue.Heights.Data.AvenueCollection Get(Int32 TaskID)
        {
            this.Add(new Task(TaskID));
            return this;
        }

        public void Update()
        {
            foreach (Task aTask in this)
            {
                aTask.Update();
            }
        }

        #endregion

        #region GetByReferences

        public Avenue.Workflow.Data.Tasks GetByStoryID(Int32 StoryID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Task_GetByStoryID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, StoryID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Task.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Tasks GetByTaskStatusID(Int32 TaskStatusID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Task_GetByTaskStatusID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, TaskStatusID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Task.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Tasks GetByTaskAssignedUser(Int32 TaskAssignedUser)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Task_GetByTaskAssignedUser";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskAssignedUser", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, TaskAssignedUser, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Task.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        #endregion
    }
}
