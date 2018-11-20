using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Shop;
using Service.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service.Shop
{
    public class PackagedBoxService
    {
        public long Add(PackagedBoxDTO pPackagedBoxDTO)
        {
            long PackagedBoxID = 0;

            using (var Context = new BaseContext())
            {
                var PackagedBox = new PackagedBoxModel
                {
                    BoxID = pPackagedBoxDTO.BoxID,
                    Price = pPackagedBoxDTO.Price,
                    CustomerMessage = pPackagedBoxDTO.CustomerMessage,
                    IsDeleted = false
                };
                Context.PackagedBoxes.Add(PackagedBox);
                Context.SaveChanges();
                PackagedBoxID = PackagedBox.ID;
            }
            return PackagedBoxID;
        }

        public long Edit(PackagedBoxDTO pPackagedBoxDTO)
        {
            long PackagedBoxID = 0;
     
            using (var Context = new BaseContext())
            {
                var PackagedBox = Context.PackagedBoxes.FirstOrDefault(a => a.ID == pPackagedBoxDTO.ID);
                if (PackagedBox != null)
                {
                    PackagedBox.BoxID = pPackagedBoxDTO.BoxID;
                    PackagedBox.Price = pPackagedBoxDTO.Price;
                    PackagedBox.CustomerMessage = pPackagedBoxDTO.CustomerMessage;
                    Context.SaveChanges();
                    PackagedBoxID = PackagedBox.ID;
                }
            }
            return PackagedBoxID;
        }

        public long Delete(long ID)
        {
            long PackagedBoxID = 0;
            using (var Context = new BaseContext())
            {
                var PackagedBox = Context.PackagedBoxes.FirstOrDefault(a => a.ID == ID);
                if (PackagedBox != null)
                {
                    PackagedBox.IsDeleted = true;
                    Context.SaveChanges();
                    PackagedBoxID = PackagedBox.ID;
                }
            }
            return PackagedBoxID;
        }

        public List<PackagedBoxDTO> GetAll()
        {
            var Result = new List<PackagedBoxDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.PackagedBoxes
                    .Select(a => new PackagedBoxDTO
                    {
                        ID = a.ID,
                        BoxID = a.BoxID,
                        Price = a.Price,
                        CustomerMessage = a.CustomerMessage
                    }).ToList();
            }
            return Result;
        }

        public PackagedBoxDTO GetByID(long ID)
        {
            var Result = new PackagedBoxDTO();
            using (var Context = new BaseContext())
            {
                var PackagedBox = Context.PackagedBoxes.FirstOrDefault(a => a.ID == ID);
                if (PackagedBox != null)
                {
                    Result.ID = PackagedBox.ID;
                    Result.BoxID = PackagedBox.BoxID;
                    Result.Price = PackagedBox.Price;
                    Result.CustomerMessage = PackagedBox.CustomerMessage;
                }
            }
            return Result;
        }

        public bool AddToCard(PackagedBoxDTO pPackagedBoxDTO)
        {
            bool Result = false;
            var CardList = (List<PackagedBoxDTO>)System.Web.HttpContext.Current.Session["Card"];
            if (CardList != null)
            {
                CardList.Add(pPackagedBoxDTO);
                Result = true;
            }
            else
            {
                CardList = new List<PackagedBoxDTO>
                {
                    pPackagedBoxDTO
                };
                Result = true;
            }
            return Result;
        }

        public List<PackagedBoxDTO> GetCard()
        {
            //System.Web.HttpContext.Current.Session["Card"] =
            //new List<PackagedBoxDTO>
            //{
            //    new PackagedBoxDTO
            //    {
            //        BoxTitle="Packaged Box 1",
            //        Price=120000,
            //        BoxImageName="1.jpg"
            //    },
            //    new PackagedBoxDTO
            //    {
            //        BoxTitle="Packaged Box 1",
            //        Price=50000,
            //        BoxImageName="1.jpg"
            //    }
            //};
            var Result = (List<PackagedBoxDTO>)System.Web.HttpContext.Current.Session["Card"];
            return Result;
        }
    }
}
