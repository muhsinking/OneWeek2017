using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    public class Door : IScriptableObject
    {

        public Door(string name)
        {
            VariableName = name;
        }

        public string VariableName { get; set; }

        public string GetParameterizedName()
        {
            return "Door " + VariableName;
        }

        public void Open()
        {
            Console.WriteLine("HOLY SHIT YOU OPENED " + VariableName);
        }
    }
}
