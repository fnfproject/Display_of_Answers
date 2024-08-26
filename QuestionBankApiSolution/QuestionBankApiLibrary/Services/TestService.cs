using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestionBankApiLibrary.Data;
using QuestionBankApiLibrary.Dtos;
using QuestionBankApiLibrary.Models;

namespace QuestionBankApiLibrary.Services
{
    public class TestService : ITestService
    {
        private readonly QuestionBankDbContext _context;

        public TestService(QuestionBankDbContext context)
        {
            _context = context;
        }

        public async Task<Test> AddTestAsync(TestDto testDto)
        {
            var test = new Test
            {
                TestName = testDto.TestName,
                HyperLinks = testDto.HyperLinks,
                TestMaxMarks = testDto.TestMaxMarks,
                TestNoOfQuestions = testDto.TestNoOfQuestions,
                CreatedBy = testDto.CreatedBy,
                StartTime = testDto.StartTime,
                ExpiryTime = testDto.ExpiryTime,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return test;
        }

        public async Task<Test> GetTestAsync(int testId)
        {
            return await _context.Tests.FindAsync(testId);
        }
    }
}