using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphic_3D
{
    class X_Arrow : AxisArrows
    {
        public X_Arrow():base(new Vertex(1,0,0))
        {
            //цвет
            Color = Color.Blue;
        }
    }
}
