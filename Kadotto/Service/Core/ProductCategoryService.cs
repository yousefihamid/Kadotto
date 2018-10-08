using Common.Core;
using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class ProductCategoryService
    {
        public long Add(ProductCategoryDTO pProductCategoryDTO)
        {
            long ProductCategoryID = 0;
            using (var Context = new BaseContext())
            {
                var ProductCategory = new ProductCategoryModel
                {
                    Title = pProductCategoryDTO.Title,
                    ParentID = pProductCategoryDTO.ParentID,
                };
                Context.ProductCategories.Add(ProductCategory);
                Context.SaveChanges();
                ProductCategoryID = ProductCategory.ID;
            }
            return ProductCategoryID;
        }

        public long Edit(ProductCategoryDTO pProductCategoryDTO)
        {
            long ProductCategoryID = 0;
            using (var Context = new BaseContext())
            {
                var ProductCategory = Context.ProductCategories.FirstOrDefault(a => a.ID == pProductCategoryDTO.ID);
                if (ProductCategory != null)
                {
                    ProductCategory.Title = pProductCategoryDTO.Title;
                    ProductCategory.ParentID = pProductCategoryDTO.ParentID;
                    Context.SaveChanges();
                    ProductCategoryID = ProductCategory.ID;
                }
            }
            return ProductCategoryID;
        }

        public long Delete(long ID)
        {
            long ProductCategoryID = 0;
            using (var Context = new BaseContext())
            {
                var ProductCategory = Context.ProductCategories.FirstOrDefault(a => a.ID == ID);
                if (ProductCategory != null)
                {
                    Context.ProductCategories.Remove(ProductCategory);
                    Context.SaveChanges();
                    ProductCategoryID = ID;
                }
            }
            return ProductCategoryID;
        }

        public List<ProductCategoryDTO> GetAll()
        {
            var Result = new List<ProductCategoryDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.ProductCategories
                    .Select(a => new ProductCategoryDTO
                    {
                        ID = a.ID,
                        Title = a.Title,
                        ParentID = a.ParentID
                    }).ToList();
            }
            return Result;
        }

        public ProductCategoryDTO GetByID(long ID)
        {
            var Result = new ProductCategoryDTO();
            using (var Context = new BaseContext())
            {
                var ProductCategory = Context.ProductCategories.FirstOrDefault(a => a.ID == ID);
                if (ProductCategory != null)
                {
                    Result.ID = ProductCategory.ID;
                    Result.Title = ProductCategory.Title;
                    Result.ParentID = ProductCategory.ParentID;
                    if (ProductCategory.ParentID != null)
                        Result.ParentTitle = Context.ProductCategories.FirstOrDefault(a => a.ID == ProductCategory.ParentID).Title;
                }
            }
            return Result;
        }
    }
}
