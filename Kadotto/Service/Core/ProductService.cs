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
    public class ProductService
    {
        public long Add(ProductDTO pProductDTO)
        {
            long ProductID = 0;
            using (var Context = new BaseContext())
            {
                var Product = new ProductModel
                {
                    Title = pProductDTO.Title,
                    BrifDescription = pProductDTO.BrifDescription,
                    LongDescription = pProductDTO.LongDescription,
                    ProductCategoryID = pProductDTO.ProductCategoryID,
                    Vendor = pProductDTO.Vendor,
                    Quantity = pProductDTO.Quantity,
                    Weight = pProductDTO.Weight,
                    Height = pProductDTO.Height,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DisplayOrder = pProductDTO.DisplayOrder,
                    Visible = pProductDTO.Visible,
                    Deleted = false
                };
                Context.Products.Add(Product);
                Context.SaveChanges();
                ProductID = Product.ID;
            }
            return ProductID;
        }

        public long Edit(ProductDTO pProductDTO)
        {
            long ProductID = 0;
            using (var Context = new BaseContext())
            {
                var Product = Context.Products.FirstOrDefault(a => a.ID == pProductDTO.ID);
                if (Product != null)
                {
                    Product.Title = pProductDTO.Title;
                    Product.BrifDescription = pProductDTO.BrifDescription;
                    Product.LongDescription = pProductDTO.LongDescription;
                    Product.ProductCategoryID = pProductDTO.ProductCategoryID;
                    Product.Vendor = pProductDTO.Vendor;
                    Product.Quantity = pProductDTO.Quantity;
                    Product.Weight = pProductDTO.Weight;
                    Product.Height = pProductDTO.Height;
                    Product.UpdateDate = DateTime.Now;
                    Product.DisplayOrder = pProductDTO.DisplayOrder;
                    Product.Visible = pProductDTO.Visible;
                    Context.SaveChanges();
                    ProductID = Product.ID;
                }
            }
            return ProductID;
        }

        public long Delete(long ID)
        {
            long ProductID = 0;
            using (var Context = new BaseContext())
            {
                var Product = Context.Products.FirstOrDefault(a => a.ID == ID);
                if (Product != null)
                {
                    Product.Deleted = true;
                    //Context.Products.Remove(Product);
                    Context.SaveChanges();
                    ProductID = ID;
                }
            }
            return ProductID;
        }

        public List<ProductDTO> GetAll()
        {
            var Result = new List<ProductDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Products.Where(a => a.Deleted == false)
                    .Select(a => new ProductDTO
                    {
                        ID = a.ID,
                        Title = a.Title,
                        BrifDescription = a.BrifDescription,
                        LongDescription = a.LongDescription,
                        ProductCategoryID = a.ProductCategoryID,
                        Vendor = a.Vendor,
                        Quantity = a.Quantity,
                        Weight = a.Weight,
                        Height = a.Height,
                        CreationDate = a.CreationDate,
                        UpdateDate = a.UpdateDate,
                        DisplayOrder = a.DisplayOrder,
                        Visible = a.Visible,
                        Price = a.Price,
                        ImageName = a.ImageName
                    }).ToList();
            }
            return Result;
        }

        public ProductDTO GetByID(long ID)
        {
            var Result = new ProductDTO();
            using (var Context = new BaseContext())
            {
                var Product = Context.Products.FirstOrDefault(a => a.ID == ID);
                if (Product != null)
                {
                    Result.ID = Product.ID;
                    Result.Title = Product.Title;
                    Result.BrifDescription = Product.BrifDescription;
                    Result.LongDescription = Product.LongDescription;
                    Result.ProductCategoryID = Product.ProductCategoryID;
                    Result.Vendor = Product.Vendor;
                    Result.Quantity = Product.Quantity;
                    Result.Weight = Product.Weight;
                    Result.Height = Product.Height;
                    Result.CreationDate = Product.CreationDate;
                    Result.UpdateDate = Product.UpdateDate;
                    Result.DisplayOrder = Product.DisplayOrder;
                    Result.Visible = Product.Visible;
                    Result.ProductCategoryTitle = Context.ProductCategories.FirstOrDefault(a => a.ID == Product.ProductCategoryID).Title;
                }
            }
            return Result;
        }
    }
}
