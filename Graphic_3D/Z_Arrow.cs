using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphic_3D
{
    class Z_Arrow : AxisArrows
    {
        public Z_Arrow() : base(new Vertex(0, 0, 1))
        {
            //цвет
            Color = Color.Green;
        }
    }
}
