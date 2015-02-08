using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Data
{
    public class Stories : Avenue.Heights.Data.AvenueCollection, Avenue.Heights.Data.IAvenueCollection
    {
        #region Default Functions

        public Avenue.Heights.Data.AvenueCollection Get(Int32 StoryID)
        {
            this.Add(new Story(StoryID));
            return this;
        }

        public void Update()
        {
            foreach (Story aStory in this)
            {
                aStory.Update();
            }
        }

        #endregion

        #region GetByReferences

        public Avenue.Workflow.Data.Stories GetByStoryID(Int32 StoryID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Story_GetByStoryID";
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
                Story.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Stories GetByIterationID(Int32 IterationID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Story_GetByIterationID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, IterationID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Story.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Stories GetByIterationTimePeriodID(Int32 IterationTimePeriodID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Story_GetByIterationTimePeriodID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, IterationTimePeriodID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Story.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Stories GetByStoryTypeID(Int32 StoryTypeID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Story_GetByStoryTypeID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoryTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, StoryTypeID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Story.GenerateAvenueList(reader, ref refthis);
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
