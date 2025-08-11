using System.Runtime.InteropServices;

namespace ManagerGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.Text = "Windows App Manager";

            this.Load += Form1_Load;
            this.Resize += Form1_Resize;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 30);

            var titleBar = new Panel
            {
                Height = 30,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(55, 55, 55)
            };
            this.Controls.Add(titleBar);

            // Make draggable
            cuiLabel1.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        // Win32 stuff
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        private const int WM_NCHITTEST = 0x84;
        private const int RESIZE_HANDLE_SIZE = 10; // pixels

        private Size _originalFormSize;
        private Dictionary<Control, Rectangle> _originalControlBounds = new();
        private Dictionary<Control, float> _originalFontSizes = new();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                var cursor = PointToClient(Cursor.Position);
                if (cursor.X <= RESIZE_HANDLE_SIZE)
                {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)HTLEFT;
                }
                else if (cursor.X >= ClientSize.Width - RESIZE_HANDLE_SIZE)
                {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else if (cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTRIGHT;
                }
                else if (cursor.Y <= RESIZE_HANDLE_SIZE)
                {
                    m.Result = (IntPtr)HTTOP;
                }
                else if (cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                }
            }
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Dictionary<Control, Rectangle> originalRects = new();
        private int originalWidth;
        private int originalHeight;
        private void Form1_Load(object sender, EventArgs e)
        {
            _originalFormSize = this.Size;

            SaveControlLayout(this);
        }

        private void SaveControlLayout(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                _originalControlBounds[ctrl] = ctrl.Bounds;
                _originalFontSizes[ctrl] = ctrl.Font.Size;

                if (ctrl.HasChildren)
                    SaveControlLayout(ctrl);
            }
        }

        private void ResizeControls(Control parent, float scaleX, float scaleY)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (_originalControlBounds.ContainsKey(ctrl))
                {
                    Rectangle originalBounds = _originalControlBounds[ctrl];

                    int newX = (int)(originalBounds.X * scaleX);
                    int newY = (int)(originalBounds.Y * scaleY);
                    int newWidth = (int)(originalBounds.Width * scaleX);
                    int newHeight = (int)(originalBounds.Height * scaleY);

                    ctrl.SetBounds(newX, newY, newWidth, newHeight);

                    if (_originalFontSizes.ContainsKey(ctrl))
                    {
                        float originalSize = _originalFontSizes[ctrl];
                        float newSize = Math.Min(scaleX, scaleY) * originalSize;
                        ctrl.Font = new Font(ctrl.Font.FontFamily, newSize, ctrl.Font.Style);
                    }
                }

                if (ctrl.HasChildren)
                    ResizeControls(ctrl, scaleX, scaleY);
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            float scaleX = (float)this.Width / _originalFormSize.Width;
            float scaleY = (float)this.Height / _originalFormSize.Height;

            ResizeControls(this, scaleX, scaleY);
        }

        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


