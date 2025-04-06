using UrlValidator.Models;

namespace UrlValidator.Verifiers.Contract;

public interface IUrlVerifier
{
    public UrlVerificationResult VerifyUrl(Uri url);

}