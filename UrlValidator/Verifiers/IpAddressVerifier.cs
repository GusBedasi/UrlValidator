using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class IpAddressVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (System.Net.IPAddress.TryParse(url.Host, out _))
        {
            return this.AsResult(-50, "URL uses raw IP address", RiskLevel.High);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
