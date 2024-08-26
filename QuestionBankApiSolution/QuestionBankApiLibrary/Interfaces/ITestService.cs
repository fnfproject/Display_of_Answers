using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Models;

namespace QuestionBankApiLibrary.Services
{
    public interface ITestService
    {

        Task<Test> AddTestAsync(TestDto testDto);
        Task<Test> GetTestAsync(int testId);
    }
}