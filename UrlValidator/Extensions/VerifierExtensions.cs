using UrlValidator.Models;
using UrlValidator.Models.Enums;

namespace UrlValidator.Extensions;

public static class VerifierExtensions
{
    public static UrlVerificationResult AsResult(this object verifier, int score, string reason, RiskLevel riskLevel)
    {
        return new UrlVerificationResult
        {
            Score = score,
            Reason = reason,
            VerifierName = verifier.GetType().Name,
            Risk = riskLevel,
        };
    }
}