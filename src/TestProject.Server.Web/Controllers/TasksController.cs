using Microsoft.AspNetCore.Mvc;
using TestProject.Server.Core.Services;
using TestProject.Server.Web.ApiModels;

namespace TestProject.Server.Web.Controllers;
public class TasksController : Controller {
    private IArraySumFinder _arraySumFinder;
    private ILinkedListAddingService _linkedListAddingService;
    private IPalindromeDetector _palindromeDetector;
    private ILogger _logger;

    public TasksController(IArraySumFinder arraySumFinder, ILinkedListAddingService linkedListAddingService, IPalindromeDetector palindromeDetector,
         ILoggerFactory loggerFactory) {
        _arraySumFinder = arraySumFinder;
        _linkedListAddingService = linkedListAddingService;
        _palindromeDetector = palindromeDetector;
        _logger = loggerFactory.CreateLogger("MainController");
    }

    [HttpPost("/FirstTask")]
    public async Task<IActionResult> FirstTask([FromBody] FirstTaskRequest request) {
        if (request != null && ModelState.IsValid && request?.Numbers.Count > 0) {
            long result = 0;

            try {
                result = _arraySumFinder.GetSum(request.Numbers);
            }
            catch (OverflowException e) {
                _logger.LogError("Array numbers sum eceeded Int64 max value.");
                return BadRequest("Too big numbers");
            }
            return Ok(Math.Abs(result));
        }
        else {
            return BadRequest();
        }
    }

    [HttpPost("/SecondTask")]
    public async Task<IActionResult> SecondTask([FromBody] SecondTaskRequest request) {
        if (request == null || !ModelState.IsValid) {
            return BadRequest();
        }

        Core.Models.LinkedListNode<int> result;

        try {
            result = _linkedListAddingService.Add(request.FirstNumberNode, request.SecondNumberNode);
        }
        catch (OverflowException e) {
            return BadRequest("Too big numbers");
            _logger.LogError("Array numbers sum eceeded Int64 max value.");
        }

        return Ok(result);
    }

    [HttpPost("/ThirdTask")]
    public async Task<IActionResult> ThirdTask([FromBody] ThirdTaskRequest request) {
        if (!ModelState.IsValid || String.IsNullOrEmpty(request.Input)) {
            return BadRequest();
        }

        if (request.Input.Length > 100) {
            return BadRequest("Too big string");
        }

        bool result = _palindromeDetector.IsPalindrome(request.Input);

        return Ok(result);
    }
}
