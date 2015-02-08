using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class UserIterations : System.Collections.Generic.List<Access.UserIteration>
    {
        #region Constructors

        public UserIterations()
            : base()
        {

        }

        public UserIterations(Avenue.Heights.Data.AvenueCollection DataUserIterations)
            : base()
        {
            Generate(DataUserIterations);
        }

        public UserIterations(Access.UserIteration[] AccessUserIterations)
            : base()
        {
            this.AddRange(AccessUserIterations);
        }

        public UserIterations(System.Collections.Generic.IEnumerable<Access.UserIteration> AccessUserIterations)
            : base()
        {
            this.AddRange(AccessUserIterations);
        }

        public UserIterations(Access.UserIteration AUserIteration)
            : base()
        {
            this.Add(AUserIteration);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataUserIterations)
        {
            foreach (Data.UserIteration aUserIteration in DataUserIterations)
            {
                base.Add(new Access.UserIteration(aUserIteration));
            }
        }

        #region Get

        public Access.UserIterations Get(Int32 UserIterationID)
        {
            Data.UserIteration aUserIteration = new Data.UserIteration(UserIterationID);
            this.Add(new Access.UserIteration(aUserIteration));
            return this;
        }

        public Access.UserIterations GetByIterationID(Int32 IterationID)
        {
            Data.UserIterations DataUserIterations = new Data.UserIterations();
            DataUserIterations.GetByIterationID(IterationID);
            Generate(DataUserIterations);
            return this;
        }

        public Access.UserIterations GetByUserID(Int32 UserID)
        {
            Data.UserIterations DataUserIterations = new Data.UserIterations();
            DataUserIterations.GetByUserID(UserID);
            Generate(DataUserIterations);
            return this;
        }

        #endregion

        #region Selects

        public UserIterations SelectByIteration(Iteration Iteration)
        {
            return new UserIterations(this.Where(f => f.IterationID.IterationID == Iteration.IterationID));
        }

        public UserIterations SelectByUserID(User User)
        {
            return new UserIterations(this.Where(f => f.UserID.UserID == User.UserID));
        }

        public Iterations SelectDistinctIterations()
        {
            return new Iterations(this.Select(f => f.IterationID).Distinct(new Access.Iteration.IterationEqualityComparer()).ToArray());
        }

        public Users SelectDistinctUsers()
        {
            return new Users(this.Select(f => f.UserID).Distinct(new Access.User.UserEqualityComparer()).ToArray());
        }

        #endregion

        #region Filters

        public UserIterations FilterByIteration(Iteration Iteration)
        {
            UserIterations tmp = this.SelectByIteration(Iteration);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public UserIterations FilterByUser(User User)
        {
            UserIterations tmp = this.SelectByUserID(User);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        #endregion
    }
}
