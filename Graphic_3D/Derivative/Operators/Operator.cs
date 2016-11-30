using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    abstract class Operator:Function
    {
        protected Operator(Function a, Function b)
        {
            leftFunc = a;
            rightFunc = b;
        }
        protected readonly Function leftFunc;
        protected readonly Function rightFunc;
    }
}
