using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Shop;
using Service.Core;
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
            var Box = new BoxService().GetByID(pPackagedBoxDTO.BoxID);
            if (Box != null)
            {
                pPackagedBoxDTO.BoxImageName = Box.ImageName;
                pPackagedBoxDTO.BoxTitle = Box.Name;
                var CardList = (List<PackagedBoxDTO>)System.Web.HttpContext.Current.Session["Card"];
                if (CardList != null)
                {
                    CardList.Add(pPackagedBoxDTO);
                }
                else
                {
                    CardList = new List<PackagedBoxDTO>
                    {
                        pPackagedBoxDTO
                    };
                }
                System.Web.HttpContext.Current.Session["Card"] = CardList;
                Result = true;
            }
            return Result;
        }

        public List<PackagedBoxDTO> GetCard()
        {
            System.Web.HttpContext.Current.Session["Card"] = new List<PackagedBoxDTO>
            {
                new PackagedBoxDTO
                {
                    BoxTitle="BoxTitle1",
                    Price=100,
                    BoxImageName="1.jpg"
                },
                 new PackagedBoxDTO
                {
                    BoxTitle="BoxTitle2",
                    Price=200,
                    BoxImageName="1.jpg"
                },
            };
            var Result = (List<PackagedBoxDTO>)System.Web.HttpContext.Current.Session["Card"];
            return Result;
        }

        public bool RemoveFromCard(PackagedBoxDTO pPackagedBoxDTO)
        {
            bool Result = false;
            var Box = new BoxService().GetByID(pPackagedBoxDTO.BoxID);
            if (Box != null)
            {
                pPackagedBoxDTO.BoxImageName = Box.ImageName;
                pPackagedBoxDTO.BoxTitle = Box.Name;
                var CardList = (List<PackagedBoxDTO>)System.Web.HttpContext.Current.Session["Card"];
                if (CardList != null)
                {
                    CardList.Add(pPackagedBoxDTO);
                }
                else
                {
                    CardList = new List<PackagedBoxDTO>
                    {
                        pPackagedBoxDTO
                    };
                }
                System.Web.HttpContext.Current.Session["Card"] = CardList;
                Result = true;
            }
            return Result;
        }
    }
}
