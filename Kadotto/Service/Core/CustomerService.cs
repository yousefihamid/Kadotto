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
    public class CustomerService
    {
        public long Add(CustomerDTO pCustomerDTO)
        {
            long CustomerID = 0;
            using (var Context = new BaseContext())
            {
                var Customer = new CustomerModel
                {
                    Name = pCustomerDTO.Name,
                    Family = pCustomerDTO.Family,
                    UserName = pCustomerDTO.UserName,
                    Password = pCustomerDTO.Password,
                    IsAdmin = false,
                    PhoneNumber = pCustomerDTO.PhoneNumber,
                    Email = pCustomerDTO.Email,
                    IsActive = true,
                    IsVerified = true,
                    CreationDate = DateTime.Now
                };
                Context.Customers.Add(Customer);
                Context.SaveChanges();
                CustomerID = Customer.ID;
            }
            return CustomerID;
        }

        public long Edit(CustomerDTO pCustomerDTO)
        {
            long CustomerID = 0;
            using (var Context = new BaseContext())
            {
                var Customer = Context.Customers.FirstOrDefault(a => a.ID == pCustomerDTO.ID);
                if (Customer != null)
                {
                    Customer.Name = pCustomerDTO.Name;
                    Customer.Family = pCustomerDTO.Family;
                    Customer.PhoneNumber = pCustomerDTO.PhoneNumber;
                    Customer.Email = pCustomerDTO.Email;
                    Context.SaveChanges();
                    CustomerID = Customer.ID;
                }
            }
            return CustomerID;
        }

        public long Delete(long ID)
        {
            long CustomerID = 0;
            using (var Context = new BaseContext())
            {
                var Customer = Context.Customers.FirstOrDefault(a => a.ID == ID);
                if (Customer != null)
                {
                    Customer.IsActive = false;
                    Context.SaveChanges();
                    CustomerID = ID;
                }
            }
            return CustomerID;
        }

        public List<CustomerDTO> GetAll()
        {
            var Result = new List<CustomerDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Customers.
                    Select(a => new CustomerDTO
                    {
                        ID = a.ID,
                        UserName = a.UserName,
                        Family = a.Family,
                        IsAdmin = a.IsAdmin,
                        Name = a.Name,
                        PhoneNumber = a.PhoneNumber,
                        Email = a.Email,
                        IsActive = a.IsActive,
                        IsVerified = a.IsVerified,
                        CreationDate = a.CreationDate,
                        Password = a.Password
                    }).ToList();
            }
            return Result;
        }

        public CustomerDTO GetByID(long ID)
        {
            var Result = new CustomerDTO();
            using (var Context = new BaseContext())
            {
                var Customer = Context.Customers.FirstOrDefault(a => a.ID == ID);
                if (Customer != null)
                {
                    Result.ID = Customer.ID;
                    Result.UserName = Customer.UserName;
                    Result.Family = Customer.Family;
                    Result.IsAdmin = Customer.IsAdmin;
                    Result.Name = Customer.Name;
                    Result.PhoneNumber = Customer.PhoneNumber;
                    Result.Email = Customer.Email;
                    Result.IsActive = Customer.IsActive;
                    Result.IsVerified = Customer.IsVerified;
                    Result.CreationDate = Customer.CreationDate;
                    Result.Password = Customer.Password;
                }
            }
            return Result;
        }
    }
}
