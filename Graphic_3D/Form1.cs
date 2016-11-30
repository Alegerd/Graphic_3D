using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_3D
{
    public partial class Form1 : Form
    {
        bool GUIpanelVisible { get; set; }
        bool LeftMouseBtnDown;
        Executioner executioner;
        Graphics g;
        Bitmap bitmap;
        Point mousePosition;


        public Form1()
        {
            InitializeComponent();
        }
        private void MoveGUIPanel()
        {
            if (GUIpanelVisible)
            {
                //закрытие панели управления
                GUIpanel.Left += GUIpanel.Width - 6;
                GUIpanelBtn.Left += GUIpanel.Width - 6;

                //смена значка
                GUIpanelBtn.Text = "<";

                //установка флага
                GUIpanelVisible = false;
            }
            else
            {
                //открытие панели управления
                GUIpanel.Left -= GUIpanel.Width - 6;
                GUIpanelBtn.Left -= GUIpanel.Width - 6;

                //смена значка
                GUIpanelBtn.Text = ">";

                //установка флага
                GUIpanelVisible = true;
            }
        }

        //GUIpanelBtn
        private void button1_Click(object sender, EventArgs e)
        {
            MoveGUIPanel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //растягиваем GUIpanel по размеру формы
            GUIpanel.Left = pictureBox1.Width;
            GUIpanel.Top = 0;
            GUIpanel.Height = (sender as Form).Height - 30;

            //создаем рисовалку на PictureBox
            bitmap = new Bitmap(1280, 720);
            pictureBox1.Image = bitmap;
            g = Graphics.FromImage(bitmap);

            //создаем центр координат, смещая систему
            CoordinateCenter CC = new CoordinateCenter(new Vertex(pictureBox1.Width / 2, pictureBox1.Height / 2, 0));

            //создаем главный класс
            executioner = new Executioner(CC, g, pictureBox1);

            //рисуем объекты
            executioner.RedrawAll();
        }

        //Resize 
        private void Form1_Resize(object sender, EventArgs e)
        {
            //растягиваем PictureBox по размеру формы
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = (sender as Form).Width;
            pictureBox1.Height = (sender as Form).Height;


            //убираем GUIpanel
            GUIpanelVisible = false;
            GUIpanelBtn.Text = "<";

            //растягиваем GUIpanel по размеру формы
            GUIpanel.Left = pictureBox1.Width - 10;
            GUIpanel.Top = 0;
            GUIpanel.Height = (sender as Form).Height - 30;

            //растягиваем GUIpanelBtn по размеру формы
            GUIpanelBtn.Left = pictureBox1.Width - GUIpanelBtn.Width - 10;
            GUIpanelBtn.Top = (sender as Form).Height / 2 - GUIpanelBtn.Height;

            //пересоздаем центр координат, смещая систему
            CoordinateCenter CC = new CoordinateCenter(new Vertex(pictureBox1.Width / 2, pictureBox1.Height / 2, 0));
            executioner.CoordinateCenter = CC;

            //рисуем объекты
            g.Clear(Consts.BGColor);
            executioner.RedrawAll();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LeftMouseBtnDown)
            {
                if (e.X < mousePosition.X)
                {
                    g.Clear(Consts.BGColor);
                    executioner.TurnSystemY(-1);
                    executioner.RedrawAll();
                    pictureBox1.Refresh();
                }
                else if (e.X > mousePosition.X)
                {
                    g.Clear(Consts.BGColor);
                    executioner.TurnSystemY(1);
                    executioner.RedrawAll();
                    pictureBox1.Refresh();
                }

                if (e.Y < mousePosition.Y)
                {
                    g.Clear(Consts.BGColor);
                    executioner.TurnSystemX(-1);
                    executioner.RedrawAll();
                    pictureBox1.Refresh();
                }
                else if (e.Y > mousePosition.Y)
                {
                    g.Clear(Consts.BGColor);
                    executioner.TurnSystemX(1);
                    executioner.RedrawAll();
                    pictureBox1.Refresh();
                }
            }

            //обновление позиции мыши, для последующего вычисления смещения
            mousePosition = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) LeftMouseBtnDown = true;
            mousePosition = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) LeftMouseBtnDown = false;
        }

        private void BuildBtn_Click(object sender, EventArgs e)
        {
            //создание модели, в зависимости от выбранной RadioButton
            if (CilinderRB.Checked)
            {
                executioner.BuildModel(Executioner.ModelKinds.Cilinder);
            }
            else if (ElipsoidRB.Checked)
            {
                executioner.BuildModel(Executioner.ModelKinds.Elipsoid);
            }
            executioner.RedrawAll();
            pictureBox1.Refresh();
        }
    }
}
