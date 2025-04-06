using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class SchemeVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        return url.Scheme != "http" 
            ? this.AsResult(score: 10, reason: "No issues found", RiskLevel.Low) 
            : this.AsResult(score: -100, reason: "The URL is not HTTPS so the data isn't encrypted", RiskLevel.Critical);
    }
}
