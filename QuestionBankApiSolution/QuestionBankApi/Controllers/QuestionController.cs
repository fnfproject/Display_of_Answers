using Microsoft.AspNetCore.Mvc;
using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Services;
using QuestionBankApiLibrary.Models;

namespace QuestionBankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _questionService.AddQuestionAsync(questionDto);
            return CreatedAtAction(nameof(GetQuestions), new { id = result.QuestionId }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _questionService.GetQuestionsAsync();
            return Ok(questions);
        }
    }
}