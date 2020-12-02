using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QA_Test_Json.Interfaces;
using QA_Test_Json.Models;

namespace QA_Test_Json.Pages
{
    public enum FilterType
    {
        None,
        Text,
        Category
    }

    public class Filter
    {
        public FilterType FType;
        public string FilterValue;
        public Filter(FilterType type, string filter)
        {
            FType = type;
            FilterValue = filter;
        }
        public Filter()
        {

        }
    }
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IQuestionRepository repo;
        [BindProperty]public Question Question{get;set;}
        [BindProperty]public string QuestionInput{get;set;}
        [BindProperty]public string QuestionDescription{get;set;}
        [BindProperty]public string CategoryInput{get;set;}
        [BindProperty]public string SearchInput{get;set;}
        [BindProperty]public string CategoryFilterInput{get;set;}
        [BindProperty]public FilterType Type{get;set;}
        [BindProperty]public List<Question> CurrentFilterList{get;set;}
        [BindProperty]public Filter Filter {get;set;}
        [BindProperty]public bool IsFiltered{get;set; } = false;

        public IndexModel(ILogger<IndexModel> logger, IQuestionRepository rep)
        {
            _logger = logger;
            repo = rep;
        }

        public void OnGet() // no filter on normal home page
        {
            if(Filter == null) Filter = new Filter();
           // IsFiltered = false;
            //Type = FilterType.Category; // check if filtered is "None"
        }

        public IActionResult OnPost()
        {
           // IsFiltered = true;
           // Filter.FilterValue = "Astrologi"; // should choose from selected pop-up
           // Filter.FType = FilterType.Category;
           // ViewData["MyObject"] = Filter;
           //// OnGet(); // does this work instead of redirect?
           // return RedirectToPage("Index");

            Question = new Question(QuestionInput,QuestionDescription, CategoryInput); // gets error if exact title match with existing one
            repo.AddQuestion(Question);
            return RedirectToPage("/Questions/Index", new { Question.Title});
        }
        public IActionResult OnPostSearchCategory()
        {
            Filter.FilterValue = CategoryFilterInput;
            Filter.FType = Type;
            ViewData["MyObject"] = Filter;
           // OnGet(); // does this work instead of redirect?
            return RedirectToPage("Index");
             return RedirectToPage("Index", new { CategoryFilterInput, FilterType.Category});
        }
        public void OnPostSearchTitle()
        {
            //return RedirectToPage("Index", new { SearchInput, FilterType.Text});
        }
    }
}
