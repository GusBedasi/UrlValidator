using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class PathKeywordVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.AbsolutePath.Contains("login") 
            || url.AbsolutePath.Contains("verify") 
            || url.AbsolutePath.Contains("update"))
        {
            return this.AsResult(-10, "Suspicious path keywords detected", RiskLevel.Medium);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
