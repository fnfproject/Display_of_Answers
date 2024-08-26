using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Models;

namespace QuestionBankApiLibrary.Services
{
    public interface IResultService
    {
        Task<Result> AddResultAsync(ResultDto resultDto);
        Task<Result> GetResultAsync(int resultId);
    }
}