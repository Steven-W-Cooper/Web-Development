using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Heights.Access
{

    public interface IAvenueData
    {
         AvenueData Get(Int32 PrimaryKey);
         void Insert();
         void Update();
         void Delete();
    }

    public class AvenueData
    {
        static void CheckNumeric(String text, Decimal value)
        {
            Decimal.TryParse(text, out value);
        }
    }
}
