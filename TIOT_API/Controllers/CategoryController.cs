using BusinessEntities;
using BusinessServices.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/category

        private readonly ICategoryServices _CategoryServices;

        public CategoryController()
        {
            _CategoryServices = new CategoryServices();
        }

        // GET api/client  
        public HttpResponseMessage Get()
        {
            var category = _CategoryServices.GetAllCategory();
            if (category != null)
            {
                var categoryEntities = category as List<CategoryEntity> ?? category.ToList();
                if (categoryEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, categoryEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        // GET api/client/5
        public HttpResponseMessage Get(int id)
        {
            var category = _CategoryServices.GetCategoryById(id);
            if (category != null)
                return Request.CreateResponse(HttpStatusCode.OK, category);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/client
        public int Post([FromBody]CategoryEntity categoryEntity)
        {
            return _CategoryServices.CreateCategory(categoryEntity);
        }

        // PUT api/client/5
        public bool Put(int id, [FromBody]CategoryEntity categoryEntity)
        {
            if (id > 0)
            {
                return _CategoryServices.UpdateCategory(id, categoryEntity);
            }
            return false;
        }

        // DELETE api/client/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _CategoryServices.DeleteCategory(id);
            return false;
        }
    }
}
