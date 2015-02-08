using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class Task : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _TaskID;

        private Int32 _StoryID;

        private String _TaskDescription;

        private DateTime? _TaskStartDate;

        private DateTime? _TaskEndDate;

        private Decimal? _TaskEstimatedTime;

        private Decimal? _TaskClockedTime;

        private Int32 _TaskStatusID;

        private Int32? _TaskAssignedUser;

        #endregion

        #region Properties

        public Int32 TaskID
        {
            get { return _TaskID; }
        }

        public Int32 StoryID
        {
            get { return _StoryID; }
            set { _StoryID = value; }
        }

        public String TaskDescription
        {
            get { return _TaskDescription; }
            set { _TaskDescription = value; }
        }

        public DateTime? TaskStartDate
        {
            get { return _TaskStartDate; }
            set { _TaskStartDate = value; }
        }

        public DateTime? TaskEndDate
        {
            get { return _TaskEndDate; }
            set { _TaskEndDate = value; }
        }

        public Decimal? TaskEstimatedTime
        {
            get { return _TaskEstimatedTime; }
            set { _TaskEstimatedTime = value; }
        }

        public Decimal? TaskClockedTime
        {
            get { return _TaskClockedTime; }
            set { _TaskClockedTime = value; }
        }

        public Int32 TaskStatusID
        {
            get { return _TaskStatusID; }
            set { _TaskStatusID = value; }
        }

        public Int32? TaskAssignedUser
        {
            get { return _TaskAssignedUser.Value; }
            set { _TaskAssignedUser = value; }
        }

        #endregion

        #region Constructor

        public Task()
            : base()
        {

        }

        public Task(Int32 TaskID)
        {
            new Task();
            this.Get(TaskID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_Task_GetByTaskID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_Task_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskDescription", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStartDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskEndDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskEstimatedTime", System.Data.SqlDbType.Decimal, 18, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskClockedTime", System.Data.SqlDbType.Decimal, 18, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskAssignedUser", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_Task_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskDescription", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStartDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskEndDate", System.Data.SqlDbType.DateTime, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskEstimatedTime", System.Data.SqlDbType.Decimal, 18, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskClockedTime", System.Data.SqlDbType.Decimal, 18, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskAssignedUser", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_Task_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaskID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 TaskID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@TaskID"].Value = TaskID;
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
                InsertCommand.Parameters["@TaskID"].Value = null;
                InsertCommand.Parameters["@StoryID"].Value = CheckParameterDBNull(this.StoryID);
                InsertCommand.Parameters["@TaskDescription"].Value = CheckParameterDBNull(this.TaskDescription);
                InsertCommand.Parameters["@TaskStartDate"].Value = CheckParameterDBNull(this.TaskStartDate);
                InsertCommand.Parameters["@TaskEndDate"].Value = CheckParameterDBNull(this.TaskEndDate);
                InsertCommand.Parameters["@TaskEstimatedTime"].Value = CheckParameterDBNull(this.TaskEstimatedTime);
                InsertCommand.Parameters["@TaskClockedTime"].Value = CheckParameterDBNull(this.TaskClockedTime);
                InsertCommand.Parameters["@TaskStatusID"].Value = CheckParameterDBNull(this.TaskStatusID);
                InsertCommand.Parameters["@TaskAssignedUser"].Value = CheckParameterDBNull(this.TaskAssignedUser);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }
                this._TaskID = (Int32)InsertCommand.Parameters["@TaskID"].Value;
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
                UpdateCommand.Parameters["@TaskID"].Value = CheckParameterDBNull(this.TaskID);
                UpdateCommand.Parameters["@StoryID"].Value = CheckParameterDBNull(this.StoryID);
                UpdateCommand.Parameters["@TaskDescription"].Value = CheckParameterDBNull(this.TaskDescription);
                UpdateCommand.Parameters["@TaskStartDate"].Value = CheckParameterDBNull(this.TaskStartDate);
                UpdateCommand.Parameters["@TaskEndDate"].Value = CheckParameterDBNull(this.TaskEndDate);
                UpdateCommand.Parameters["@TaskEstimatedTime"].Value = CheckParameterDBNull(this.TaskEstimatedTime);
                UpdateCommand.Parameters["@TaskClockedTime"].Value = CheckParameterDBNull(this.TaskClockedTime);
                UpdateCommand.Parameters["@TaskStatusID"].Value = CheckParameterDBNull(this.TaskStatusID);
                UpdateCommand.Parameters["@TaskAssignedUser"].Value = CheckParameterDBNull(this.TaskAssignedUser);
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
                DeleteCommand.Parameters["@TaskID"].Value = this.TaskID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._TaskID = 0;
                this.StoryID = 0;
                this.TaskDescription = null;
                this.TaskStartDate = null;
                this.TaskEndDate = null;
                this.TaskEstimatedTime = null;
                this.TaskClockedTime = null;
                this.TaskStatusID = 0;
                this.TaskAssignedUser = 0;
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
            Avenue.Workflow.Data.Task tmpData = (Avenue.Workflow.Data.Task)Data;
            tmpData._TaskID = (Int32)CheckDBNull(Reader["TaskID"]);
            tmpData.StoryID = (Int32)CheckDBNull(Reader["StoryID"]);
            tmpData.TaskDescription = (String)CheckDBNull(Reader["TaskDescription"]);
            tmpData.TaskStartDate = (DateTime?)CheckDBNull(Reader["TaskStartDate"]);
            tmpData.TaskEndDate = (DateTime?)CheckDBNull(Reader["TaskEndDate"]);
            tmpData.TaskEstimatedTime = (Decimal?)CheckDBNull(Reader["TaskEstimatedTime"]);
            tmpData.TaskClockedTime = (Decimal?)CheckDBNull(Reader["TaskClockedTime"]);
            tmpData.TaskStatusID = (Int32)CheckDBNull(Reader["TaskStatusID"]);
            tmpData.TaskAssignedUser = (Int32)CheckDBNull(Reader["TaskAssignedUser"]);
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
