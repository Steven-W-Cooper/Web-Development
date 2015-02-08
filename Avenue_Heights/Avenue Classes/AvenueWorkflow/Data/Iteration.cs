using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class Iteration : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _IterationID;

        private String _IterationDescription;

        private Int32 _IterationTypeID;

        private Int32? _DefaultIterationTimePeriod;

        private Int32 _IterationOwner;

        #endregion

        #region Properties

        public Int32 IterationID
        {
            get { return _IterationID; }
        }

        public String IterationDescription
        {
            get { return _IterationDescription; }
            set { _IterationDescription = value; }
        }

        public Int32 IterationTypeID
        {
            get { return _IterationTypeID; }
            set { _IterationTypeID = value; }
        }

        public Int32? DefaultIterationTimePeriod
        {
            get { return _DefaultIterationTimePeriod; }
            set { _DefaultIterationTimePeriod = value; }
        }

        public Int32 IterationOwner
        {
            get { return _IterationOwner; }
            set { _IterationOwner = value; }
        }

        #endregion

        #region Constructor

        public Iteration()
            : base()
        {

        }

        public Iteration(Int32 IterationID)
        {
            new Iteration();
            this.Get(IterationID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_Iteration_GetByIterationID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_Iteration_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationDescription", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DefaultIterationTimePeriod", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationOwner", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_Iteration_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationDescription", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DefaultIterationTimePeriod", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationOwner", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_Iteration_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 IterationID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@IterationID"].Value = IterationID;
                System.Data.SqlClient.SqlDataReader reader = null;
                try
                {
                    reader = Command.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                while (reader.Read())
                {
                    Avenue.Heights.Data.AvenueData atmp = this;
                    GenerateAvenueData(reader, ref atmp);
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
                InsertCommand.Parameters["@IterationID"].Value = null;
                InsertCommand.Parameters["@IterationDescription"].Value = CheckParameterDBNull(this.IterationDescription);
                InsertCommand.Parameters["@IterationTypeID"].Value = CheckParameterDBNull(this.IterationTypeID);
                InsertCommand.Parameters["@DefaultIterationTimePeriod"].Value = CheckParameterDBNull(this.DefaultIterationTimePeriod);
                InsertCommand.Parameters["@IterationOwner"].Value = CheckParameterDBNull(this.IterationOwner);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                this._IterationID = (Int32)InsertCommand.Parameters["@IterationID"].Value;
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
                UpdateCommand.Parameters["@IterationID"].Value = CheckParameterDBNull(this.IterationID);
                UpdateCommand.Parameters["@IterationDescription"].Value = CheckParameterDBNull(this.IterationDescription);
                UpdateCommand.Parameters["@IterationTypeID"].Value = CheckParameterDBNull(this.IterationTypeID);
                UpdateCommand.Parameters["@DefaultIterationTimePeriod"].Value = CheckParameterDBNull(this.DefaultIterationTimePeriod);
                UpdateCommand.Parameters["@IterationOwner"].Value = CheckParameterDBNull(this.IterationOwner);
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
                DeleteCommand.Parameters["@IterationID"].Value = this.IterationID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._IterationID = 0;
                this.IterationDescription = null;
                this.IterationTypeID = 0;
                this.DefaultIterationTimePeriod = 0;
                this.IterationOwner = 0;
            }
            finally
            {
                DeleteCommand.Parameters.Clear();
                DeleteCommand.Connection.Close();
            }
        }

        #endregion

        #region Generate

        public static void GenerateAvenueData(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueData Data)
        {
            Avenue.Workflow.Data.Iteration tmpData = (Avenue.Workflow.Data.Iteration)Data;
            tmpData._IterationID = (Int32)CheckDBNull(Reader["IterationID"]);
            tmpData.IterationDescription = (String)CheckDBNull(Reader["IterationDescription"]);
            tmpData.IterationTypeID = (Int32)CheckDBNull(Reader["IterationTypeID"]);
            tmpData.DefaultIterationTimePeriod = (Int32)CheckDBNull(Reader["DefaultIterationTimePeriod"]);
            tmpData.IterationOwner = (Int32)CheckDBNull(Reader["IterationOwner"]);
        }


        public static void GenerateAvenueList(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueCollection Collection)
        {
            while (Reader.Read())
            {
                Avenue.Workflow.Data.Iteration aIteration = new Avenue.Workflow.Data.Iteration();
                Avenue.Heights.Data.AvenueData aData = (Avenue.Heights.Data.AvenueData)aIteration;
                GenerateAvenueData(Reader, ref aData);
                Collection.Add(aData);
            }
        }
        #endregion
    }
}
