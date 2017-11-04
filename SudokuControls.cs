using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Game
{
    public partial class SudokuControls : UserControl
    {

        public Color SelectedColor { get; set; }
        public Color ErrorColor { get; set; }
        public Color DefaultColor { get; set; }
        public Color LineColor { get; set; }
        public Color ThickLineColor { get; set; }

        public Point SelecedBox { get; set; }


        public SudokuControls()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();

            SelectedColor = Color.AliceBlue;
            ErrorColor = Color.Red;
            DefaultColor = Color.LightGray;
            LineColor = Color.LightGray;
            ThickLineColor = Color.Black;
            SelecedBox = new Point();
        }

        private void SudokuControls_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(Size.Height, Size.Height);
        }

        private void SudokuControls_Paint(object sender, PaintEventArgs e)
        {
            Brush br1 = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(br1, e.ClipRectangle);
            br1.Dispose();

            float step_w1 = (Width-1) / 9f;
            float step_h1 = (Height-1) / 9f;

            if (SelecedBox.X != 0 && SelecedBox.Y != 0)
            {
                Rectangle rec = new Rectangle((int)((SelecedBox.X - 1) * step_w1), (int)((SelecedBox.Y - 1) * step_h1), (int)step_w1+1, (int)step_h1+1);
                e.Graphics.FillRectangle(Brushes.LightBlue, rec);
            }


            for (int i = 0; i < 9; i++)
            {
                Pen p = new Pen(LineColor)
                {
                    EndCap = System.Drawing.Drawing2D.LineCap.SquareAnchor,
                    StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor
                };
                e.Graphics.DrawLine(p, 0,(int)i * step_h1, Width, (int)i * step_h1);
                p.Dispose();
            }

            for (int i = 0; i < 9; i++)
            {
                Pen p = new Pen(LineColor)
                {
                    EndCap = System.Drawing.Drawing2D.LineCap.SquareAnchor,
                    StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor
                };
                e.Graphics.DrawLine(p, (int)i * step_w1, 0, (int)i * step_w1, Width);
                p.Dispose();
            }

            float tlw = 3f;
            float step_w = (Width - tlw) / 3f;
            float step_h = (Height - tlw) / 3f;

            for (int i = 0; i <= 3; i++)
            {
                Pen p = new Pen(ThickLineColor, tlw)
                {
                    EndCap = System.Drawing.Drawing2D.LineCap.SquareAnchor,
                    StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor
                };
                e.Graphics.DrawLine(p, (int)tlw/2f, (int)tlw / 2f + (int)i * step_h, (int)tlw / 2f + Width, (int)tlw/2f + (int)i * step_h);
                p.Dispose();
            }

            for (int i = 0; i <= 3; i++)
            {
                Pen p = new Pen(ThickLineColor, tlw)
                {
                    EndCap = System.Drawing.Drawing2D.LineCap.SquareAnchor,
                    StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor
                };
                e.Graphics.DrawLine(p, (int)tlw / 2f + (int)i * step_w, (int)tlw / 2f, (int)tlw / 2f + (int)i * step_w, (int)tlw / 2f + Width);
                p.Dispose();
            }

            
        }

        private void SudokuControls_MouseClick(object sender, MouseEventArgs e)
        {
            float step_w = Width / 9f;
            float step_h = Height / 9f;

            int row = (int)(e.Y / step_h)+1;
            int col = (int)(e.X / step_w)+1;
            SelecedBox = new Point(col, row);
            Invalidate();
            ParentForm.Text = "(" + col.ToString() + " , " + row.ToString() + ")";
        }

        private void SudokuControls_KeyDown(object sender, KeyEventArgs e)
        {
            Keys test = Keys.D1 | Keys.D2 | Keys.D3 | Keys.D4 | Keys.D5 | Keys.D6 | Keys.D7 | Keys.D8 | Keys.D9 
                | Keys.NumPad1 | Keys.NumPad2 | Keys.NumPad3 | Keys.NumPad4 | Keys.NumPad5 | Keys.NumPad6 
                | Keys.NumPad7 | Keys.NumPad8 | Keys.NumPad9;
            int num = 0;

            if (SelecedBox.X != 0 && SelecedBox.Y == 0)
            {
                if (e.KeyCode == test)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.D1:
                            num = 1;
                            break;
                        case Keys.D2:
                            num = 2;
                            break;
                        case Keys.D3:
                            num = 3;
                            break;
                        case Keys.D4:
                            num = 4;
                            break;
                        case Keys.D5:
                            num = 5;
                            break;
                        case Keys.D6:
                            num = 6;
                            break;
                        case Keys.D7:
                            num = 7;
                            break;
                        case Keys.D8:
                            num = 8;
                            break;
                        case Keys.D9:
                            num = 9;
                            break;
                        case Keys.D0:
                            num = 0;
                            break;                       
                          
                    }
                }
                ParentForm.Text = num.ToString();
            }
        }
    }
}
