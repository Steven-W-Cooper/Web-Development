using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Data
{
    public class IterationTypes : Avenue.Heights.Data.AvenueCollection, Avenue.Heights.Data.IAvenueCollection
    {
        #region Default Functions

        public Avenue.Heights.Data.AvenueCollection Get(Int32 IterationTypeID)
        {
            this.Add(new IterationType(IterationTypeID));
            return this;
        }

        public void Update()
        {
            foreach (IterationType aIterationType in this)
            {
                aIterationType.Update();
            }
        }

        #endregion

        #region GetByReference

        public Avenue.Workflow.Data.IterationTypes GetAll()
        {
            System.Data.SqlClient.SqlCommand acommand = new System.Data.SqlClient.SqlCommand();
            acommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString);
            acommand.CommandText = "dbo.ave_IterationType_Get";
            acommand.CommandType = System.Data.CommandType.StoredProcedure;
            acommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            try
            {
                if (acommand.Connection.State == System.Data.ConnectionState.Closed) acommand.Connection.Open();
                System.Data.SqlClient.SqlDataReader reader = acommand.ExecuteReader();

                Avenue.Heights.Data.AvenueCollection refthis = this;
                IterationType.GenerateAvenueList(reader, ref refthis);
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
