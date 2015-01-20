using Asterisk.NET.FastAGI;
using Asterisk.NET.FastAGI.MappingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterisk.NET.SyncAGI
{
    public class AsteriskSyncAGI
    {
        #region Flags
        /// <summary>
        /// If set to true, causes the AGIChannel to throw an exception when a status code of 511 (Channel Dead) is returned.
        /// This is set to false by default to maintain backwards compatibility
        /// </summary>
        public bool SC511_CAUSES_EXCEPTION = false;

        /// <summary>
        /// If set to true, causes the AGIChannel to throw an exception when return status is 0 and reply is HANGUP.
        /// This is set to false by default to maintain backwards compatibility
        /// </summary>
        public bool SCHANGUP_CAUSES_EXCEPTION = false;
        #endregion

        public IMappingStrategy MappingStrategy { internal get; set; }
        public AGIRequest Request { get; set; }

        #region Constructor - AsteriskSyncAGI()
        /// <summary>
        /// Creates a new AsteriskFastAGI.
        /// </summary>
        public AsteriskSyncAGI()
        {
            this.MappingStrategy = new ResourceMappingStrategy();            
        }

        /// <summary>
        /// Creates a new AsteriskFastAGI.
        /// </summary>
        public AsteriskSyncAGI(string mappingStrategy)
        {
            this.MappingStrategy = new ResourceMappingStrategy(mappingStrategy);
        }
        #endregion
        public void Start()
        {
            this.MappingStrategy.Load();
            AGIConnectionHandler connectionHandler = new AGIConnectionHandler(null, this.MappingStrategy, this.SC511_CAUSES_EXCEPTION, this.SCHANGUP_CAUSES_EXCEPTION, false);
            connectionHandler.Request = Request;
            connectionHandler.Run();
        }
    }
}