using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace libDCS_Mod_app
{
    public class ServerCheck
    {
        public bool GetServerResponse()
        {
            string ip = "144.6.240.188";
            int port = 10308;

            bool isResponsive = false;

            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    s.Connect(ip, port);

                    isResponsive = true;
                }
                catch (SocketException)
                {
                    isResponsive = false;
                }
            }

            return isResponsive;
        }
    }
}
