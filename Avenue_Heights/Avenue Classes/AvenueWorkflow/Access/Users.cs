using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Users : System.Collections.Generic.List<Access.User>
    {
        #region Constructors

        public Users()
            : base()
        {

        }

        public Users(Avenue.Heights.Data.AvenueCollection DataUsers)
            : base()
        {
            Generate(DataUsers);
        }

        public Users(Access.User[] AccessUsers)
            : base()
        {
            this.AddRange(AccessUsers);
        }

        public Users(System.Collections.Generic.IEnumerable<Access.User> AccessUsers)
            : base()
        {
            this.AddRange(AccessUsers);
        }

        public Users(Access.User AUser)
            : base()
        {
            this.Add(AUser);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataUsers)
        {
            foreach (Data.User aUser in DataUsers)
            {
                base.Add(new Access.User(aUser));
            }
        }

        #region Get

        public Access.Users Get(Int32 UserID)
        {
            Data.User aUser = new Data.User(UserID);
            this.Add(new Access.User(aUser));
            return this;
        }

        public Access.Users GetByUserTypeID(Int32 UserThemeID)
        {
            Data.Users DataUsers = new Data.Users();
            DataUsers.GetByUserThemeID(UserThemeID);
            Generate(DataUsers);
            return this;
        }

        #endregion
    }
}
