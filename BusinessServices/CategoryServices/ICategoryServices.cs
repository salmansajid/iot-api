using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.CategoryServices
{
    public interface ICategoryServices
    {

        CategoryEntity GetCategoryById(int CategoryId);
        IEnumerable<CategoryEntity> GetAllCategory();
        int CreateCategory(CategoryEntity categoryEntity);
        bool UpdateCategory(int CategoryId, CategoryEntity categoryEntity);
        bool DeleteCategory(int CategoryId);
    }
}
