using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace IS4.STS.Identity.Helpers
{
    public static class CertificatesHelpers
    {
        public static X509Certificate2 GetSigningCertificate(StoreName storeName, StoreLocation location, string thumbprint)
        {
            using (X509Store store = new X509Store(storeName, location))
            {
                store.Open(OpenFlags.ReadOnly);

                var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                store.Close();
                if (certificates.Count > 0)
                    return certificates[0];

                return null;
            }
        }

        public static X509Certificate2 GetSigningCertificateFromFile(string filename, string password)
        {
            var cert = new X509Certificate2(filename, password);
            return cert;
        }
    }
}
