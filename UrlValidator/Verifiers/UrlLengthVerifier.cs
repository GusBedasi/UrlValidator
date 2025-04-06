using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class UrlLengthVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.AbsoluteUri.Length > 200)
        {
            return this.AsResult(-20, "URL is excessively long", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
