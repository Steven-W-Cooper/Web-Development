using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights.Access
{

    public interface IAvenueCollection
    {
        AvenueCollection Get(Int32 PrimaryKey);
    }

    public class AvenueCollection : System.Collections.ArrayList
    {
    }
}
