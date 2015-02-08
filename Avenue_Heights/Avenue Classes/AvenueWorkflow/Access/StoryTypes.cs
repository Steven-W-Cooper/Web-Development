using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class StoryTypes : System.Collections.Generic.List<Access.StoryType>
    {
        #region Constructors

        public StoryTypes()
            : base()
        {

        }

        public StoryTypes(Avenue.Heights.Data.AvenueCollection DataStoryTypes)
            : base()
        {
            Generate(DataStoryTypes);
        }

        public StoryTypes(Access.StoryType[] AccessStoryTypes)
            : base()
        {
            this.AddRange(AccessStoryTypes);
        }

        public StoryTypes(System.Collections.Generic.IEnumerable<Access.StoryType> AccessStoryTypes)
            : base()
        {
            this.AddRange(AccessStoryTypes);
        }

        public StoryTypes(Access.StoryType AStoryType)
            : base()
        {
            this.Add(AStoryType);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataStoryTypes)
        {
            foreach (Data.StoryType aStoryType in DataStoryTypes)
            {
                base.Add(new Access.StoryType(aStoryType));
            }
        }

        #region Get

        public Access.StoryTypes Get(Int32 StoryTypeID)
        {
            Data.StoryType aStoryType = new Data.StoryType(StoryTypeID);
            this.Add(new Access.StoryType(aStoryType));
            return this;
        }

        public Access.StoryTypes GetAll()
        {
            Data.StoryTypes DataStoryTypes = new Data.StoryTypes();
            DataStoryTypes.GetAll();
            Generate(DataStoryTypes);
            return this;
        }

        #endregion
    }
}
