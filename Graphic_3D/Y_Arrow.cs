﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphic_3D
{
    class Y_Arrow : AxisArrows
    {
        public Y_Arrow() : base(new Vertex(0, 1, 0))
        {
            //цвет
            Color = Color.Red;
        }
    }
}
