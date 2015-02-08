using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class IterationTypes : System.Collections.Generic.List<Access.IterationType>
    {
        #region Constructors

        public IterationTypes()
            : base()
        {

        }

        public IterationTypes(Avenue.Heights.Data.AvenueCollection DataIterationTypes)
            : base()
        {
            Generate(DataIterationTypes);
        }

        public IterationTypes(Access.IterationType[] AccessIterationTypes)
            : base()
        {
            this.AddRange(AccessIterationTypes);
        }

        public IterationTypes(System.Collections.Generic.IEnumerable<Access.IterationType> AccessIterationTypes)
            : base()
        {
            this.AddRange(AccessIterationTypes);
        }

        public IterationTypes(Access.IterationType AIterationType) : base()
        {
            this.Add(AIterationType);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataIterationTypes)
        {
            foreach (Data.IterationType aIterationType in DataIterationTypes)
            {
                base.Add(new Access.IterationType(aIterationType));
            }
        }

        #region Get

        public Access.IterationTypes Get(Int32 IterationTypeID)
        {
            Data.IterationType aIterationType = new Data.IterationType(IterationTypeID);
            this.Add(new Access.IterationType(aIterationType));
            return this;
        }

        public Access.IterationTypes GetAll()
        {
            Data.IterationTypes DataIterationTypes = new Data.IterationTypes();
            DataIterationTypes.GetAll();
            Generate(DataIterationTypes);
            return this;
        }
        #endregion
    }
}
