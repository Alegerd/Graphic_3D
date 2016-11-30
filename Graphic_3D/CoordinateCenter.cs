using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graphic_3D
{
    //центр кооординат
    class CoordinateCenter
    {
        public Vertex Position { get; set; }

        public CoordinateCenter(Vertex position)
        {
            Position = position;
        }
    }
}
