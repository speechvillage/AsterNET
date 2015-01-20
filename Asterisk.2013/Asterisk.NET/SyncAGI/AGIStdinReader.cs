using Asterisk.NET.FastAGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterisk.NET.SyncAGI
{
    public class AGIStdinReader : AGIReader
    {
#if LOGGER
        private Logger logger = Logger.Instance();
#endif
        public AGIStdinReader()
            : base(null)
        {
        }

        protected override string DoRead()
        {
            return Console.ReadLine();
        }

        protected override AGIRequest FillRequest(List<string> lines)
        {
            return new AGIRequest(lines);
        }
    }
}
