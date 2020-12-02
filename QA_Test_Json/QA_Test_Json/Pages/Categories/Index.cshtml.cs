using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA_Test_Json.Models;
using QA_Test_Json.Interfaces;

namespace QA_Test_Json.Pages.Categories
{
    public class IndexModel : PageModel
    {
        [BindProperty]public IQuestionRepository repo{get;set;}
        [BindProperty]public List<Question> CategoryList{get;set;}

        public IndexModel(IQuestionRepository rep)
        {
            repo = rep;
        }
        public void OnGet(string category)
        {
            foreach (var item in repo.GetAllQuestions())
            {
                if(item.Category == category) CategoryList.Add(item);
            }
        }
    }
}
