using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    class Identity:Function
    {
        public override double Calc(double val)
        {
            return val;
        }

        public override Function Derivative()
        {
            return new Constant(1);
        }
    }
}
