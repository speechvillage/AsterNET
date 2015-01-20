using Asterisk.NET.FastAGI;
using System;
using System.IO;

namespace Asterisk.NET.SyncAGI
{
    /// <summary>
    /// Default implementation of the AGIStdoWriter interface.
    /// </summary>
    public class AGIStdoWriter : AGIWriter
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AGIStdoWriter()
            : base(null)
        {
        }

        public override void SendCommand(Asterisk.NET.FastAGI.Command.AGICommand command)
        {
            string buffer = command.BuildCommand();
            try
            {
                Console.WriteLine(buffer);
            }
            catch (Exception e)
            {
                throw new AGINetworkException("Unable to send command to Asterisk: " + e.Message, e);
            }
        }
    }
}
