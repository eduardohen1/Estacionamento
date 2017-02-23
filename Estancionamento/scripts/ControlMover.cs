using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento.scripts
{
    class ControlMover
    {
        public enum Direcao
        {
            Qualquer,
            Horizontal,
            Vertical
        }
        public static void Init(Control control)
        {
            Init(control, Direcao.Qualquer);
        }
        public static void Init(Control control, Direcao direcao)
        {
            Init(control, control, direcao);
        }
        public static void Init(Control control, Control container, Direcao direcao)
        {
            bool Dragging = false;
            Point DragStart = Point.Empty;
            control.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                Dragging = true;
                DragStart = new Point(e.X, e.Y);
                control.Capture = true;
            };
            control.MouseUp += delegate(object sender, MouseEventArgs e)
            {
                Dragging = false;
                control.Capture = false;
            };
            control.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (Dragging)
                {
                    if (direcao != Direcao.Vertical)
                        container.Left = Math.Max(0, e.X + container.Left - DragStart.X);
                    if (direcao != Direcao.Horizontal)
                        container.Top = Math.Max(0, e.Y + container.Top - DragStart.Y);
                }
            };
        }
    }
}
