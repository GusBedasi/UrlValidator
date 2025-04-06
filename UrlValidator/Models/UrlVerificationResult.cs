using UrlValidator.Models.Enums;

namespace UrlValidator.Models;

public class UrlVerificationResult
{
    public int Score { get; set; }
    public string Reason { get; set; }
    public string VerifierName { get; set; }
    public RiskLevel Risk { get; set; } = RiskLevel.Medium;
}