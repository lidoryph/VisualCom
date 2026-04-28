using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Online.Extra
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen(string Message)
        {
            InitializeComponent();
            MessageLabel.Text = Message;
        }
    }
}
