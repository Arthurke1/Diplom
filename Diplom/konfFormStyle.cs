using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Diplom
{
    public partial class konfFormStyle : Component
    {
        #region -- Свойства --
        public Form Form { get; set; }
        private fStyle formStyle = fStyle.none;
        public fStyle FormStyle
        {
            get => formStyle;
            set
            {
                formStyle = value;
                Sign();
            }
        }
        public enum fStyle
        {
            none
        }
        #endregion
        #region -- Переменные --
        [Description("Указывает, может ли пользователь изменять размер окна")]
        public bool AllowUserResize { get; set; }

        [Description("Меню быстрого доступа, отображаемое при щелчке правой кнопкой мыши на иконке окна")]
        public ContextMenuStrip ContextMenuForm { get; set; }


        private Color HeaderColor = Color.DimGray; // Цвет шапки
        private int HeaderHeight = 28; // Ширина кнопки в шапке

        private Size IconSize = new Size(14, 14);

        private StringFormat SF = new StringFormat();
        private Font Font = new Font("Arial", 8.75F, FontStyle.Regular);

        Pen WhitePen = new Pen(Color.White) { Width = 1.55F };
        private Pen penBtnMaximize = new Pen(Color.White, 1.55F); // Кисть для кнопки Развернуть/Свернуть в окно
        public int ControlBoxButtonsWidth { get; set; } = 28;
        private Size ControlBoxIconSize = new Size(10, 10); // Размер иконок меню окна
        private Rectangle rectIcon = new Rectangle(); // Структура иконки формы
        private bool IconHovered = false; // Наведен ли курсор на иконку
        private Rectangle rectHeader = new Rectangle(); // Структура заголовка формы
        bool MousePressed = false; // Кнопка мыши нажата
        Point clickPosition; // Начальная позиция курсора в момент клика
        Point moveStartPosition; // Начальная позиция формы в момент клика
        private MouseButtons LastClickedMouseButton; // Какая кнопка мыши была нажата последний раз

        private bool CanDragForm = false; // Указывает может ли форма перетаскивается
        private bool IsResizing = false; // Режим изменения размера

        private bool btnMaximizeHovered = false; // Наведен ли курсор на кнопку Развернуть/Свернуть в окно

        private Rectangle rectBorder = new Rectangle(); // Структура обводки
        private int ResizeBorderSize = 4; // Размер невидимой границы при наведении на которую меняется курсор, чтобы изменять размер формы
        private int ResizeAngleBorderOffset = 15; // Смещение от углов, где мы трактуем угловую часть для изменения размера по углам
        private Pen penBtnMinimize = new Pen(Color.White, 1.55F); // Кисть для кнопки Свернуть
        Rectangle rectBtnClose = new Rectangle();
        private Rectangle rectBtnMax = new Rectangle(); // Структура кнопки меню окна Развернуть/Свернуть в окно
        private Rectangle rectBtnMin = new Rectangle(); // Структура кнопки меню окна Свернуть
        private bool btnMinimizeHovered = false; // Наведен ли курсор на кнопку Свернуть

        private BorderHoverPositionEnum BorderHoverPosition = BorderHoverPositionEnum.None; // Куда наведен курсор в отношении обводки для изменения формы
        enum BorderHoverPositionEnum
        {
            None, // Не наведен
            Left, Top, Right, Bottom, // Стороны
            TopLeft, TopRight, BottomLeft, BottomRight // Углы
        }

        // Указывает, нужно ли восстановить позицию окна,
        // которая была, перед разворачиванием на весь экран (Maximize), с помощью перетаскивания окна вверх экана
        private bool FormNeedReposition = false;

        private int ResizeStartRight = 0;
        private int ResizeStartBottom = 0;

        bool btnCloseHovered = false;

        #endregion
        public konfFormStyle()
        {
            InitializeComponent();
        }

        public konfFormStyle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private void Sign()
        {
            if (Form != null)
            {
                Form.Load += Form_Load;
            }
        }
        private void Apply()
        {
            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;

            Size minimumSize = new Size(100, 50);
            if (Form.MinimumSize.Width < minimumSize.Width || Form.MinimumSize.Height < minimumSize.Height)
                Form.MinimumSize = minimumSize;

            Form.FormBorderStyle = FormBorderStyle.None;

            SetDoubleBuffred(Form);

            OffsetControls();
            // События формы 
            Form.Paint += Form_Paint;
            Form.MouseDown += Form_MouseDown;
            Form.MouseUp += Form_MouseUp;
            Form.MouseMove += Form_MouseMove;
            Form.SizeChanged += Form_SizeChanged;
            Form.MouseLeave += Form_MouseLeave;
            Form.DoubleClick += Form_DoubleClick;
            Form.Click += Form_Click;
        }
        private void OffsetControls()
        {
            Form.Height = Form.Height + HeaderHeight;

            foreach (Control ctrl in Form.Controls)
            {
                ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + HeaderHeight);
                ctrl.Refresh();
            }
        }
        #region -- Form Events --
        private void Form_Load(object sender, EventArgs e)
        {
            Apply();
        }
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            Form.Refresh();
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawStyle(e.Graphics);
        }
        private void Form_MouseLeave(object sender, EventArgs e)
        {
            btnCloseHovered = false;
            btnMaximizeHovered = false;
            btnMinimizeHovered = false;
            Form.Invalidate();
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // Меняет расположение в большом окне
            if (CanDragForm && e.Button == MouseButtons.Left)
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    float maxWidth = Form.Width;
                    float cursosOnMaxPosition = e.X;
                    float coeff = cursosOnMaxPosition / (maxWidth / 100f) / 100f;

                    // Change WindowState if is Maximized
                    Form.WindowState = FormWindowState.Normal;

                    int XFormOffset = (int)(Form.Width * coeff);

                    Form.Location = new Point(Cursor.Position.X - XFormOffset, Cursor.Position.Y - HeaderHeight / 2);
                    moveStartPosition = Form.Location;
                    clickPosition = Cursor.Position;
                }
                else
                {
                    // Moving
                    Size frmOffset = new Size(Point.Subtract(Cursor.Position, new Size(clickPosition)));
                    Form.Location = Point.Add(moveStartPosition, frmOffset);
                }
            }
            else
            {
                if (rectBtnClose.Contains(e.Location))
                {
                    if (btnCloseHovered == false)
                    {
                        btnCloseHovered = true;
                        Form.Invalidate();
                    }
                }
                else
                {
                    if (btnCloseHovered == true)
                    {
                        btnCloseHovered = false;
                        Form.Invalidate();
                    }
                }
                // Свернуть
                if (rectBtnMax.Contains(e.Location))
                {
                    if (btnMaximizeHovered == false)
                    {
                        btnMaximizeHovered = true;
                        Form.Invalidate();
                    }
                }
                else
                {
                    if (btnMaximizeHovered)
                    {
                        btnMaximizeHovered = false;
                        Form.Invalidate();
                    }
                }
                // Minimize Button Hovering
                if (rectBtnMin.Contains(e.Location))
                {
                    if (btnMinimizeHovered == false)
                    {
                        btnMinimizeHovered = true;


                        Form.Invalidate();
                    }
                }
                else
                {
                    if (btnMinimizeHovered)
                    {
                        btnMinimizeHovered = false;
                        Form.Invalidate();
                    }
                }
                // Icon Hovering
                if (rectIcon.Contains(e.Location))
                {
                    IconHovered = true;
                }
                else
                {
                    IconHovered = false;
                }
            }

            // On hover on border for resize
            if (AllowUserResize && IsResizing == false && Form.WindowState == FormWindowState.Normal)
            {
                if (rectBorder.Top + ResizeBorderSize >= e.Location.Y)
                {
                    // Левый верхний угол
                    if (e.Location.X <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.TopLeft;
                    }
                    // Правый верхний угол
                    else if (e.Location.X >= rectBorder.Width - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.TopRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeNS;
                        BorderHoverPosition = BorderHoverPositionEnum.Top;
                    }
                }
                else if (rectBorder.Bottom - ResizeBorderSize <= e.Location.Y)
                {
                    // Левый нижний угол
                    if (e.Location.X <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomLeft;
                    }
                    // Правый нижний угол
                    else if (e.Location.X >= rectBorder.Width - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeNS;
                        BorderHoverPosition = BorderHoverPositionEnum.Bottom;
                    }
                }
                else if (rectBorder.Left + ResizeBorderSize >= e.Location.X)
                {
                    // Левый верхний угол
                    if (e.Location.Y <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.TopLeft;
                    }
                    // Левый нижний угол
                    else if (e.Location.Y >= rectBorder.Height - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomLeft;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeWE;
                        BorderHoverPosition = BorderHoverPositionEnum.Left;
                    }
                }
                else if (rectBorder.Right - ResizeBorderSize <= e.Location.X)
                {
                    // Правый верхний угол
                    if (e.Location.Y <= ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNESW;
                        BorderHoverPosition = BorderHoverPositionEnum.TopRight;
                    }
                    // Правый нижний угол
                    else if (e.Location.Y >= rectBorder.Height - ResizeAngleBorderOffset)
                    {
                        Form.Cursor = Cursors.SizeNWSE;
                        BorderHoverPosition = BorderHoverPositionEnum.BottomRight;
                    }
                    else
                    {
                        Form.Cursor = Cursors.SizeWE;
                        BorderHoverPosition = BorderHoverPositionEnum.Right;
                    }
                }
                else if (Form.Cursor != Cursors.Default)
                {
                    Form.Cursor = Cursors.Default;
                    BorderHoverPosition = BorderHoverPositionEnum.None;
                }
            }

            // Resize
            else if (AllowUserResize && IsResizing && Form.WindowState == FormWindowState.Normal)
            {
                // Resize
                switch (BorderHoverPosition)
                {
                    // Стороны / Sides
                    case BorderHoverPositionEnum.Left:
                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.Top:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);
                        break;

                    case BorderHoverPositionEnum.Right:
                        Form.Width = Cursor.Position.X - Form.Left;
                        break;

                    case BorderHoverPositionEnum.Bottom:
                        Form.Height = Cursor.Position.Y - Form.Top;
                        break;


                    // Углы / Angles
                    case BorderHoverPositionEnum.TopLeft:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);

                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.TopRight:
                        Form.Location = new Point(Form.Location.X, Cursor.Position.Y);
                        Form.Height = Form.Height - (Form.Bottom - ResizeStartBottom);

                        Form.Width = Cursor.Position.X - Form.Left;
                        break;

                    case BorderHoverPositionEnum.BottomLeft:
                        Form.Height = Cursor.Position.Y - Form.Top;

                        Form.Location = new Point(Cursor.Position.X, Form.Location.Y);
                        Form.Width = Form.Width - (Form.Right - ResizeStartRight);
                        break;

                    case BorderHoverPositionEnum.BottomRight:
                        Form.Height = Cursor.Position.Y - Form.Top;
                        Form.Width = Cursor.Position.X - Form.Left;
                        break;
                }
            }
        }
        private void Form_DoubleClick(object sender, EventArgs e)
        {
            if (FormStyle == fStyle.none) return;

            if (BorderHoverPosition != BorderHoverPositionEnum.None)
                return;

            if (MousePressed && LastClickedMouseButton == MouseButtons.Left && rectHeader.Contains(Form.PointToClient(Cursor.Position)))
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    Form.WindowState = FormWindowState.Normal;
                }
                else if (Form.WindowState == FormWindowState.Normal)
                {
                    Form.WindowState = FormWindowState.Maximized;
                }
            }
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (Form.IsHandleCreated == false) return;

            MousePressed = false;
            CanDragForm = false;
            IsResizing = false;

            if (AllowUserResize && BorderHoverPosition != BorderHoverPositionEnum.None)
                return;

            // Если окно поднять вверх -> разворачиваем на весь экран
            if (Cursor.Position.Y == Screen.FromHandle(Form.Handle).WorkingArea.Y
                && Form.WindowState == FormWindowState.Normal)
            {
                Form.WindowState = FormWindowState.Maximized;
                FormNeedReposition = true;
            }

            // Огранечение по Y
            if (Form.Location.Y < Screen.FromHandle(Form.Handle).WorkingArea.Y)
            {
                Form.Location = new Point(Form.Location.X, Screen.FromHandle(Form.Handle).WorkingArea.Y);
            }

            // Нажатия на кнопки управления окном
            if (e.Button == MouseButtons.Left && Form.ControlBox == true)
            {
                // Close Button Click
                if (rectBtnClose.Contains(e.Location))
                    Form.Close();

                // Max Button Click
                if (rectBtnMax.Contains(e.Location) && Form.MaximizeBox == true)
                {
                    if (Form.WindowState == FormWindowState.Maximized)
                    {
                        Form.WindowState = FormWindowState.Normal;

                        if (FormNeedReposition)
                        {
                            FormNeedReposition = false;
                            Form.Location = moveStartPosition;
                        }
                    }
                    else if (Form.WindowState == FormWindowState.Normal)
                    {
                        Form.WindowState = FormWindowState.Maximized;
                    }
                }

                // Min Button Click
                if (rectBtnMin.Contains(e.Location) && Form.MinimizeBox == true)
                    Form.WindowState = FormWindowState.Minimized;
            }

            // Контекстное меню при нажатии на иконку
            if (e.Button == MouseButtons.Right && IconHovered)
            {
                if (ContextMenuForm != null)
                {
                    ContextMenuForm.Show(Cursor.Position);
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (rectBtnClose.Contains(e.Location))
                    Form.Close();
            }
        }
        private void Form_Click(object sender, EventArgs e)
        {
            Form.Focus();
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {

            MousePressed = true;

            if (AllowUserResize && BorderHoverPosition != BorderHoverPositionEnum.None)
            {
                if (e.Button == MouseButtons.Left)
                {
                    IsResizing = true;
                    ResizeStartRight = Form.Right;
                    ResizeStartBottom = Form.Bottom;
                    return;
                }
            }

            if (e.Location.Y <= HeaderHeight
              && !rectBtnClose.Contains(e.Location)
                && !rectBtnMax.Contains(e.Location)
                && !rectBtnMin.Contains(e.Location))
            {
                CanDragForm = true;
                clickPosition = Cursor.Position;
                moveStartPosition = Form.Location;
            }
            LastClickedMouseButton = e.Button;
        }

        #endregion
        private void DrawStyle(Graphics graph)
        {
            graph.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rectHeader = new Rectangle(0, 0, Form.Width - 1, HeaderHeight);
            Rectangle rectBorder = new Rectangle(0, 0, Form.Width - 1, Form.Height - 1);

            Rectangle rectTitleText = new Rectangle(rectHeader.X + 25, rectHeader.Y, rectHeader.Width, rectHeader.Height);
            Rectangle rectIcon = new Rectangle(
                rectHeader.Height / 2 - IconSize.Width / 2,
                rectHeader.Height / 2 - IconSize.Height / 2,
                IconSize.Width, IconSize.Height
                );

            rectBtnClose = new Rectangle(rectHeader.Width - rectHeader.Height, rectHeader.Y, rectHeader.Height, rectHeader.Height);
            Rectangle rectCrosshair = new Rectangle(
                rectBtnClose.X + rectBtnClose.Width / 2 - 5,
                rectBtnClose.Height / 2 - 5,
                10, 10);

            // Maximize Button Structure
            rectBtnMax = new Rectangle(rectBtnClose.X - ControlBoxButtonsWidth, rectHeader.Y, ControlBoxButtonsWidth, rectHeader.Height);
            // Maximize Icon Structure
            Rectangle rectMaxButtonIcon = new Rectangle(
                rectBtnMax.X + rectBtnMax.Width / 2 - ControlBoxIconSize.Width / 2,
                rectBtnMax.Height / 2 - ControlBoxIconSize.Height / 2,
                ControlBoxIconSize.Width, ControlBoxIconSize.Height);
            // Second Maximize Icon Structure [in Maximized state]
            Rectangle rectMaxButtonIconSecond = rectMaxButtonIcon;

            if (Form.WindowState == FormWindowState.Maximized)
            {
                //Inflate - изменяет размер и одновременно положение (В данном случае -1 по ширине и +2 по X, -1 по высоте и +2 по Y)

                rectMaxButtonIconSecond.Inflate(-1, -1);
                rectMaxButtonIconSecond.Offset(1, -1);

                rectMaxButtonIcon.Inflate(-1, -1);
                rectMaxButtonIcon.Offset(-1, 1);
            }
            // Minimize Button Structure
            rectBtnMin = new Rectangle(rectBtnMax.X - ControlBoxButtonsWidth, rectHeader.Y, ControlBoxButtonsWidth, rectHeader.Height);

            Point point1BtnMin = new Point(
                    rectBtnMin.X + rectBtnMin.Width / 2 - ControlBoxIconSize.Width / 2,
                    rectBtnMin.Height / 2 + ControlBoxIconSize.Height / 2
                    );
            Point point2BtnMin = new Point(
                rectBtnMin.X + rectBtnMin.Width / 2 + ControlBoxIconSize.Width / 2,
                rectBtnMin.Height / 2 + ControlBoxIconSize.Height / 2
                );

            //Шапка
            graph.DrawRectangle(new Pen(HeaderColor), rectHeader);
            graph.FillRectangle(new SolidBrush(HeaderColor), rectHeader);

            Brush headerBrush = new SolidBrush(HeaderColor);


            //Текст заголовка
            graph.DrawString(Form.Text, Font, new SolidBrush(Color.White), rectTitleText, SF);

            //Иконка
            graph.DrawImage(Form.Icon.ToBitmap(), rectIcon);

            //Кнопка Close
            graph.DrawRectangle(new Pen(btnCloseHovered ? Color.Red : HeaderColor), rectBtnClose);
            graph.FillRectangle(new SolidBrush(btnCloseHovered ? Color.Red : HeaderColor), rectBtnClose);
            DrawCrosshair(graph, rectCrosshair, WhitePen);

            // Кнопка [ _ ]            
            graph.DrawRectangle(new Pen(btnMinimizeHovered && Form.MinimizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMin);
            graph.FillRectangle(new SolidBrush(btnMinimizeHovered && Form.MinimizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMin);

            // Draw icon           
            graph.DrawLine(penBtnMinimize, point1BtnMin, point2BtnMin);

            // МАКС
            graph.DrawRectangle(new Pen(btnMaximizeHovered && Form.MaximizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMax);
            graph.FillRectangle(new SolidBrush(btnMaximizeHovered && Form.MaximizeBox ? Color.FromArgb(100, Color.Gray) : Color.Transparent), rectBtnMax);
            //if (EnableControlBoxIconsLight)
            //{
            //    if (Form.WindowState == FormWindowState.Maximized)
            //    {
            //        Drawer.DrawBlurredRectangle(graph, Color.White, rectMaxButtonIconSecond, 8, 20);
            //    }
            //    Drawer.DrawBlurredRectangle(graph, Color.White, rectMaxButtonIcon, 8, 20);
            //}

            // Draw icon
            if (Form.WindowState == FormWindowState.Maximized)
            {
                graph.DrawRectangle(penBtnMaximize, rectMaxButtonIconSecond);
                //graph.FillRectangle(new SolidBrush(HeaderColor), rectMaxButtonIcon);
                graph.FillRectangle(headerBrush, rectMaxButtonIcon);
            }
            graph.DrawRectangle(penBtnMaximize, rectMaxButtonIcon);


            //Обводка
            graph.DrawRectangle(new Pen(Color.Black), rectBorder);
        }
        private void DrawCrosshair(Graphics graph, Rectangle rect, Pen pen)
        {
            graph.DrawLine(pen, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            graph.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X, rect.Y + rect.Height);
        }
        public static void SetDoubleBuffred(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo pDoubleBuffered =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}
