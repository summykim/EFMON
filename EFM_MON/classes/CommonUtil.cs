using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EFM_MON.classes
{
   static class CommonUtil
{
        public static String getLocalIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Console.WriteLine("No Network Available");
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress ippaddress =
                host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            Console.WriteLine(ippaddress);
            return ippaddress.ToString();

        }
    }
}
