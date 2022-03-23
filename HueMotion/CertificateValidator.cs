using System.Diagnostics;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public static class CertificateValidator
{
    public static bool VerifyServerCertificate(HttpRequestMessage arg1, X509Certificate2? arg2, X509Chain? arg3, SslPolicyErrors arg4)
    {
        try
        {
            var ca = new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "huebridge_cacert.pem"));

            var chain2 = new X509Chain();
            chain2.ChainPolicy.ExtraStore.Add(ca);
            chain2.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

            var isValid = chain2.Build(ca);
            var chainRoot = chain2.ChainElements[chain2.ChainElements.Count - 1].Certificate;
            isValid = isValid && chainRoot.RawData.SequenceEqual(ca.RawData);

            Debug.Assert(isValid == true);

            return isValid;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return false;
    }
}
