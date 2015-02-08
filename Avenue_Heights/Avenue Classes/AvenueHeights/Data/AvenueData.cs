using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights.Data
{
    /// <summary>
    /// This is an Interface to make sure that all the classes contain the same functions
    /// </summary>
    public interface IAvenueData
    {
        void Get(Int32 PrimaryKey);
        void Insert();
        void Update();
        void Delete();
        void Initialise();
        void InitialiseInsert();
        void InitialiseUpdate();
        void InitialiseDelete();
    }

    public class AvenueData
    {
        /// <summary>
        /// for each column we get in the database, this will check to see whether that Column is there (exists)
        /// </summary>
        /// <param name="Column"></param>
        /// <returns></returns>
        public static Object CheckDBNull(Object Column)
        {
            if (Column == System.DBNull.Value) return null;
            else return Column;
        }

        /// <summary>
        /// for each parameter that we pass through to be inserted/updated this will check to see if it is null
        /// </summary>
        /// <param name="Column"></param>
        /// <returns></returns>
        public static Object CheckParameterDBNull(Object Column)
        {
            if (Column == null)
            {
               return System.Data.SqlTypes.SqlString.Null;
            }
            else
            {
                if (typeof(DateTime) == Column.GetType())
                {
                    if (((DateTime)Column) < DateTime.Parse("9999-12-31 23:59:59") && ((DateTime)Column) > DateTime.Parse("1753-01-01 00:00:00")) return Column;
                    else return DateTime.Parse("1900-01-01").AddHours(((DateTime)Column).Hour).AddMinutes(((DateTime)Column).Minute).AddSeconds(((DateTime)Column).Second);
                }
                return Column;
            }
        }

        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand _command;
        private System.Data.SqlClient.SqlCommand _InsertCommand;
        private System.Data.SqlClient.SqlCommand _UpdateCommand;
        private System.Data.SqlClient.SqlCommand _DeleteCommand;

        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString;
        }

        public System.Data.SqlClient.SqlCommand Command
        {
            get
            {
                if (_command == null)
                {
                    _command = new System.Data.SqlClient.SqlCommand();
                    _command.Connection = this.Connection;
                }
                return _command;
            }
            set { _command = value; }
        }

        public System.Data.SqlClient.SqlCommand InsertCommand
        {
            get
            {
                if (_InsertCommand == null)
                {
                    _InsertCommand = new System.Data.SqlClient.SqlCommand();
                    _InsertCommand.Connection = this.Connection;
                }
                return _InsertCommand;
            }
            set { _InsertCommand = value; }
        }

        public System.Data.SqlClient.SqlCommand UpdateCommand
        {
            get
            {
                if (_UpdateCommand == null)
                {
                    _UpdateCommand = new System.Data.SqlClient.SqlCommand();
                    _UpdateCommand.Connection = this.Connection;
                }
                return _UpdateCommand;
            }
            set { _UpdateCommand = value; }
        }

        public System.Data.SqlClient.SqlCommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new System.Data.SqlClient.SqlCommand();
                    _DeleteCommand.Connection = this.Connection;
                }
                return _DeleteCommand;
            }
            set { _DeleteCommand = value; }
        }

        public System.Data.SqlClient.SqlConnection Connection
        {
            get
            {
                if (_connection == null) this.InitConnection();
                return _connection;
            }
            set { _connection = value; }
        }

        public static Boolean CheckSQLCacheDependencyEnabled()
        {
            try
            {
                System.Configuration.Configuration Config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
                System.Web.Configuration.SqlCacheDependencySection Section = (System.Web.Configuration.SqlCacheDependencySection)Config.GetSection("system.web/caching/sqlCacheDependency");
                return Section.Enabled;
            }
            catch (Exception ex) { return false; }
        }

        public System.Web.Caching.SqlCacheDependency GetDependency()
        {
            if (CheckSQLCacheDependencyEnabled()) return new System.Web.Caching.SqlCacheDependency(Command);
            else return null;
        }
    }
}
