using System;
using System.Collections.Generic;
using System.Text;

namespace DaylightComputers
{
    public sealed class WorkEvents : List<WorkEventArg>
    {
        static object lockObj = new object();
        static object syncRoot = new object();
        private static volatile WorkEvents instance;

        private WorkEvents()
        {

        }

        public static WorkEvents Instance
        {
            get
            {
                // Double-checked lock approach (singleton pattern)
                // Creates a thread safe singleton as described at:
                // http://msdn.microsoft.com/en-us/library/ms998558.aspx
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new WorkEvents();
                        }
                    }
                }

                return instance;
            }
        }

        public void Add(WorkEventArg dwo)
        {
            lock (lockObj)
            {
                base.Add(dwo);
            }
        }

        public void Remove(WorkEventArg dwo)
        {
            lock (lockObj)
            {
                base.Remove(dwo);
            }
        }

        public WorkEventArg GetEventObject()
        {
            if (this.Count > 0)
            {
                if (this[0] != null)
                {
                    WorkEventArg dwoTemp = this[0];
                    Remove(this[0]);
                    return dwoTemp;

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
