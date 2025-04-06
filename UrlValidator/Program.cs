using System.Reflection;
using UrlValidator.Pipeline;

namespace UrlValidator;

public class Program
{
    public static void Main(string[] args)
    {
        var maliciousUri = new Uri("http://secure.login.paypaI-account-support.tk:8080/login/verify.php?auth=password&token=1234");
        var normalUri =  new Uri("http://paypal.com");
        
        var pipeline = new UrlVerifierPipeline()
            .AddAllVerifiersFromAssembly(Assembly.GetExecutingAssembly());
        
        var result = pipeline.Run(maliciousUri);

        result.EvaluateUrlScore();
        
        Console.WriteLine($"Final Score: {result.Score}");
        Console.WriteLine($"Status: {result.Status}");
        Console.WriteLine("Verifier Insights:");
        
        foreach (var insight in result.VerifierResults)
        {
            Console.WriteLine($"[{insight.VerifierName}] RiskLevel: {insight.Risk} - Score: {insight.Score} - {insight.Reason}");
        }
    }
}