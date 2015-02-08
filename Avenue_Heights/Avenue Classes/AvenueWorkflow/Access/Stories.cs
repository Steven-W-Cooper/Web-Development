using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Stories : System.Collections.Generic.List<Access.Story>
    {
        #region Constructors

        public Stories()
            : base()
        {

        }

        public Stories(Avenue.Heights.Data.AvenueCollection DataStories)
            : base()
        {
            Generate(DataStories);
        }

        public Stories(Access.Story[] AccessStories)
            : base()
        {
            this.AddRange(AccessStories);
        }

        public Stories(System.Collections.Generic.IEnumerable<Access.Story> AccessStories)
            : base()
        {
            this.AddRange(AccessStories);
        }

        public Stories(Access.Story AStory)
            : base()
        {
            this.Add(AStory);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataStories)
        {
            foreach (Data.Story aStory in DataStories)
            {
                base.Add(new Access.Story(aStory));
            }
        }

        #region Get

        public Access.Stories Get(Int32 StoryID)
        {
            Data.Story aStory = new Data.Story(StoryID);
            this.Add(new Access.Story(aStory));
            return this;
        }

        public Access.Stories GetByStoryID(Int32 StoryID)
        {
            Data.Stories DataStories = new Data.Stories();
            DataStories.GetByStoryID(StoryID);
            Generate(DataStories);
            return this;
        }

        public Access.Stories GetByIterationID(Int32 IterationID)
        {
            Data.Stories DataStories = new Data.Stories();
            DataStories.GetByIterationID(IterationID);
            Generate(DataStories);
            return this;
        }

        public Access.Stories GetByIterationTimePeriodID(Int32 IterationTimePeriodID)
        {
            Data.Stories DataStories = new Data.Stories();
            DataStories.GetByIterationTimePeriodID(IterationTimePeriodID);
            Generate(DataStories);
            return this;
        }

        public Access.Stories GetByStoryTypeID(Int32 StoryTypeID)
        {
            Data.Stories DataStories = new Data.Stories();
            DataStories.GetByStoryTypeID(StoryTypeID);
            Generate(DataStories);
            return this;
        }

        #endregion

        #region Selects

        public Access.Stories SelectByIteration(Iteration Iteration)
        {
            return new Stories(this.Where(f => f.IterationID.IterationID == Iteration.IterationID));
        }

        public Access.Stories SelectByIterationTimePeriod(IterationTimePeriod IterationTimePeriod)
        {
            return new Stories(this.Where(f => f.IterationTimePeriodID != null).Where(f => f.IterationTimePeriodID.IterationTimePeriodID == IterationTimePeriod.IterationTimePeriodID));
        }

        public Access.Stories SelectByStoryType(StoryType StoryType)
        {
            return new Stories(this.Where(f => f.StoryTypeID.StoryTypeID == StoryType.StoryTypeID));
        }

        #endregion

        #region Filter

        public Access.Stories FilterByIteration(Iteration Iteration)
        {
            Access.Stories tmp = this.SelectByIteration(Iteration);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public Access.Stories FilterByIterationTimePeriod(IterationTimePeriod IterationTimePeriod)
        {
            Access.Stories tmp = this.SelectByIterationTimePeriod(IterationTimePeriod);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        public Access.Stories FilterByStoryType(StoryType StoryType)
        {
            Access.Stories tmp = this.SelectByStoryType(StoryType);
            this.Clear();
            this.AddRange(tmp);
            return this;
        }

        #endregion
    }
}
