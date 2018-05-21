using System;
using System.Collections.Generic;
using System.Text;

namespace DaylightComputers
{
    class PathFilter
    {
        private string filter;
        private int id;
        private static int counter;
        public PathFilter(string filter)
        {
            this.filter = filter;
            this.id = counter++;
        }
        public string Filter
        {
            get
            {
                return filter;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public override string ToString()
        {
            return filter;
        }
    }
}
