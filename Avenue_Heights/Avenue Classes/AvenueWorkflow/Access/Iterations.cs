using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Iterations : System.Collections.Generic.List<Access.Iteration>
    {
        #region Constructors

        public Iterations()
            : base()
        {

        }

        public Iterations(Avenue.Heights.Data.AvenueCollection DataIterations)
            : base()
        {
            Generate(DataIterations);
        }

        public Iterations(Access.Iteration[] AccessIterations)
            : base()
        {
            this.AddRange(AccessIterations);
        }

        public Iterations(System.Collections.Generic.IEnumerable<Access.Iteration> AccessIterations)
            : base()
        {
            this.AddRange(AccessIterations);
        }

        public Iterations(Access.Iteration AIteration)
            : base()
        {
            this.Add(AIteration);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataIterations)
        {
            foreach (Data.Iteration aIteration in DataIterations)
            {
                base.Add(new Access.Iteration(aIteration));
            }
        }

        #region Get

        public Access.Iterations Get(Int32 IterationID)
        {
            Data.Iteration aIteration = new Data.Iteration(IterationID);
            this.Add(new Access.Iteration(aIteration));
            return this;
        }

        public Access.Iterations GetByIterationTypeID(Int32 IterationTypeID)
        {
            Data.Iterations DataIterations = new Data.Iterations();
            DataIterations.GetByIterationTypeID(IterationTypeID);
            Generate(DataIterations);
            return this;
        }

        public Access.Iterations GetByIterationOwner(Int32 IterationOwner)
        {
            Data.Iterations DataIterations = new Data.Iterations();
            DataIterations.GetByIterationOwner(IterationOwner);
            Generate(DataIterations);
            return this;
        }

        #endregion

        #region Selects

        public Iterations SelectByIterationType(IterationType IterationType)
        {
            return new Iterations(this.Where(f => f.IterationTypeID.IterationTypeID == IterationType.IterationTypeID));
        }

        public Iterations SelectByIterationOwner(User IterationOwner)
        {
            return new Iterations(this.Where(f => f.IterationOwner.UserID == IterationOwner.UserID));
        }

        #endregion

        #region Filters

        public Iterations FilterByIterationType(IterationType IterationType)
        {
            Iterations tmp = this.SelectByIterationType(IterationType);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public Iterations FilterByIterationOwner(User IterationOwner)
        {
            Iterations tmp = this.SelectByIterationOwner(IterationOwner);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        #endregion
    }
}
