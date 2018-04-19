using OnlineSinav.BLL.Concrete;
using OnlineSinav.Service.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineSinav.Service.WebAPI.Controllers
{
    public class LessonController : ApiController
    {
        LessonService _lessonService;

        public LessonController()
        {
            _lessonService = new LessonService();
        }

        public IHttpActionResult GetLessons()
        {
            List<LessonDTO> list = _lessonService.GetList().Select(a => new LessonDTO()
            {
                LessonID = a.LessonID,
                Name = a.Name
            }).ToList();

            return Ok(list);
        }
    }
}
