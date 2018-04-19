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
    public class CategoryController : ApiController
    {
        CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public IHttpActionResult GetCategories()
        {
            List<CategoryDTO> list = _categoryService.GetList().Select(a => new CategoryDTO()
            {
                CategoryID = a.CategoryID,
                Name = a.Name
            }).ToList();
            
            return Ok(list);
        }
    }
}
