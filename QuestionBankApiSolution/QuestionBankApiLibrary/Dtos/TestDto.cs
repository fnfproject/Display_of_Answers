using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionBankApiLibrary.Dtos
{
    public class TestDto
    {
        public string TestName { get; set; }
        public string HyperLinks { get; set; }
        public int TestMaxMarks { get; set; }
        public int TestNoOfQuestions { get; set; }
        public int CreatedBy { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
