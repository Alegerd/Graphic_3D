using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic_3D
{
    //главный класс
    class Executioner
    {
        public CoordinateCenter CoordinateCenter;
        private Graphics g;
        private PictureBox PictureBox;
        public Model Model { get; set; }

        bool ModelIsCreated;

        public enum ModelKinds
        {
            Cilinder,
            Elipsoid
        }
        public ModelKinds ModelKind;

        private List<SceneObject> Objects = new List<SceneObject>();

        private List<AxisArrows> Arrows = new List<AxisArrows>();
        private X_Arrow X_Arrow = new X_Arrow();
        private Y_Arrow Y_Arrow = new Y_Arrow();
        private Z_Arrow Z_Arrow = new Z_Arrow();

        public Executioner(CoordinateCenter CC, Graphics G, PictureBox PB)
        {
            Model = new Model();
            CoordinateCenter = CC;
            g = G;
            PictureBox = PB;

            //добавляем стрелки в списки
            Arrows.Add(X_Arrow);
            Arrows.Add(Y_Arrow);
            Arrows.Add(Z_Arrow);
            Objects.Add(X_Arrow);
            Objects.Add(Y_Arrow);
            Objects.Add(Z_Arrow);

            //добавляем модель в список
            Objects.Add(Model);
        }

        public void DrawAxis()
        {
            //рисуем стрелки, проходя по списку стрелок
            foreach (AxisArrows Arrow in Arrows)
            {
                g.DrawLine(new Pen(new SolidBrush(Arrow.Color)),
                          CoordinateCenter.Position.X,
                          CoordinateCenter.Position.Y,
                          CoordinateCenter.Position.X + Arrow.Position.X * Consts.ArrowsScale,
                          CoordinateCenter.Position.Y - Arrow.Position.Y * Consts.ArrowsScale);
            }
            PictureBox.Refresh();
        }

        public void TurnSystemX(int direction)
        {
            //поворачиваем каждую стрелку по X, в соответствии с направлением
            foreach (SceneObject Object in Objects)
            {
                Object.TurnByX(direction);
            }
        }

        public void TurnSystemY(int direction)
        {
            //поворачиваем каждую стрелку по Y, в соответствии с направлением
            foreach (SceneObject Object in Objects)
            {
                Object.TurnByY(direction);
            }
        }

        public void RedrawAll()
        {
            DrawAxis();
            DrawModel();
        }

        public void BuildModel(ModelKinds modelKind)
        {
            ModelKind = modelKind;

            //новый ряд
            List<Vertex> RowVertexes = new List<Vertex>();

            //предыдущий ряд
            List<Vertex> PrewRowVertexes = RowVertexes;


            switch (modelKind)
            {
                case ModelKinds.Cilinder:
                    #region
                    float z = -1.0f;
                    for (int i = 0; i < 20; i++, z += 0.1f)
                    {
                        RowVertexes = new List<Vertex>();

                        //первый из "кольца"
                        Vertex FirstVertexPos = null;
                        Vertex FirstVertexNeg = FirstVertexPos;

                        //предыдущий из "кольца"
                        Vertex PrewVertexPos = FirstVertexPos;
                        Vertex PrewVertexNeg = FirstVertexPos;

                        float y = -1.0f;
                        for (int j = 0; j <= 20; j++, y += 0.1f)
                        {
                            if (j == 20)
                                j = 20;
                            y = Convert.ToSingle(Math.Round(y, 3));
                            //расчет X м передача точек в массив модели
                            double x = Math.Sqrt((1 - y * y / (1 * 1)) * 1 * 1);

                            if (!Double.IsNaN(x))
                            {
                                Vertex newVertexPos = new Vertex(Convert.ToSingle(x), y, z);
                                Vertex newVertexNeg = new Vertex(Convert.ToSingle(-x), y, z);

                                Model.Vertexes.Add(newVertexPos);
                                Model.Vertexes.Add(newVertexNeg);

                                //добавление вершины в ряд
                                RowVertexes.Add(newVertexPos);
                                RowVertexes.Add(newVertexNeg);

                                if (FirstVertexPos == null)
                                {
                                    FirstVertexPos = newVertexPos;
                                }

                                if (FirstVertexNeg == null)
                                {
                                    FirstVertexNeg = newVertexNeg;
                                }

                                newVertexPos.prewVertex = PrewVertexPos;
                                PrewVertexPos = newVertexPos;
                                newVertexNeg.prewVertex = PrewVertexNeg;
                                PrewVertexNeg = newVertexNeg;
                            }
                        }

                        //замыкаем круг
                        if (RowVertexes.Count != 0)
                        {
                            FirstVertexPos.prewVertex = FirstVertexPos;
                            FirstVertexNeg.prewVertex = FirstVertexNeg;
                        }

                        //соединяем ряды
                        for (int l = 0; l < RowVertexes.Count; l++)
                        {
                            if (z == -1)
                            {
                                RowVertexes[l].prewRowVertex = RowVertexes[l];
                            }
                            else
                            {
                                RowVertexes[l].prewRowVertex = PrewRowVertexes[l];
                            }
                        }

                        PrewRowVertexes = RowVertexes;
                    }
                    #endregion
                    break;
                case ModelKinds.Elipsoid:
                    #region
                    for (z = -1; z < 1; z += 0.1f)
                    {
                        RowVertexes = new List<Vertex>();

                        //первый из "кольца"
                        Vertex FirstVertexPos = null;
                        Vertex FirstVertexNeg = FirstVertexPos;

                        //предыдущий из "кольца"
                        Vertex PrewVertexPos = FirstVertexPos;
                        Vertex PrewVertexNeg = FirstVertexPos;

                        for (float y = -1; y <= 1; y += 0.1f)
                        {
                            //расчет X и передача точек в массив модели
                            y = Convert.ToSingle(Math.Round(y, 2));
                            z = Convert.ToSingle(Math.Round(z, 2));

                            double x = Math.Sqrt((1 - ((z * z) / (0.5 * 0.5)) - ((y * y) / (1 * 1))) * 1 * 1);

                            if (!Double.IsNaN(x))
                            {
                                Vertex newVertexPos = new Vertex(Convert.ToSingle(x), y, z);
                                Vertex newVertexNeg = new Vertex(Convert.ToSingle(-x), y, z);

                                Model.Vertexes.Add(newVertexPos);
                                Model.Vertexes.Add(newVertexNeg);

                                //добавление вершины в ряд
                                RowVertexes.Add(newVertexPos);
                                RowVertexes.Add(newVertexNeg);

                                if (FirstVertexPos == null)
                                {
                                    FirstVertexPos = newVertexPos;
                                }

                                if (FirstVertexNeg == null)
                                {
                                    FirstVertexNeg = newVertexNeg;
                                }

                                newVertexPos.prewVertex = PrewVertexPos;
                                PrewVertexPos = newVertexPos;
                                newVertexNeg.prewVertex = PrewVertexNeg;
                                PrewVertexNeg = newVertexNeg;
                            }
                        }

                        //замыкаем круг
                        if (RowVertexes.Count != 0)
                        {
                            FirstVertexPos.prewVertex = FirstVertexPos;
                            FirstVertexNeg.prewVertex = FirstVertexNeg;
                        }

                        //соединяем ряды
                        //for (int i = 0; i < RowVertexes.Count; i++)
                        //{
                        //    if (z == -10)
                        //    {
                        //        RowVertexes[i].prewRowVertex = RowVertexes[i];
                        //    }
                        //    else
                        //    {
                        //        RowVertexes[i].prewRowVertex = PrewRowVertexes[i];
                        //    }
                        //}

                        //PrewRowVertexes = RowVertexes;
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        private void DrawModel()
        {
            foreach (Vertex Vertex in Model.Vertexes)
            {
                //g.DrawEllipse(Pens.Black, CoordinateCenter.Position.X + Vertex.X * Consts.Scale, CoordinateCenter.Position.Y + Vertex.Y * Consts.Scale, 1, 1);

                g.DrawLine(Pens.Black, CoordinateCenter.Position.X + Vertex.prewVertex.X * Consts.Scale, CoordinateCenter.Position.Y + Vertex.prewVertex.Y * Consts.Scale,
                                       CoordinateCenter.Position.X + Vertex.X * Consts.Scale, CoordinateCenter.Position.Y + Vertex.Y * Consts.Scale);

                //g.DrawLine(Pens.Black, CoordinateCenter.Position.X + Vertex.prewRowVertex.X * Consts.Scale, CoordinateCenter.Position.Y + Vertex.prewRowVertex.Y * Consts.Scale,
                //       CoordinateCenter.Position.X + Vertex.X * Consts.Scale, CoordinateCenter.Position.Y + Vertex.Y * Consts.Scale);
            }
        }
    }
}
