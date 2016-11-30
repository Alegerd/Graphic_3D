using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    class Addition:Operator
    {
        public Addition(Function a, Function b) : base(a, b)
        { }

        public override double Calc(double val)
        {
            return leftFunc.Calc(val) + rightFunc.Calc(val);
        }

        public override Function Derivative()
        {
            return leftFunc.Derivative() + rightFunc.Derivative();
        }
    }
}
