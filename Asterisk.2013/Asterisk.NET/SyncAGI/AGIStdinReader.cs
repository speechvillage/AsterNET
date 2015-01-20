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

        public override AGIRequest ReadRequest()
        {
            string line;
            List<string> lines = new List<string>();
            try
            {
#if LOGGER
                logger.Info("AGIStdinReader.ReadRequest():");
#endif
                while ((line = Console.ReadLine()) != null)
                {
                    if (line.Length == 0)
                        break;
                    lines.Add(line);
#if LOGGER
                    logger.Info(line);
#endif
                }
            }
            catch (Exception ex)
            {
                throw new AGINetworkException("Unable to read request from Asterisk: " + ex.Message, ex);
            }

            AGIRequest request = new AGIRequest(lines);
            return request;
        }

        public override AGIReply ReadReply()
        {
            string line;
            string badSyntax = ((int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX).ToString();

            List<string> lines = new List<string>();
            try
            {
                line = Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new AGINetworkException("Unable to read reply from Asterisk: " + ex.Message, ex);
            }
            if (line == null)
                throw new AGIHangupException();

            lines.Add(line);
            // read synopsis and usage if statuscode is 520
            if (line.StartsWith(badSyntax))
                try
                {
                    while ((line = Console.ReadLine()) != null)
                    {
                        lines.Add(line);
                        if (line.StartsWith(badSyntax))
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new AGINetworkException("Unable to read reply from Asterisk: " + ex.Message, ex);
                }
            return new AGIReply(lines);
        }
    }
}
