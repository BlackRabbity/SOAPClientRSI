using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAPClientRSI.Utilities
{
    public static class ClientProvider
    {
        private static readonly CinemaImplClient _client;
        private static readonly X509Certificate2 _trustedCertificate;
        static ClientProvider()
        {
            // Load the trusted certificate (assuming it's stored locally)
            _trustedCertificate = new X509Certificate2("../../../certificate/mykeystore2.p12", "password");
            using (X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(_trustedCertificate);
                store.Close();
            }
            // MTOM message encoding
            BasicHttpBinding binding = new BasicHttpBinding
            {
                MessageEncoding = WSMessageEncoding.Mtom,
                MaxReceivedMessageSize = 100000000,
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };
            EndpointAddress endpointAddress = new EndpointAddress("https://127.0.0.1:9999/ws/CinemaImpl?wsdl");

            // Set custom certificate validation
            System.Net.ServicePointManager.ServerCertificateValidationCallback = CustomCertificateValidation;
            _client = new CinemaImplClient(binding, endpointAddress);
        }

        public static CinemaImplClient Client => _client;
        private static bool CustomCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }
            return IsTrustedCertificate((X509Certificate2)certificate);
        }
        private static bool IsTrustedCertificate(X509Certificate2 certificate)
        {
            using (X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (cert.Thumbprint == certificate.Thumbprint)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
