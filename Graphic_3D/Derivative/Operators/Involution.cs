using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    class Involution:Operator
    {
        public Involution(Function a, Function b) : base(a, b)
        { }

        public override double Calc(double val)
        {
            return Math.Pow(leftFunc.Calc(val),rightFunc.Calc(val));
        }

        public override Function Derivative()
        { 
            return rightFunc * (leftFunc ^ rightFunc - 1) * leftFunc.Derivative();
        }
    }
}
