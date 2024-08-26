using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Services;

namespace QuestionBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly ITestService _testService;

        public ResultController(IResultService resultService, ITestService testService)
        {
            _resultService = resultService;
            _testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> AddResult([FromBody] ResultDto resultDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _resultService.AddResultAsync(resultDto);
            return CreatedAtAction(nameof(GetResult), new { id = result.ResultId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResult(int id)
        {
            var result = await _resultService.GetResultAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            var test = await _testService.GetTestAsync(result.TestId);
            return Ok(new { Result = result, Test = test });
        }
    }
}
