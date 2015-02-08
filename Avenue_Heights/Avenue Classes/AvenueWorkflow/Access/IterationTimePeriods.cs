using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class IterationTimePeriods : System.Collections.Generic.List<Access.IterationTimePeriod>
    {
        #region Constructors

        public IterationTimePeriods()
            : base()
        {

        }

        public IterationTimePeriods(Avenue.Heights.Data.AvenueCollection DataIterationTimePeriods)
            : base()
        {
            Generate(DataIterationTimePeriods);
        }

        public IterationTimePeriods(Access.IterationTimePeriod[] AccessIterationTimePeriods)
            : base()
        {
            this.AddRange(AccessIterationTimePeriods);
        }

        public IterationTimePeriods(System.Collections.Generic.IEnumerable<Access.IterationTimePeriod> AccessIterationTimePeriods)
            : base()
        {
            this.AddRange(AccessIterationTimePeriods);
        }

        public IterationTimePeriods(Access.IterationTimePeriod AIterationTimePeriod)
            : base()
        {
            this.Add(AIterationTimePeriod);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataIterationTimePeriods)
        {
            foreach (Data.IterationTimePeriod aIterationTimePeriod in DataIterationTimePeriods)
            {
                base.Add(new Access.IterationTimePeriod(aIterationTimePeriod));
            }
        }

        #region Get

        public Access.IterationTimePeriods Get(Int32 IterationTimePeriodID)
        {
            Data.IterationTimePeriod aIterationTimePeriod = new Data.IterationTimePeriod(IterationTimePeriodID);
            this.Add(new Access.IterationTimePeriod(aIterationTimePeriod));
            return this;
        }

        public Access.IterationTimePeriods GetByIterationID(Int32 IterationID)
        {
            Data.IterationTimePeriods DataIterationTimePeriods = new Data.IterationTimePeriods();
            DataIterationTimePeriods.GetByIterationID(IterationID);
            Generate(DataIterationTimePeriods);
            return this;
        }

        #endregion

        #region Select

        public Access.IterationTimePeriods SelectByIteration(Access.Iteration Iteration)
        {
            Access.IterationTimePeriods tmp = new IterationTimePeriods(this.Where(f => f.IterationID.IterationID == Iteration.IterationID));
            return tmp;
        }

        #endregion

        #region Filter

        public Access.IterationTimePeriods FilterByIteration(Access.Iteration Iteration)
        {
            Access.IterationTimePeriods tmp = this.SelectByIteration(Iteration);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        #endregion

        #region OtherFunctions

        public Access.IterationTimePeriod getCurrentTimePeriod()
        {
            Access.IterationTimePeriods tempList = new IterationTimePeriods();
            tempList.AddRange(this.OrderBy(f => f.IterationTimePeriodStartDate).Where(f => DateTime.Now >= f.IterationTimePeriodStartDate && DateTime.Now <= f.IterationTimePeriodEndDate));
            if (tempList.Count() > 0) return tempList.First();
            else return this.OrderBy(f => f.IterationTimePeriodStartDate).First();
        }

        public Access.IterationTimePeriod getNewestTimePeriod()
        {
            return this.OrderBy(f => f.IterationTimePeriodEndDate).Last();
        }

        #endregion
    }
}
