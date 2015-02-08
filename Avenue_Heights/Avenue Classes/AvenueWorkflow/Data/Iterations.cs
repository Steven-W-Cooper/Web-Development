using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Data
{
    public class Iterations : Avenue.Heights.Data.AvenueCollection, Avenue.Heights.Data.IAvenueCollection
    {
        #region Default Functions

        public Avenue.Heights.Data.AvenueCollection Get(Int32 IterationID)
        {
            this.Add(new Iteration(IterationID));
            return this;
        }

        public void Update()
        {
            foreach (Iteration aIteration in this)
            {
                aIteration.Update();
            }
        }

        #endregion

        #region GetByReferences

        public Avenue.Workflow.Data.Iterations GetByIterationTypeID(Int32 IterationTypeID)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Iteration_GetByIterationTypeID";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, IterationTypeID, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Iteration.GenerateAvenueList(reader, ref refthis);
            }
            finally
            {
                acommand.Connection.Close();
            }
            return this;
        }

        public Avenue.Workflow.Data.Iterations GetByIterationOwner(Int32 IterationOwner)
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_Iteration_GetByIterationOwner";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationOwner", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, IterationOwner, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed)
                {
                    acommand.Connection.Open();
                }
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();
                Avenue.Heights.Data.AvenueCollection refthis = this;
                Iteration.GenerateAvenueList(reader, ref refthis);
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
