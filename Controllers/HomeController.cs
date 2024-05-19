using Microsoft.AspNetCore.Mvc;

using NevronTask.Extensions;
using NevronTask.Models;

using Newtonsoft.Json;

namespace NevronTask.Controllers;

public class HomeController : Controller
{
    private const string SessionKeyNumbers = "Numbers";
    private const string SessionKeySum = "Sum";

    public IActionResult Index()
    {
        var numbers = HttpContext.Session.Get<List<int>>(SessionKeyNumbers) ?? new List<int>();
        int sum = HttpContext.Session.Get<int>(SessionKeySum);
        return View(new InitialData { Numbers = numbers, Sum = sum, });
    }

    /// <summary>
    /// Clears the numbers data from the session
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult ClearNumbers()
    {
        HttpContext.Session.Set(SessionKeyNumbers, new List<int>());
        HttpContext.Session.Set(SessionKeySum, 0);
        return Ok();
    }

    /// <summary>
    /// Creates a new random number between 1 and 1001 and stores in it the session
    /// </summary>
    /// <returns>The new number and the new count </returns>
    [HttpPost]
    public IActionResult AddNumber()
    {
        var numbers = HttpContext.Session.Get<List<int>>(SessionKeyNumbers) ?? [];
        var random = new Random();

        var number = random.Next(1, 1001); // Get 
        numbers.Add(number); // Adding a random number between 1 and 100
        HttpContext.Session.Set(SessionKeyNumbers, numbers);

        return Ok(new { count = numbers.Count, number = number });
    }

    [HttpPost]
    public IActionResult SumNumbers()
    {
        var numbers = HttpContext.Session.Get<List<int>>(SessionKeyNumbers) ?? [];
        var sum = numbers.Sum();
        HttpContext.Session.Set(SessionKeySum, sum);
        return Ok(new { sum });
    }
}
