using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAPClientRSI.Utilities
{
    public static class ClientProvider
    {
        private static readonly CinemaImplClient _client;
        static ClientProvider()
        {
            // MTOM message encoding
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MessageEncoding = WSMessageEncoding.Mtom;

            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:9999/ws/CinemaImpl");

            _client = new CinemaImplClient(binding, endpointAddress);
        }

        public static CinemaImplClient Client => _client;
    }
}
