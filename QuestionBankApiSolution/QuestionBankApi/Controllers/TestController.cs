using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Services;

namespace QuestionBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;

        public TestController(ITestService testService, IQuestionService questionService)
        {
            _testService = testService;
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTest([FromBody] TestDto testDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _testService.AddTestAsync(testDto);
            return CreatedAtAction(nameof(GetTest), new { id = test.TestId }, test);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTest(int id)
        {
            var test = await _testService.GetTestAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            var questions = await _questionService.GetQuestionsAsync();
            return Ok(new { Test = test, Questions = questions });
        }
    }
}
