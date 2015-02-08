using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class IterationType : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _IterationTypeID;

        private String _IterationTypeName;

        #endregion

        #region Properties

        public Int32 IterationTypeID
        {
            get { return _IterationTypeID; }
        }

        public String IterationTypeName
        {
            get { return _IterationTypeName; }
            set { _IterationTypeName = value; }
        }

        #endregion

        #region Constructor

        public IterationType() : base()
        {

        }

        public IterationType(Int32 IterationTypeID)
        {
            new IterationType();
            this.Get(IterationTypeID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_IterationType_GetByIterationTypeID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_IterationType_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_IterationType_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_IterationType_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 IterationTypeID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@IterationTypeID"].Value = IterationTypeID;
                System.Data.SqlClient.SqlDataReader reader = null;
                try
                {
                    reader = Command.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                while (reader.Read())
                {
                    Avenue.Heights.Data.AvenueData atmp = this;
                    GenerateAvenueData(reader,ref atmp);
                    break;
                }
            }
            finally
            {
                Command.Parameters.Clear();
                Command.Connection.Close();
            }
        }

        public void Insert()
        {
            try
            {
                if (InsertCommand.Connection.State == ConnectionState.Closed)
                {
                    InsertCommand.Connection.Open();
                    InitialiseInsert();
                }
                InsertCommand.Parameters["@IterationTypeID"].Value = null;
                InsertCommand.Parameters["@IterationTypeName"].Value = CheckParameterDBNull(this.IterationTypeName);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                this._IterationTypeID = (Int32)InsertCommand.Parameters["@IterationTypeID"].Value;
            }
            finally
            {
                InsertCommand.Parameters.Clear();
                InsertCommand.Connection.Close();
            }
        }

        public void Update()
        {
            try
            {
                if (UpdateCommand.Connection.State == ConnectionState.Closed)
                {
                    UpdateCommand.Connection.Open();
                    InitialiseUpdate();
                }
                UpdateCommand.Parameters["@IterationTypeID"].Value = CheckParameterDBNull(this.IterationTypeID);
                UpdateCommand.Parameters["@IterationTypeID"].Value = CheckParameterDBNull(this.IterationTypeName);
                try
                {
                    UpdateCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
            }
            finally
            {
                UpdateCommand.Parameters.Clear();
                UpdateCommand.Connection.Close();
            }
        }

        public void Delete()
        {
            try
            {
                if (DeleteCommand.Connection.State == ConnectionState.Closed)
                {
                    DeleteCommand.Connection.Open();
                    InitialiseDelete();
                }
                DeleteCommand.Parameters["@IterationTypeID"].Value = this.IterationTypeID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._IterationTypeID = 0;
                this.IterationTypeName = null;
            }
            finally
            {
                DeleteCommand.Parameters.Clear();
                DeleteCommand.Connection.Close();
            }
        }

        #endregion

        #region Generate

        private static void GenerateAvenueData(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueData Data)
        {
            Avenue.Workflow.Data.IterationType tmpData = (Avenue.Workflow.Data.IterationType)Data;
            tmpData._IterationTypeID = (Int32)CheckDBNull(Reader["IterationTypeID"]);
            tmpData.IterationTypeName = (String)CheckDBNull(Reader["IterationTypeName"]);
        }


        public static void GenerateAvenueList(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueCollection Collection)
        {
            while (Reader.Read())
            {
                Avenue.Heights.Data.AvenueData aData = (Avenue.Heights.Data.AvenueData)(new Avenue.Workflow.Data.IterationType());
                GenerateAvenueData(Reader, ref aData);
                Collection.Add(aData);
            }
        }
        #endregion
    }
}
