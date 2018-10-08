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
    public class BoxService
    {
        public long Add(BoxDTO pBoxDTO)
        {
            long BoxID = 0;
            using (var Context = new BaseContext())
            {
                var Box = new BoxModel
                {
                    Name = pBoxDTO.Name,
                    BoxSize = pBoxDTO.BoxSize,
                    BoxPlaceCount = pBoxDTO.BoxPlaceCount,
                    Description = pBoxDTO.Description,
                    DisplayOrder = pBoxDTO.DisplayOrder,
                    Deleted = false
                };
                Context.Boxes.Add(Box);
                Context.SaveChanges();
                BoxID = Box.ID;
            }
            return BoxID;
        }

        public long Edit(BoxDTO pBoxDTO)
        {
            long BoxID = 0;
            using (var Context = new BaseContext())
            {
                var Box = Context.Boxes.FirstOrDefault(a => a.ID == pBoxDTO.ID);
                if (Box != null)
                {
                    Box.Name = pBoxDTO.Name;
                    Box.BoxSize = pBoxDTO.BoxSize;
                    Box.BoxPlaceCount = pBoxDTO.BoxPlaceCount;
                    Box.Description = pBoxDTO.Description;
                    Box.DisplayOrder = pBoxDTO.DisplayOrder;
                    Context.SaveChanges();
                    BoxID = Box.ID;
                }
            }
            return BoxID;
        }

        public long Delete(long ID)
        {
            long BoxID = 0;
            using (var Context = new BaseContext())
            {
                var Box = Context.Boxes.FirstOrDefault(a => a.ID == ID);
                if (Box != null)
                {
                    Box.Deleted = true;
                    //Context.Boxes.Remove(Box);
                    Context.SaveChanges();
                    BoxID = ID;
                }
            }
            return BoxID;
        }

        public List<BoxDTO> GetAll()
        {
            var Result = new List<BoxDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Boxes.Where(a => a.Deleted == false)
                    .Select(a => new BoxDTO
                    {
                        ID = a.ID,
                        Name = a.Name,
                        BoxSize = a.BoxSize,
                        BoxPlaceCount = a.BoxPlaceCount,
                        Description = a.Description,
                        DisplayOrder = a.DisplayOrder,
                        Deleted = a.Deleted
                    }).ToList();
            }
            return Result;
        }

        public BoxDTO GetByID(long ID)
        {
            var Result = new BoxDTO();
            using (var Context = new BaseContext())
            {
                var Box = Context.Boxes.FirstOrDefault(a => a.ID == ID);
                if (Box != null)
                {
                    Result.ID = Box.ID;
                    Result.Name = Box.Name;
                    Result.BoxSize = Box.BoxSize;
                    Result.BoxPlaceCount = Box.BoxPlaceCount;
                    Result.Description = Box.Description;
                    Result.DisplayOrder = Box.DisplayOrder;
                }
            }
            return Result;
        }
    }
}
