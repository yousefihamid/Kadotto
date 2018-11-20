using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Shop;
using Service.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service.Shop
{
    public class OrderDetailService
    {
        public long Add(OrderDetailDTO pOrderDetailDTO)
        {
            long OrderDetailID = 0;

            using (var Context = new BaseContext())
            {
                var OrderDetail = new OrderDetailModel
                {
                    OrderID = pOrderDetailDTO.OrderID,
                    PackagedBoxID = pOrderDetailDTO.PackagedBoxID
                };
                Context.OrderDetails.Add(OrderDetail);
                Context.SaveChanges();
                OrderDetailID = OrderDetail.ID;
            }
            return OrderDetailID;
        }

        public long Edit(OrderDetailDTO pOrderDetailDTO)
        {
            long OrderDetailID = 0;
     
            using (var Context = new BaseContext())
            {
                var OrderDetail = Context.OrderDetails.FirstOrDefault(a => a.ID == pOrderDetailDTO.ID);
                if (OrderDetail != null)
                {
                    OrderDetail.OrderID = pOrderDetailDTO.OrderID;
                    OrderDetail.PackagedBoxID = pOrderDetailDTO.PackagedBoxID;
                    Context.SaveChanges();
                    OrderDetailID = OrderDetail.ID;
                }
            }
            return OrderDetailID;
        }

        public long Delete(long ID)
        {
            long OrderDetailID = 0;
            using (var Context = new BaseContext())
            {
                var OrderDetail = Context.OrderDetails.FirstOrDefault(a => a.ID == ID);
                if (OrderDetail != null)
                {
                    Context.OrderDetails.Remove(OrderDetail);
                    Context.SaveChanges();
                    OrderDetailID = ID;
                }
            }
            return OrderDetailID;
        }

        public List<OrderDetailDTO> GetAll()
        {
            var Result = new List<OrderDetailDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.OrderDetails
                    .Select(a => new OrderDetailDTO
                    {
                        ID = a.ID,
                        OrderID = a.OrderID,
                        PackagedBoxID = a.PackagedBoxID,
                    }).ToList();
            }
            return Result;
        }

        public OrderDetailDTO GetByID(long ID)
        {
            var Result = new OrderDetailDTO();
            using (var Context = new BaseContext())
            {
                var OrderDetail = Context.OrderDetails.FirstOrDefault(a => a.ID == ID);
                if (OrderDetail != null)
                {
                    Result.ID = OrderDetail.ID;
                    Result.OrderID = OrderDetail.OrderID;
                    Result.PackagedBoxID = OrderDetail.PackagedBoxID;
                }
            }
            return Result;
        }
    }
}
