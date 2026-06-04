using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisualCom;

namespace VisualCom.Forms.Online
{
    public partial class SockTest : Form
    {

        private bool locked;
        private bool cclass;

        public SockTest()
        {
            InitializeComponent();

            var connection = Configuration.Connection;
            if (connection != null)
            {
                connection.OnImageUnlocked += Connection_OnImageUnlocked;
                connection.OnImageLocked += Connection_OnImageLocked;
                connection.OnAnnotationCreated += Connection_OnAnnotationCreated;
                connection.OnClassCreated += Connection_OnClassCreated;
                connection.OnClassDeleted += Connection_OnClassDeleted;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            var connection = Configuration.Connection;
            if (connection != null)
            {
                connection.OnImageUnlocked -= Connection_OnImageUnlocked;
                connection.OnImageLocked -= Connection_OnImageLocked;
                connection.OnAnnotationCreated -= Connection_OnAnnotationCreated;
                connection.OnClassCreated -= Connection_OnClassCreated;
                connection.OnClassDeleted -= Connection_OnClassDeleted;
            }

            base.OnFormClosed(e);
        }

        private void Connection_OnImageUnlocked(object sender, VisComClient.ImageUnlockedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Connection_OnImageUnlocked(sender, e)));
                return;
            }

            MessageBox.Show($"{e.User} desbloqueó {e.Image}");
        }

        private void Connection_OnImageLocked(object sender, VisComClient.ImageLockedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Connection_OnImageLocked(sender, e)));
                return;
            }

            MessageBox.Show($"{e.User} bloqueó {e.Image}");
        }

        private void Connection_OnAnnotationCreated(object sender, VisComClient.AnnotationCreatedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Connection_OnAnnotationCreated(sender, e)));
                return;
            }
        }

        private void Connection_OnClassCreated(object sender, VisComClient.ClassCreatedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Connection_OnClassCreated(sender, e)));
                return;
            }
        }

        private void Connection_OnClassDeleted(object sender, VisComClient.ClassDeletedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Connection_OnClassDeleted(sender, e)));
                return;
            }
        }

        private void cclass_but_Click(object sender, EventArgs e)
        { }

        private void ann_bu_Click(object sender, EventArgs e)
        {
            ann_bu.Enabled = false;
        }
        private void lock_but_Click(object sender, EventArgs e)
        {
            Configuration.Connection.LockImage("testsock", "testlock.png");
            lock_but.Enabled = false;
            unlock_but.Enabled = true;
            locked = true;
        }
        private void unlock_but_Click(object sender, EventArgs e)
        {
            Configuration.Connection.UnlockImage("testsock", "testlock.png");
            lock_but.Enabled = true;
            unlock_but.Enabled = false;
            locked = false;
        }
    }
}
