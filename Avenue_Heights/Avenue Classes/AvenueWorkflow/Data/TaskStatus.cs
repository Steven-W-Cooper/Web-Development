using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class TaskStatus : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _TaskStatusID;

        private String _TaskStatusName;

        #endregion

        #region Properties

        public Int32 TaskStatusID
        {
            get { return _TaskStatusID; }
        }

        public String TaskStatusName
        {
            get { return _TaskStatusName; }
            set { _TaskStatusName = value; }
        }

        #endregion

        #region Constructor

        public TaskStatus()
            : base()
        {

        }

        public TaskStatus(Int32 TaskStatusID)
        {
            new TaskStatus();
            this.Get(TaskStatusID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_TaskStatus_GetByTaskStatusID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_TaskStatus_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_TaskStatus_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_TaskStatus_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 TaskStatusID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@TaskStatusID"].Value = TaskStatusID;
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
                InsertCommand.Parameters["@TaskStatusID"].Value = null;
                InsertCommand.Parameters["@TaskStatusName"].Value = CheckParameterDBNull(this.TaskStatusName);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                this._TaskStatusID = (Int32)InsertCommand.Parameters["@TaskStatusID"].Value;
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
                UpdateCommand.Parameters["@TaskStatusID"].Value = CheckParameterDBNull(this.TaskStatusID);
                UpdateCommand.Parameters["@TaskStatusID"].Value = CheckParameterDBNull(this.TaskStatusName);
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
                DeleteCommand.Parameters["@TaskStatusID"].Value = this.TaskStatusID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._TaskStatusID = 0;
                this.TaskStatusName = null;
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
            Avenue.Workflow.Data.TaskStatus tmpData = (Avenue.Workflow.Data.TaskStatus)Data;
            tmpData._TaskStatusID = (Int32)CheckDBNull(Reader["TaskStatusID"]);
            tmpData.TaskStatusName = (String)CheckDBNull(Reader["TaskStatusName"]);
        }


        public static void GenerateAvenueList(System.Data.SqlClient.SqlDataReader Reader, ref Avenue.Heights.Data.AvenueCollection Collection)
        {
            while (Reader.Read())
            {
                Avenue.Heights.Data.AvenueData aData = new Avenue.Heights.Data.AvenueData();
                GenerateAvenueData(Reader, ref aData);
                Collection.Add(aData);
            }
        }
        #endregion
    }
}
