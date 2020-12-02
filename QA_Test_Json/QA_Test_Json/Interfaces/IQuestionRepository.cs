using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QA_Test_Json.Models;

namespace QA_Test_Json.Interfaces
{
    public interface IQuestionRepository
    {
        public void AddQuestion(Question q);
        public Question GetQuestion(string title);
        public List<Question> GetAllQuestions();
        public List<Question> FilterQuestionsByTitle(string title);
        public List<Question> FilterQuestionsByCategory(string category);
        public void DeleteComment();
    }
}
