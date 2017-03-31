using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rtaNetworking.Streaming;

namespace rtaVideoStreamer
{
    public partial class Program
    {   
        public static int portConnect = 11000; // for sending byte stream
        public static void Main(string[] args)
        {
            ImageStreamingServer _Server;
            _Server = new ImageStreamingServer();
            _Server.Start(8090); // videoserver 
            Client.start(portConnect); // connect to socket
            
        }
        
    }
}
