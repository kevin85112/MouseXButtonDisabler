using System;
using System.Windows.Forms;

namespace MouseXButtonDisabler
{
    public partial class Form_main : Form
    {
        public bool IsActive { get; private set; } = false;

        private ContextMenu contextMenu_main;
        private MenuItem menuItem_open;
        private MenuItem menuItem_close;
        private MenuItem menuItem_active;
        private void InitializeMenu()
        {
            menuItem_open = new MenuItem
            {
                Index = 0,
                Text = "O&pen"
            };
            menuItem_open.Click += (object sender, EventArgs e) =>
            {
                notifyIcon_main_MouseDoubleClick(sender, null);
            };
            menuItem_active = new MenuItem
            {
                Index = 1,
                Text = "A&ctive"
            };
            menuItem_active.Click += (object sender, EventArgs e) =>
            {
                button_Active_Click(sender, e);
            };
            menuItem_close = new MenuItem
            {
                Index = 2,
                Text = "E&xit"
            };
            menuItem_close.Click += (object sender, EventArgs e) =>
            {
                Close();
            };
            contextMenu_main = new ContextMenu();
            contextMenu_main.MenuItems.Add(menuItem_open);
            contextMenu_main.MenuItems.Add(menuItem_active);
            contextMenu_main.MenuItems.Add(menuItem_close);
        }

        public Form_main()
        {
            InitializeComponent();
            InitializeMenu();
            notifyIcon_main.ContextMenu = contextMenu_main;
        }

        private void button_Active_Click(object sender, EventArgs e)
        {
            const string activeText = " - Active";

            bool isActive = !IsActive;
            if (isActive)
            {
                if (!WindowsKeyboard.HookMouse())
                {
                    MessageBox.Show("Failed to hook mouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Active.Text = "Stop";
                menuItem_active.Text = "S&top";
                notifyIcon_main.Text += activeText;
            }
            else
            {
                if (!WindowsKeyboard.UnhookMouse())
                {
                    MessageBox.Show("Failed to unhook mouse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Active.Text = "Active";
                menuItem_active.Text = "A&ctive";
                notifyIcon_main.Text = notifyIcon_main.Text.Substring(0, notifyIcon_main.Text.Length - activeText.Length);
            }
            IsActive = isActive;
        }

        private void notifyIcon_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form_main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon_main.Visible = true;
                Hide();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon_main.Visible = false;
            }
        }
    }
}
