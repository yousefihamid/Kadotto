namespace Common.Authentication
{
    public class UserDTO
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public bool IsAdmin { get; set; }
        public string PhoneNumber { get; set; }
    }
}
