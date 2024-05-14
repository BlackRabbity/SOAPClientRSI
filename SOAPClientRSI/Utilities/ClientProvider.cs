﻿using ServiceReference;
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
            binding.MaxReceivedMessageSize = 20000000;


            EndpointAddress endpointAddress = new EndpointAddress("http://192.168.200.9:9999/ws/CinemaImpl?wsdl");

            _client = new CinemaImplClient(binding, endpointAddress);
        }

        public static CinemaImplClient Client => _client;
    }
}
