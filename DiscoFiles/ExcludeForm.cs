using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DaylightComputers
{
    public partial class ExcludeForm : Form
    {
        private PathString excludePath;
        private bool isEntryError;

        public ExcludeForm(ref PathString excludePath)
        {
            InitializeComponent();
            this.excludePath = excludePath;
        }

        private void ExcludeForm_Load(object sender, EventArgs e)
        {
            excludePathTextBox.Text = this.excludePath.path;
        }

        private void exludePathButton_Click(object sender, EventArgs e)
        {
            excludePathFolderBrowserDialog.SelectedPath = excludePathTextBox.Text;
            DialogResult dr = excludePathFolderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                excludePathTextBox.Text =  excludePathFolderBrowserDialog.SelectedPath;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (excludePathTextBox.Text == string.Empty)
            {
                MessageBox.Show("The path must have at least one character in it.");
                excludePathTextBox.Focus();
                isEntryError = true;
            }
            this.excludePath.path = excludePathTextBox.Text;
            this.Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (isEntryError)
            {
                e.Cancel = true;
                isEntryError = false;
            }
            else
            {
                base.OnClosing(e);
            }
        }

    }
}
