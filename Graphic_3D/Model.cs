using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_3D
{
    class Model:SceneObject
    {
        public List<Vertex> Vertexes = new List<Vertex>();

        public override void TurnByX(int direction)
        {
            float newZ;
            float newY;
            for (int i = 0; i < Vertexes.Count; i++)
            {
                newZ = Convert.ToSingle(-Vertexes[i].Y * -direction * Math.Sin(Consts.RotationAngle / 180 * Math.PI) + Vertexes[i].Z * Math.Cos(Consts.RotationAngle / 180 * Math.PI));
                newY = Convert.ToSingle(Vertexes[i].Y * Math.Cos(Consts.RotationAngle / 180 * Math.PI) + Vertexes[i].Z * -direction * Math.Sin(Consts.RotationAngle / 180 * Math.PI));
                Vertexes[i].Z = newZ;
                Vertexes[i].Y = newY;
            }
        }

        public override void TurnByY(int direction)
        {
            float newX;
            float newZ;
            for (int i = 0; i < Vertexes.Count; i++)
            {
                newZ = Convert.ToSingle(Vertexes[i].X * direction * Math.Sin(Consts.RotationAngle / 180 * Math.PI) + Vertexes[i].Z * Math.Cos(Consts.RotationAngle / 180 * Math.PI));
                newX = Convert.ToSingle(Vertexes[i].X * Math.Cos(Consts.RotationAngle / 180 * Math.PI) - Vertexes[i].Z * direction * Math.Sin(Consts.RotationAngle / 180 * Math.PI));
                Vertexes[i].Z = newZ;
                Vertexes[i].X = newX;
            }
        }

    }
}
