# SunamoCollections

## Short description

Rozsáhlá knihovna pomocných metod pro běžné operace s kolekcemi: úpravy seznamů, zpracování řetězců, vyhledávání prvků a převody dat.


A comprehensive .NET library providing utility methods for common collection operations including list manipulation, string processing, element searching, and data conversion.

## Overview

SunamoCollections is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development. It targets `net10.0`, `net9.0`, and `net8.0`.

## Main Components

### Core Class: `CA`

The `CA` partial class provides a wide range of static utility methods organized across multiple files:

- **Element operations**: `InitFillWith`, `Count`, `First`, `FirstOrNull`, `GetIndex`, `HasIndex`
- **String transformations**: `Trim`, `ToLower`, `WrapWith`, `Prepend`, `AddSuffix`, `TrimEnd`, `TrimStart`
- **Search and filtering**: `ContainsAnyFromElementBool`, `ReturnWhichContains`, `ReturnWhichContainsIndexes`, `StartWith`, `EndsWith`
- **Removal operations**: `RemoveNullEmptyWs`, `RemoveStringsEmpty`, `RemoveWhichContains`, `RemoveWildcard`, `RemoveStartingWith`
- **Comparison**: `CompareListDifferent`, `IsTheSame`, `IsAllTheSameString`, `HasDuplicates`
- **Conversion**: `ToList<T>`, `ToListString`, `ToLong`, `ToShort`, `ToBool`, `ToObject`, `JoinBytesArray`
- **Splitting and dividing**: `DivideBy`, `DivideByPercent`, `SplitList`, `Split`

### Additional Classes

- **`CANew`** - Facade for newer collection utility methods
- **`ResultWithExceptionCollections<T>`** - Result wrapper with optional exception information
- **`RemoveEmptyLinesService`** - Service for removing empty lines from string lists
- **`FromToCollections`** / **`FromToTSHCollections<T>`** - From-to range containers
- **`ABLCA<T>`** - Pair of lists for comparison results

## Installation

```bash
dotnet add package SunamoCollections
```

## Usage Examples

```csharp
// Initialize a list with default values
var list = new List<string>();
CA.InitFillWith(list, 10, "default");

// Check for duplicates
bool hasDuplicates = CA.HasDuplicates(myList);

// Filter elements containing a term
var matches = CA.ReturnWhichContains(lines, "searchTerm");

// Divide a list into groups
var groups = CA.DivideBy(items, 3);

// Check if text contains any candidate
bool found = CA.ContainsAnyFromElementBool("input text", candidates);
```

## Dependencies

- **Diacritics** - Diacritic character handling
- **Microsoft.Extensions.Logging.Abstractions** - Logging abstractions

## Package Information

- **Package Name**: SunamoCollections
- **Target Frameworks**: net10.0, net9.0, net8.0
- **License**: MIT

## License

See the repository root for license information.

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 2/12 (16.7 %) |
| Public methods referenced by tests | 29/131 (22.1 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoCollections","container":"pinp","testProjects":1,"publicTypes":12,"typesReferencedByTests":2,"publicMethods":131,"methodsReferencedByTests":29,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
