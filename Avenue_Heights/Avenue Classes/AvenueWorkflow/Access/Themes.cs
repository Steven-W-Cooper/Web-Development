using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Workflow.Access
{
    public class Themes : System.Collections.Generic.List<Access.Theme>
    {
        #region Constructors

        public Themes()
            : base()
        {

        }

        public Themes(Avenue.Heights.Data.AvenueCollection DataThemes)
            : base()
        {
            Generate(DataThemes);
        }

        public Themes(Access.Theme[] AccessThemes)
            : base()
        {
            this.AddRange(AccessThemes);
        }

        public Themes(System.Collections.Generic.IEnumerable<Access.Theme> AccessThemes)
            : base()
        {
            this.AddRange(AccessThemes);
        }

        public Themes(Access.Theme ATheme)
            : base()
        {
            this.Add(ATheme);
        }

        #endregion

        private void Generate(Avenue.Heights.Data.AvenueCollection DataThemes)
        {
            foreach (Data.Theme aTheme in DataThemes)
            {
                base.Add(new Access.Theme(aTheme));
            }
        }

        #region Get

        public Access.Themes Get(Int32 ThemeID)
        {
            Data.Theme aTheme = new Data.Theme(ThemeID);
            this.Add(new Access.Theme(aTheme));
            return this;
        }

        public Access.Themes GetAll()
        {
            Avenue.Workflow.Data.Themes DataThemes = new Data.Themes();
            DataThemes.GetAll();
            Generate(DataThemes);
            return this;
        }

        #endregion
    }
}
