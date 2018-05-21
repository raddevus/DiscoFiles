using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DaylightComputers
{
    public enum EventType
    {
        changed,
        renamed,
        created,
        deleted
    }

    public partial class DiscoFilesForm : Form
    {

        private ListViewColumnSorter lvwColumnSorter;


        List<PathFilter> pathFilter = new List<PathFilter>();
        private Object lockObj = new Object();

//        static DoWorkEventCollection currentDoWorkObjects = new DoWorkEventCollection();
        
        public DiscoFilesForm()
        {
            InitializeComponent();
            InitializeListView();
            this.lvwColumnSorter = new ListViewColumnSorter();
            this.infoListView.ListViewItemSorter = this.lvwColumnSorter;
            //excludePathsComboBox.DataBindings.Add("Text", pathFilter,"Filter",true,DataSourceUpdateMode.OnValidation);
        }

        private void InitializeListView()
        {
            this.infoListView.Columns.Add("File Name");
            this.infoListView.Columns.Add("Last Accessed");
            this.infoListView.Columns.Add("Access Count");
            this.infoListView.Columns.Add("Access Type");
            this.infoListView.View = View.Details;
            this.infoListView.Columns[0].Width = 300;
            this.infoListView.Columns[1].Width = 110;
            this.infoListView.Columns[2].Width = 95;
            this.infoListView.Columns[3].Width = 95;
        }


        private void HandleButtonEnable()
        {
            this.startSpyButton.Enabled = !this.startSpyButton.Enabled;
            this.stopSpyButton.Enabled = !this.stopSpyButton.Enabled;
        }

        private void startSpyButton_Click(object sender, EventArgs e)
        {
            fileSystemWatcher.Path = pathMonitorTextBox.Text; // "c:\\";
            fileSystemWatcher.EnableRaisingEvents = true;
            HandleButtonEnable();
        }
        
        private bool checkFilter(string inPath)
        {
            bool passed = true;
            foreach (PathFilter localPath in pathFilter)
            {
                if (inPath.Contains(localPath.Filter))
                {
                    passed = false;
                    break;
                }
            }
            return passed;
        }

        public void HandleFileSystemWatcherUpdate()
        {
            WorkEventArg doWorkEventObject = WorkEvents.Instance.GetEventObject();
            if (doWorkEventObject != null)
            {
                string fileName = doWorkEventObject.FileName;
                if (checkFilter(Path.GetDirectoryName(fileName)))
                {
                    string eventTypeString = doWorkEventObject.EventTypeString;

                    ListViewItem currItem = null;
                    lock (infoListView)
                    {
                        try
                        {
                            foreach (ListViewItem lvi in infoListView.Items)
                            {
                                if (lvi.Text == fileName && lvi.Tag.ToString() == eventTypeString)
                                {
                                    currItem = lvi;
                                    continue;
                                }

                            }
                        }
                        catch
                        {
                        }
                    }

                    WorkEventArg dwo = new WorkEventArg(fileName, eventTypeString, currItem);

                    // DoWorkEventArgs dw = new DoWorkEventArgs(dwo);

                    if (!changeEventBackgroundWorker.IsBusy)
                    {
                        changeEventBackgroundWorker.RunWorkerAsync(dwo);
                    }
                    else
                    {
                        WorkEvents.Instance.Add(dwo);
                    }
                }
            }
        }

        private void HandleFileSystemWatcherUpdate(EventType eventType, System.IO.FileSystemEventArgs e)
        {
            try {
                string fileName = fileSystemWatcher.Path + e.Name;
                if (checkFilter(Path.GetDirectoryName(fileName)))
                {


                    string eventTypeString = string.Empty;
                    switch (eventType)
                    {
                        case EventType.changed:
                            {
                                if (!fileChangedCheckBox.Checked)
                                {
                                    // return immediately, if the user doesn't want to  listen for this event
                                    return;
                                }
                                eventTypeString = "changed";

                                break;
                            }
                        case EventType.created:
                            {
                                if (!fileCreatedCheckBox.Checked)
                                {
                                    // return immediately, if the user doesn't want to  listen for this event
                                    return;
                                }

                                eventTypeString = "created";
                                break;
                            }
                        case EventType.deleted:
                            {
                                if (!fileDeletedCheckBox.Checked)
                                {
                                    // return immediately, if the user doesn't want to  listen for this event
                                    return;
                                }
                                eventTypeString = "deleted";
                                break;
                            }
                        case EventType.renamed:
                            {
                                if (!fileRenamedCheckBox.Checked)
                                {
                                    // return immediately, if the user doesn't want to  listen for this event
                                    return;
                                }

                                eventTypeString = "renamed";
                                break;
                            }
                    }


                    ListViewItem currItem = null;
                    lock (infoListView)
                    {
                        try
                        {
                            foreach (ListViewItem lvi in infoListView.Items)
                            {
                                if (lvi.Text == fileName && lvi.Tag.ToString() == eventTypeString)
                                {
                                    currItem = lvi;
                                    continue;
                                }

                            }
                        }
                        catch
                        {
                        }
                    }

                    WorkEventArg dwo = new WorkEventArg(fileName, eventTypeString, currItem);

                    // DoWorkEventArgs dw = new DoWorkEventArgs(dwo);

                    if (!changeEventBackgroundWorker.IsBusy)
                    {
                        changeEventBackgroundWorker.RunWorkerAsync(dwo);
                    }
                    else
                    {
                        WorkEvents.Instance.Add(dwo);
                    }
                }
            }
            catch (Exception ex)
            {
                String outMessage = string.Format("{0} - {1} : Exception {2} : {3}{4}", DateTime.Now, ex.Message, ex.GetType(), e.Name, Environment.NewLine);
                File.AppendAllText("discoFilesError.log", outMessage);
                //MessageBox.Show(this, outMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeEventBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (lockObj)
            {
                WorkEventArg dwo = (WorkEventArg)e.Argument;

                if (dwo.CurrentItem != null)
                {
                    dwo.CurrentItem.Text = dwo.FileName;
                    dwo.CurrentItem.SubItems[1].Text = DateTime.Now.ToLongTimeString();
                    Int64 currCount = Convert.ToInt64(dwo.CurrentItem.SubItems[2].Text.ToString()) + 1;
                    dwo.CurrentItem.SubItems[2].Text = currCount.ToString();
                }
                else
                {
                    ListViewItem mainItem = new ListViewItem(dwo.FileName);
                    mainItem.Tag = dwo.EventTypeString;
                    mainItem.SubItems.Add(DateTime.Now.ToLongTimeString());
                    //first time add a 1 for the count
                    mainItem.SubItems.Add("1");
                    mainItem.SubItems.Add(dwo.EventTypeString);
                    infoListView.Items.Add(mainItem);
                }
            }
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            HandleFileSystemWatcherUpdate(EventType.deleted, e);
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            HandleFileSystemWatcherUpdate(EventType.renamed, e);
        }

        private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            HandleFileSystemWatcherUpdate(EventType.changed, e);
        }

        private void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            HandleFileSystemWatcherUpdate(EventType.created, e);
        }

        private void StopFileWatcher()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            HandleButtonEnable();
        }

        private void stopSpyButton_Click(object sender, EventArgs e)
        {
            StopFileWatcher();
        }

        private void addExclusionButton_Click(object sender, EventArgs e)
        {
            string excludePath = string.Empty;
            try
            {
                excludePath = Path.GetDirectoryName(infoListView.SelectedItems[0].Text);
            }
            catch
            {
            }
            PathString inPath = new PathString(excludePath);
            ExcludeForm exForm = new ExcludeForm(ref inPath);
            DialogResult dr = exForm.ShowDialog(this);
            if (dr == DialogResult.OK && inPath.path != string.Empty)
            {
                MessageBox.Show(inPath.path);
                PathFilter pf = new PathFilter(inPath.path);
                pathFilter.Add(pf);

                excludePathsComboBox.DataSource = null;
                excludePathsComboBox.DataSource = pathFilter;
                excludePathsComboBox.ValueMember = "Id";
                excludePathsComboBox.DisplayMember = "Filter";

            }
            
        }

        private void infoListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(
                    Path.GetDirectoryName(infoListView.SelectedItems[0].SubItems[0].Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message, ex.GetType().ToString());
            }
        }

        private void infoListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (this.lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    this.lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    this.lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                this.lvwColumnSorter.SortColumn = e.Column;
                this.lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.infoListView.Sort();
        }

        private void pathMonitorButton_Click(object sender, EventArgs e)
        {
            if (pathMonitorTextBox.Text != string.Empty)
            {
                discoPathFolderBrowser.SelectedPath = pathMonitorTextBox.Text;
            }
            DialogResult dr = discoPathFolderBrowser.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pathMonitorTextBox.Text = discoPathFolderBrowser.SelectedPath;
            }
            else
            {

            }
        }

        private void excludePathsComboBox_DropDown(object sender, EventArgs e)
        {
            excludePathsComboBox.DropDownWidth = 550;
        }

        private void DiscoFilesForm_Load(object sender, EventArgs e)
        {
            SystemWideHotKey.RegisterHotKey(this, Keys.Shift | Keys.F12 | Keys.Control);
            this.Text = String.Format("DiscoFiles - v{0}", Application.ProductVersion);
        }

        private void DiscoFilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemWideHotKey.UnregisterHotKey(this);
        }

        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == SystemWideHotKey.WM_HOTKEY)
            {
                StopFileWatcher();
            }

        }

        private void ExtraWorkTimer_Tick(object sender, EventArgs e)
        {
            ExtraWorkTimer.Stop();
            HandleFileSystemWatcherUpdate();
            ExtraWorkTimer.Start();
        }
    }

}
