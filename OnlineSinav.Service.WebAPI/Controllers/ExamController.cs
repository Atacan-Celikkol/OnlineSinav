using OnlineSinav.BLL.Concrete;
using OnlineSinav.Model;
using OnlineSinav.Service.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineSinav.Service.WebAPI.Controllers
{
    public class ExamController : ApiController
    {
        ExamService _examService;

        public ExamController()
        {
            _examService = new ExamService();
        }

        public IHttpActionResult GetExams()
        {
            List<ExamDTO> exams = _examService.GetList().Select(a => new ExamDTO()
            {
                CategoryID = a.CategoryID,
                CategoryName = a.Category.Name,
                Date = a.Date,
                Duration = a.Duration,
                ExamID = a.ExamID,
                IsActive = a.IsActive,
                LessonID = a.LessonID,
                LessonName = a.Lesson.Name,
                Name = a.Name
            }).ToList();

            return Ok(exams);
        }

        public IHttpActionResult GetByID(int id)
        {
            Exam exam = _examService.GetByID(id);
            if (exam == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(exam);
            }
        }

        public IHttpActionResult Post(ExamDTO examDTO)
        {
            Exam exam = new Exam()
            {
                CategoryID = examDTO.CategoryID,
                Date = examDTO.Date,
                Duration = examDTO.Duration,
                IsActive = examDTO.IsActive,
                LessonID = examDTO.LessonID,
                Name = examDTO.Name
            };

            _examService.Add(exam);

            return Ok();
        }
    }
}
