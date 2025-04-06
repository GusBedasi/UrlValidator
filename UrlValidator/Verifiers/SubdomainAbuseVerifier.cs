using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class SubdomainAbuseVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Host.Split('.').Length > 3)
        {
            return this.AsResult(-30, "Suspicious subdomain nesting", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
