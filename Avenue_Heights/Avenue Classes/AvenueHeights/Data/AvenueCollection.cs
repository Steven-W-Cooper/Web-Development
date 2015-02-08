using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights.Data
{
      public interface IAvenueCollection
    {
        AvenueCollection Get(Int32 PrimaryKey);
        void Update();
    }

    public class AvenueCollection : System.Collections.ArrayList
    {
        private System.Data.SqlClient.SqlConnection _connection;

        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AvenueHeightsConnection"].ConnectionString;
        }

        public System.Data.SqlClient.SqlConnection Connection
        {
            get
            {
                if (this._connection == null) this.InitConnection();
                return this._connection;
            }
            set { _connection = value; }
        }

        public System.Web.Caching.SqlCacheDependency GetDependency(System.Data.SqlClient.SqlCommand Command)
        {
            if(AvenueData.CheckSQLCacheDependencyEnabled()) return new System.Web.Caching.SqlCacheDependency(Command);
            else return null;
        }
    }
}
