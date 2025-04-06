using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class TldSuspicionVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Host.EndsWith(".ru") || url.Host.EndsWith(".cn") || url.Host.EndsWith(".xyz") || url.Host.EndsWith(".tk"))
        {
            return this.AsResult(-30, "Suspicious top-level domain", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
