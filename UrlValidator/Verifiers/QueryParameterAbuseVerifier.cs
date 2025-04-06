using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class QueryParameterAbuseVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Query.Contains("token") || url.Query.Contains("auth") || url.Query.Contains("password"))
        {
            return this.AsResult(-15, "Sensitive query parameters found", RiskLevel.Critical);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}
