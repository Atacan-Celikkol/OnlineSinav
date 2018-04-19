using OnlineSinav.BLL.Concrete;
using OnlineSinav.Model;
using OnlineSinav.UI.WebMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSinav.UI.WebMVC.Controllers
{
    [CustomAuthorize]
    public class ExamController : Controller
    {
        ExamService _examService;

        public ExamController()
        {
            _examService = new ExamService();
        }

        public ActionResult List()
        {
            return View(_examService.GetList());
        }

        public ActionResult GetExam(int id)
        {
            Exam currentExam = _examService.GetByID(id);
            Question currentQuestion = Session["CurrentQuestion"] == null ? currentExam.Questions.ToList()[0] : Session["CurrentQuestion"] as Question;

            Session["Correct"] = Session["Correct"] == null ? 0 : Session["Correct"];
            Session["Wrong"] = Session["Wrong"] == null ? 0 : Session["Wrong"];
            Session["Left"] = Session["Left"] == null ? currentExam.Questions.Count : Session["Left"];
            Session["Exam"] = currentExam;
            Session["CurrentQuestion"] = currentQuestion;
            ViewBag.Time = 120 / 60;

            return View(currentExam);
        }

        public PartialViewResult BindQuestion()
        {
            Question currentQuestion = Session["CurrentQuestion"] as Question;
            return PartialView("_PartialQuestion", currentQuestion);
        }

        public JsonResult CheckAnswer(string answer)
        {
            Exam currentExam = Session["Exam"] as Exam;
            Question currentQuestion = Session["CurrentQuestion"] as Question;
            Choice correct = currentQuestion.Choices.First(a => a.IsCorrect);

            if (correct.Text == answer)
            {
                Session["Correct"] = ((int)Session["Correct"]) + 1;
            }
            else
            {
                Session["Wrong"] = ((int)Session["Wrong"]) + 1;
            }

            Session["Left"] = ((int)Session["Left"]) - 1;

            int currentIndex = currentExam.Questions.ToList().IndexOf(currentQuestion);
            if (currentIndex == currentExam.Questions.Count - 1)
            {
                Session["CurrentQuestion"] = null;
            }
            else
            {
                Session["CurrentQuestion"] = currentExam.Questions.ElementAt(currentIndex + 1);
                BindQuestion();
            }

            return Json("OK");
        }

        public PartialViewResult GetLeftQuestions()
        {
            List<Question> qList;
            Exam currentExam = Session["Exam"] as Exam;
            Question currentQuestion = Session["CurrentQuestion"] as Question;

            qList = currentExam.Questions.Where(a => a.QuestionID > currentQuestion.QuestionID && a.IsActive).ToList();

            return PartialView("_PartialQuestionList", qList);
        }
    }
}