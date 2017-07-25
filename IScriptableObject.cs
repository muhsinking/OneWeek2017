using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    interface IScriptableObject
    {

        // Returns the name of the variable and it's type, ie. 'Door doorName'
        //
        string GetParameterizedName();
    }
}
