using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Shop;
using Service.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service.Shop
{
    public class OrderService
    {
        public long Add(OrderDTO pOrderDTO)
        {
            long OrderID = 0;

            using (var Context = new BaseContext())
            {
                var Order = new OrderModel
                {
                    CustomerID = pOrderDTO.CustomerID,
                    CreateDate = pOrderDTO.CreateDate,
                    ShippedDate = pOrderDTO.ShippedDate
                };
                Context.Orders.Add(Order);
                Context.SaveChanges();
                OrderID = Order.ID;
            }
            return OrderID;
        }

        public long Edit(OrderDTO pOrderDTO)
        {
            long OrderID = 0;
     
            using (var Context = new BaseContext())
            {
                var Order = Context.Orders.FirstOrDefault(a => a.ID == pOrderDTO.ID);
                if (Order != null)
                {
                    Order.CustomerID = pOrderDTO.CustomerID;
                    Order.CreateDate = pOrderDTO.CreateDate;
                    Order.ShippedDate = pOrderDTO.ShippedDate;
                    Context.SaveChanges();
                    OrderID = Order.ID;
                }
            }
            return OrderID;
        }

        public long Delete(long ID)
        {
            long OrderID = 0;
            using (var Context = new BaseContext())
            {
                var Order = Context.Orders.FirstOrDefault(a => a.ID == ID);
                if (Order != null)
                {
                    Context.Orders.Remove(Order);
                    Context.SaveChanges();
                    OrderID = ID;
                }
            }
            return OrderID;
        }

        public List<OrderDTO> GetAll()
        {
            var Result = new List<OrderDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Orders
                    .Select(a => new OrderDTO
                    {
                        ID = a.ID,
                        CustomerID = a.CustomerID,
                        CreateDate = a.CreateDate,
                        ShippedDate = a.ShippedDate
                    }).ToList();
            }
            return Result;
        }

        public OrderDTO GetByID(long ID)
        {
            var Result = new OrderDTO();
            using (var Context = new BaseContext())
            {
                var Order = Context.Orders.FirstOrDefault(a => a.ID == ID);
                if (Order != null)
                {
                    Result.ID = Order.ID;
                    Result.CustomerID = Order.CustomerID;
                    Result.CreateDate = Order.CreateDate;
                    Result.ShippedDate = Order.ShippedDate;
                }
            }
            return Result;
        }
    }
}
