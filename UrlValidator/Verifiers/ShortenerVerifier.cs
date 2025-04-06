using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class ShortenerVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Host.Contains("bit.ly") || url.Host.Contains("tinyurl.com") || url.Host.Contains("goo.gl"))
        {
            return this.AsResult(-25, "URL uses a known shortener service", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
