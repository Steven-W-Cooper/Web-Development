using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Avenue.Workflow.Data
{
    public class User : Avenue.Heights.Data.AvenueData, Avenue.Heights.Data.IAvenueData
    {
        #region Variables

        private Int32 _UserID;

        private String _UserFirstName;

        private String _UserLastName;

        private String _UserName;

        private String _UserEmail;

        private Int32 _UserThemeID;

        private Guid? _UserAspNetMembership;

        private byte[] _UserPicture;

        #endregion

        #region Properties

        public Int32 UserID
        {
            get { return _UserID; }
        }

        public String UserFirstName
        {
            get { return _UserFirstName; }
            set { _UserFirstName = value; }
        }

        public String UserLastName
        {
            get { return _UserLastName; }
            set { _UserLastName = value; }
        }

        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public String UserEmail
        {
            get { return _UserEmail; }
            set { _UserEmail = value; }
        }

        public Int32 UserThemeID
        {
            get { return _UserThemeID; }
            set { _UserThemeID = value; }
        }

        public Guid? UserAspNetMembership
        {
            get { return _UserAspNetMembership; }
            set { _UserAspNetMembership = value; }
        }

        public byte[] UserPicture
        {
            get { return _UserPicture; }
            set { _UserPicture = value; }
        }

        #endregion

        #region Constructor

        public User()
            : base()
        {

        }

        public User(Int32 UserID)
        {
            new User();
            this.Get(UserID);
        }

        #endregion

        #region Initialise

        public void Initialise()
        {
            this.Command.CommandText = "dbo.ave_User_GetByUserID";
            this.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseInsert()
        {
            this.InsertCommand.CommandText = "dbo.ave_User_Insert";
            this.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserFirstName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserLastName", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserEmail", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserThemeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserAspNetMembership", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPicture", System.Data.SqlDbType.VarBinary, -1, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseUpdate()
        {
            this.UpdateCommand.CommandText = "dbo.ave_User_Update";
            this.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserFirstName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserLastName", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserEmail", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserThemeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserAspNetMembership", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPicture", System.Data.SqlDbType.VarBinary, -1, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        public void InitialiseDelete()
        {
            this.DeleteCommand.CommandText = "dbo.ave_User_Delete";
            this.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        #endregion

        #region Default Functions

        public void Get(Int32 UserID)
        {
            try
            {
                if (Command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    Command.Connection.Open();
                    Initialise();
                }
                Command.Parameters["@UserID"].Value = UserID;
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
                InsertCommand.Parameters["@UserID"].Value = null;
                InsertCommand.Parameters["@UserFirstName"].Value = CheckParameterDBNull(this.UserFirstName);
                InsertCommand.Parameters["@UserLastName"].Value = CheckParameterDBNull(this.UserLastName);
                InsertCommand.Parameters["@UserName"].Value = CheckParameterDBNull(this.UserName);
                InsertCommand.Parameters["@UserEmail"].Value = CheckParameterDBNull(this.UserEmail);
                InsertCommand.Parameters["@UserThemeID"].Value = CheckParameterDBNull(this.UserThemeID);
                InsertCommand.Parameters["@UserAspNetMembership"].Value = CheckParameterDBNull(this.UserAspNetMembership);
                InsertCommand.Parameters["@UserPicture"].Value = CheckParameterDBNull(this.UserPicture);
                try
                {
                    InsertCommand.ExecuteNonQuery();
                    this._UserID = (Int32)InsertCommand.Parameters["@UserID"].Value;
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

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
                UpdateCommand.Parameters["@UserID"].Value = CheckParameterDBNull(this.UserID);
                UpdateCommand.Parameters["@UserFirstName"].Value = CheckParameterDBNull(this.UserFirstName);
                UpdateCommand.Parameters["@UserLastName"].Value = CheckParameterDBNull(this.UserLastName);
                UpdateCommand.Parameters["@UserName"].Value = CheckParameterDBNull(this.UserName);
                UpdateCommand.Parameters["@UserEmail"].Value = CheckParameterDBNull(this.UserEmail);
                UpdateCommand.Parameters["@UserThemeID"].Value = CheckParameterDBNull(this.UserThemeID);
                UpdateCommand.Parameters["@UserAspNetMembership"].Value = CheckParameterDBNull(this.UserAspNetMembership);
                UpdateCommand.Parameters["@UserPicture"].Value = CheckParameterDBNull(this.UserPicture);
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
                DeleteCommand.Parameters["@UserID"].Value = this.UserID;
                try
                {
                    DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException SQLex) { }

                this._UserID = 0;
                this.UserFirstName = null;
                this.UserLastName = null;
                this.UserName = null;
                this.UserEmail = null;
                this.UserThemeID = 0;
                this.UserAspNetMembership = null;
                this.UserPicture = null;
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
            Avenue.Workflow.Data.User tmpData = (Avenue.Workflow.Data.User)Data;
            tmpData._UserID = (Int32)CheckDBNull(Reader["UserID"]);
            tmpData.UserFirstName = (String)CheckDBNull(Reader["UserFirstName"]);
            tmpData.UserLastName = (String)CheckDBNull(Reader["UserLastName"]);
            tmpData.UserName = (String)CheckDBNull(Reader["UserName"]);
            tmpData.UserEmail = (String)CheckDBNull(Reader["UserEmail"]);
            tmpData.UserThemeID = (Int32)CheckDBNull(Reader["UserThemeID"]);
            tmpData.UserAspNetMembership = (Guid)CheckDBNull(Reader["UserAspNetMembership"]);
            tmpData.UserPicture = (byte[])CheckDBNull(Reader["UserPicture"]);
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
