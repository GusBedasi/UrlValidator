using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;

namespace UrlValidator.Verifiers;

public class BrandSpoofVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Host.Contains("paypal") && !url.Host.EndsWith("paypal.com"))
        {
            return this.AsResult(-40, "Potential brand spoofing", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}