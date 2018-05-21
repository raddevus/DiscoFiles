using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DaylightComputers
{
    public class WorkEventArg
    {
        private string fileName;
        private string eventTypeString;
        private ListViewItem currentItem;

        public WorkEventArg(string fileName, string eventTypeString, ListViewItem currentItem)
        {
            this.fileName = fileName;
            this.eventTypeString = eventTypeString;
            if (currentItem != null)
            {
                this.currentItem = currentItem;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public string EventTypeString
        {
            get
            {
                return eventTypeString;
            }
        }

        public ListViewItem CurrentItem
        {
            get
            {
                if (currentItem != null)
                {
                    return currentItem;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
