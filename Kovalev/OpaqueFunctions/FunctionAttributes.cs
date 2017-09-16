using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpaqueFunctions
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class OpaqueFunction : System.Attribute
    {
        public string shortName;

        public OpaqueFunction()
        {
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class FunctionName : System.Attribute
    {
        public string shortName;
        public string description;

        public FunctionName(string name, string desc)
        {
            this.shortName = name;
            this.description = desc;
        }
    }


    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class InverseTo : System.Attribute
    {
        public string inverseName;

        public InverseTo(string name)
        {
            this.inverseName = name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class EquivalentIntConstant : System.Attribute
    {
        public int value;

        public EquivalentIntConstant(int v)
        {
            this.value = v;
        }
    }
}
