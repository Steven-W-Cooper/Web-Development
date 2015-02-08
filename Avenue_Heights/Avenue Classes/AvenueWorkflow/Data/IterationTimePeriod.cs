using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class IterationTimePeriod : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _IterationTimePeriodID;

        private Int32 _IterationID;

        private DateTime _IterationTimePeriodStartDate;

        private DateTime _IterationTimePeriodEndDate;

        #endregion

        #region Properties

        public Int32 IterationTimePeriodID
        {
            get { return _IterationTimePeriodID; }
        }

        public Int32 IterationID
        {
            get { return _IterationID; }
            set { _IterationID = value; }
        }

        public DateTime IterationTimePeriodStartDate
        {
            get { return _IterationTimePeriodStartDate; }
            set { _IterationTimePeriodStartDate = value; }
        }

        public DateTime IterationTimePeriodEndDate
        {
            get { return _IterationTimePeriodEndDate; }
            set { _IterationTimePeriodEndDate = value; }
        }

        #endregion

        #region Constructor

        public IterationTimePeriod()
            : base()
        {

        }

        public IterationTimePeriod(Int32 IterationTimePeriodID)
        {
            new IterationTimePeriod();
            this.Get(IterationTimePeriodID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_IterationTimePeriod_GetByIterationTimePeriodID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_IterationTimePeriod_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodStartDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodEndDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_IterationTimePeriod_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodStartDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodEndDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_IterationTimePeriod_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IterationTimePeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 IterationTimePeriodID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@IterationTimePeriodID"].Value = IterationTimePeriodID;
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
                InsertCommand.Parameters["@IterationTimePeriodID"].Value = null;
                InsertCommand.Parameters["@IterationID"].Value = CheckParameterDBNull(this.IterationID);
                InsertCommand.Parameters["@IterationTimePeriodStartDate"].Value = CheckParameterDBNull(this.IterationTimePeriodStartDate);
                InsertCommand.Parameters["@IterationTimePeriodEndDate"].Value = CheckParameterDBNull(this.IterationTimePeriodEndDate);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                this._IterationTimePeriodID = (Int32)InsertCommand.Parameters["@IterationTimePeriodID"].Value;
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
                UpdateCommand.Parameters["@IterationTimePeriodID"].Value = CheckParameterDBNull(this.IterationTimePeriodID);
                UpdateCommand.Parameters["@IterationID"].Value = CheckParameterDBNull(this.IterationID);
                UpdateCommand.Parameters["@IterationTimePeriodStartDate"].Value = CheckParameterDBNull(this.IterationTimePeriodStartDate);
                UpdateCommand.Parameters["@IterationTimePeriodEndDate"].Value = CheckParameterDBNull(this.IterationTimePeriodEndDate);
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
                DeleteCommand.Parameters["@IterationTimePeriodID"].Value = this.IterationTimePeriodID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._IterationTimePeriodID = 0;
                this.IterationID = 0;
                this.IterationTimePeriodStartDate = DateTime.MinValue;
                this.IterationTimePeriodEndDate = DateTime.MinValue;
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
            Avenue.Workflow.Data.IterationTimePeriod tmpData = (Avenue.Workflow.Data.IterationTimePeriod)Data;
            tmpData._IterationTimePeriodID = (Int32)CheckDBNull(Reader["IterationTimePeriodID"]);
            tmpData.IterationID = (Int32)CheckDBNull(Reader["IterationID"]);
            tmpData.IterationTimePeriodStartDate = (DateTime)CheckDBNull(Reader["IterationTimePeriodStartDate"]);
            tmpData.IterationTimePeriodEndDate = (DateTime)CheckDBNull(Reader["IterationTimePeriodEndDate"]);
        }


        public static void GenerateAvenueList(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueCollection Collection)
        {
            while (Reader.Read())
            {
                Avenue.Workflow.Data.IterationTimePeriod aIterationTimePeriod = new Avenue.Workflow.Data.IterationTimePeriod();
                Avenue.Heights.Data.AvenueData aData = (Avenue.Heights.Data.AvenueData)aIterationTimePeriod;
                GenerateAvenueData(Reader, ref aData);
                Collection.Add(aData);
            }
        }
        #endregion
    }
}
