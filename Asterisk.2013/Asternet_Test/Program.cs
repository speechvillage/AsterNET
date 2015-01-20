using Asterisk.NET.FastAGI;
using Asterisk.NET.FastAGI.Command;
using Asterisk.NET.FastAGI.MappingStrategies;
using Asterisk.NET.SyncAGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asternet_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AsteriskSyncAGI syncAgi = new AsteriskSyncAGI();
            AGIRequest request = new AGIRequest(new List<string>());
            request.Script = "test";
            syncAgi.MappingStrategy = new GeneralMappingStrategy(new List<ScriptMapping>()
            {
                new ScriptMapping() {
                    ScriptClass = "Asterisk.NET.Test.CustomIVR",
                    ScriptName = "test"
                }
            });
            syncAgi.Request = request;
            syncAgi.Start();  
        }
    }
}
