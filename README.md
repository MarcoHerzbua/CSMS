# has-to-be Coding Challenge 
## CSMS

Author: Marco Herzog

Techstack: ASP.Net Core 6.0, Visual Studio 2022, Swashbuckle.AspNetCore

### Content
- Visual Studio project written in C# 
- UML diagram of models used in api
- .zip file with executable web api

### How to Test
- Run CSMS.exe
- Open "https://localhost:5001/swagger" in browser
- Use Swagger UI to test "CSProcess/rate" with JSON input

```
{
"rate": { "energy": 0.3, "time": 2, "transaction": 1 },
"cdr": { "meterStart": 1204307, "timestampStart": "2021-04-05T10:04:00Z", "meterStop": 1215230, "timestampStop":
"2021-04-05T11:27:00Z" }
}
```

### Suggested improvements
- Api should implement asynchrous calls, since simultaneous requests are very likely
- expand on error handling, implement specific error codes 
- automated testing environment - implement tests for every new functionality and run before deployment