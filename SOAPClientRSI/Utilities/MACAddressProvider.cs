using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SOAPClientRSI.Utilities
{
    public static class MACAddressProvider
    {
        public static string GetMACAddress()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface iface in interfaces)
            {
                if (iface.OperationalStatus != OperationalStatus.Up || iface.NetworkInterfaceType == NetworkInterfaceType.Loopback || !iface.GetIPProperties().GetIPv4Properties().IsDhcpEnabled)
                {
                    continue;
                }

                PhysicalAddress address = iface.GetPhysicalAddress();

                string macAddress = BitConverter.ToString(address.GetAddressBytes());
                return macAddress;
            }
            throw new InvalidOperationException("Unable to retrieve MAC address.");
        }
    }
}
