using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        
        private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public CategoryServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public CategoryEntity GetCategoryById(int categoryId)
        {
            var category = _unitOfWork.CategoryRepository.GetByID(categoryId);
            if (category != null)
            {
                Mapper.CreateMap<Category, CategoryEntity>();
                var categoryModel = Mapper.Map<Category, CategoryEntity>(category);
                return categoryModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<CategoryEntity> GetAllCategory()
        {
            var category = _unitOfWork.CategoryRepository.GetAll().ToList();
            if (category.Any())
            {
                Mapper.CreateMap<Category, CategoryEntity>();
                var categoryInfo = from ct in category
                                   where ct.Deleted == false
                                   orderby ct.CategoryID descending
                                 select ct;
                var categoryModel = Mapper.Map<List<Category>, List<CategoryEntity>>(categoryInfo.ToList());
                return categoryModel;
            }
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateCategory(CategoryEntity categoryEntity)
        {
            using (var scope = new TransactionScope())
            {
                var category = new Category
                {
                    
                    Name = categoryEntity.Name,
                    EnableORDisable = categoryEntity.EnableORDisable,
                    Deleted = categoryEntity.Deleted
                };

                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Save();
                scope.Complete();
                return category.CategoryID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateCategory(int categoryId, CategoryEntity categoryEntity)
        {
            var success = false;
            if (categoryEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var category = _unitOfWork.CategoryRepository.GetByID(categoryId);
                    if (category != null)
                    {
                        category.Name = categoryEntity.Name;
                        category.EnableORDisable = categoryEntity.EnableORDisable;
                        category.Deleted = categoryEntity.Deleted;
                        _unitOfWork.CategoryRepository.Update(category);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public bool DeleteCategory(int categoryId)
        {
            var success = false;
            if (categoryId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var category = _unitOfWork.CategoryRepository.GetByID(categoryId);
                    if (category != null)
                    {

                        _unitOfWork.CategoryRepository.Delete(category);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


    }
}
