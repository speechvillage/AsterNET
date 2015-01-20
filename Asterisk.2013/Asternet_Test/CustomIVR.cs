using System;
using Asterisk.NET.FastAGI;

namespace Asterisk.NET.Test
{
	public class CustomIVR : AGIScript
	{
		private string escapeKeys = "0123456789*#";		

		public override void Service(AGIRequest request, AGIChannel channel)
		{
            try
            {
                StreamFile("testTTS", escapeKeys);
                StreamFile("testTTS", escapeKeys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
		}
	}
}
