using System.Reflection;
using UrlValidator.Domain;
using UrlValidator.Models;
using UrlValidator.Verifiers.Contract;

namespace UrlValidator.Pipeline;

public class UrlVerifierPipeline
{
    private readonly List<IUrlVerifier> _verifiers = new();

    public UrlVerifierPipeline()
    { }
    
    public UrlVerifierPipeline(List<IUrlVerifier> urlVerifierses)
    {
        _verifiers = urlVerifierses;
    }
    
    public UrlVerifierPipeline AddAllVerifiersFromAssembly(Assembly assembly)
    {
        var verifierType = typeof(IUrlVerifier);

        var implementations = assembly
            .GetTypes()
            .Where(t => verifierType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToList();

        foreach (var impl in implementations)
        {
            if (Activator.CreateInstance(impl) is IUrlVerifier instance)
            {
                _verifiers.Add(instance);
            }
        }
        
        return this;
    }

    public UrlVerifierPipeline AddVerifier(IUrlVerifier urlVerifier)
    {
        _verifiers.Add(urlVerifier);
        return this;
    }

    public UrlScore Run(Uri url)
    {
        var result = new UrlScore(url);

        foreach (var verifier in _verifiers)
        {
            var verification = verifier.VerifyUrl(url);
            result.AddScore(verification);
        }
        
        return result;
    }
}