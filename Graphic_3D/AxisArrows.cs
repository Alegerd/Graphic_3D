using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphic_3D
{
    class AxisArrows:SceneObject
    {
        public Color Color { get; set; }
        public Vertex Position { get; set; }

        public AxisArrows(Vertex position)
        {
            Position = position;
        }

        public override void TurnByX(int direction)
        {
            float newZ;
            float newY;

            newZ = Convert.ToSingle(-Position.Y * Math.Sin(direction * Consts.RotationAngle / 180 * Math.PI) + Position.Z * Math.Cos(direction * Consts.RotationAngle / 180 * Math.PI));
            newY = Convert.ToSingle(Position.Y * Math.Cos(direction * Consts.RotationAngle / 180 * Math.PI) + Position.Z * Math.Sin(direction * Consts.RotationAngle / 180 * Math.PI));
            Position.Z = newZ;
            Position.Y = newY;
        }

        public override void TurnByY(int direction)
        {
            float newX;
            float newZ;

            newZ = Convert.ToSingle(Position.X * Math.Sin(direction * Consts.RotationAngle / 180 * Math.PI) + Position.Z * Math.Cos(direction * Consts.RotationAngle / 180 * Math.PI));
            newX = Convert.ToSingle(Position.X * Math.Cos(direction * Consts.RotationAngle / 180 * Math.PI) - Position.Z * Math.Sin(direction * Consts.RotationAngle / 180 * Math.PI));
            Position.Z = newZ;
            Position.X = newX;
        }
    }
}
