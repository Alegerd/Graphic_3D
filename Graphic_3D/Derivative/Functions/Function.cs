using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    abstract class Function
    {
        public abstract double Calc(double x);
        public abstract Function Derivative();


        #region * 
        public static Function operator * (Function func1, Function func2)
        {
            return new Multiplication(func1,func2);
        }

        public static Function operator *(double k, Function b)
        {
            return new Constant(k) * b;
        }

        public static Function operator *(Function b, double k)
        {
            return new Constant(k) * b;
        }
        #endregion

        #region+
        public static Function operator +(Function func1, Function func2)
        {
            return new Addition(func1, func2);
        }

        public static Function operator +(double k, Function b)
        {
            return new Constant(k) + b;
        }

        public static Function operator +(Function b, double k)
        {
            return new Constant(k) + b;
        }
        #endregion

        #region-
        public static Function operator -(Function func1, Function func2)
        {
            return new Subtraction(func1, func2);
        }

        public static Function operator -(double k, Function b)
        {
            return new Constant(k) - b;
        }

        public static Function operator -(Function b, double k)
        {
            return new Constant(k) - b;
        }
        #endregion

        #region^
        public static Function operator ^(Function func1, Function func2)
        {
            return new Involution(func1, func2);
        }

        public static Function operator ^(double k, Function b)
        {
            return new Constant(k) ^ b;
        }

        public static Function operator ^(Function b, double k)
        {
            return new Constant(k) ^ b;
        }
        #endregion

        #region / 
        public static Function operator /(Function func1, Function func2)
        {
            return new Division(func1, func2);
        }

        public static Function operator /(double k, Function b)
        {
            return new Constant(k) / b;
        }

        public static Function operator /(Function b, double k)
        {
            return new Constant(k) / b;
        }
        #endregion
    }
}
