using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPLTestMonitor
{
    public partial class AddState : Form
    {
        public AddState()
        {
            InitializeComponent();
        }

        private void AddState_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void AddState_but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddState_but_OK_Click(object sender, EventArgs e)
        {
            if (this.AddState_txt_stateName.Text != "")
            {
                AddState.newState = this.AddState_txt_stateName.Text;
            }
            else
            {
                AddState.newState = null;
            }
            this.Close();
        }

        public static string newState
        {
            get;
            set;
        }

    }
}
