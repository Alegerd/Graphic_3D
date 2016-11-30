using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphic_3D
{
    class Vertex : Point3D
    {
        public Vertex(float x, float y, float z) : base(x, y, z)
        {

        }

        //ссылка на предыдущий, для их соединения
        public Vertex prewVertex;

        //ссылка на соответствующий из другого ряда, для их соединения
        public Vertex prewRowVertex;

        public float RealX;
        public float RealY;
        public float RealZ;

        public float dx;
        public float dy;
    }
}
