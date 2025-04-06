using UrlValidator.Domain.Enums;
using UrlValidator.Models;
using UrlValidator.Models.Enums;

namespace UrlValidator.Domain;

public record UrlScore
{
    public List<UrlVerificationResult> VerifierResults { get; private set; } = new();

    public UrlScore(Uri url)
    {
        Url = url;  
    } 
    
    public Uri Url { get; private set; }
    public UrlStatus Status { get; private set; }
    public int Score { get; private set; }

    public void AddScore(UrlVerificationResult result)
    {
        Score += result.Score;
        VerifierResults.Add(result);
    }

    public void AddScore(Func<Uri, int> scoreSelector)
    {
        Score += scoreSelector(Url);
    }

    public void EvaluateUrlScore()
    {
        var highestRisk = VerifierResults
            .OrderByDescending(r => r.Risk)
            .FirstOrDefault()?.Risk ?? RiskLevel.Low;

        var totalNegScore = VerifierResults
            .Where(r => r.Score < 0)
            .Sum(r => r.Score);

        var totalPosScore = VerifierResults
            .Where(r => r.Score > 0)
            .Sum(r => r.Score);

        var totalChecks = VerifierResults.Count;
        var failedChecks = VerifierResults.Count(r => r.Score < 0);

        // Decision tree logic
        if (highestRisk == RiskLevel.Critical || totalNegScore <= -100)
        {
            Status = UrlStatus.Fraud;
        }
        else if (failedChecks >= totalChecks * 0.5 || totalNegScore <= -50)
        {
            Status = UrlStatus.Suspicious;
        }
        else if (totalPosScore >= 50 && failedChecks == 0)
        {
            Status = UrlStatus.Good;
        }
        else
        {
            Status = UrlStatus.Unknown;
        }
    }
}