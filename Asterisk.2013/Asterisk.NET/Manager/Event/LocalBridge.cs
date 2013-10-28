using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterisk.NET.Manager.Event
{
    public class LocalBridgeEvent : ManagerEvent
    {
        public string Channel1 { get; set; }
        public string Channel2 { get; set; }
        public string UniqueId1 { get; set; }
        public string UniqueId2 { get; set; }
        public string Context { get; set; }
        public string Exten { get; set; }
        public string LocalOptimization { get; set; }


        public LocalBridgeEvent(ManagerConnection source) : base(source)
        {
            
        }

    }

}
