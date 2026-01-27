# QA Automation – Börse Stuttgart

This project contains automated UI smoke tests for the Börse Stuttgart **Bond Finder** page.

Target page:
https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/

---

## Tech Stack

- **C# (.NET 6)**
- **xUnit**
- **Selenium WebDriver (Chrome)**
- **WebDriverWait (no Thread.Sleep)**

---

## Test Scope

The goal of this test suite is **UI smoke coverage** of the Bond Finder page.

The tests verify that the page is usable and all critical UI sections are present.

### Covered areas:

- Page loads successfully
- Cookie consent handling (accepted if shown)
- Header / top navigation exists
- Navigation links are present
- Call-to-action (CTA) button exists in the top bar (language-independent)
- Main headline is present (not language-dependent)
- Search and filter inputs exist
- Results / pagination container exists
- Footer exists
- Social media links exist in the footer


## ▶️ How to Run Tests

### Prerequisites
- .NET 6 SDK
- Google Chrome

### Run tests
```bash
dotnet test
