# 🕵️‍♂️ UrlValidator

**UrlValidator** is a modular, pluggable and extensible .NET pipeline that analyzes URLs for fraud, phishing, and security threats. It’s designed to give insights into what makes a URL suspicious or safe, and is perfect for anti-scam platforms, security tooling, or educational purposes.

---

## 🚀 Features

- 🔍 **Pluggable Verifier System** – Easily add new verifiers for patterns, domains, query strings, etc.
- 🧠 **Smart Evaluation Logic** – Goes beyond score thresholds using contextual and risk-based evaluation.
- 📋 **Detailed Diagnostic Output** – Every verifier contributes insights, not just scores.
- ⚡ **Reflection-Based Auto-Wiring** – No need to manually register verifiers.
- 🧪 **Unit Tested** – Includes full test coverage for all verifiers.
- 🧰 Built in **.NET 8**, but compatible with .NET 6+

---

## 🧠 How It Works

- Verifiers implement the `IUrlVerifier` interface.
- The `UrlVerificationPipeline` automatically finds and runs all verifiers using reflection.
- Each verifier contributes a `UrlVerificationResult` with:
  - **Score** (positive or negative)
  - **Reason** (human-readable)
  - **Risk Level** (`Low`, `Medium`, `High`, `Critical`)
- The pipeline uses smart logic to assign a `UrlStatus`:
  - `Good`
  - `Suspicious`
  - `Fraud`
  - `Unknown`

---

## 📦 Example

```csharp
var pipeline = new UrlVerificationPipeline()
    .AddAllVerifiersFromAssembly(Assembly.GetExecutingAssembly());

var result = pipeline.Run(new Uri("http://secure.login.paypaI-account-support.tk:8080/verify.php?auth=password"));

Console.WriteLine($"Final Score: {result.Score}");
Console.WriteLine($"Status: {result.Status}");

foreach (var insight in result.VerifierResults)
{
    Console.WriteLine($"[{insight.VerifierName}] Score: {insight.Score} - {insight.Reason} (Risk: {insight.Risk})");
}
```

# Fraudulent URL Report

**Final Score:** -205  
**Status:** **Fraud**

---

### Verifier Breakdown

- **[SchemeVerifier]**
  - **Score:** -50  
  - **Reason:** The URL uses unencrypted HTTP  
  - **Risk:** High

- **[SubdomainAbuseVerifier]**
  - **Score:** -30  
  - **Reason:** Suspicious subdomain nesting  
  - **Risk:** Medium

- **[BrandSpoofVerifier]**
  - **Score:** -40  
  - **Reason:** Potential brand spoofing  
  - **Risk:** High

- **[HomographVerifier]**
  - **Score:** -50  
  - **Reason:** Homograph attack detected  
  - **Risk:** Critical

- **[PathKeywordVerifier]**
  - **Score:** -10  
  - **Reason:** Suspicious path keywords detected  
  - **Risk:** Medium

- **[QueryParameterAbuseVerifier]**
  - **Score:** -15  
  - **Reason:** Sensitive query parameters found  
  - **Risk:** Medium

- **[ShortenerVerifier]**
  - **Score:** 0  
  - **Reason:** No issues found  
  - **Risk:** Medium

- **[TldSuspicionVerifier]**
  - **Score:** -30  
  - **Reason:** Suspicious top-level domain  
  - **Risk:** Medium


---

## 🔐 Example Verifiers

| Verifier                 | Trigger                                | Penalty | Risk     |
|--------------------------|----------------------------------------|---------|----------|
| `SchemeVerifier`         | Uses HTTP instead of HTTPS             | -50     | High     |
| `SubdomainAbuseVerifier` | Too many subdomains                    | -30     | Medium   |
| `BrandSpoofVerifier`     | Contains fake PayPal domain            | -40     | High     |
| `HomographVerifier`      | Uses lookalike characters              | -50     | Critical |
| `ShortenerVerifier`      | Uses bit.ly, tinyurl, etc.             | -25     | Medium   |

> 💡 Verifiers can be added easily — just implement `IUrlVerifier` and drop it in.

---

🛠 Tech Stack

- .NET 8

Using cool features and patterns
- xUnit for testing
- Reflection for DI-free auto-registration
- Extensible enums and factory pattern

---

🤝 Contributing
* Pull requests, ideas, and suggestions are welcome!
* Feel free to open issues for bug reports, feature requests, or general questi

---
Let me know if you want to add:
- Badges (CI, NuGet, License, etc.)
- A logo/banner for branding
- Docker/CI usage
- GitHub Pages API testing UI

Want me to tailor it for public package publishing or internal enterprise use?
