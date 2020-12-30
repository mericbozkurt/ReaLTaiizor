﻿#region Imports

using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

#endregion

namespace ReaLTaiizor.Controls
{
    #region SkyComboBox

    public class SkyComboBox : ComboBox
    {
        #region " Control Help - Properties & Flicker Control "

        private int _StartIndex = 0;
        public int StartIndex
        {
            get => _StartIndex;
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public void ReplaceItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_highlightColor), e.Bounds);
                    LinearGradientBrush gloss = new LinearGradientBrush(e.Bounds, ListSelectedBackColorA, ListSelectedBackColorB, 90);
                    e.Graphics.FillRectangle(gloss, new Rectangle(new Point(e.Bounds.X, e.Bounds.Y), new Size(e.Bounds.Width, e.Bounds.Height)));
                    e.Graphics.DrawRectangle(new Pen(ListBorderColor) { DashStyle = ListDashType }, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(ListBackColor), e.Bounds);
                }

                using (SolidBrush b = new SolidBrush(ListForeColor))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height));
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
        }

        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>
            {
                FirstPoint,
                SecondPoint,
                ThirdPoint
            };
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }

        private Color _highlightColor = Color.FromArgb(121, 176, 214);
        public Color ItemHighlightColor
        {
            get => _highlightColor;
            set
            {
                _highlightColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Variables
        private SmoothingMode _SmoothingType = SmoothingMode.HighQuality;
        private Color _BGColorA = Color.FromArgb(245, 245, 245);
        private Color _BGColorB = Color.FromArgb(230, 230, 230);
        private Color _BorderColorA = Color.FromArgb(252, 252, 252);
        private Color _BorderColorB = Color.FromArgb(249, 249, 249);
        private Color _BorderColorC = Color.FromArgb(189, 189, 189);
        private Color _BorderColorD = Color.FromArgb(200, 168, 168, 168);
        private Color _TriangleColorA = Color.FromArgb(121, 176, 214);
        private Color _TriangleColorB = Color.FromArgb(27, 94, 137);
        private Color _LineColorA = Color.White;
        private Color _LineColorB = Color.FromArgb(189, 189, 189);
        private Color _LineColorC = Color.White;
        private Color _ListForeColor = Color.Black;
        private Color _ListBackColor = Color.FromArgb(255, 255, 255, 255);
        private Color _ListBorderColor = Color.FromArgb(50, Color.Black);
        private DashStyle _ListDashType = DashStyle.Dot;
        private Color _ListSelectedBackColorA = Color.FromArgb(15, Color.White);
        private Color _ListSelectedBackColorB = Color.FromArgb(0, Color.White);
        #endregion

        #region Settings
        public SmoothingMode SmoothingType
        {
            get => _SmoothingType;
            set
            {
                _SmoothingType = value;
                Invalidate();
            }
        }

        public Color BGColorA
        {
            get { return _BGColorA; }
            set { _BGColorA = value; }
        }

        public Color BGColorB
        {
            get { return _BGColorB; }
            set { _BGColorB = value; }
        }

        public Color BorderColorA
        {
            get { return _BorderColorA; }
            set { _BorderColorA = value; }
        }

        public Color BorderColorB
        {
            get { return _BorderColorB; }
            set { _BorderColorB = value; }
        }

        public Color BorderColorC
        {
            get { return _BorderColorC; }
            set { _BorderColorC = value; }
        }

        public Color BorderColorD
        {
            get { return _BorderColorD; }
            set { _BorderColorD = value; }
        }

        public Color TriangleColorA
        {
            get { return _TriangleColorA; }
            set { _TriangleColorA = value; }
        }

        public Color TriangleColorB
        {
            get { return _TriangleColorB; }
            set { _TriangleColorB = value; }
        }

        public Color LineColorA
        {
            get { return _LineColorA; }
            set { _LineColorA = value; }
        }

        public Color LineColorB
        {
            get { return _LineColorB; }
            set { _LineColorB = value; }
        }

        public Color LineColorC
        {
            get { return _LineColorC; }
            set { _LineColorC = value; }
        }

        public Color ListForeColor
        {
            get { return _ListForeColor; }
            set { _ListForeColor = value; }
        }

        public Color ListBackColor
        {
            get { return _ListBackColor; }
            set { _ListBackColor = value; }
        }

        public Color ListBorderColor
        {
            get { return _ListBorderColor; }
            set { _ListBorderColor = value; }
        }

        public DashStyle ListDashType
        {
            get { return _ListDashType; }
            set { _ListDashType = value; }
        }

        public Color ListSelectedBackColorA
        {
            get { return _ListSelectedBackColorA; }
            set { _ListSelectedBackColorA = value; }
        }

        public Color ListSelectedBackColorB
        {
            get { return _ListSelectedBackColorB; }
            set { _ListSelectedBackColorB = value; }
        }
        #endregion

        public SkyComboBox() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(27, 94, 137);
            Font = new Font("Verdana", 6.75f, FontStyle.Bold);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Size = new Size(75, 21);
            ItemHeight = 16;
            DrawItem += new DrawItemEventHandler(ReplaceItem);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingType;

            G.Clear(BackColor);
            LinearGradientBrush bodyGradNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 2), BGColorA, BGColorB, 90);
            G.FillRectangle(bodyGradNone, bodyGradNone.Rectangle);
            LinearGradientBrush bodyInBorderNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 3), BorderColorA, BorderColorB, 90);
            G.DrawRectangle(new Pen(bodyInBorderNone), new Rectangle(1, 1, Width - 3, Height - 4));
            G.DrawRectangle(new Pen(BorderColorC), new Rectangle(0, 0, Width - 1, Height - 2));
            G.DrawLine(new Pen(BorderColorD), new Point(1, Height - 1), new Point(Width - 2, Height - 1));
            DrawTriangle(TriangleColorA, new Point(Width - 14, 8), new Point(Width - 7, 8), new Point(Width - 11, 12), G);
            G.DrawLine(new Pen(TriangleColorB), new Point(Width - 14, 8), new Point(Width - 8, 8));

            //Draw Separator line
            G.DrawLine(new Pen(LineColorA), new Point(Width - 22, 1), new Point(Width - 22, Height - 3));
            G.DrawLine(new Pen(LineColorB), new Point(Width - 21, 1), new Point(Width - 21, Height - 3));
            G.DrawLine(new Pen(LineColorC), new Point(Width - 20, 1), new Point(Width - 20, Height - 3));
            
            try
            {
                G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(5, -1, Width - 20, Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            catch
            {
            }

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}