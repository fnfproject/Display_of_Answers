using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Models;

namespace QuestionBankApiLibrary.Services
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionAsync(QuestionDto questionDto);
        Task<IEnumerable<Question>> GetQuestionsAsync();
    }
}