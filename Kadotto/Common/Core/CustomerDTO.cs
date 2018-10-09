using Common.Utility;
using System;

namespace Common.Core
{
    public class CustomerDTO
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public bool IsAdmin { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public string CreationDateString
        {
            get
            {
                return DateTimeConvert.GetPersianDate(CreationDate);
            }
            set
            {
            }
        }
    }
}
