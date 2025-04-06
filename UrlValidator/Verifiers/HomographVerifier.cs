using UrlValidator.Extensions;
using UrlValidator.Models;
using UrlValidator.Models.Enums;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Verifiers;

public class HomographVerifier : IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url)
    {
        if (url.Host.Contains("g00gle") || url.Host.Contains("micr0soft") || url.Host.Contains("paypaI"))
        {
            return this.AsResult(-50, "Homograph attack detected", RiskLevel.High);
        }

        return this.AsResult(0, "No issues found", RiskLevel.Low);
    }
}