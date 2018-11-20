using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Shop;
using System.Collections.Generic;
using System.Linq;

namespace Service.Shop
{
    public class PackagedBoxDetailService
    {
        public long Add(PackagedBoxDetailDTO pPackagedBoxDetailDTO)
        {
            long PackagedBoxDetailID = 0;

            using (var Context = new BaseContext())
            {
                var PackagedBoxDetail = new PackagedBoxDetailModel
                {
                    PackagedBoxID = pPackagedBoxDetailDTO.PackagedBoxID,
                    ProductID = pPackagedBoxDetailDTO.ProductID,
                    IsDeleted = false
                };
                Context.PackagedBoxDetails.Add(PackagedBoxDetail);
                Context.SaveChanges();
                PackagedBoxDetailID = PackagedBoxDetail.ID;
            }
            return PackagedBoxDetailID;
        }

        public long Edit(PackagedBoxDetailDTO pPackagedBoxDetailDTO)
        {
            long PackagedBoxDetailID = 0;
     
            using (var Context = new BaseContext())
            {
                var PackagedBoxDetail = Context.PackagedBoxDetails.FirstOrDefault(a => a.ID == pPackagedBoxDetailDTO.ID);
                if (PackagedBoxDetail != null)
                {
                    PackagedBoxDetail.PackagedBoxID = pPackagedBoxDetailDTO.PackagedBoxID;
                    PackagedBoxDetail.ProductID = pPackagedBoxDetailDTO.ProductID;
                    Context.SaveChanges();
                    PackagedBoxDetailID = PackagedBoxDetail.ID;
                }
            }
            return PackagedBoxDetailID;
        }

        public long Delete(long ID)
        {
            long PackagedBoxDetailID = 0;
            using (var Context = new BaseContext())
            {
                var PackagedBoxDetail = Context.PackagedBoxDetails.FirstOrDefault(a => a.ID == ID);
                if (PackagedBoxDetail != null)
                {
                    PackagedBoxDetail.IsDeleted = true;
                    Context.SaveChanges();
                    PackagedBoxDetailID = PackagedBoxDetail.ID;
                }
            }
            return PackagedBoxDetailID;
        }

        public List<PackagedBoxDetailDTO> GetAll()
        {
            var Result = new List<PackagedBoxDetailDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.PackagedBoxDetails
                    .Select(a => new PackagedBoxDetailDTO
                    {
                        ID = a.ID,
                        PackagedBoxID = a.PackagedBoxID,
                        ProductID = a.ProductID,
                    }).ToList();
            }
            return Result;
        }

        public PackagedBoxDetailDTO GetByID(long ID)
        {
            var Result = new PackagedBoxDetailDTO();
            using (var Context = new BaseContext())
            {
                var PackagedBoxDetail = Context.PackagedBoxDetails.FirstOrDefault(a => a.ID == ID);
                if (PackagedBoxDetail != null)
                {
                    Result.ID = PackagedBoxDetail.ID;
                    Result.PackagedBoxID = PackagedBoxDetail.PackagedBoxID;
                    Result.ProductID = PackagedBoxDetail.ProductID;
                }
            }
            return Result;
        }
    }
}
