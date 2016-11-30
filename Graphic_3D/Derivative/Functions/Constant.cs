using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    class Constant:Function
    {

        public Constant(double val)
        {
            value = val;
        }

        private readonly double value;

        public override double Calc(double val)
        {
            return value;
        }

        public override Function Derivative()
        {
            return new Constant(0);
        }
    }
}
